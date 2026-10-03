namespace VideoBitrateCalculator
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.txtTotalSeconds = new System.Windows.Forms.TextBox();
            this.txtOverhead = new System.Windows.Forms.TextBox();
            this.txtVideobitrate = new System.Windows.Forms.TextBox();
            this.txtTotalbitrate = new System.Windows.Forms.TextBox();
            this.txtHours = new System.Windows.Forms.TextBox();
            this.txtMinutes = new System.Windows.Forms.TextBox();
            this.txtSeconds = new System.Windows.Forms.TextBox();
            this.txtAudiobitrate = new System.Windows.Forms.TextBox();
            this.txtTrackNumber = new System.Windows.Forms.TextBox();
            this.VideoBitrateFromTimeSizeAudio = new System.Windows.Forms.Button();
            this.btnTimeFromBitrateFileSize = new System.Windows.Forms.Button();
            this.AudioBitrateFromTimeSizeVideo = new System.Windows.Forms.Button();
            this.btnOverhead = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.BytesSum = new System.Windows.Forms.TextBox();
            this.kiloBytesSum = new System.Windows.Forms.TextBox();
            this.bitsSum = new System.Windows.Forms.TextBox();
            this.kibiBytesSum = new System.Windows.Forms.TextBox();
            this.mebiBytesSum = new System.Windows.Forms.TextBox();
            this.megaBytesSum = new System.Windows.Forms.TextBox();
            this.gibiBytesSum = new System.Windows.Forms.TextBox();
            this.gigaBytesSum = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.btnH264baseline = new System.Windows.Forms.Button();
            this.btnVideoSize = new System.Windows.Forms.Button();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.btnH265Main = new System.Windows.Forms.Button();
            this.btnMP4 = new System.Windows.Forms.Button();
            this.btnRaw = new System.Windows.Forms.Button();
            this.btnH264high = new System.Windows.Forms.Button();
            this.txtAspectRatio = new System.Windows.Forms.TextBox();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.textBitPixel = new System.Windows.Forms.TextBox();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.checkBoxCGI = new System.Windows.Forms.CheckBox();
            this.checkBoxNoisyimageTreesBushes = new System.Windows.Forms.CheckBox();
            this.checkBoxDarkScenesStillimages = new System.Windows.Forms.CheckBox();
            this.btnAudioSize = new System.Windows.Forms.Button();
            this.label34 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.btnFPSselect = new System.Windows.Forms.Button();
            this.txtFrameRate = new System.Windows.Forms.TextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.SizeFromTimeAndBitrate = new System.Windows.Forms.Button();
            this.btnPixelSelect = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.linkVideoBitrateCalculator = new System.Windows.Forms.LinkLabel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // txtTotalSeconds
            // 
            this.txtTotalSeconds.AccessibleDescription = "";
            this.txtTotalSeconds.Font = new System.Drawing.Font("Unispace", 11F, System.Drawing.FontStyle.Bold);
            this.txtTotalSeconds.Location = new System.Drawing.Point(191, 82);
            this.txtTotalSeconds.Name = "txtTotalSeconds";
            this.txtTotalSeconds.Size = new System.Drawing.Size(122, 25);
            this.txtTotalSeconds.TabIndex = 1;
            this.txtTotalSeconds.Tag = "";
            this.txtTotalSeconds.Text = "0";
            this.txtTotalSeconds.TextChanged += new System.EventHandler(this.Seconds_TextChanged);
            // 
            // txtOverhead
            // 
            this.txtOverhead.Font = new System.Drawing.Font("Unispace", 11F, System.Drawing.FontStyle.Bold);
            this.txtOverhead.Location = new System.Drawing.Point(191, 160);
            this.txtOverhead.Name = "txtOverhead";
            this.txtOverhead.Size = new System.Drawing.Size(122, 25);
            this.txtOverhead.TabIndex = 2;
            this.txtOverhead.Tag = "";
            this.txtOverhead.Text = "0";
            // 
            // txtVideobitrate
            // 
            this.txtVideobitrate.Font = new System.Drawing.Font("Unispace", 11F, System.Drawing.FontStyle.Bold);
            this.txtVideobitrate.Location = new System.Drawing.Point(191, 134);
            this.txtVideobitrate.Name = "txtVideobitrate";
            this.txtVideobitrate.Size = new System.Drawing.Size(122, 25);
            this.txtVideobitrate.TabIndex = 3;
            this.txtVideobitrate.Tag = "";
            this.txtVideobitrate.Text = "0";
            this.txtVideobitrate.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // txtTotalbitrate
            // 
            this.txtTotalbitrate.Font = new System.Drawing.Font("Unispace", 11F, System.Drawing.FontStyle.Bold);
            this.txtTotalbitrate.Location = new System.Drawing.Point(191, 108);
            this.txtTotalbitrate.Name = "txtTotalbitrate";
            this.txtTotalbitrate.Size = new System.Drawing.Size(122, 25);
            this.txtTotalbitrate.TabIndex = 4;
            this.txtTotalbitrate.Tag = "";
            this.txtTotalbitrate.Text = "0";
            this.txtTotalbitrate.TextChanged += new System.EventHandler(this.txtTotalbitrate_TextChanged);
            // 
            // txtHours
            // 
            this.txtHours.Font = new System.Drawing.Font("Unispace", 11F, System.Drawing.FontStyle.Bold);
            this.txtHours.Location = new System.Drawing.Point(514, 76);
            this.txtHours.Name = "txtHours";
            this.txtHours.Size = new System.Drawing.Size(28, 25);
            this.txtHours.TabIndex = 5;
            this.txtHours.Tag = "";
            this.txtHours.Text = "00";
            this.txtHours.TextChanged += new System.EventHandler(this.textBox5_TextChanged);
            // 
            // txtMinutes
            // 
            this.txtMinutes.Font = new System.Drawing.Font("Unispace", 11F, System.Drawing.FontStyle.Bold);
            this.txtMinutes.Location = new System.Drawing.Point(571, 76);
            this.txtMinutes.Name = "txtMinutes";
            this.txtMinutes.Size = new System.Drawing.Size(28, 25);
            this.txtMinutes.TabIndex = 6;
            this.txtMinutes.Tag = "";
            this.txtMinutes.Text = "00";
            this.txtMinutes.TextChanged += new System.EventHandler(this.textBox6_TextChanged);
            // 
            // txtSeconds
            // 
            this.txtSeconds.Font = new System.Drawing.Font("Unispace", 11F, System.Drawing.FontStyle.Bold);
            this.txtSeconds.Location = new System.Drawing.Point(628, 76);
            this.txtSeconds.Name = "txtSeconds";
            this.txtSeconds.Size = new System.Drawing.Size(28, 25);
            this.txtSeconds.TabIndex = 7;
            this.txtSeconds.Tag = "";
            this.txtSeconds.Text = "00";
            // 
            // txtAudiobitrate
            // 
            this.txtAudiobitrate.Font = new System.Drawing.Font("Unispace", 11F, System.Drawing.FontStyle.Bold);
            this.txtAudiobitrate.Location = new System.Drawing.Point(514, 129);
            this.txtAudiobitrate.Name = "txtAudiobitrate";
            this.txtAudiobitrate.Size = new System.Drawing.Size(59, 25);
            this.txtAudiobitrate.TabIndex = 8;
            this.txtAudiobitrate.Tag = "";
            this.txtAudiobitrate.Text = "0";
            // 
            // txtTrackNumber
            // 
            this.txtTrackNumber.Font = new System.Drawing.Font("Unispace", 11F, System.Drawing.FontStyle.Bold);
            this.txtTrackNumber.Location = new System.Drawing.Point(514, 155);
            this.txtTrackNumber.Name = "txtTrackNumber";
            this.txtTrackNumber.Size = new System.Drawing.Size(21, 25);
            this.txtTrackNumber.TabIndex = 9;
            this.txtTrackNumber.Tag = "";
            this.txtTrackNumber.Text = "0";
            // 
            // VideoBitrateFromTimeSizeAudio
            // 
            this.VideoBitrateFromTimeSizeAudio.Font = new System.Drawing.Font("Unispace", 11F, System.Drawing.FontStyle.Bold);
            this.VideoBitrateFromTimeSizeAudio.Location = new System.Drawing.Point(191, 189);
            this.VideoBitrateFromTimeSizeAudio.Name = "VideoBitrateFromTimeSizeAudio";
            this.VideoBitrateFromTimeSizeAudio.Size = new System.Drawing.Size(259, 23);
            this.VideoBitrateFromTimeSizeAudio.TabIndex = 10;
            this.VideoBitrateFromTimeSizeAudio.Text = "Video from time,size,audio";
            this.VideoBitrateFromTimeSizeAudio.UseVisualStyleBackColor = true;
            this.VideoBitrateFromTimeSizeAudio.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnTimeFromBitrateFileSize
            // 
            this.btnTimeFromBitrateFileSize.Font = new System.Drawing.Font("Unispace", 11F, System.Drawing.FontStyle.Bold);
            this.btnTimeFromBitrateFileSize.Location = new System.Drawing.Point(191, 249);
            this.btnTimeFromBitrateFileSize.Name = "btnTimeFromBitrateFileSize";
            this.btnTimeFromBitrateFileSize.Size = new System.Drawing.Size(219, 24);
            this.btnTimeFromBitrateFileSize.TabIndex = 11;
            this.btnTimeFromBitrateFileSize.Text = "Bitrate and file size";
            this.btnTimeFromBitrateFileSize.UseVisualStyleBackColor = true;
            // 
            // AudioBitrateFromTimeSizeVideo
            // 
            this.AudioBitrateFromTimeSizeVideo.Font = new System.Drawing.Font("Unispace", 11F, System.Drawing.FontStyle.Bold);
            this.AudioBitrateFromTimeSizeVideo.Location = new System.Drawing.Point(456, 189);
            this.AudioBitrateFromTimeSizeVideo.Name = "AudioBitrateFromTimeSizeVideo";
            this.AudioBitrateFromTimeSizeVideo.Size = new System.Drawing.Size(257, 23);
            this.AudioBitrateFromTimeSizeVideo.TabIndex = 12;
            this.AudioBitrateFromTimeSizeVideo.Text = "Audio from time,size,video";
            this.AudioBitrateFromTimeSizeVideo.UseVisualStyleBackColor = true;
            this.AudioBitrateFromTimeSizeVideo.Click += new System.EventHandler(this.AudioBitrateFromTimeSizeVideo_Click);
            // 
            // btnOverhead
            // 
            this.btnOverhead.Font = new System.Drawing.Font("Unispace", 11F, System.Drawing.FontStyle.Bold);
            this.btnOverhead.Location = new System.Drawing.Point(191, 218);
            this.btnOverhead.Name = "btnOverhead";
            this.btnOverhead.Size = new System.Drawing.Size(336, 25);
            this.btnOverhead.TabIndex = 13;
            this.btnOverhead.Text = "Overhead from time,size,video,audio";
            this.btnOverhead.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Unispace", 11F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(105, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 18);
            this.label1.TabIndex = 14;
            this.label1.Text = "Seconds:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Unispace", 11F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(49, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 18);
            this.label2.TabIndex = 15;
            this.label2.Text = "Video bitrate:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Unispace", 11F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(50, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 18);
            this.label3.TabIndex = 16;
            this.label3.Text = "Total bitrate:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Unispace", 11F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(374, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(134, 18);
            this.label4.TabIndex = 17;
            this.label4.Text = "Audio bitrate:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Unispace", 11F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(419, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 18);
            this.label5.TabIndex = 18;
            this.label5.Text = "HH:MM:SS:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Unispace", 11F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(94, 160);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 18);
            this.label6.TabIndex = 19;
            this.label6.Text = "Overhead:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Unispace", 11F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(383, 158);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(125, 18);
            this.label7.TabIndex = 20;
            this.label7.Text = "Audio tracks:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Unispace", 11F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.SteelBlue;
            this.label8.Location = new System.Drawing.Point(24, 191);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(161, 18);
            this.label8.TabIndex = 21;
            this.label8.Text = "Compute bitrates:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Unispace", 11F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.SteelBlue;
            this.label9.Location = new System.Drawing.Point(50, 252);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(134, 18);
            this.label9.TabIndex = 22;
            this.label9.Text = "Get time from:";
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Unispace", 11F, System.Drawing.FontStyle.Bold);
            this.button5.Location = new System.Drawing.Point(541, 155);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(21, 21);
            this.button5.TabIndex = 23;
            this.button5.Text = "+";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Unispace", 11F, System.Drawing.FontStyle.Bold);
            this.label10.Location = new System.Drawing.Point(579, 131);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(44, 18);
            this.label10.TabIndex = 24;
            this.label10.Text = "kbps";
            // 
            // button6
            // 
            this.button6.Font = new System.Drawing.Font("Unispace", 11F, System.Drawing.FontStyle.Bold);
            this.button6.Location = new System.Drawing.Point(568, 155);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(24, 21);
            this.button6.TabIndex = 25;
            this.button6.Text = "-";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Unispace", 11F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))));
            this.label11.Location = new System.Drawing.Point(12, 49);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(476, 18);
            this.label11.TabIndex = 26;
            this.label11.Text = "Calculate bitrates from total file size and duration";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Unispace", 11F, System.Drawing.FontStyle.Bold);
            this.label12.Location = new System.Drawing.Point(605, 81);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(17, 18);
            this.label12.TabIndex = 27;
            this.label12.Text = ":";
            this.label12.Click += new System.EventHandler(this.label12_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Unispace", 11F, System.Drawing.FontStyle.Bold);
            this.label13.Location = new System.Drawing.Point(548, 80);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(17, 18);
            this.label13.TabIndex = 28;
            this.label13.Text = ":";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Unispace", 11F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))));
            this.label14.Location = new System.Drawing.Point(7, 282);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(476, 18);
            this.label14.TabIndex = 29;
            this.label14.Text = "Calculate total file size from bitrates and duration";
            this.label14.Click += new System.EventHandler(this.label14_Click);
            // 
            // BytesSum
            // 
            this.BytesSum.Font = new System.Drawing.Font("Unispace", 11F, System.Drawing.FontStyle.Bold);
            this.BytesSum.Location = new System.Drawing.Point(191, 306);
            this.BytesSum.Name = "BytesSum";
            this.BytesSum.Size = new System.Drawing.Size(133, 25);
            this.BytesSum.TabIndex = 30;
            this.BytesSum.Tag = "";
            this.BytesSum.Text = "0";
            // 
            // kiloBytesSum
            // 
            this.kiloBytesSum.Font = new System.Drawing.Font("Unispace", 11F, System.Drawing.FontStyle.Bold);
            this.kiloBytesSum.Location = new System.Drawing.Point(191, 333);
            this.kiloBytesSum.Name = "kiloBytesSum";
            this.kiloBytesSum.Size = new System.Drawing.Size(133, 25);
            this.kiloBytesSum.TabIndex = 32;
            this.kiloBytesSum.Tag = "";
            this.kiloBytesSum.Text = "0";
            // 
            // bitsSum
            // 
            this.bitsSum.Font = new System.Drawing.Font("Unispace", 11F, System.Drawing.FontStyle.Bold);
            this.bitsSum.Location = new System.Drawing.Point(484, 306);
            this.bitsSum.Name = "bitsSum";
            this.bitsSum.Size = new System.Drawing.Size(133, 25);
            this.bitsSum.TabIndex = 33;
            this.bitsSum.Tag = "";
            this.bitsSum.Text = "0";
            // 
            // kibiBytesSum
            // 
            this.kibiBytesSum.Font = new System.Drawing.Font("Unispace", 11F, System.Drawing.FontStyle.Bold);
            this.kibiBytesSum.Location = new System.Drawing.Point(484, 333);
            this.kibiBytesSum.Name = "kibiBytesSum";
            this.kibiBytesSum.Size = new System.Drawing.Size(133, 25);
            this.kibiBytesSum.TabIndex = 34;
            this.kibiBytesSum.Tag = "";
            this.kibiBytesSum.Text = "0";
            // 
            // mebiBytesSum
            // 
            this.mebiBytesSum.Font = new System.Drawing.Font("Unispace", 11F, System.Drawing.FontStyle.Bold);
            this.mebiBytesSum.Location = new System.Drawing.Point(484, 359);
            this.mebiBytesSum.Name = "mebiBytesSum";
            this.mebiBytesSum.Size = new System.Drawing.Size(133, 25);
            this.mebiBytesSum.TabIndex = 35;
            this.mebiBytesSum.Tag = "";
            this.mebiBytesSum.Text = "0";
            // 
            // megaBytesSum
            // 
            this.megaBytesSum.Font = new System.Drawing.Font("Unispace", 11F, System.Drawing.FontStyle.Bold);
            this.megaBytesSum.Location = new System.Drawing.Point(191, 359);
            this.megaBytesSum.Name = "megaBytesSum";
            this.megaBytesSum.Size = new System.Drawing.Size(133, 25);
            this.megaBytesSum.TabIndex = 36;
            this.megaBytesSum.Tag = "";
            this.megaBytesSum.Text = "0";
            // 
            // gibiBytesSum
            // 
            this.gibiBytesSum.Font = new System.Drawing.Font("Unispace", 11F, System.Drawing.FontStyle.Bold);
            this.gibiBytesSum.Location = new System.Drawing.Point(484, 385);
            this.gibiBytesSum.Name = "gibiBytesSum";
            this.gibiBytesSum.Size = new System.Drawing.Size(133, 25);
            this.gibiBytesSum.TabIndex = 37;
            this.gibiBytesSum.Tag = "";
            this.gibiBytesSum.Text = "0";
            // 
            // gigaBytesSum
            // 
            this.gigaBytesSum.Font = new System.Drawing.Font("Unispace", 11F, System.Drawing.FontStyle.Bold);
            this.gigaBytesSum.Location = new System.Drawing.Point(191, 385);
            this.gigaBytesSum.Name = "gigaBytesSum";
            this.gigaBytesSum.Size = new System.Drawing.Size(133, 25);
            this.gigaBytesSum.TabIndex = 38;
            this.gigaBytesSum.Tag = "";
            this.gigaBytesSum.Text = "0";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Unispace", 11F, System.Drawing.FontStyle.Bold);
            this.label15.Location = new System.Drawing.Point(429, 309);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(53, 18);
            this.label15.TabIndex = 39;
            this.label15.Text = "bits:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Unispace", 11F, System.Drawing.FontStyle.Bold);
            this.label16.Location = new System.Drawing.Point(43, 388);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(143, 18);
            this.label16.TabIndex = 40;
            this.label16.Text = "gigaBytes (GB):";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Unispace", 11F, System.Drawing.FontStyle.Bold);
            this.label17.Location = new System.Drawing.Point(43, 359);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(143, 18);
            this.label17.TabIndex = 41;
            this.label17.Text = "megaBytes (MB):";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Unispace", 11F, System.Drawing.FontStyle.Bold);
            this.label18.Location = new System.Drawing.Point(43, 333);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(143, 18);
            this.label18.TabIndex = 42;
            this.label18.Text = "kiloBytes (kB):";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Unispace", 11F, System.Drawing.FontStyle.Bold);
            this.label19.Location = new System.Drawing.Point(330, 336);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(152, 18);
            this.label19.TabIndex = 43;
            this.label19.Text = "kibiBytes (KiB):\t";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Unispace", 11F, System.Drawing.FontStyle.Bold);
            this.label20.Location = new System.Drawing.Point(124, 309);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(62, 18);
            this.label20.TabIndex = 44;
            this.label20.Text = "Bytes:";
            this.label20.Click += new System.EventHandler(this.label20_Click);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Unispace", 11F, System.Drawing.FontStyle.Bold);
            this.label21.Location = new System.Drawing.Point(330, 362);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(152, 18);
            this.label21.TabIndex = 45;
            this.label21.Text = "mebiBytes (MiB):";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Unispace", 11F, System.Drawing.FontStyle.Bold);
            this.label22.Location = new System.Drawing.Point(330, 388);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(152, 18);
            this.label22.TabIndex = 46;
            this.label22.Text = "gibiBytes (GiB):";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Unispace", 11F, System.Drawing.FontStyle.Bold);
            this.label23.ForeColor = System.Drawing.Color.SteelBlue;
            this.label23.Location = new System.Drawing.Point(7, 429);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(179, 18);
            this.label23.TabIndex = 48;
            this.label23.Text = "Get file size from:";
            // 
            // btnH264baseline
            // 
            this.btnH264baseline.Font = new System.Drawing.Font("Unispace", 11F, System.Drawing.FontStyle.Bold);
            this.btnH264baseline.Location = new System.Drawing.Point(298, 575);
            this.btnH264baseline.Name = "btnH264baseline";
            this.btnH264baseline.Size = new System.Drawing.Size(142, 28);
            this.btnH264baseline.TabIndex = 49;
            this.btnH264baseline.Text = "H.264 baseline";
            this.btnH264baseline.UseVisualStyleBackColor = true;
            // 
            // btnVideoSize
            // 
            this.btnVideoSize.Font = new System.Drawing.Font("Unispace", 11F, System.Drawing.FontStyle.Bold);
            this.btnVideoSize.Location = new System.Drawing.Point(371, 427);
            this.btnVideoSize.Name = "btnVideoSize";
            this.btnVideoSize.Size = new System.Drawing.Size(160, 24);
            this.btnVideoSize.TabIndex = 50;
            this.btnVideoSize.Text = "Video size only";
            this.btnVideoSize.UseVisualStyleBackColor = true;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Unispace", 11F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))));
            this.label24.Location = new System.Drawing.Point(12, 467);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(755, 18);
            this.label24.TabIndex = 51;
            this.label24.Text = "Suggest a good quality video bitrate from frame dimensions, codec, and content ty" +
    "pe";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Unispace", 11F, System.Drawing.FontStyle.Bold);
            this.label25.Location = new System.Drawing.Point(51, 553);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(134, 18);
            this.label25.TabIndex = 52;
            this.label25.Text = "Video content:";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Unispace", 11F, System.Drawing.FontStyle.Bold);
            this.label26.Location = new System.Drawing.Point(330, 494);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(26, 18);
            this.label26.TabIndex = 53;
            this.label26.Text = "px";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Unispace", 11F, System.Drawing.FontStyle.Bold);
            this.label27.Location = new System.Drawing.Point(59, 526);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(125, 18);
            this.label27.TabIndex = 54;
            this.label27.Text = "Aspect ratio:";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Unispace", 11F, System.Drawing.FontStyle.Bold);
            this.label28.Location = new System.Drawing.Point(394, 521);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(107, 18);
            this.label28.TabIndex = 55;
            this.label28.Text = "Bits/pixel:";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Unispace", 11F, System.Drawing.FontStyle.Bold);
            this.label29.Location = new System.Drawing.Point(24, 495);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(161, 18);
            this.label29.TabIndex = 56;
            this.label29.Text = "Dimensions (W×H):";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("Unispace", 11F, System.Drawing.FontStyle.Bold);
            this.label32.ForeColor = System.Drawing.Color.SteelBlue;
            this.label32.Location = new System.Drawing.Point(-3, 580);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(188, 18);
            this.label32.TabIndex = 59;
            this.label32.Text = "Suggest bitrate for:";
            // 
            // btnH265Main
            // 
            this.btnH265Main.Font = new System.Drawing.Font("Unispace", 11F, System.Drawing.FontStyle.Bold);
            this.btnH265Main.Location = new System.Drawing.Point(564, 575);
            this.btnH265Main.Name = "btnH265Main";
            this.btnH265Main.Size = new System.Drawing.Size(111, 28);
            this.btnH265Main.TabIndex = 61;
            this.btnH265Main.Text = "H.265 main";
            this.btnH265Main.UseVisualStyleBackColor = true;
            // 
            // btnMP4
            // 
            this.btnMP4.Font = new System.Drawing.Font("Unispace", 11F, System.Drawing.FontStyle.Bold);
            this.btnMP4.Location = new System.Drawing.Point(240, 575);
            this.btnMP4.Name = "btnMP4";
            this.btnMP4.Size = new System.Drawing.Size(49, 28);
            this.btnMP4.TabIndex = 63;
            this.btnMP4.Text = "MP4";
            this.btnMP4.UseVisualStyleBackColor = true;
            // 
            // btnRaw
            // 
            this.btnRaw.Font = new System.Drawing.Font("Unispace", 11F, System.Drawing.FontStyle.Bold);
            this.btnRaw.Location = new System.Drawing.Point(190, 575);
            this.btnRaw.Name = "btnRaw";
            this.btnRaw.Size = new System.Drawing.Size(44, 28);
            this.btnRaw.TabIndex = 64;
            this.btnRaw.Text = "Raw";
            this.btnRaw.UseVisualStyleBackColor = true;
            // 
            // btnH264high
            // 
            this.btnH264high.Font = new System.Drawing.Font("Unispace", 11F, System.Drawing.FontStyle.Bold);
            this.btnH264high.Location = new System.Drawing.Point(446, 575);
            this.btnH264high.Name = "btnH264high";
            this.btnH264high.Size = new System.Drawing.Size(113, 28);
            this.btnH264high.TabIndex = 65;
            this.btnH264high.Text = "H.264 high";
            this.btnH264high.UseVisualStyleBackColor = true;
            // 
            // txtAspectRatio
            // 
            this.txtAspectRatio.Font = new System.Drawing.Font("Unispace", 11F, System.Drawing.FontStyle.Bold);
            this.txtAspectRatio.Location = new System.Drawing.Point(190, 524);
            this.txtAspectRatio.Name = "txtAspectRatio";
            this.txtAspectRatio.Size = new System.Drawing.Size(64, 25);
            this.txtAspectRatio.TabIndex = 66;
            this.txtAspectRatio.Tag = "";
            this.txtAspectRatio.Text = "0";
            // 
            // txtWidth
            // 
            this.txtWidth.Font = new System.Drawing.Font("Unispace", 11F, System.Drawing.FontStyle.Bold);
            this.txtWidth.Location = new System.Drawing.Point(190, 494);
            this.txtWidth.Multiline = true;
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size(53, 25);
            this.txtWidth.TabIndex = 67;
            this.txtWidth.Tag = "";
            this.txtWidth.Text = "0";
            this.txtWidth.TextChanged += new System.EventHandler(this.txtWidth_TextChanged);
            // 
            // textBitPixel
            // 
            this.textBitPixel.Font = new System.Drawing.Font("Unispace", 11F, System.Drawing.FontStyle.Bold);
            this.textBitPixel.Location = new System.Drawing.Point(508, 518);
            this.textBitPixel.Name = "textBitPixel";
            this.textBitPixel.Size = new System.Drawing.Size(99, 25);
            this.textBitPixel.TabIndex = 68;
            this.textBitPixel.Tag = "";
            this.textBitPixel.Text = "0";
            // 
            // txtHeight
            // 
            this.txtHeight.Font = new System.Drawing.Font("Unispace", 11F, System.Drawing.FontStyle.Bold);
            this.txtHeight.Location = new System.Drawing.Point(272, 494);
            this.txtHeight.Multiline = true;
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(52, 25);
            this.txtHeight.TabIndex = 69;
            this.txtHeight.Tag = "";
            this.txtHeight.Text = "0";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Font = new System.Drawing.Font("Unispace", 11F, System.Drawing.FontStyle.Bold);
            this.label33.Location = new System.Drawing.Point(249, 498);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(17, 18);
            this.label33.TabIndex = 71;
            this.label33.Text = "X";
            // 
            // checkBoxCGI
            // 
            this.checkBoxCGI.AutoSize = true;
            this.checkBoxCGI.Font = new System.Drawing.Font("Unispace", 11F, System.Drawing.FontStyle.Bold);
            this.checkBoxCGI.Location = new System.Drawing.Point(191, 553);
            this.checkBoxCGI.Name = "checkBoxCGI";
            this.checkBoxCGI.Size = new System.Drawing.Size(135, 22);
            this.checkBoxCGI.TabIndex = 73;
            this.checkBoxCGI.Text = "(Mostly) CGI";
            this.checkBoxCGI.UseVisualStyleBackColor = true;
            // 
            // checkBoxNoisyimageTreesBushes
            // 
            this.checkBoxNoisyimageTreesBushes.AutoSize = true;
            this.checkBoxNoisyimageTreesBushes.Font = new System.Drawing.Font("Unispace", 11F, System.Drawing.FontStyle.Bold);
            this.checkBoxNoisyimageTreesBushes.Location = new System.Drawing.Point(578, 554);
            this.checkBoxNoisyimageTreesBushes.Name = "checkBoxNoisyimageTreesBushes";
            this.checkBoxNoisyimageTreesBushes.Size = new System.Drawing.Size(243, 22);
            this.checkBoxNoisyimageTreesBushes.TabIndex = 74;
            this.checkBoxNoisyimageTreesBushes.Text = "Noisy image/Trees/Bushes";
            this.checkBoxNoisyimageTreesBushes.UseVisualStyleBackColor = true;
            // 
            // checkBoxDarkScenesStillimages
            // 
            this.checkBoxDarkScenesStillimages.AutoSize = true;
            this.checkBoxDarkScenesStillimages.Font = new System.Drawing.Font("Unispace", 11F, System.Drawing.FontStyle.Bold);
            this.checkBoxDarkScenesStillimages.Location = new System.Drawing.Point(322, 552);
            this.checkBoxDarkScenesStillimages.Name = "checkBoxDarkScenesStillimages";
            this.checkBoxDarkScenesStillimages.Size = new System.Drawing.Size(243, 22);
            this.checkBoxDarkScenesStillimages.TabIndex = 75;
            this.checkBoxDarkScenesStillimages.Text = "Dark scenes/Still images";
            this.checkBoxDarkScenesStillimages.UseVisualStyleBackColor = true;
            // 
            // btnAudioSize
            // 
            this.btnAudioSize.Font = new System.Drawing.Font("Unispace", 11F, System.Drawing.FontStyle.Bold);
            this.btnAudioSize.Location = new System.Drawing.Point(537, 427);
            this.btnAudioSize.Name = "btnAudioSize";
            this.btnAudioSize.Size = new System.Drawing.Size(152, 24);
            this.btnAudioSize.TabIndex = 76;
            this.btnAudioSize.Text = "Audio size only";
            this.btnAudioSize.UseVisualStyleBackColor = true;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Font = new System.Drawing.Font("Unispace", 11F, System.Drawing.FontStyle.Bold);
            this.label34.Location = new System.Drawing.Point(319, 165);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(44, 18);
            this.label34.TabIndex = 77;
            this.label34.Text = "kbps";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Font = new System.Drawing.Font("Unispace", 11F, System.Drawing.FontStyle.Bold);
            this.label35.Location = new System.Drawing.Point(319, 138);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(44, 18);
            this.label35.TabIndex = 78;
            this.label35.Text = "kbps";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Font = new System.Drawing.Font("Unispace", 11F, System.Drawing.FontStyle.Bold);
            this.label36.Location = new System.Drawing.Point(319, 115);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(44, 18);
            this.label36.TabIndex = 79;
            this.label36.Text = "kbps";
            // 
            // btnFPSselect
            // 
            this.btnFPSselect.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnFPSselect.Font = new System.Drawing.Font("Unispace", 11F, System.Drawing.FontStyle.Bold);
            this.btnFPSselect.Location = new System.Drawing.Point(633, 491);
            this.btnFPSselect.Name = "btnFPSselect";
            this.btnFPSselect.Size = new System.Drawing.Size(27, 23);
            this.btnFPSselect.TabIndex = 81;
            this.btnFPSselect.Text = "▼";
            this.btnFPSselect.UseVisualStyleBackColor = true;
            this.btnFPSselect.Click += new System.EventHandler(this.btnFPSselect_Click);
            // 
            // txtFrameRate
            // 
            this.txtFrameRate.Font = new System.Drawing.Font("Unispace", 11F, System.Drawing.FontStyle.Bold);
            this.txtFrameRate.Location = new System.Drawing.Point(508, 491);
            this.txtFrameRate.Name = "txtFrameRate";
            this.txtFrameRate.Size = new System.Drawing.Size(69, 25);
            this.txtFrameRate.TabIndex = 82;
            this.txtFrameRate.Text = "0";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Unispace", 11F, System.Drawing.FontStyle.Bold);
            this.label31.Location = new System.Drawing.Point(583, 494);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(44, 18);
            this.label31.TabIndex = 83;
            this.label31.Text = "FPS:";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Font = new System.Drawing.Font("Unispace", 11F, System.Drawing.FontStyle.Bold);
            this.label37.Location = new System.Drawing.Point(395, 494);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(107, 18);
            this.label37.TabIndex = 84;
            this.label37.Text = "Frame rate:";
            // 
            // SizeFromTimeAndBitrate
            // 
            this.SizeFromTimeAndBitrate.Font = new System.Drawing.Font("Unispace", 11F, System.Drawing.FontStyle.Bold);
            this.SizeFromTimeAndBitrate.Location = new System.Drawing.Point(192, 427);
            this.SizeFromTimeAndBitrate.Name = "SizeFromTimeAndBitrate";
            this.SizeFromTimeAndBitrate.Size = new System.Drawing.Size(173, 23);
            this.SizeFromTimeAndBitrate.TabIndex = 85;
            this.SizeFromTimeAndBitrate.Text = "Time and bitrate";
            this.SizeFromTimeAndBitrate.UseVisualStyleBackColor = true;
            // 
            // btnPixelSelect
            // 
            this.btnPixelSelect.Font = new System.Drawing.Font("Unispace", 11F, System.Drawing.FontStyle.Bold);
            this.btnPixelSelect.Location = new System.Drawing.Point(357, 493);
            this.btnPixelSelect.Name = "btnPixelSelect";
            this.btnPixelSelect.Size = new System.Drawing.Size(24, 21);
            this.btnPixelSelect.TabIndex = 86;
            this.btnPixelSelect.Text = "▼";
            this.btnPixelSelect.UseVisualStyleBackColor = true;
            this.btnPixelSelect.Click += new System.EventHandler(this.btnPixelSelect_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(11, 12);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(75, 23);
            this.btnHelp.TabIndex = 87;
            this.btnHelp.Text = "Help";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // linkVideoBitrateCalculator
            // 
            this.linkVideoBitrateCalculator.AutoSize = true;
            this.linkVideoBitrateCalculator.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkVideoBitrateCalculator.Location = new System.Drawing.Point(92, 12);
            this.linkVideoBitrateCalculator.Name = "linkVideoBitrateCalculator";
            this.linkVideoBitrateCalculator.Size = new System.Drawing.Size(119, 20);
            this.linkVideoBitrateCalculator.TabIndex = 88;
            this.linkVideoBitrateCalculator.TabStop = true;
            this.linkVideoBitrateCalculator.Text = "www.dr-lex.be";
            this.linkVideoBitrateCalculator.Click += new System.EventHandler(this.linkVideoBitrateCalculator_LinkClicked);
            // 
            // MainForm
            // 
            this.AccessibleDescription = "";
            this.AccessibleName = "";
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(838, 609);
            this.Controls.Add(this.linkVideoBitrateCalculator);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnPixelSelect);
            this.Controls.Add(this.SizeFromTimeAndBitrate);
            this.Controls.Add(this.label37);
            this.Controls.Add(this.label31);
            this.Controls.Add(this.txtFrameRate);
            this.Controls.Add(this.btnFPSselect);
            this.Controls.Add(this.label36);
            this.Controls.Add(this.label35);
            this.Controls.Add(this.label34);
            this.Controls.Add(this.btnAudioSize);
            this.Controls.Add(this.checkBoxDarkScenesStillimages);
            this.Controls.Add(this.checkBoxNoisyimageTreesBushes);
            this.Controls.Add(this.checkBoxCGI);
            this.Controls.Add(this.label33);
            this.Controls.Add(this.txtHeight);
            this.Controls.Add(this.textBitPixel);
            this.Controls.Add(this.txtWidth);
            this.Controls.Add(this.txtAspectRatio);
            this.Controls.Add(this.btnH264high);
            this.Controls.Add(this.btnRaw);
            this.Controls.Add(this.btnMP4);
            this.Controls.Add(this.btnH265Main);
            this.Controls.Add(this.label32);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.btnVideoSize);
            this.Controls.Add(this.btnH264baseline);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.gigaBytesSum);
            this.Controls.Add(this.gibiBytesSum);
            this.Controls.Add(this.megaBytesSum);
            this.Controls.Add(this.mebiBytesSum);
            this.Controls.Add(this.kibiBytesSum);
            this.Controls.Add(this.bitsSum);
            this.Controls.Add(this.kiloBytesSum);
            this.Controls.Add(this.BytesSum);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOverhead);
            this.Controls.Add(this.AudioBitrateFromTimeSizeVideo);
            this.Controls.Add(this.btnTimeFromBitrateFileSize);
            this.Controls.Add(this.VideoBitrateFromTimeSizeAudio);
            this.Controls.Add(this.txtTrackNumber);
            this.Controls.Add(this.txtAudiobitrate);
            this.Controls.Add(this.txtSeconds);
            this.Controls.Add(this.txtMinutes);
            this.Controls.Add(this.txtHours);
            this.Controls.Add(this.txtTotalbitrate);
            this.Controls.Add(this.txtVideobitrate);
            this.Controls.Add(this.txtOverhead);
            this.Controls.Add(this.txtTotalSeconds);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(854, 648);
            this.MinimumSize = new System.Drawing.Size(308, 50);
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Video Bitrate Calculator - Credit To - Dr. Lex";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtTotalSeconds;
        private System.Windows.Forms.TextBox txtOverhead;
        private System.Windows.Forms.TextBox txtVideobitrate;
        private System.Windows.Forms.TextBox txtTotalbitrate;
        private System.Windows.Forms.TextBox txtHours;
        private System.Windows.Forms.TextBox txtMinutes;
        private System.Windows.Forms.TextBox txtSeconds;
        private System.Windows.Forms.TextBox txtAudiobitrate;
        private System.Windows.Forms.TextBox txtTrackNumber;
        private System.Windows.Forms.Button VideoBitrateFromTimeSizeAudio;
        private System.Windows.Forms.Button btnTimeFromBitrateFileSize;
        private System.Windows.Forms.Button AudioBitrateFromTimeSizeVideo;
        private System.Windows.Forms.Button btnOverhead;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox BytesSum;
        private System.Windows.Forms.TextBox kiloBytesSum;
        private System.Windows.Forms.TextBox bitsSum;
        private System.Windows.Forms.TextBox kibiBytesSum;
        private System.Windows.Forms.TextBox mebiBytesSum;
        private System.Windows.Forms.TextBox megaBytesSum;
        private System.Windows.Forms.TextBox gibiBytesSum;
        private System.Windows.Forms.TextBox gigaBytesSum;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Button btnH264baseline;
        private System.Windows.Forms.Button btnVideoSize;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Button btnH265Main;
        private System.Windows.Forms.Button btnMP4;
        private System.Windows.Forms.Button btnRaw;
        private System.Windows.Forms.Button btnH264high;
        private System.Windows.Forms.TextBox txtAspectRatio;
        private System.Windows.Forms.TextBox txtWidth;
        private System.Windows.Forms.TextBox textBitPixel;
        private System.Windows.Forms.TextBox txtHeight;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.CheckBox checkBoxCGI;
        private System.Windows.Forms.CheckBox checkBoxNoisyimageTreesBushes;
        private System.Windows.Forms.CheckBox checkBoxDarkScenesStillimages;
        private System.Windows.Forms.Button btnAudioSize;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Button btnFPSselect;
        private System.Windows.Forms.TextBox txtFrameRate;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Button SizeFromTimeAndBitrate;
        private System.Windows.Forms.Button btnPixelSelect;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.LinkLabel linkVideoBitrateCalculator;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

