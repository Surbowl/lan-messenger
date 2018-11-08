namespace 聊天软件
{
    partial class Form1_12
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1_12));
            this.rbtn_f_12 = new System.Windows.Forms.RadioButton();
            this.rbtn_k_12 = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1_12 = new System.Windows.Forms.GroupBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2_12 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3_12 = new System.Windows.Forms.ToolStripStatusLabel();
            this.label1_12 = new System.Windows.Forms.Label();
            this.label2_12 = new System.Windows.Forms.Label();
            this.cbox_IP_12 = new System.Windows.Forms.ComboBox();
            this.cbox_Port_12 = new System.Windows.Forms.ComboBox();
            this.btn_Start_12 = new System.Windows.Forms.Button();
            this.btn_Exit_12 = new System.Windows.Forms.Button();
            this.checkBox1_12 = new System.Windows.Forms.CheckBox();
            this.txt_ReceiveMsg_12 = new System.Windows.Forms.TextBox();
            this.txt_SendMsg_12 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_Name_12 = new System.Windows.Forms.TextBox();
            this.btn_SendMsg_12 = new System.Windows.Forms.Button();
            this.btn_Clear_12 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.groupBox1_12.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbtn_f_12
            // 
            this.rbtn_f_12.AutoSize = true;
            this.rbtn_f_12.Location = new System.Drawing.Point(31, 33);
            this.rbtn_f_12.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rbtn_f_12.Name = "rbtn_f_12";
            this.rbtn_f_12.Size = new System.Drawing.Size(86, 21);
            this.rbtn_f_12.TabIndex = 0;
            this.rbtn_f_12.Text = "我是服务端";
            this.rbtn_f_12.UseVisualStyleBackColor = true;
            this.rbtn_f_12.CheckedChanged += new System.EventHandler(this.rbtn_f_12_CheckedChanged);
            // 
            // rbtn_k_12
            // 
            this.rbtn_k_12.AutoSize = true;
            this.rbtn_k_12.Location = new System.Drawing.Point(31, 72);
            this.rbtn_k_12.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rbtn_k_12.Name = "rbtn_k_12";
            this.rbtn_k_12.Size = new System.Drawing.Size(86, 21);
            this.rbtn_k_12.TabIndex = 1;
            this.rbtn_k_12.Text = "我是客户端";
            this.rbtn_k_12.UseVisualStyleBackColor = true;
            this.rbtn_k_12.CheckedChanged += new System.EventHandler(this.rbtn_k_12_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1_12);
            this.panel1.Location = new System.Drawing.Point(0, 12);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(186, 141);
            this.panel1.TabIndex = 2;
            // 
            // groupBox1_12
            // 
            this.groupBox1_12.Controls.Add(this.rbtn_k_12);
            this.groupBox1_12.Controls.Add(this.rbtn_f_12);
            this.groupBox1_12.Location = new System.Drawing.Point(25, 12);
            this.groupBox1_12.Name = "groupBox1_12";
            this.groupBox1_12.Size = new System.Drawing.Size(145, 117);
            this.groupBox1_12.TabIndex = 2;
            this.groupBox1_12.TabStop = false;
            this.groupBox1_12.Text = "客户端属性";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2_12,
            this.toolStripStatusLabel3_12});
            this.statusStrip1.Location = new System.Drawing.Point(0, 458);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.statusStrip1.Size = new System.Drawing.Size(579, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(68, 17);
            this.toolStripStatusLabel1.Text = "当前时间：";
            // 
            // toolStripStatusLabel2_12
            // 
            this.toolStripStatusLabel2_12.Name = "toolStripStatusLabel2_12";
            this.toolStripStatusLabel2_12.Size = new System.Drawing.Size(113, 17);
            this.toolStripStatusLabel2_12.Text = "正在获取系统时间...";
            // 
            // toolStripStatusLabel3_12
            // 
            this.toolStripStatusLabel3_12.Name = "toolStripStatusLabel3_12";
            this.toolStripStatusLabel3_12.Size = new System.Drawing.Size(156, 17);
            this.toolStripStatusLabel3_12.Text = "             请选择客户端属性";
            // 
            // label1_12
            // 
            this.label1_12.AutoSize = true;
            this.label1_12.Location = new System.Drawing.Point(3, 163);
            this.label1_12.Name = "label1_12";
            this.label1_12.Size = new System.Drawing.Size(46, 17);
            this.label1_12.TabIndex = 4;
            this.label1_12.Text = "      IP:";
            // 
            // label2_12
            // 
            this.label2_12.AutoSize = true;
            this.label2_12.Location = new System.Drawing.Point(4, 203);
            this.label2_12.Name = "label2_12";
            this.label2_12.Size = new System.Drawing.Size(71, 17);
            this.label2_12.TabIndex = 5;
            this.label2_12.Text = "      端口号:";
            // 
            // cbox_IP_12
            // 
            this.cbox_IP_12.Enabled = false;
            this.cbox_IP_12.FormattingEnabled = true;
            this.cbox_IP_12.Location = new System.Drawing.Point(46, 160);
            this.cbox_IP_12.Name = "cbox_IP_12";
            this.cbox_IP_12.Size = new System.Drawing.Size(138, 25);
            this.cbox_IP_12.TabIndex = 6;
            this.cbox_IP_12.Text = "请输入IP";
            this.cbox_IP_12.Enter += new System.EventHandler(this.cbox_IP_Enter_12);
            this.cbox_IP_12.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbox_IP_Keypress_12);
            this.cbox_IP_12.Leave += new System.EventHandler(this.cbox_IP_Leave_12);
            // 
            // cbox_Port_12
            // 
            this.cbox_Port_12.Enabled = false;
            this.cbox_Port_12.FormattingEnabled = true;
            this.cbox_Port_12.Items.AddRange(new object[] {
            "8090"});
            this.cbox_Port_12.Location = new System.Drawing.Point(72, 200);
            this.cbox_Port_12.Name = "cbox_Port_12";
            this.cbox_Port_12.Size = new System.Drawing.Size(112, 25);
            this.cbox_Port_12.TabIndex = 7;
            this.cbox_Port_12.Text = "请输入端口号";
            this.cbox_Port_12.Enter += new System.EventHandler(this.cbox_Port_Enter_12);
            this.cbox_Port_12.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbox_Port_Keypress_12);
            this.cbox_Port_12.Leave += new System.EventHandler(this.cbox_Port_Leave_12);
            // 
            // btn_Start_12
            // 
            this.btn_Start_12.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Start_12.Enabled = false;
            this.btn_Start_12.Location = new System.Drawing.Point(6, 267);
            this.btn_Start_12.Name = "btn_Start_12";
            this.btn_Start_12.Size = new System.Drawing.Size(90, 32);
            this.btn_Start_12.TabIndex = 8;
            this.btn_Start_12.Text = "开启服务";
            this.btn_Start_12.UseVisualStyleBackColor = true;
            this.btn_Start_12.Click += new System.EventHandler(this.btn_Start_12_Click);
            // 
            // btn_Exit_12
            // 
            this.btn_Exit_12.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Exit_12.Enabled = false;
            this.btn_Exit_12.Location = new System.Drawing.Point(97, 267);
            this.btn_Exit_12.Name = "btn_Exit_12";
            this.btn_Exit_12.Size = new System.Drawing.Size(88, 32);
            this.btn_Exit_12.TabIndex = 9;
            this.btn_Exit_12.Text = "退出聊天";
            this.btn_Exit_12.UseVisualStyleBackColor = true;
            this.btn_Exit_12.Click += new System.EventHandler(this.btn_Exit_12_Click);
            this.btn_Exit_12.MouseEnter += new System.EventHandler(this.btn_Exit_MouseEnter_12);
            // 
            // checkBox1_12
            // 
            this.checkBox1_12.AutoSize = true;
            this.checkBox1_12.Enabled = false;
            this.checkBox1_12.Location = new System.Drawing.Point(7, 240);
            this.checkBox1_12.Name = "checkBox1_12";
            this.checkBox1_12.Size = new System.Drawing.Size(110, 21);
            this.checkBox1_12.TabIndex = 10;
            this.checkBox1_12.Text = "记住IP与端口号";
            this.checkBox1_12.UseVisualStyleBackColor = true;
            // 
            // txt_ReceiveMsg_12
            // 
            this.txt_ReceiveMsg_12.BackColor = System.Drawing.SystemColors.Window;
            this.txt_ReceiveMsg_12.Location = new System.Drawing.Point(190, 7);
            this.txt_ReceiveMsg_12.Multiline = true;
            this.txt_ReceiveMsg_12.Name = "txt_ReceiveMsg_12";
            this.txt_ReceiveMsg_12.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_ReceiveMsg_12.Size = new System.Drawing.Size(384, 330);
            this.txt_ReceiveMsg_12.TabIndex = 11;
            this.txt_ReceiveMsg_12.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_ReceiveMsg_Keypress_12);
            // 
            // txt_SendMsg_12
            // 
            this.txt_SendMsg_12.Location = new System.Drawing.Point(190, 372);
            this.txt_SendMsg_12.Multiline = true;
            this.txt_SendMsg_12.Name = "txt_SendMsg_12";
            this.txt_SendMsg_12.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_SendMsg_12.Size = new System.Drawing.Size(384, 81);
            this.txt_SendMsg_12.TabIndex = 12;
            this.txt_SendMsg_12.Text = "请在此输入要发送的消息";
            this.txt_SendMsg_12.Enter += new System.EventHandler(this.txt_SendMsg_Enter_12);
            this.txt_SendMsg_12.Leave += new System.EventHandler(this.txt_SendMsg_Leave_12);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(192, 346);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 17);
            this.label3.TabIndex = 13;
            this.label3.Text = "我的昵称：";
            // 
            // txt_Name_12
            // 
            this.txt_Name_12.Location = new System.Drawing.Point(251, 343);
            this.txt_Name_12.Name = "txt_Name_12";
            this.txt_Name_12.Size = new System.Drawing.Size(124, 23);
            this.txt_Name_12.TabIndex = 14;
            this.txt_Name_12.Text = "匿名";
            this.txt_Name_12.Enter += new System.EventHandler(this.txt_Name_Enter_12);
            this.txt_Name_12.Leave += new System.EventHandler(this.txt_Name_Leave_12);
            // 
            // btn_SendMsg_12
            // 
            this.btn_SendMsg_12.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_SendMsg_12.Enabled = false;
            this.btn_SendMsg_12.Location = new System.Drawing.Point(486, 338);
            this.btn_SendMsg_12.Name = "btn_SendMsg_12";
            this.btn_SendMsg_12.Size = new System.Drawing.Size(88, 32);
            this.btn_SendMsg_12.TabIndex = 15;
            this.btn_SendMsg_12.Text = "发送消息";
            this.btn_SendMsg_12.UseVisualStyleBackColor = true;
            this.btn_SendMsg_12.Click += new System.EventHandler(this.btn_SendMsg_12_Click);
            this.btn_SendMsg_12.MouseEnter += new System.EventHandler(this.btn_SendMsg_MouseEnter_12);
            // 
            // btn_Clear_12
            // 
            this.btn_Clear_12.Location = new System.Drawing.Point(436, 343);
            this.btn_Clear_12.Name = "btn_Clear_12";
            this.btn_Clear_12.Size = new System.Drawing.Size(42, 23);
            this.btn_Clear_12.TabIndex = 16;
            this.btn_Clear_12.Text = "清屏";
            this.btn_Clear_12.UseVisualStyleBackColor = true;
            this.btn_Clear_12.Click += new System.EventHandler(this.btn_Clear_12_Click);
            // 
            // Form1_12
            // 
            this.AcceptButton = this.btn_SendMsg_12;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.CancelButton = this.btn_Exit_12;
            this.ClientSize = new System.Drawing.Size(579, 480);
            this.Controls.Add(this.btn_Clear_12);
            this.Controls.Add(this.btn_SendMsg_12);
            this.Controls.Add(this.txt_Name_12);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_SendMsg_12);
            this.Controls.Add(this.txt_ReceiveMsg_12);
            this.Controls.Add(this.btn_Exit_12);
            this.Controls.Add(this.btn_Start_12);
            this.Controls.Add(this.cbox_Port_12);
            this.Controls.Add(this.cbox_IP_12);
            this.Controls.Add(this.label2_12);
            this.Controls.Add(this.label1_12);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.checkBox1_12);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "Form1_12";
            this.Text = "Surbowl点对点聊天小工具 v1.0.2";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed_12);
            this.panel1.ResumeLayout(false);
            this.groupBox1_12.ResumeLayout(false);
            this.groupBox1_12.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbtn_f_12;
        private System.Windows.Forms.RadioButton rbtn_k_12;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2_12;
        private System.Windows.Forms.Label label1_12;
        private System.Windows.Forms.GroupBox groupBox1_12;
        private System.Windows.Forms.Label label2_12;
        private System.Windows.Forms.ComboBox cbox_IP_12;
        private System.Windows.Forms.ComboBox cbox_Port_12;
        private System.Windows.Forms.Button btn_Start_12;
        private System.Windows.Forms.Button btn_Exit_12;
        private System.Windows.Forms.CheckBox checkBox1_12;
        private System.Windows.Forms.TextBox txt_ReceiveMsg_12;
        private System.Windows.Forms.TextBox txt_SendMsg_12;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_Name_12;
        private System.Windows.Forms.Button btn_SendMsg_12;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3_12;
        private System.Windows.Forms.Button btn_Clear_12;
    }
}

