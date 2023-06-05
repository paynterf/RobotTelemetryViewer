namespace RobotTelemetryViewer
{
    partial class frm_Main
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_TotFrames = new System.Windows.Forms.Label();
            this.lbl = new System.Windows.Forms.Label();
            this.lbl_TotSec = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.gBox1 = new System.Windows.Forms.GroupBox();
            this.tBar_FrameSelect = new System.Windows.Forms.TrackBar();
            this.label23 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lbl_Data_1 = new System.Windows.Forms.Label();
            this.tb_Idx = new System.Windows.Forms.TextBox();
            this.tb_Sec = new System.Windows.Forms.TextBox();
            this.tb_Rdist = new System.Windows.Forms.TextBox();
            this.tb_Ldist = new System.Windows.Forms.TextBox();
            this.lbl_String_1 = new System.Windows.Forms.Label();
            this.tb_String_1 = new System.Windows.Forms.TextBox();
            this.tb_String_2 = new System.Windows.Forms.TextBox();
            this.lbl_String_2 = new System.Windows.Forms.Label();
            this.tb_String_4 = new System.Windows.Forms.TextBox();
            this.lbl_String_4 = new System.Windows.Forms.Label();
            this.tb_String_3 = new System.Windows.Forms.TextBox();
            this.lbl_String_3 = new System.Windows.Forms.Label();
            this.tb_Data_8 = new System.Windows.Forms.TextBox();
            this.tb_Data_7 = new System.Windows.Forms.TextBox();
            this.tb_Data_6 = new System.Windows.Forms.TextBox();
            this.tb_Data_5 = new System.Windows.Forms.TextBox();
            this.tb_Data_2 = new System.Windows.Forms.TextBox();
            this.tb_Data_1 = new System.Windows.Forms.TextBox();
            this.tb_Data_4 = new System.Windows.Forms.TextBox();
            this.tb_Data_3 = new System.Windows.Forms.TextBox();
            this.tb_Hdgdeg = new System.Windows.Forms.TextBox();
            this.lbl_Data_8 = new System.Windows.Forms.Label();
            this.lbl_Data_6 = new System.Windows.Forms.Label();
            this.lbl_Data_4 = new System.Windows.Forms.Label();
            this.lbl_Data_7 = new System.Windows.Forms.Label();
            this.lbl_Data_2 = new System.Windows.Forms.Label();
            this.lbl_Data_5 = new System.Windows.Forms.Label();
            this.label_0 = new System.Windows.Forms.Label();
            this.lbl_Data_3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DataPanel = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.gBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tBar_FrameSelect)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.DataPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Window;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(843, 853);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.Resize += new System.EventHandler(this.pictureBox1_Resize);
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Dock = System.Windows.Forms.DockStyle.Right;
            this.vScrollBar1.Location = new System.Drawing.Point(846, 0);
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(24, 853);
            this.vScrollBar1.TabIndex = 1;
            this.vScrollBar1.ValueChanged += new System.EventHandler(this.vScrollBar1_ValueChanged);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel1.Controls.Add(this.vScrollBar1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(870, 853);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Total Frames";
            // 
            // lbl_TotFrames
            // 
            this.lbl_TotFrames.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl_TotFrames.AutoSize = true;
            this.lbl_TotFrames.Location = new System.Drawing.Point(108, 23);
            this.lbl_TotFrames.Name = "lbl_TotFrames";
            this.lbl_TotFrames.Size = new System.Drawing.Size(94, 16);
            this.lbl_TotFrames.TabIndex = 1;
            this.lbl_TotFrames.Text = "lbl_TotFrames";
            // 
            // lbl
            // 
            this.lbl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl.AutoSize = true;
            this.lbl.Location = new System.Drawing.Point(1, 45);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(65, 16);
            this.lbl.TabIndex = 1;
            this.lbl.Text = "Total Sec";
            // 
            // lbl_TotSec
            // 
            this.lbl_TotSec.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl_TotSec.AutoSize = true;
            this.lbl_TotSec.Location = new System.Drawing.Point(108, 45);
            this.lbl_TotSec.Name = "lbl_TotSec";
            this.lbl_TotSec.Size = new System.Drawing.Size(72, 16);
            this.lbl_TotSec.TabIndex = 1;
            this.lbl_TotSec.Text = "lbl_TotSec";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 16);
            this.label5.TabIndex = 1;
            this.label5.Text = "Right Side";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 16);
            this.label6.TabIndex = 1;
            this.label6.Text = "Left Side";
            // 
            // gBox1
            // 
            this.gBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gBox1.Controls.Add(this.lbl);
            this.gBox1.Controls.Add(this.label1);
            this.gBox1.Controls.Add(this.lbl_TotSec);
            this.gBox1.Controls.Add(this.lbl_TotFrames);
            this.gBox1.Location = new System.Drawing.Point(930, 107);
            this.gBox1.Name = "gBox1";
            this.gBox1.Size = new System.Drawing.Size(180, 81);
            this.gBox1.TabIndex = 2;
            this.gBox1.TabStop = false;
            this.gBox1.Text = "Stats";
            // 
            // tBar_FrameSelect
            // 
            this.tBar_FrameSelect.Location = new System.Drawing.Point(15, 30);
            this.tBar_FrameSelect.Name = "tBar_FrameSelect";
            this.tBar_FrameSelect.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tBar_FrameSelect.Size = new System.Drawing.Size(56, 390);
            this.tBar_FrameSelect.TabIndex = 3;
            this.tBar_FrameSelect.ValueChanged += new System.EventHandler(this.tBar_FrameSelect_ValueChanged);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(164, 51);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(24, 16);
            this.label23.TabIndex = 0;
            this.label23.Text = "Idx";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(159, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Sec";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(155, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Ldist";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(152, 141);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 16);
            this.label7.TabIndex = 6;
            this.label7.Text = "Rdist";
            // 
            // lbl_Data_1
            // 
            this.lbl_Data_1.AutoSize = true;
            this.lbl_Data_1.Location = new System.Drawing.Point(140, 201);
            this.lbl_Data_1.Name = "lbl_Data_1";
            this.lbl_Data_1.Size = new System.Drawing.Size(50, 16);
            this.lbl_Data_1.TabIndex = 10;
            this.lbl_Data_1.Text = "Data_1";
            this.lbl_Data_1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tb_Idx
            // 
            this.tb_Idx.Location = new System.Drawing.Point(194, 48);
            this.tb_Idx.Name = "tb_Idx";
            this.tb_Idx.Size = new System.Drawing.Size(47, 22);
            this.tb_Idx.TabIndex = 1;
            // 
            // tb_Sec
            // 
            this.tb_Sec.Location = new System.Drawing.Point(194, 78);
            this.tb_Sec.Name = "tb_Sec";
            this.tb_Sec.Size = new System.Drawing.Size(47, 22);
            this.tb_Sec.TabIndex = 3;
            // 
            // tb_Rdist
            // 
            this.tb_Rdist.Location = new System.Drawing.Point(194, 138);
            this.tb_Rdist.Name = "tb_Rdist";
            this.tb_Rdist.Size = new System.Drawing.Size(47, 22);
            this.tb_Rdist.TabIndex = 7;
            // 
            // tb_Ldist
            // 
            this.tb_Ldist.Location = new System.Drawing.Point(194, 108);
            this.tb_Ldist.Name = "tb_Ldist";
            this.tb_Ldist.Size = new System.Drawing.Size(47, 22);
            this.tb_Ldist.TabIndex = 5;
            // 
            // lbl_String_1
            // 
            this.lbl_String_1.AutoSize = true;
            this.lbl_String_1.Location = new System.Drawing.Point(5, 435);
            this.lbl_String_1.Name = "lbl_String_1";
            this.lbl_String_1.Size = new System.Drawing.Size(55, 16);
            this.lbl_String_1.TabIndex = 4;
            this.lbl_String_1.Text = "String_1";
            // 
            // tb_String_1
            // 
            this.tb_String_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_String_1.Location = new System.Drawing.Point(5, 454);
            this.tb_String_1.Name = "tb_String_1";
            this.tb_String_1.Size = new System.Drawing.Size(241, 21);
            this.tb_String_1.TabIndex = 5;
            // 
            // tb_String_2
            // 
            this.tb_String_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_String_2.Location = new System.Drawing.Point(5, 500);
            this.tb_String_2.Name = "tb_String_2";
            this.tb_String_2.Size = new System.Drawing.Size(241, 21);
            this.tb_String_2.TabIndex = 13;
            // 
            // lbl_String_2
            // 
            this.lbl_String_2.AutoSize = true;
            this.lbl_String_2.Location = new System.Drawing.Point(5, 481);
            this.lbl_String_2.Name = "lbl_String_2";
            this.lbl_String_2.Size = new System.Drawing.Size(55, 16);
            this.lbl_String_2.TabIndex = 12;
            this.lbl_String_2.Text = "String_2";
            // 
            // tb_String_4
            // 
            this.tb_String_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_String_4.Location = new System.Drawing.Point(5, 592);
            this.tb_String_4.Name = "tb_String_4";
            this.tb_String_4.Size = new System.Drawing.Size(241, 21);
            this.tb_String_4.TabIndex = 9;
            // 
            // lbl_String_4
            // 
            this.lbl_String_4.AutoSize = true;
            this.lbl_String_4.Location = new System.Drawing.Point(5, 575);
            this.lbl_String_4.Name = "lbl_String_4";
            this.lbl_String_4.Size = new System.Drawing.Size(55, 16);
            this.lbl_String_4.TabIndex = 8;
            this.lbl_String_4.Text = "String_4";
            // 
            // tb_String_3
            // 
            this.tb_String_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_String_3.Location = new System.Drawing.Point(5, 546);
            this.tb_String_3.Name = "tb_String_3";
            this.tb_String_3.Size = new System.Drawing.Size(241, 21);
            this.tb_String_3.TabIndex = 7;
            // 
            // lbl_String_3
            // 
            this.lbl_String_3.AutoSize = true;
            this.lbl_String_3.Location = new System.Drawing.Point(5, 528);
            this.lbl_String_3.Name = "lbl_String_3";
            this.lbl_String_3.Size = new System.Drawing.Size(55, 16);
            this.lbl_String_3.TabIndex = 6;
            this.lbl_String_3.Text = "String_3";
            // 
            // tb_Data_8
            // 
            this.tb_Data_8.Location = new System.Drawing.Point(193, 408);
            this.tb_Data_8.Name = "tb_Data_8";
            this.tb_Data_8.Size = new System.Drawing.Size(47, 22);
            this.tb_Data_8.TabIndex = 21;
            // 
            // tb_Data_7
            // 
            this.tb_Data_7.Location = new System.Drawing.Point(193, 378);
            this.tb_Data_7.Name = "tb_Data_7";
            this.tb_Data_7.Size = new System.Drawing.Size(47, 22);
            this.tb_Data_7.TabIndex = 19;
            // 
            // tb_Data_6
            // 
            this.tb_Data_6.Location = new System.Drawing.Point(193, 348);
            this.tb_Data_6.Name = "tb_Data_6";
            this.tb_Data_6.Size = new System.Drawing.Size(47, 22);
            this.tb_Data_6.TabIndex = 21;
            // 
            // tb_Data_5
            // 
            this.tb_Data_5.Location = new System.Drawing.Point(193, 318);
            this.tb_Data_5.Name = "tb_Data_5";
            this.tb_Data_5.Size = new System.Drawing.Size(47, 22);
            this.tb_Data_5.TabIndex = 19;
            // 
            // tb_Data_2
            // 
            this.tb_Data_2.Location = new System.Drawing.Point(194, 228);
            this.tb_Data_2.Name = "tb_Data_2";
            this.tb_Data_2.Size = new System.Drawing.Size(47, 22);
            this.tb_Data_2.TabIndex = 13;
            // 
            // tb_Data_1
            // 
            this.tb_Data_1.Location = new System.Drawing.Point(194, 198);
            this.tb_Data_1.Name = "tb_Data_1";
            this.tb_Data_1.Size = new System.Drawing.Size(47, 22);
            this.tb_Data_1.TabIndex = 11;
            // 
            // tb_Data_4
            // 
            this.tb_Data_4.Location = new System.Drawing.Point(193, 288);
            this.tb_Data_4.Name = "tb_Data_4";
            this.tb_Data_4.Size = new System.Drawing.Size(47, 22);
            this.tb_Data_4.TabIndex = 17;
            // 
            // tb_Data_3
            // 
            this.tb_Data_3.Location = new System.Drawing.Point(193, 258);
            this.tb_Data_3.Name = "tb_Data_3";
            this.tb_Data_3.Size = new System.Drawing.Size(47, 22);
            this.tb_Data_3.TabIndex = 15;
            // 
            // tb_Hdgdeg
            // 
            this.tb_Hdgdeg.Location = new System.Drawing.Point(194, 168);
            this.tb_Hdgdeg.Name = "tb_Hdgdeg";
            this.tb_Hdgdeg.Size = new System.Drawing.Size(47, 22);
            this.tb_Hdgdeg.TabIndex = 9;
            // 
            // lbl_Data_8
            // 
            this.lbl_Data_8.AutoSize = true;
            this.lbl_Data_8.Location = new System.Drawing.Point(140, 411);
            this.lbl_Data_8.Name = "lbl_Data_8";
            this.lbl_Data_8.Size = new System.Drawing.Size(50, 16);
            this.lbl_Data_8.TabIndex = 20;
            this.lbl_Data_8.Text = "Data_8";
            // 
            // lbl_Data_6
            // 
            this.lbl_Data_6.AutoSize = true;
            this.lbl_Data_6.Location = new System.Drawing.Point(140, 351);
            this.lbl_Data_6.Name = "lbl_Data_6";
            this.lbl_Data_6.Size = new System.Drawing.Size(50, 16);
            this.lbl_Data_6.TabIndex = 20;
            this.lbl_Data_6.Text = "Data_6";
            // 
            // lbl_Data_4
            // 
            this.lbl_Data_4.AutoSize = true;
            this.lbl_Data_4.Location = new System.Drawing.Point(140, 291);
            this.lbl_Data_4.Name = "lbl_Data_4";
            this.lbl_Data_4.Size = new System.Drawing.Size(50, 16);
            this.lbl_Data_4.TabIndex = 16;
            this.lbl_Data_4.Text = "Data_4";
            // 
            // lbl_Data_7
            // 
            this.lbl_Data_7.AutoSize = true;
            this.lbl_Data_7.Location = new System.Drawing.Point(140, 381);
            this.lbl_Data_7.Name = "lbl_Data_7";
            this.lbl_Data_7.Size = new System.Drawing.Size(50, 16);
            this.lbl_Data_7.TabIndex = 18;
            this.lbl_Data_7.Text = "Data_7";
            // 
            // lbl_Data_2
            // 
            this.lbl_Data_2.AutoSize = true;
            this.lbl_Data_2.Location = new System.Drawing.Point(140, 231);
            this.lbl_Data_2.Name = "lbl_Data_2";
            this.lbl_Data_2.Size = new System.Drawing.Size(50, 16);
            this.lbl_Data_2.TabIndex = 12;
            this.lbl_Data_2.Text = "Data_2";
            // 
            // lbl_Data_5
            // 
            this.lbl_Data_5.AutoSize = true;
            this.lbl_Data_5.Location = new System.Drawing.Point(140, 321);
            this.lbl_Data_5.Name = "lbl_Data_5";
            this.lbl_Data_5.Size = new System.Drawing.Size(50, 16);
            this.lbl_Data_5.TabIndex = 18;
            this.lbl_Data_5.Text = "Data_5";
            // 
            // label_0
            // 
            this.label_0.AutoSize = true;
            this.label_0.Location = new System.Drawing.Point(157, 171);
            this.label_0.Name = "label_0";
            this.label_0.Size = new System.Drawing.Size(33, 16);
            this.label_0.TabIndex = 8;
            this.label_0.Text = "Hdg";
            // 
            // lbl_Data_3
            // 
            this.lbl_Data_3.AutoSize = true;
            this.lbl_Data_3.Location = new System.Drawing.Point(140, 261);
            this.lbl_Data_3.Name = "lbl_Data_3";
            this.lbl_Data_3.Size = new System.Drawing.Size(50, 16);
            this.lbl_Data_3.TabIndex = 14;
            this.lbl_Data_3.Text = "Data_3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "> Max Dist";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Green;
            this.label8.Location = new System.Drawing.Point(111, 17);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 16);
            this.label8.TabIndex = 1;
            this.label8.Text = "                 ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Blue;
            this.label9.Location = new System.Drawing.Point(111, 36);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 16);
            this.label9.TabIndex = 1;
            this.label9.Text = "                 ";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.SlateGray;
            this.label10.Location = new System.Drawing.Point(111, 55);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(58, 16);
            this.label10.TabIndex = 1;
            this.label10.Text = "                 ";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Location = new System.Drawing.Point(929, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(180, 81);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Legend";
            // 
            // DataPanel
            // 
            this.DataPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.DataPanel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.DataPanel.Controls.Add(this.tb_String_2);
            this.DataPanel.Controls.Add(this.tBar_FrameSelect);
            this.DataPanel.Controls.Add(this.lbl_String_2);
            this.DataPanel.Controls.Add(this.label23);
            this.DataPanel.Controls.Add(this.tb_String_4);
            this.DataPanel.Controls.Add(this.label3);
            this.DataPanel.Controls.Add(this.lbl_String_4);
            this.DataPanel.Controls.Add(this.label4);
            this.DataPanel.Controls.Add(this.tb_String_3);
            this.DataPanel.Controls.Add(this.label7);
            this.DataPanel.Controls.Add(this.lbl_String_3);
            this.DataPanel.Controls.Add(this.lbl_Data_1);
            this.DataPanel.Controls.Add(this.tb_String_1);
            this.DataPanel.Controls.Add(this.lbl_Data_3);
            this.DataPanel.Controls.Add(this.tb_Data_8);
            this.DataPanel.Controls.Add(this.label_0);
            this.DataPanel.Controls.Add(this.tb_Data_7);
            this.DataPanel.Controls.Add(this.lbl_Data_5);
            this.DataPanel.Controls.Add(this.tb_Data_6);
            this.DataPanel.Controls.Add(this.lbl_Data_2);
            this.DataPanel.Controls.Add(this.tb_Data_5);
            this.DataPanel.Controls.Add(this.lbl_Data_7);
            this.DataPanel.Controls.Add(this.tb_Data_2);
            this.DataPanel.Controls.Add(this.lbl_Data_4);
            this.DataPanel.Controls.Add(this.tb_Data_1);
            this.DataPanel.Controls.Add(this.tb_Idx);
            this.DataPanel.Controls.Add(this.tb_Data_4);
            this.DataPanel.Controls.Add(this.lbl_Data_6);
            this.DataPanel.Controls.Add(this.tb_Ldist);
            this.DataPanel.Controls.Add(this.tb_Sec);
            this.DataPanel.Controls.Add(this.tb_Data_3);
            this.DataPanel.Controls.Add(this.lbl_Data_8);
            this.DataPanel.Controls.Add(this.tb_Hdgdeg);
            this.DataPanel.Controls.Add(this.lbl_String_1);
            this.DataPanel.Controls.Add(this.tb_Rdist);
            this.DataPanel.Location = new System.Drawing.Point(874, 202);
            this.DataPanel.Name = "DataPanel";
            this.DataPanel.Size = new System.Drawing.Size(251, 640);
            this.DataPanel.TabIndex = 2;
            this.DataPanel.TabStop = false;
            this.DataPanel.Text = "Frame Selecter";
            // 
            // frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1121, 854);
            this.Controls.Add(this.DataPanel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gBox1);
            this.Controls.Add(this.panel1);
            this.Name = "frm_Main";
            this.Text = "Robot Telemetry Viewer V1.0.2";
            this.Load += new System.EventHandler(this.frm_Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.gBox1.ResumeLayout(false);
            this.gBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tBar_FrameSelect)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.DataPanel.ResumeLayout(false);
            this.DataPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.VScrollBar vScrollBar1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_TotFrames;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.Label lbl_TotSec;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox gBox1;
        private System.Windows.Forms.TrackBar tBar_FrameSelect;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbl_Data_1;
        private System.Windows.Forms.TextBox tb_Idx;
        private System.Windows.Forms.TextBox tb_Sec;
        private System.Windows.Forms.TextBox tb_Rdist;
        private System.Windows.Forms.TextBox tb_Ldist;
        private System.Windows.Forms.Label lbl_String_1;
        private System.Windows.Forms.TextBox tb_String_1;
        private System.Windows.Forms.TextBox tb_Data_2;
        private System.Windows.Forms.TextBox tb_Hdgdeg;
        private System.Windows.Forms.Label lbl_Data_2;
        private System.Windows.Forms.Label label_0;
        private System.Windows.Forms.TextBox tb_Data_1;
        private System.Windows.Forms.TextBox tb_Data_6;
        private System.Windows.Forms.TextBox tb_Data_5;
        private System.Windows.Forms.TextBox tb_Data_4;
        private System.Windows.Forms.TextBox tb_Data_3;
        private System.Windows.Forms.Label lbl_Data_6;
        private System.Windows.Forms.Label lbl_Data_4;
        private System.Windows.Forms.Label lbl_Data_5;
        private System.Windows.Forms.Label lbl_Data_3;
        private System.Windows.Forms.TextBox tb_String_2;
        private System.Windows.Forms.Label lbl_String_2;
        private System.Windows.Forms.TextBox tb_String_4;
        private System.Windows.Forms.Label lbl_String_4;
        private System.Windows.Forms.TextBox tb_String_3;
        private System.Windows.Forms.Label lbl_String_3;
        private System.Windows.Forms.TextBox tb_Data_8;
        private System.Windows.Forms.TextBox tb_Data_7;
        private System.Windows.Forms.Label lbl_Data_8;
        private System.Windows.Forms.Label lbl_Data_7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox DataPanel;
    }
}

