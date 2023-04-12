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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tb_Idx = new System.Windows.Forms.TextBox();
            this.tb_Sec = new System.Windows.Forms.TextBox();
            this.tb_Rdist = new System.Windows.Forms.TextBox();
            this.tb_Ldist = new System.Windows.Forms.TextBox();
            this.tb_Hdg = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.gBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tBar_FrameSelect)).BeginInit();
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
            this.pictureBox1.Size = new System.Drawing.Size(686, 609);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.Resize += new System.EventHandler(this.pictureBox1_Resize);
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Dock = System.Windows.Forms.DockStyle.Right;
            this.vScrollBar1.Location = new System.Drawing.Point(660, 0);
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(26, 609);
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
            this.panel1.Size = new System.Drawing.Size(686, 609);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Total Frames";
            // 
            // lbl_TotFrames
            // 
            this.lbl_TotFrames.AutoSize = true;
            this.lbl_TotFrames.Location = new System.Drawing.Point(112, 22);
            this.lbl_TotFrames.Name = "lbl_TotFrames";
            this.lbl_TotFrames.Size = new System.Drawing.Size(94, 16);
            this.lbl_TotFrames.TabIndex = 1;
            this.lbl_TotFrames.Text = "lbl_TotFrames";
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Location = new System.Drawing.Point(5, 56);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(65, 16);
            this.lbl.TabIndex = 1;
            this.lbl.Text = "Total Sec";
            // 
            // lbl_TotSec
            // 
            this.lbl_TotSec.AutoSize = true;
            this.lbl_TotSec.Location = new System.Drawing.Point(112, 56);
            this.lbl_TotSec.Name = "lbl_TotSec";
            this.lbl_TotSec.Size = new System.Drawing.Size(72, 16);
            this.lbl_TotSec.TabIndex = 1;
            this.lbl_TotSec.Text = "lbl_TotSec";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 102);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 16);
            this.label5.TabIndex = 1;
            this.label5.Text = "label1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(112, 102);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 16);
            this.label6.TabIndex = 1;
            this.label6.Text = "label1";
            // 
            // gBox1
            // 
            this.gBox1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.gBox1.Controls.Add(this.lbl);
            this.gBox1.Controls.Add(this.label6);
            this.gBox1.Controls.Add(this.label5);
            this.gBox1.Controls.Add(this.label1);
            this.gBox1.Controls.Add(this.lbl_TotSec);
            this.gBox1.Controls.Add(this.lbl_TotFrames);
            this.gBox1.Location = new System.Drawing.Point(695, 12);
            this.gBox1.Name = "gBox1";
            this.gBox1.Size = new System.Drawing.Size(180, 167);
            this.gBox1.TabIndex = 2;
            this.gBox1.TabStop = false;
            // 
            // tBar_FrameSelect
            // 
            this.tBar_FrameSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tBar_FrameSelect.Location = new System.Drawing.Point(703, 208);
            this.tBar_FrameSelect.Name = "tBar_FrameSelect";
            this.tBar_FrameSelect.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tBar_FrameSelect.Size = new System.Drawing.Size(56, 390);
            this.tBar_FrameSelect.TabIndex = 3;
            this.tBar_FrameSelect.ValueChanged += new System.EventHandler(this.tBar_FrameSelect_ValueChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(799, 229);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Idx";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(792, 257);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Sec";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(788, 285);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Ldist";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(785, 313);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 16);
            this.label7.TabIndex = 4;
            this.label7.Text = "Rdist";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(790, 341);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(33, 16);
            this.label8.TabIndex = 4;
            this.label8.Text = "Hdg";
            // 
            // tb_Idx
            // 
            this.tb_Idx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_Idx.Location = new System.Drawing.Point(827, 226);
            this.tb_Idx.Name = "tb_Idx";
            this.tb_Idx.Size = new System.Drawing.Size(47, 22);
            this.tb_Idx.TabIndex = 5;
            // 
            // tb_Sec
            // 
            this.tb_Sec.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_Sec.Location = new System.Drawing.Point(827, 254);
            this.tb_Sec.Name = "tb_Sec";
            this.tb_Sec.Size = new System.Drawing.Size(47, 22);
            this.tb_Sec.TabIndex = 5;
            // 
            // tb_Rdist
            // 
            this.tb_Rdist.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_Rdist.Location = new System.Drawing.Point(827, 310);
            this.tb_Rdist.Name = "tb_Rdist";
            this.tb_Rdist.Size = new System.Drawing.Size(47, 22);
            this.tb_Rdist.TabIndex = 5;
            // 
            // tb_Ldist
            // 
            this.tb_Ldist.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_Ldist.Location = new System.Drawing.Point(827, 282);
            this.tb_Ldist.Name = "tb_Ldist";
            this.tb_Ldist.Size = new System.Drawing.Size(47, 22);
            this.tb_Ldist.TabIndex = 5;
            // 
            // tb_Hdg
            // 
            this.tb_Hdg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_Hdg.Location = new System.Drawing.Point(827, 338);
            this.tb_Hdg.Name = "tb_Hdg";
            this.tb_Hdg.Size = new System.Drawing.Size(47, 22);
            this.tb_Hdg.TabIndex = 5;
            // 
            // frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(887, 610);
            this.Controls.Add(this.tb_Hdg);
            this.Controls.Add(this.tb_Ldist);
            this.Controls.Add(this.tb_Rdist);
            this.Controls.Add(this.tb_Sec);
            this.Controls.Add(this.tb_Idx);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tBar_FrameSelect);
            this.Controls.Add(this.gBox1);
            this.Controls.Add(this.panel1);
            this.Name = "frm_Main";
            this.Text = "Robot Telemetry Viewer";
            this.Load += new System.EventHandler(this.frm_Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.gBox1.ResumeLayout(false);
            this.gBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tBar_FrameSelect)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tb_Idx;
        private System.Windows.Forms.TextBox tb_Sec;
        private System.Windows.Forms.TextBox tb_Rdist;
        private System.Windows.Forms.TextBox tb_Ldist;
        private System.Windows.Forms.TextBox tb_Hdg;
    }
}

