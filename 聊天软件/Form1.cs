using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Data.SqlClient;

namespace 聊天软件
{
    public partial class Form1_12 : Form
    {
        Socket socket_Server = null;  //定义套接字，用于服务端监听客户端 
        Socket socket_Client = null;  //定义套接字，用于客户端监听服务端 
        Socket chatSocket = null;     //定义套接字，用于服务端与客户端通话 
        Thread thread = null;         //定义一个线程对象，用于监听 

        public Form1_12()
        {
            InitializeComponent();
            TextBox.CheckForIllegalCrossThreadCalls = false;  //允许这两种控件跨线程访问 
            Button.CheckForIllegalCrossThreadCalls = false;
        } 

        #region 服务端功能 
        //开启服务（启动监听）
        private void Listen()
        {
            //1.设置服务端的IP地址和端口号 
            IPAddress ip = IPAddress.Parse(cbox_IP_12.Text.Trim());  //提取IP地址 
            int port = int.Parse(cbox_Port_12.Text.Trim());          //提取端口号 
            IPEndPoint point = new IPEndPoint(ip, port);  //根据IP地址和端口号构建一个网络结点对象 
            //2. 创建一个Socket对象，用于监听客户端
            socket_Server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket_Server.Bind(point); //将结点对象绑定到套接字上，注意是绑定，不是连接。（绑定 是绑定本机的，连接是连接对方的） 
            socket_Server.Listen(10);   //设置连接队列的最大长度，也就是同时可以和多少客户端连接， 可以根据服务器的性能设置更大的 
            //3.将监听程序装入线程，并实例化线程
            thread = new Thread(Listen_Disp);
            thread.IsBackground = true;    //设置为后台线程
            thread.Start();  //启动线程 
            txt_ReceiveMsg_12.AppendText("监听启动成功!\t\n");
            toolStripStatusLabel3_12.Text = "            正在监听...";
            btn_SendMsg_12.Enabled = true;
            checkBox1_12.Enabled = false;
            btn_Start_12.Enabled = false;
            cbox_IP_12.Enabled = false;
            cbox_Port_12.Enabled = false;
            groupBox1_12.Enabled = false; //将客户端的功能设为不可用 
        }

        //定义监听程序 
        void Listen_Disp()
        {
            while (true)  //无限循环监听 
            {
                if (socket_Server == null)
                {
                    break;  //如果服务停止，即socket为空，则直接返回
                }
                else
                {
                    //1. 一直在等待，如果有客户端连接过来了，就开始准备聊天通信 
                    chatSocket = socket_Server.Accept();
                    string cName = chatSocket.RemoteEndPoint.ToString();  //获取客户端的网络结点对 象（对方的IP和端口号）
                    txt_ReceiveMsg_12.AppendText("成功与" + cName + "建立连接！\t\n");
                    toolStripStatusLabel3_12.Text = "            与" + cName + "建立连接";
                    //2. 为该客户端的通话开启一个新线程 
                    Thread th = new Thread(Chat);
                     th.IsBackground = true;
                     th.Start();
                }
            }
        }

        //与客户端的通话程序 
        void Chat()
        {
            bool isListen = true;
            while (isListen)
            {
                if (chatSocket == null || chatSocket.Connected == false)
                {
                    break;   //如果客户端断开了，则直接退出 
                }
                else if (chatSocket.Available > 0)
                {
                    Byte[] bytes = new Byte[4096]; //创建字节数对象，用于接收消息(就像准备一个大箱子，准备装船上的货物，箱子的大小可以自己设置) 
                    int len = chatSocket.Receive(bytes);
                    string msg = Encoding.UTF8.GetString(bytes, 0, len);
                    if (msg.Contains("is closed."))  //如果接收到的消息是客户端要关闭了 
                    {
                        toolStripStatusLabel3_12.Text = "            客户端已退出聊天";
                        txt_ReceiveMsg_12.AppendText(msg + "\t\n");
                        isListen = false;  //不用再监听了，断开这个Socket了 
                        chatSocket.Close();
                        chatSocket = null;
                    }
                    else
                    {
                        txt_ReceiveMsg_12.AppendText(msg + "\t\n");
                    }
                }
            }
        }
        #endregion 服务端功能结束 

