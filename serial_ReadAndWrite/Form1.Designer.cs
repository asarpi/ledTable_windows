namespace serial_ReadAndWrite
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.msgBox = new System.Windows.Forms.RichTextBox();
            this.connectButton = new System.Windows.Forms.Button();
            this.disconnectButton = new System.Windows.Forms.Button();
            this.sendMsg_TextBox = new System.Windows.Forms.TextBox();
            this.sendMsg_button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBox_BoardName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtBox_ConnectionState = new System.Windows.Forms.TextBox();
            this.txtBox_ConnectedPort = new System.Windows.Forms.TextBox();
            this.txtBox_ConnectionBaudRate = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button_fullWave = new System.Windows.Forms.Button();
            this.comboBox_wave_cycNum = new System.Windows.Forms.ComboBox();
            this.comboBox_transStepNum = new System.Windows.Forms.ComboBox();
            this.comboBox_wave_stepNum = new System.Windows.Forms.ComboBox();
            this.comboBox_transition = new System.Windows.Forms.ComboBox();
            this.button_sendWave = new System.Windows.Forms.Button();
            this.button_sendColor = new System.Windows.Forms.Button();
            this.button_setColor = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.textBox_wave_R = new System.Windows.Forms.TextBox();
            this.textBox_wave_G = new System.Windows.Forms.TextBox();
            this.textBox_wave_B = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.button_start = new System.Windows.Forms.Button();
            this.button_stop = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // msgBox
            // 
            this.msgBox.Location = new System.Drawing.Point(17, 273);
            this.msgBox.Name = "msgBox";
            this.msgBox.Size = new System.Drawing.Size(275, 223);
            this.msgBox.TabIndex = 1;
            this.msgBox.Text = "";
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(18, 198);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(93, 23);
            this.connectButton.TabIndex = 2;
            this.connectButton.Text = "Kapcsolódás";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // disconnectButton
            // 
            this.disconnectButton.Location = new System.Drawing.Point(192, 198);
            this.disconnectButton.Name = "disconnectButton";
            this.disconnectButton.Size = new System.Drawing.Size(100, 23);
            this.disconnectButton.TabIndex = 2;
            this.disconnectButton.Text = "Szétkapcsolás";
            this.disconnectButton.UseVisualStyleBackColor = true;
            this.disconnectButton.Click += new System.EventHandler(this.disconnectButton_Click);
            // 
            // sendMsg_TextBox
            // 
            this.sendMsg_TextBox.Location = new System.Drawing.Point(17, 247);
            this.sendMsg_TextBox.Name = "sendMsg_TextBox";
            this.sendMsg_TextBox.Size = new System.Drawing.Size(275, 20);
            this.sendMsg_TextBox.TabIndex = 3;
            // 
            // sendMsg_button
            // 
            this.sendMsg_button.Location = new System.Drawing.Point(108, 198);
            this.sendMsg_button.Name = "sendMsg_button";
            this.sendMsg_button.Size = new System.Drawing.Size(85, 23);
            this.sendMsg_button.TabIndex = 4;
            this.sendMsg_button.Text = "Üzenet";
            this.sendMsg_button.UseVisualStyleBackColor = true;
            this.sendMsg_button.Click += new System.EventHandler(this.sendMsg_button_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(97, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Hardver paraméterek";
            // 
            // txtBox_BoardName
            // 
            this.txtBox_BoardName.Enabled = false;
            this.txtBox_BoardName.Location = new System.Drawing.Point(65, 40);
            this.txtBox_BoardName.Name = "txtBox_BoardName";
            this.txtBox_BoardName.Size = new System.Drawing.Size(219, 20);
            this.txtBox_BoardName.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Board";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(85, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Csatlakozás tulajdonságai";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(45, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "PORT neve";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(45, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "BAUD rate";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(45, 43);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "állapot";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtBox_ConnectionState);
            this.groupBox1.Location = new System.Drawing.Point(17, 61);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(275, 126);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // txtBox_ConnectionState
            // 
            this.txtBox_ConnectionState.Enabled = false;
            this.txtBox_ConnectionState.Location = new System.Drawing.Point(132, 40);
            this.txtBox_ConnectionState.Name = "txtBox_ConnectionState";
            this.txtBox_ConnectionState.Size = new System.Drawing.Size(115, 20);
            this.txtBox_ConnectionState.TabIndex = 6;
            // 
            // txtBox_ConnectedPort
            // 
            this.txtBox_ConnectedPort.Enabled = false;
            this.txtBox_ConnectedPort.Location = new System.Drawing.Point(149, 130);
            this.txtBox_ConnectedPort.Name = "txtBox_ConnectedPort";
            this.txtBox_ConnectedPort.Size = new System.Drawing.Size(115, 20);
            this.txtBox_ConnectedPort.TabIndex = 6;
            // 
            // txtBox_ConnectionBaudRate
            // 
            this.txtBox_ConnectionBaudRate.Enabled = false;
            this.txtBox_ConnectionBaudRate.Location = new System.Drawing.Point(149, 158);
            this.txtBox_ConnectionBaudRate.Name = "txtBox_ConnectionBaudRate";
            this.txtBox_ConnectionBaudRate.Size = new System.Drawing.Size(115, 20);
            this.txtBox_ConnectionBaudRate.TabIndex = 6;
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(17, 24);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(275, 44);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(18, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(319, 536);
            this.tabControl1.TabIndex = 8;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.msgBox);
            this.tabPage1.Controls.Add(this.txtBox_BoardName);
            this.tabPage1.Controls.Add(this.txtBox_ConnectionBaudRate);
            this.tabPage1.Controls.Add(this.txtBox_ConnectedPort);
            this.tabPage1.Controls.Add(this.connectButton);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.disconnectButton);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.sendMsg_TextBox);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.sendMsg_button);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(311, 510);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Kapcsolat";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.textBox_wave_B);
            this.tabPage2.Controls.Add(this.textBox_wave_G);
            this.tabPage2.Controls.Add(this.textBox_wave_R);
            this.tabPage2.Controls.Add(this.button_fullWave);
            this.tabPage2.Controls.Add(this.comboBox_wave_cycNum);
            this.tabPage2.Controls.Add(this.comboBox_transStepNum);
            this.tabPage2.Controls.Add(this.comboBox_wave_stepNum);
            this.tabPage2.Controls.Add(this.comboBox_transition);
            this.tabPage2.Controls.Add(this.button_sendWave);
            this.tabPage2.Controls.Add(this.button_sendColor);
            this.tabPage2.Controls.Add(this.button_setColor);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(311, 510);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Színek";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // button_fullWave
            // 
            this.button_fullWave.Location = new System.Drawing.Point(156, 258);
            this.button_fullWave.Name = "button_fullWave";
            this.button_fullWave.Size = new System.Drawing.Size(89, 23);
            this.button_fullWave.TabIndex = 2;
            this.button_fullWave.Text = "teljes hullám";
            this.button_fullWave.UseVisualStyleBackColor = true;
            this.button_fullWave.Click += new System.EventHandler(this.button_fullWave_Click);
            // 
            // comboBox_wave_cycNum
            // 
            this.comboBox_wave_cycNum.FormattingEnabled = true;
            this.comboBox_wave_cycNum.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.comboBox_wave_cycNum.Location = new System.Drawing.Point(209, 211);
            this.comboBox_wave_cycNum.Name = "comboBox_wave_cycNum";
            this.comboBox_wave_cycNum.Size = new System.Drawing.Size(81, 21);
            this.comboBox_wave_cycNum.TabIndex = 1;
            this.comboBox_wave_cycNum.Text = "1";
            // 
            // comboBox_transStepNum
            // 
            this.comboBox_transStepNum.FormattingEnabled = true;
            this.comboBox_transStepNum.Items.AddRange(new object[] {
            "2",
            "5",
            "10",
            "15",
            "30",
            "50",
            "65",
            "80",
            "100"});
            this.comboBox_transStepNum.Location = new System.Drawing.Point(197, 82);
            this.comboBox_transStepNum.Name = "comboBox_transStepNum";
            this.comboBox_transStepNum.Size = new System.Drawing.Size(81, 21);
            this.comboBox_transStepNum.TabIndex = 1;
            this.comboBox_transStepNum.Text = "30";
            // 
            // comboBox_wave_stepNum
            // 
            this.comboBox_wave_stepNum.FormattingEnabled = true;
            this.comboBox_wave_stepNum.Items.AddRange(new object[] {
            "20",
            "40",
            "60"});
            this.comboBox_wave_stepNum.Location = new System.Drawing.Point(119, 211);
            this.comboBox_wave_stepNum.Name = "comboBox_wave_stepNum";
            this.comboBox_wave_stepNum.Size = new System.Drawing.Size(81, 21);
            this.comboBox_wave_stepNum.TabIndex = 1;
            this.comboBox_wave_stepNum.Text = "40";
            // 
            // comboBox_transition
            // 
            this.comboBox_transition.FormattingEnabled = true;
            this.comboBox_transition.Items.AddRange(new object[] {
            "lineáris",
            "szinuszos",
            "exponenciális"});
            this.comboBox_transition.Location = new System.Drawing.Point(110, 82);
            this.comboBox_transition.Name = "comboBox_transition";
            this.comboBox_transition.Size = new System.Drawing.Size(81, 21);
            this.comboBox_transition.TabIndex = 1;
            this.comboBox_transition.Text = "szinuszos";
            // 
            // button_sendWave
            // 
            this.button_sendWave.Location = new System.Drawing.Point(50, 258);
            this.button_sendWave.Name = "button_sendWave";
            this.button_sendWave.Size = new System.Drawing.Size(89, 23);
            this.button_sendWave.TabIndex = 0;
            this.button_sendWave.Text = "hullám indítása";
            this.button_sendWave.UseVisualStyleBackColor = true;
            this.button_sendWave.Click += new System.EventHandler(this.button_sendWave_Click);
            // 
            // button_sendColor
            // 
            this.button_sendColor.Location = new System.Drawing.Point(110, 128);
            this.button_sendColor.Name = "button_sendColor";
            this.button_sendColor.Size = new System.Drawing.Size(89, 23);
            this.button_sendColor.TabIndex = 0;
            this.button_sendColor.Text = "szín beállítása";
            this.button_sendColor.UseVisualStyleBackColor = true;
            this.button_sendColor.Click += new System.EventHandler(this.button_sendColor_Click);
            // 
            // button_setColor
            // 
            this.button_setColor.Location = new System.Drawing.Point(15, 80);
            this.button_setColor.Name = "button_setColor";
            this.button_setColor.Size = new System.Drawing.Size(89, 23);
            this.button_setColor.TabIndex = 0;
            this.button_setColor.Text = "szín beállítása";
            this.button_setColor.UseVisualStyleBackColor = true;
            this.button_setColor.Click += new System.EventHandler(this.button_setColor_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.button_stop);
            this.tabPage3.Controls.Add(this.button_start);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(311, 510);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Profilok";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // textBox_wave_R
            // 
            this.textBox_wave_R.Location = new System.Drawing.Point(15, 212);
            this.textBox_wave_R.Name = "textBox_wave_R";
            this.textBox_wave_R.Size = new System.Drawing.Size(27, 20);
            this.textBox_wave_R.TabIndex = 3;
            this.textBox_wave_R.Text = "255";
            // 
            // textBox_wave_G
            // 
            this.textBox_wave_G.Location = new System.Drawing.Point(47, 212);
            this.textBox_wave_G.Name = "textBox_wave_G";
            this.textBox_wave_G.Size = new System.Drawing.Size(27, 20);
            this.textBox_wave_G.TabIndex = 3;
            this.textBox_wave_G.Text = "255";
            // 
            // textBox_wave_B
            // 
            this.textBox_wave_B.Location = new System.Drawing.Point(81, 212);
            this.textBox_wave_B.Name = "textBox_wave_B";
            this.textBox_wave_B.Size = new System.Drawing.Size(27, 20);
            this.textBox_wave_B.TabIndex = 3;
            this.textBox_wave_B.Text = "255";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 193);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(15, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "R";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(53, 193);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(15, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "G";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(86, 193);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(14, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "B";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(131, 193);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(51, 13);
            this.label10.TabIndex = 4;
            this.label10.Text = "lépészám";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(219, 193);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(58, 13);
            this.label11.TabIndex = 4;
            this.label11.Text = "ciklusszám";
            // 
            // button_start
            // 
            this.button_start.Location = new System.Drawing.Point(58, 80);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(75, 23);
            this.button_start.TabIndex = 0;
            this.button_start.Text = "start";
            this.button_start.UseVisualStyleBackColor = true;
            this.button_start.Click += new System.EventHandler(this.button_start_Click);
            // 
            // button_stop
            // 
            this.button_stop.Location = new System.Drawing.Point(148, 80);
            this.button_stop.Name = "button_stop";
            this.button_stop.Size = new System.Drawing.Size(75, 23);
            this.button_stop.TabIndex = 0;
            this.button_stop.Text = "stop";
            this.button_stop.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 580);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Asztalvilágító bizgentyű";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox msgBox;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.Button disconnectButton;
        private System.Windows.Forms.TextBox sendMsg_TextBox;
        private System.Windows.Forms.Button sendMsg_button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBox_BoardName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtBox_ConnectionState;
        private System.Windows.Forms.TextBox txtBox_ConnectedPort;
        private System.Windows.Forms.TextBox txtBox_ConnectionBaudRate;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button button_setColor;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.ComboBox comboBox_transition;
        private System.Windows.Forms.ComboBox comboBox_transStepNum;
        private System.Windows.Forms.Button button_sendColor;
        private System.Windows.Forms.ComboBox comboBox_wave_cycNum;
        private System.Windows.Forms.ComboBox comboBox_wave_stepNum;
        private System.Windows.Forms.Button button_sendWave;
        private System.Windows.Forms.Button button_fullWave;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox_wave_R;
        private System.Windows.Forms.TextBox textBox_wave_G;
        private System.Windows.Forms.TextBox textBox_wave_B;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.Button button_stop;
        private System.Windows.Forms.Button button_start;
    }
}

