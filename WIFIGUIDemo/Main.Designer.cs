namespace WIFIGUIDemo
{
    partial class Main
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmdDisconnect = new System.Windows.Forms.Button();
            this.cmdConnect = new System.Windows.Forms.Button();
            this.lbPort = new System.Windows.Forms.Label();
            this.lblIPAddress = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.txtIPAddress = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ExportData = new System.Windows.Forms.Button();
            this.rotateBox = new System.Windows.Forms.TextBox();
            this.LFRight = new System.Windows.Forms.TextBox();
            this.LFLeft = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtCounter = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.chkRed = new System.Windows.Forms.CheckBox();
            this.chkGreen = new System.Windows.Forms.CheckBox();
            this.cmdGetCount = new System.Windows.Forms.Button();
            this.cmdSetLEDs = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.AccnData = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.MagnetData = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Photodiode = new System.Windows.Forms.TextBox();
            this.RightSpeed = new System.Windows.Forms.TextBox();
            this.LeftSpeed = new System.Windows.Forms.TextBox();
            this.Motor2Dist = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Motor1Dist = new System.Windows.Forms.TextBox();
            this.SlowFoward = new System.Windows.Forms.Button();
            this.FowardButton = new System.Windows.Forms.Button();
            this.SlowBackward = new System.Windows.Forms.Button();
            this.Backward = new System.Windows.Forms.Button();
            this.Clockwise = new System.Windows.Forms.Button();
            this.AntiClockwise = new System.Windows.Forms.Button();
            this.Stop = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkSwitch2Stat = new System.Windows.Forms.CheckBox();
            this.chkSwitch1Stat = new System.Windows.Forms.CheckBox();
            this.chkGreenStat = new System.Windows.Forms.CheckBox();
            this.chkRedStat = new System.Windows.Forms.CheckBox();
            this.cmdSwitchLedStatus = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.photoChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.clearGraph = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.lineChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.photoChart)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lineChart)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmdDisconnect);
            this.groupBox1.Controls.Add(this.cmdConnect);
            this.groupBox1.Controls.Add(this.lbPort);
            this.groupBox1.Controls.Add(this.lblIPAddress);
            this.groupBox1.Controls.Add(this.txtPort);
            this.groupBox1.Controls.Add(this.txtIPAddress);
            this.groupBox1.Location = new System.Drawing.Point(821, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(225, 118);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Connection";
            // 
            // cmdDisconnect
            // 
            this.cmdDisconnect.Location = new System.Drawing.Point(15, 82);
            this.cmdDisconnect.Name = "cmdDisconnect";
            this.cmdDisconnect.Size = new System.Drawing.Size(75, 23);
            this.cmdDisconnect.TabIndex = 5;
            this.cmdDisconnect.Text = "Disconnect";
            this.cmdDisconnect.UseVisualStyleBackColor = true;
            this.cmdDisconnect.Click += new System.EventHandler(this.cmdDisconnect_Click);
            // 
            // cmdConnect
            // 
            this.cmdConnect.Enabled = false;
            this.cmdConnect.Location = new System.Drawing.Point(138, 82);
            this.cmdConnect.Name = "cmdConnect";
            this.cmdConnect.Size = new System.Drawing.Size(75, 23);
            this.cmdConnect.TabIndex = 4;
            this.cmdConnect.Text = "Connect";
            this.cmdConnect.UseVisualStyleBackColor = true;
            this.cmdConnect.Click += new System.EventHandler(this.cmdConnect_Click);
            // 
            // lbPort
            // 
            this.lbPort.AutoSize = true;
            this.lbPort.Location = new System.Drawing.Point(12, 57);
            this.lbPort.Name = "lbPort";
            this.lbPort.Size = new System.Drawing.Size(60, 13);
            this.lbPort.TabIndex = 3;
            this.lbPort.Text = "Server Port";
            // 
            // lblIPAddress
            // 
            this.lblIPAddress.AutoSize = true;
            this.lblIPAddress.Location = new System.Drawing.Point(12, 31);
            this.lblIPAddress.Name = "lblIPAddress";
            this.lblIPAddress.Size = new System.Drawing.Size(92, 13);
            this.lblIPAddress.TabIndex = 2;
            this.lblIPAddress.Text = "Server IP Address";
            // 
            // txtPort
            // 
            this.txtPort.Enabled = false;
            this.txtPort.Location = new System.Drawing.Point(113, 54);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(100, 20);
            this.txtPort.TabIndex = 1;
            // 
            // txtIPAddress
            // 
            this.txtIPAddress.Enabled = false;
            this.txtIPAddress.Location = new System.Drawing.Point(113, 28);
            this.txtIPAddress.Name = "txtIPAddress";
            this.txtIPAddress.Size = new System.Drawing.Size(100, 20);
            this.txtIPAddress.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ExportData);
            this.groupBox2.Controls.Add(this.rotateBox);
            this.groupBox2.Controls.Add(this.LFRight);
            this.groupBox2.Controls.Add(this.LFLeft);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtCounter);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.chkRed);
            this.groupBox2.Controls.Add(this.chkGreen);
            this.groupBox2.Controls.Add(this.cmdGetCount);
            this.groupBox2.Controls.Add(this.cmdSetLEDs);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.AccnData);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.MagnetData);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.Photodiode);
            this.groupBox2.Controls.Add(this.RightSpeed);
            this.groupBox2.Controls.Add(this.LeftSpeed);
            this.groupBox2.Controls.Add(this.Motor2Dist);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.Motor1Dist);
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(803, 498);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Visualisation";
            // 
            // ExportData
            // 
            this.ExportData.Location = new System.Drawing.Point(16, 240);
            this.ExportData.Name = "ExportData";
            this.ExportData.Size = new System.Drawing.Size(75, 23);
            this.ExportData.TabIndex = 22;
            this.ExportData.Text = "Export Data";
            this.ExportData.UseVisualStyleBackColor = true;
            this.ExportData.Click += new System.EventHandler(this.ExportData_Click);
            // 
            // rotateBox
            // 
            this.rotateBox.Location = new System.Drawing.Point(613, 107);
            this.rotateBox.Name = "rotateBox";
            this.rotateBox.Size = new System.Drawing.Size(116, 20);
            this.rotateBox.TabIndex = 38;
            // 
            // LFRight
            // 
            this.LFRight.Location = new System.Drawing.Point(478, 107);
            this.LFRight.Name = "LFRight";
            this.LFRight.Size = new System.Drawing.Size(107, 20);
            this.LFRight.TabIndex = 37;
            // 
            // LFLeft
            // 
            this.LFLeft.Location = new System.Drawing.Point(356, 107);
            this.LFLeft.Name = "LFLeft";
            this.LFLeft.Size = new System.Drawing.Size(107, 20);
            this.LFLeft.TabIndex = 36;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(475, 86);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(102, 13);
            this.label9.TabIndex = 35;
            this.label9.Text = "Line Following Right";
            // 
            // txtCounter
            // 
            this.txtCounter.Location = new System.Drawing.Point(11, 214);
            this.txtCounter.Name = "txtCounter";
            this.txtCounter.Size = new System.Drawing.Size(89, 20);
            this.txtCounter.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(360, 85);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(95, 13);
            this.label8.TabIndex = 34;
            this.label8.Text = "Line Following Left";
            // 
            // chkRed
            // 
            this.chkRed.AutoSize = true;
            this.chkRed.Location = new System.Drawing.Point(129, 162);
            this.chkRed.Name = "chkRed";
            this.chkRed.Size = new System.Drawing.Size(70, 17);
            this.chkRed.TabIndex = 5;
            this.chkRed.Text = "Red LED";
            this.chkRed.UseVisualStyleBackColor = true;
            // 
            // chkGreen
            // 
            this.chkGreen.AutoSize = true;
            this.chkGreen.Location = new System.Drawing.Point(11, 162);
            this.chkGreen.Name = "chkGreen";
            this.chkGreen.Size = new System.Drawing.Size(79, 17);
            this.chkGreen.TabIndex = 4;
            this.chkGreen.Text = "Green LED";
            this.chkGreen.UseVisualStyleBackColor = true;
            // 
            // cmdGetCount
            // 
            this.cmdGetCount.Location = new System.Drawing.Point(109, 214);
            this.cmdGetCount.Name = "cmdGetCount";
            this.cmdGetCount.Size = new System.Drawing.Size(100, 21);
            this.cmdGetCount.TabIndex = 1;
            this.cmdGetCount.Text = "Counter";
            this.cmdGetCount.UseVisualStyleBackColor = true;
            this.cmdGetCount.Click += new System.EventHandler(this.cmdGetCount_Click);
            // 
            // cmdSetLEDs
            // 
            this.cmdSetLEDs.Location = new System.Drawing.Point(11, 185);
            this.cmdSetLEDs.Name = "cmdSetLEDs";
            this.cmdSetLEDs.Size = new System.Drawing.Size(198, 23);
            this.cmdSetLEDs.TabIndex = 0;
            this.cmdSetLEDs.Text = "Set LEDs";
            this.cmdSetLEDs.UseVisualStyleBackColor = true;
            this.cmdSetLEDs.Click += new System.EventHandler(this.cmdSetLEDs_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(126, 87);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 13);
            this.label7.TabIndex = 29;
            this.label7.Text = "Right Motor Speed";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 82);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 13);
            this.label6.TabIndex = 28;
            this.label6.Text = "Left Motor Speed";
            // 
            // AccnData
            // 
            this.AccnData.Location = new System.Drawing.Point(356, 49);
            this.AccnData.Name = "AccnData";
            this.AccnData.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.AccnData.Size = new System.Drawing.Size(107, 20);
            this.AccnData.TabIndex = 27;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(353, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 13);
            this.label5.TabIndex = 26;
            this.label5.Text = "Accelerometer";
            // 
            // MagnetData
            // 
            this.MagnetData.Location = new System.Drawing.Point(478, 50);
            this.MagnetData.Name = "MagnetData";
            this.MagnetData.Size = new System.Drawing.Size(129, 20);
            this.MagnetData.TabIndex = 25;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(475, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "Magnetometer";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(610, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Photodiode value";
            // 
            // Photodiode
            // 
            this.Photodiode.Location = new System.Drawing.Point(613, 51);
            this.Photodiode.Name = "Photodiode";
            this.Photodiode.Size = new System.Drawing.Size(136, 20);
            this.Photodiode.TabIndex = 22;
            // 
            // RightSpeed
            // 
            this.RightSpeed.Location = new System.Drawing.Point(123, 107);
            this.RightSpeed.Name = "RightSpeed";
            this.RightSpeed.Size = new System.Drawing.Size(104, 20);
            this.RightSpeed.TabIndex = 21;
            // 
            // LeftSpeed
            // 
            this.LeftSpeed.Location = new System.Drawing.Point(7, 107);
            this.LeftSpeed.Name = "LeftSpeed";
            this.LeftSpeed.Size = new System.Drawing.Size(95, 20);
            this.LeftSpeed.TabIndex = 20;
            // 
            // Motor2Dist
            // 
            this.Motor2Dist.Location = new System.Drawing.Point(123, 47);
            this.Motor2Dist.Name = "Motor2Dist";
            this.Motor2Dist.Size = new System.Drawing.Size(100, 20);
            this.Motor2Dist.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(120, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Right Motor Dist";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Left Motor Dist";
            // 
            // Motor1Dist
            // 
            this.Motor1Dist.Location = new System.Drawing.Point(6, 51);
            this.Motor1Dist.Name = "Motor1Dist";
            this.Motor1Dist.Size = new System.Drawing.Size(96, 20);
            this.Motor1Dist.TabIndex = 16;
            // 
            // SlowFoward
            // 
            this.SlowFoward.Location = new System.Drawing.Point(76, 61);
            this.SlowFoward.Name = "SlowFoward";
            this.SlowFoward.Size = new System.Drawing.Size(97, 22);
            this.SlowFoward.TabIndex = 33;
            this.SlowFoward.Text = "Slow Forward";
            this.SlowFoward.UseVisualStyleBackColor = true;
            this.SlowFoward.Click += new System.EventHandler(this.SlowFoward_Click);
            // 
            // FowardButton
            // 
            this.FowardButton.Location = new System.Drawing.Point(76, 33);
            this.FowardButton.Name = "FowardButton";
            this.FowardButton.Size = new System.Drawing.Size(97, 22);
            this.FowardButton.TabIndex = 32;
            this.FowardButton.Text = "All Forward (W)";
            this.FowardButton.UseVisualStyleBackColor = true;
            this.FowardButton.Click += new System.EventHandler(this.FowardButton_Click);
            // 
            // SlowBackward
            // 
            this.SlowBackward.Location = new System.Drawing.Point(76, 135);
            this.SlowBackward.Name = "SlowBackward";
            this.SlowBackward.Size = new System.Drawing.Size(97, 22);
            this.SlowBackward.TabIndex = 31;
            this.SlowBackward.TabStop = false;
            this.SlowBackward.Text = "Slow Backward";
            this.SlowBackward.UseVisualStyleBackColor = true;
            this.SlowBackward.Click += new System.EventHandler(this.SlowBackward_Click);
            // 
            // Backward
            // 
            this.Backward.Location = new System.Drawing.Point(73, 163);
            this.Backward.Name = "Backward";
            this.Backward.Size = new System.Drawing.Size(100, 23);
            this.Backward.TabIndex = 16;
            this.Backward.Text = "Full Reverse (S)";
            this.Backward.UseVisualStyleBackColor = true;
            this.Backward.Click += new System.EventHandler(this.Backward_Click);
            // 
            // Clockwise
            // 
            this.Clockwise.Location = new System.Drawing.Point(148, 92);
            this.Clockwise.Name = "Clockwise";
            this.Clockwise.Size = new System.Drawing.Size(71, 37);
            this.Clockwise.TabIndex = 15;
            this.Clockwise.Text = "Clockwise (D)";
            this.Clockwise.UseMnemonic = false;
            this.Clockwise.UseVisualStyleBackColor = true;
            this.Clockwise.Click += new System.EventHandler(this.Clockwise_Click);
            // 
            // AntiClockwise
            // 
            this.AntiClockwise.Location = new System.Drawing.Point(8, 92);
            this.AntiClockwise.Name = "AntiClockwise";
            this.AntiClockwise.Size = new System.Drawing.Size(91, 37);
            this.AntiClockwise.TabIndex = 14;
            this.AntiClockwise.Text = "Anti Clockwise (A)";
            this.AntiClockwise.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.AntiClockwise.UseVisualStyleBackColor = true;
            this.AntiClockwise.Click += new System.EventHandler(this.AntiClockwise_Click);
            // 
            // Stop
            // 
            this.Stop.Location = new System.Drawing.Point(105, 99);
            this.Stop.Name = "Stop";
            this.Stop.Size = new System.Drawing.Size(37, 23);
            this.Stop.TabIndex = 13;
            this.Stop.Text = "Stop";
            this.Stop.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Stop.UseVisualStyleBackColor = true;
            this.Stop.Click += new System.EventHandler(this.Stop_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chkSwitch2Stat);
            this.groupBox3.Controls.Add(this.chkSwitch1Stat);
            this.groupBox3.Controls.Add(this.chkGreenStat);
            this.groupBox3.Controls.Add(this.chkRedStat);
            this.groupBox3.Controls.Add(this.cmdSwitchLedStatus);
            this.groupBox3.Controls.Add(this.FowardButton);
            this.groupBox3.Controls.Add(this.Stop);
            this.groupBox3.Controls.Add(this.AntiClockwise);
            this.groupBox3.Controls.Add(this.Clockwise);
            this.groupBox3.Controls.Add(this.Backward);
            this.groupBox3.Controls.Add(this.SlowFoward);
            this.groupBox3.Controls.Add(this.SlowBackward);
            this.groupBox3.Location = new System.Drawing.Point(821, 136);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(225, 374);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Commands";
            // 
            // chkSwitch2Stat
            // 
            this.chkSwitch2Stat.AutoSize = true;
            this.chkSwitch2Stat.Enabled = false;
            this.chkSwitch2Stat.Location = new System.Drawing.Point(133, 243);
            this.chkSwitch2Stat.Name = "chkSwitch2Stat";
            this.chkSwitch2Stat.Size = new System.Drawing.Size(67, 17);
            this.chkSwitch2Stat.TabIndex = 11;
            this.chkSwitch2Stat.Text = "Switch 2";
            this.chkSwitch2Stat.UseVisualStyleBackColor = true;
            // 
            // chkSwitch1Stat
            // 
            this.chkSwitch1Stat.AutoSize = true;
            this.chkSwitch1Stat.Enabled = false;
            this.chkSwitch1Stat.Location = new System.Drawing.Point(28, 243);
            this.chkSwitch1Stat.Name = "chkSwitch1Stat";
            this.chkSwitch1Stat.Size = new System.Drawing.Size(67, 17);
            this.chkSwitch1Stat.TabIndex = 10;
            this.chkSwitch1Stat.Text = "Switch 1";
            this.chkSwitch1Stat.UseVisualStyleBackColor = true;
            // 
            // chkGreenStat
            // 
            this.chkGreenStat.AutoSize = true;
            this.chkGreenStat.Enabled = false;
            this.chkGreenStat.Location = new System.Drawing.Point(133, 219);
            this.chkGreenStat.Name = "chkGreenStat";
            this.chkGreenStat.Size = new System.Drawing.Size(79, 17);
            this.chkGreenStat.TabIndex = 9;
            this.chkGreenStat.Text = "Green LED";
            this.chkGreenStat.UseVisualStyleBackColor = true;
            // 
            // chkRedStat
            // 
            this.chkRedStat.AutoSize = true;
            this.chkRedStat.Enabled = false;
            this.chkRedStat.Location = new System.Drawing.Point(28, 219);
            this.chkRedStat.Name = "chkRedStat";
            this.chkRedStat.Size = new System.Drawing.Size(70, 17);
            this.chkRedStat.TabIndex = 8;
            this.chkRedStat.Text = "Red LED";
            this.chkRedStat.UseVisualStyleBackColor = true;
            this.chkRedStat.CheckedChanged += new System.EventHandler(this.chkRedStat_CheckedChanged);
            // 
            // cmdSwitchLedStatus
            // 
            this.cmdSwitchLedStatus.Location = new System.Drawing.Point(62, 266);
            this.cmdSwitchLedStatus.Name = "cmdSwitchLedStatus";
            this.cmdSwitchLedStatus.Size = new System.Drawing.Size(100, 21);
            this.cmdSwitchLedStatus.TabIndex = 3;
            this.cmdSwitchLedStatus.Text = "Get Status";
            this.cmdSwitchLedStatus.UseVisualStyleBackColor = true;
            this.cmdSwitchLedStatus.Click += new System.EventHandler(this.cmdSwitchLedStatus_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            // 
            // photoChart
            // 
            chartArea1.Name = "ChartArea1";
            this.photoChart.ChartAreas.Add(chartArea1);
            this.photoChart.Location = new System.Drawing.Point(18, 20);
            this.photoChart.Name = "photoChart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Name = "Series2";
            this.photoChart.Series.Add(series1);
            this.photoChart.Size = new System.Drawing.Size(596, 236);
            this.photoChart.TabIndex = 23;
            this.photoChart.Text = "chart1";
            // 
            // clearGraph
            // 
            this.clearGraph.Location = new System.Drawing.Point(620, 41);
            this.clearGraph.Name = "clearGraph";
            this.clearGraph.Size = new System.Drawing.Size(75, 23);
            this.clearGraph.TabIndex = 39;
            this.clearGraph.Text = "clear graph";
            this.clearGraph.UseVisualStyleBackColor = true;
            this.clearGraph.Click += new System.EventHandler(this.clearGraph_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(0, 0);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(200, 100);
            this.tabPage2.TabIndex = 0;
            this.tabPage2.Text = "tabPage2";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(1, 1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(814, 509);
            this.tabControl1.TabIndex = 40;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(806, 483);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Main screen";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.lineChart);
            this.tabPage3.Controls.Add(this.photoChart);
            this.tabPage3.Controls.Add(this.clearGraph);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(806, 483);
            this.tabPage3.TabIndex = 1;
            this.tabPage3.Text = "Graphs";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // lineChart
            // 
            chartArea2.Name = "ChartArea1";
            this.lineChart.ChartAreas.Add(chartArea2);
            legend1.Name = "Legend1";
            this.lineChart.Legends.Add(legend1);
            this.lineChart.Location = new System.Drawing.Point(49, 248);
            this.lineChart.Name = "lineChart";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Legend = "Legend1";
            series3.Name = "Series2";
            this.lineChart.Series.Add(series2);
            this.lineChart.Series.Add(series3);
            this.lineChart.Size = new System.Drawing.Size(509, 207);
            this.lineChart.TabIndex = 40;
            this.lineChart.Text = "chart1";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1058, 522);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Name = "Main";
            this.Text = "Rover GUI";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Main_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Main_KeyUp);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.photoChart)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lineChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.TextBox txtIPAddress;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lbPort;
        private System.Windows.Forms.Label lblIPAddress;
        private System.Windows.Forms.Button cmdDisconnect;
        private System.Windows.Forms.Button cmdConnect;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button cmdSwitchLedStatus;
        private System.Windows.Forms.Button cmdGetCount;
        private System.Windows.Forms.Button cmdSetLEDs;
        private System.Windows.Forms.CheckBox chkRed;
        private System.Windows.Forms.CheckBox chkGreen;
        private System.Windows.Forms.TextBox txtCounter;
        private System.Windows.Forms.CheckBox chkSwitch2Stat;
        private System.Windows.Forms.CheckBox chkSwitch1Stat;
        private System.Windows.Forms.CheckBox chkGreenStat;
        private System.Windows.Forms.CheckBox chkRedStat;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button Stop;
        private System.Windows.Forms.Button AntiClockwise;
        private System.Windows.Forms.Button Clockwise;
        private System.Windows.Forms.TextBox Motor1Dist;
        private System.Windows.Forms.TextBox Motor2Dist;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox RightSpeed;
        private System.Windows.Forms.TextBox LeftSpeed;
        private System.Windows.Forms.Button Backward;
        private System.Windows.Forms.Button ExportData;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Photodiode;
        private System.Windows.Forms.TextBox MagnetData;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox AccnData;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button SlowBackward;
        private System.Windows.Forms.Button FowardButton;
        private System.Windows.Forms.Button SlowFoward;
        private System.Windows.Forms.TextBox LFRight;
        private System.Windows.Forms.TextBox LFLeft;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox rotateBox;
        private System.Windows.Forms.DataVisualization.Charting.Chart photoChart;
        private System.Windows.Forms.Button clearGraph;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataVisualization.Charting.Chart lineChart;
    }
}