        #region  客户端功能 
        //连接服务端
        private void Connect()
        {
                try
                {
                    //1.设置对方的IP地址和端口号 
                    IPAddress ip = IPAddress.Parse(cbox_IP_12.Text.Trim());  //提取对方IP 
                    int port = int.Parse(cbox_Port_12.Text.Trim());  //提取对方端口号 
                    IPEndPoint point = new IPEndPoint(ip, port);   //网络结点对象（服务端结点） 
                    //2. 创建Socket对方，连接服务端 
                    socket_Client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    socket_Client.Connect(point);  //连接服务端结点（注意这里是连接，而不是绑定） 
                    //3.创建接收消息的线程 
                    thread = new Thread(ReceiveMsg);
                    thread.IsBackground = true;
                    thread.Start();
                    //4.设置相关控件的状态 
                    btn_SendMsg_12.Enabled = true;
                    checkBox1_12.Enabled = false;
                    cbox_IP_12.Enabled = false;
                    cbox_Port_12.Enabled = false;
                    btn_Start_12.Enabled = false;
                    groupBox1_12.Enabled = false;
                    txt_ReceiveMsg_12.AppendText("连接成功！\t\n");
                    toolStripStatusLabel3_12.Text = "            连接成功";
                }
                catch
                {
                    MessageBox.Show("连接失败，请与服务端确认后重试。", "连接失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    toolStripStatusLabel3_12.Text = "            连接失败请重试";
                }
        }

        //接收并显示消息
        void ReceiveMsg()
        {
            bool isListen = true;
            while (isListen)   //客户端也是无限循环监听来自服务端的消息 
            {
                if (socket_Client != null && socket_Client.Connected == true)
                {
                   byte[] bytes = new byte[4096]; //设置字节流数组 
                    int len = socket_Client.Receive(bytes);
                    string msg = Encoding.UTF8.GetString(bytes, 0, len);
                    //如果收到的是服务器已经关闭的消息，则把客户端接口关了 
                    if (msg.Contains("is closed."))
                    {
                        txt_ReceiveMsg_12.AppendText("服务端已关闭\n");
                        toolStripStatusLabel3_12.Text = "            服务端已关闭";
                        isListen = false;  //不需要再监听了，关闭Socket 
                        socket_Client.Close();
                        socket_Client = null;
                        cbox_IP_12.Enabled = true;
                        cbox_Port_12.Enabled = true;
                        btn_Start_12.Enabled = true;
                        groupBox1_12.Enabled = true;
                        thread.Abort();  //关闭线程，这句要放最后否则这个线程关了，后面的代码就 不执行了 
                    }
                    else
                    {
                        txt_ReceiveMsg_12.AppendText(msg + "\t\n");
                    }
               }
            }
        }
        #endregion 客户端功能结束

        #region 窗口按钮
        //我是服务端
        private void rbtn_f_12_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtn_f_12.Checked)
            {
                label1_12.Text = "我的IP:";
                label2_12.Text = "我的端口号:";
                btn_Start_12.Text = "开启服务";
                toolStripStatusLabel3_12.Text = "            已自动获取IP与端口号";
                cbox_IP_12.Enabled = true;
                cbox_Port_12.Enabled = true;
                btn_Start_12.Enabled = true;
                checkBox1_12.Enabled = true;
                btn_Exit_12.Enabled = true;
                string strHostName = Dns.GetHostName(); //得到本机的主机名
                IPHostEntry ipEntry = Dns.GetHostByName(strHostName); //取得本机IP
                string strAddr = ipEntry.AddressList[0].ToString(); //假设本地主机为单网卡
                cbox_IP_12.Text = strAddr;
                cbox_Port_12.Text = "8090";
            }
        }

        //我是客户端
        private void rbtn_k_12_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtn_k_12.Checked)
            {
                label1_12.Text = "对方IP:";
                label2_12.Text = "对方端口号:";
                btn_Start_12.Text = "连接对方";
                toolStripStatusLabel3_12.Text = "            请输入对方IP与端口号";
                cbox_IP_12.Enabled = true;
                cbox_Port_12.Enabled = true;
                btn_Start_12.Enabled = true;
                checkBox1_12.Enabled = true;
                btn_Exit_12.Enabled = true;
            }
            string strHostName = Dns.GetHostName(); //得到本机的主机名
            IPHostEntry ipEntry = Dns.GetHostByName(strHostName); //取得本机IP
            string strAddr = ipEntry.AddressList[0].ToString(); //假设本地主机为单网卡
            if(cbox_IP_12.Text==strAddr)
            {
                cbox_IP_12.Text = "192.168.";
            }
        }

        //清屏按钮
        private void btn_Clear_12_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("是否清空聊天记录？ 清空后将无法恢复", "清屏提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                txt_ReceiveMsg_12.Text = "";
            }
        }

        //发送消息
        private void btn_SendMsg_12_Click(object sender, EventArgs e)
        {
            string msg = DateTime.Now.ToShortTimeString().ToString() + "  " + txt_Name_12.Text + " : " + txt_SendMsg_12.Text.Trim();  //要发送的消息 
            byte[] bytes = Encoding.UTF8.GetBytes(msg); //将要发送的消息转化为字节数组，因为socket 传输数据时是以字节的形式发送的 
            if(toolStripStatusLabel3_12.Text == "            正在监听...")
            {
                txt_ReceiveMsg_12.AppendText("发送失败，客户端未连接！\n");
            }
            else if (txt_SendMsg_12.Text != "")
            {
                //如果是服务端的程序（向客户端发送） 
                if (chatSocket != null && chatSocket.Connected == true)
                {
                    chatSocket.Send(bytes);
                }
                //如果是客户端的程序（向服务端发送）
                else if (socket_Client != null && socket_Client.Connected == true)
                {
                    socket_Client.Send(bytes);
                }
                txt_ReceiveMsg_12.AppendText("(Me)" + msg + "\n");  //显示在自己界面上
                txt_SendMsg_12.Text = "";
            }
            else
            {
                txt_ReceiveMsg_12.AppendText("消息为空，未发送。\n");
            }
        }

        //退出聊天
        private void btn_Exit_12_Click(object sender, EventArgs e)
        {
            //如果客户端连接还在 
            if (socket_Client != null && socket_Client.Connected == true)
            {
                //向服务端发送结束消息，关闭socket服务 
                socket_Client.Send(Encoding.UTF8.GetBytes(txt_Name_12.Text + "is closed."));
                socket_Client.Close();
                socket_Client = null;
                thread.Abort();   //这边要立即结束客户端的监听进程 
                //恢复相关控件的状态 
                txt_ReceiveMsg_12.AppendText("已断开与对方的连接\t\n");
                toolStripStatusLabel3_12.Text = "            已退出聊天";
                checkBox1_12.Enabled = true;
                cbox_IP_12.Enabled = true;
                cbox_Port_12.Enabled = true;
                btn_Start_12.Enabled = true;
                groupBox1_12.Enabled = true;
                btn_SendMsg_12.Enabled = false;
            }
            if (socket_Server != null)  //如果自己的监听socket还在，则关闭 
            {
                socket_Server.Close();
                socket_Server = null;
                thread.Abort();    //将监听线程关闭 
                //如果此时客户端还没关闭，还在线，就通知对方一下 
                if (chatSocket != null && chatSocket.Connected)
                {
                    byte[] bytes = Encoding.UTF8.GetBytes(txt_Name_12.Text + " is closed.");
                    chatSocket.Send(bytes);
                    chatSocket.Close();
                    //通知对方完了，告诉连接
                    chatSocket = null;
                }
                toolStripStatusLabel3_12.Text = "            已退出聊天";
                checkBox1_12.Enabled = true;
                cbox_IP_12.Enabled = true;
                cbox_Port_12.Enabled = true;
                btn_Start_12.Enabled = true;
                groupBox1_12.Enabled = true;
                btn_SendMsg_12.Enabled = false;
            }
        }

        //开启服务/连接对方
        private void btn_Start_12_Click(object sender, EventArgs e)
        {
            if (!rbtn_k_12.Checked && !rbtn_f_12.Checked)
            {
                MessageBox.Show("客户端属性未选择。", "请选择客户端属性", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (cbox_IP_12.Text == "" || cbox_IP_12.Text == "请输入IP"|| cbox_IP_12.Text == "192.168.")
            {
                cbox_IP_12.Focus();
                MessageBox.Show("IP不可为空，请重新输入。", "请输入IP", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (cbox_Port_12.Text == "" || cbox_Port_12.Text == "请输入端口号")
            {
                cbox_Port_12.Focus();
                MessageBox.Show("端口号不可为空，请重新输入。", "请输入端口号", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else  //记住IP与端口号
            {
                if (checkBox1_12.Checked)
                {
                    cbox_IP_12.Items.Add(cbox_IP_12.Text);
                    cbox_Port_12.Items.Add(cbox_Port_12.Text);
                }
                else
                {
                    cbox_IP_12.Items.Remove(cbox_IP_12.Text);
                    cbox_Port_12.Items.Remove(cbox_Port_12.Text);
                }
                if (btn_Start_12.Text == "开启服务")
                {
                    Listen();
                }
                else if (btn_Start_12.Text == "连接对方")
                {
                    Connect();
                }
            }
        }
        #endregion 结束窗口按钮

        #region  窗体工具的限制与动作
        //IP cbox聚焦行为
        private void cbox_IP_Enter_12(object sender, EventArgs e)
        {
            if(cbox_IP_12.Text=="请输入IP")
            {
                cbox_IP_12.Text = "192.168.";
            }
        }

        //IP cbox失焦行为
        private void cbox_IP_Leave_12(object sender, EventArgs e)
        {
            if (cbox_IP_12.Text == ""|| cbox_IP_12.Text == "192.168.")
            {
                cbox_IP_12.Text = "请输入IP";
            }
        }

        //Port cbox聚焦行为
        private void cbox_Port_Enter_12(object sender, EventArgs e)
        {
            if (cbox_Port_12.Text == "请输入端口号")
            {
                cbox_Port_12.Text = "8090";
            }
        }

        //Port cbox失焦行为
        private void cbox_Port_Leave_12(object sender, EventArgs e)
        {
            if(cbox_Port_12.Text == "")
            {
                cbox_Port_12.Text = "请输入端口号";
            }
        }

        //SendMsg txt聚焦行为
        private void txt_SendMsg_Enter_12(object sender, EventArgs e)
        {
            if (txt_SendMsg_12.Text == "请在此输入要发送的消息")
            {
                txt_SendMsg_12.Text = "";
            }
        }

        //SendMsg txt失焦行为
        private void txt_SendMsg_Leave_12(object sender, EventArgs e)
        {
            if (txt_SendMsg_12.Text == "")
            {
                txt_SendMsg_12.Text = "请在此输入要发送的消息";
            }
        }

        //txt_Name 聚焦行为
        private void txt_Name_Enter_12(object sender, EventArgs e)
        {
            if (txt_Name_12.Text == "匿名")
            {
                txt_Name_12.Text = "";
            }
        }

        //txt_Name 失焦行为
        private void txt_Name_Leave_12(object sender, EventArgs e)
        {
            if (txt_Name_12.Text == "")
            {
                txt_Name_12.Text = "匿名";
            }
        }

        //IP cbox输入限制
        private void cbox_IP_Keypress_12(object sender, KeyPressEventArgs e)
        {
            if(!char.IsDigit(e.KeyChar)&&e.KeyChar!=8&&e.KeyChar!=13&&e.KeyChar!='.')
            {
                e.Handled = true;//不接受此输入
            }
        }

        //Port cbox输入限制
        private void cbox_Port_Keypress_12(object sender, KeyPressEventArgs e)
        {
            if(!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 13)
            {
                e.Handled = true;//不接受此输入
            }
        }

        //ReceiveMsg输入限制
        private void txt_ReceiveMsg_Keypress_12(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        //btn_SendMsg 鼠标滞留提示快捷键
        private void btn_SendMsg_MouseEnter_12(object sender, EventArgs e)
        {
            ToolTip p = new ToolTip();
            p.ShowAlways = true;
            p.SetToolTip(this.btn_SendMsg_12, "快捷键：Enter");
        }

        //btn_Exit 鼠标滞留提示快捷键
        private void btn_Exit_MouseEnter_12(object sender, EventArgs e)
        {
            ToolTip p = new ToolTip();
            p.ShowAlways = true;
            p.SetToolTip(this.btn_Exit_12, "快捷键：Esc");
        }
        #endregion  输入输出限制与动作结束

        //显示时间
        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel2_12.Text = DateTime.Now.ToString();
        }

        //Form Closed动作
        private void Form1_FormClosed_12(object sender, FormClosedEventArgs e)
        {
            btn_Exit_12_Click(null, null);  //调用退出聊天函数
        }
    }
}
