using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;
using System.Windows.Input;
using System.Security.Cryptography;

//05/15/23 Variable_Header branch
//Adaptively assign telemetry header strings to textbox labels, and
//data items to the corresponding text boxes
//Header string is assumed to start with "Sec\tLCen\RCen"

namespace RobotTelemetryViewer
{
    public partial class frm_Main : Form
    {
        List<Frame> frames = new List<Frame>();
        List<string> telemetrystrings = new List<string>();

        private string fileName;

        public static int NUM_FIXED_TELEMETRY_COLUMNS = 4;

        //05/04/23 chg to public static so can access from frame.cs
        public static bool verbose = false;
        public static bool more_verbose = false;

        private string[] columnHeaders;

        public string[] ColumnHeaderStrings
        {
            get { return columnHeaders; }
            set { columnHeaders = value; }
        }


        bool first_time_pBox_draw = true;//force pBox resize one-time to init scrollbar
        float ZoomFactor = 1;//04/09/23 added to allow zoom in/out using CTRL mousewheel

        //moved to global so can use in ReSize event
        float y_extent_mm = 0;
        float x_extent_mm = 0;
        int numFrames = 0;

        public frm_Main()
        {
            InitializeComponent();
            LoadTelemetry();
            //this.Show();
        }
        private void LoadTelemetry()
        {
            numFrames = GetFrameDataFromRobotTelemetryFile();//4/11/23 rev to return number of frames loaded

            if (numFrames >= 1 )
            {
                tBar_FrameSelect.Maximum = numFrames - 1;//4/11/23 so can select any frame in frames
                tBar_FrameSelect.Minimum = 0;
                LoadColumnHeadersIntoTextBoxLabels();
                LoadFrameDataIntoReadouts(0);
                pictureBox1.Invalidate();
            }
            else
            {
                Debug.WriteLine("No Frames Found - Quitting!");
                MessageBox.Show("No Frames Found - Quitting", "No Frames Found!",MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                Application.Exit();
            }
        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            //Notes:
            //  04/11/23 - added capability to show selected frame with red rectangle

            Graphics g = e.Graphics;
            int xWidth = pictureBox1.Width;
            int yHeight = pictureBox1.Height;
            Point[] pBoxExtents_mm = { new Point(xWidth, yHeight) };

            //change to mm units with y growing up, origin at bottom
            g.PageUnit = GraphicsUnit.Millimeter;
            g.TransformPoints(CoordinateSpace.Page, CoordinateSpace.Device, pBoxExtents_mm);

            if (more_verbose)
            {
                Debug.WriteLine($"pBox_extents (mm) = ({pBoxExtents_mm[0].X }, {pBoxExtents_mm[0].Y})");
                Debug.WriteLine($"scrollbar max, value = {vScrollBar1.Maximum}, {vScrollBar1.Maximum - vScrollBar1.Value}");
            }

            g.TranslateTransform(0,  vScrollBar1.Maximum - vScrollBar1.Value);
            g.ScaleTransform(ZoomFactor, -ZoomFactor);

            //change to for loop so have explicit index to match for selection
            for (int idx = 0; idx < frames.Count; idx++)
            {
                float x = frames[idx].Ldist + frames[idx].Rdist + Frame.ROBOT_WIDTH;

                if (x > x_extent_mm)
                {
                    if (more_verbose)
                    {
                        frames[idx].print();
                        Debug.WriteLine($"replacing {x_extent_mm} with {x}");
                    }

                    x_extent_mm = x;

                }
                //frame.draw(20 * frame.Sec, g);//time x20 used as proxy for dist in mm
                frames[idx].draw(20 * frames[idx].Sec, g, idx == tBar_FrameSelect.Value );//time x20 used as proxy for dist in mm
            }

            //05/19/23 rev to fully contain vert extent of COM6 2023-05-18 19-40-02.inbound.txt (+1 - +8 doesn't work) 
            y_extent_mm = 20*(frames[frames.Count-1].Sec) + 9;//5/19/23 added 1 sec to make sure can see all
        
            if (more_verbose)
            {
                Debug.WriteLine($"x, y extents (mm) = ({x_extent_mm}, {y_extent_mm})");
            }

            //scrollbar not visible until pBox is resized, so have to force once
            if (first_time_pBox_draw)
            {
                first_time_pBox_draw = false;
                pictureBox1_Resize(null, null);//force a resize event
            }
        }
        private int GetFrameDataFromRobotTelemetryFile()//4/11/23 rev to return number of frames loaded
        {
            //05/15/23 Experiment with using variable header info to populate frame objects
            bool result = false;
            string CurTrackDir = "";

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            ofd.Title = this.Text + ": Choose Robot Telemetry File";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                fileName = ofd.FileName;
                Debug.WriteLine(fileName);

                using (StreamReader file = new StreamReader(fileName))
                {
                    int counter = 0;
                    string ln;

                    //04/10/23 rewritten to consume entire telemetry file, skipping non-telemetry lines 
                    //05/16/23 note that there can be multiple header lines as well
                    while ((ln = file.ReadLine()) != null)
                    {
                        if (verbose)
                        {
                            Debug.WriteLine(ln);
                        }
                        counter++;

                        //05/15/23 check for header line
                        if (ln.Contains("Sec") && ln.Contains("LCen") && ln.Contains("RCen"))
                        {
                            //OK, we have found a header line. If the first, capture it
                            columnHeaders = ln.Split(new char[] { '\t' });

                            if (verbose)
                            {
                                foreach (string hdrstring in columnHeaders)
                                {
                                    Debug.WriteLine(hdrstring);
                                }
                            }
                        }
                        //check for line containing 'TrackLeftWallOffset:' or 'TrackRightWallOffset:'
                        else if (ln.Contains("TrackLeftWallOffset:"))
                        {
                            //tracking left side. 
                            CurTrackDir = "TRK_LEFT";
                        }
                        else if (ln.Contains("TrackRightWallOffset:"))
                        {
                            //tracking left side. 
                            CurTrackDir = "TRK_RIGHT";
                        }

                        //06/05/23 added to alert user and quit program
                        else if (ln.Contains("DISTANCES ONLY MODE"))
                        {
                            MessageBox.Show("Distances Only Mode File - Quitting!\n" + fileName, this.Text + ": Bad File", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.Close();
                            Application.Exit();
                        }
                        else //data line or miscellaneous output 
                        {
                            //Frame ctor will raise an exception on a non-telemetry line
                            try
                            {
                                Frame frame = new Frame(ln, CurTrackDir);
                                frames.Add(frame);

                                if (verbose)
                                {
                                    Debug.WriteLine($"frames now contains {frames.Count} frames");
                                }

                                if (more_verbose)
                                {
                                    frame.print();
                                }

                            }
                            catch (Exception e)
                            {
                                if(more_verbose)
                                {
                                    Debug.WriteLine($"failed to add frame to list, message = {e.Message}");
                                }

                                ////check for line containing 'TrackLeftWallOffset:' or 'TrackRightWallOffset:'
                                //if (ln.Contains("TrackLeftWallOffset:")) 
                                //{
                                //    //tracking left side. 
                                //    CurTrackDir = "TRK_LEFT";
                                //}
                                //if (ln.Contains("TrackRightWallOffset:")) 
                                //{
                                //    //tracking left side. 
                                //    CurTrackDir = "TRK_RIGHT";
                                //}
                            }
                        }
                    }

                    //if (verbose)
                    {
                        System.Diagnostics.Debug.WriteLine($"File has {counter} lines. Added {frames.Count} Frames");
                    }

                    this.Text += ": " + fileName;
                    lbl_TotFrames.Text = frames.Count.ToString();
                    lbl_TotSec.Text = frames[frames.Count - 1].Sec.ToString();

                    file.Close();
                    result = true;
                }
            }
            //return result;
            return frames.Count;//4/11/23 rev to return number of frames loaded
        }
        private void pictureBox1_Resize(object sender, EventArgs e)
        {
            //06/02/23 this looks duplicative with code in .Paint() but it has to be done to set the scrollbar size
            //now adjust vert scrollbar
            Graphics g2 = pictureBox1.CreateGraphics();
            Point[] pBoxExtents_mm = { new Point(pictureBox1.Width, pictureBox1.Height) };

            //change to mm units with y growng up, origin at bottom
            g2.PageUnit = GraphicsUnit.Millimeter;
            g2.TransformPoints(CoordinateSpace.Page, CoordinateSpace.Device, pBoxExtents_mm);


            PointF[] data_extent_pt_pix = new PointF[] { new PointF(x_extent_mm, y_extent_mm) };
            g2.TransformPoints(CoordinateSpace.Device, CoordinateSpace.Page, data_extent_pt_pix);

            //04/08/23 these values were empirically derived, but seem to work fine
            //need the 1.1* in the 'if' statement to make sure the scrollbar doesn't disappear too soon
            //and the 1.1* in vScrollBar1.Maximum decreases the size of the 'thumb', allowing more travel
            if (pictureBox1.Height < 1.1 * data_extent_pt_pix[0].Y)
            {
                vScrollBar1.Visible = true;
                vScrollBar1.Maximum = (int)(1.1 * y_extent_mm);
                vScrollBar1.SmallChange = 20;
                vScrollBar1.LargeChange = pBoxExtents_mm[0].Y;
                vScrollBar1.Value = vScrollBar1.Maximum - vScrollBar1.LargeChange;
            }
            else
            {
                vScrollBar1.Visible = false;
            }

            if (more_verbose)
            {
                Debug.WriteLine($"x, y extents (pix) = ({data_extent_pt_pix[0].X}, {data_extent_pt_pix[0].X})");
            }

            pictureBox1.Invalidate(true);
        }
        private void vScrollBar1_ValueChanged(object sender, EventArgs e)
        {
            pictureBox1.Invalidate(true);

        }
        private void frm_Main_Load(object sender, EventArgs e)
        {
            pictureBox1.MouseWheel += new MouseEventHandler(pictureBox1_MouseWheel);
        }
        //private void pictureBox1_MouseWheel(object sender, EventArgs e)
        private void pictureBox1_MouseWheel(object sender, MouseEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control)
            {
                if(e.Delta > 0)
                {
                    //zooming in
                    ZoomFactor = 2 * ZoomFactor;
                }
                else
                {
                    //zooming out
                    ZoomFactor = ZoomFactor / 2;
                }

                if(verbose )
                {
                    Debug.WriteLine($"Zoom factor set to {ZoomFactor}");
                }
                pictureBox1.Invalidate(true);
            }

        }
        private void tBar_FrameSelect_ValueChanged(object sender, EventArgs e)
        {
            LoadFrameDataIntoReadouts(tBar_FrameSelect.Value);

            pictureBox1.Invalidate();
        }
        private void LoadFrameDataIntoReadouts(int idx)
        {
            tb_Idx.Text = idx.ToString();
            Frame frame = frames[idx];
            tb_Sec.Text = frame.Sec.ToString();
            tb_Ldist.Text = frame.Ldist.ToString();
            tb_Rdist.Text = frame.Rdist.ToString();
            tb_Hdgdeg.Text = frame.Hdgdeg.ToString();

            //OK, now iteratively update the variable data columns
            for (int i = 1;i<= frame.double_vals.Count;i++)
            {
                foreach (Control ctrl in DataPanel.Controls)
                {
                    //string searchstr = "tb_Data_" + i.ToString();
                    if (ctrl.Name.Contains("tb_Data_" + i.ToString()))
                    {
                        ((System.Windows.Forms.TextBox)ctrl).Text = frame.double_vals[i].ToString();
                    }
                }
            }
            for (int i = 1;i<= frame.string_vals.Count;i++)
            {
                foreach (Control ctrl in DataPanel.Controls)
                {
                    if (ctrl.Name.Contains("tb_String_" + i.ToString()))
                    {
                        ((System.Windows.Forms.TextBox)ctrl).Text = frame.string_vals[i];
                    }
                }
            }
        }

        private void LoadColumnHeadersIntoTextBoxLabels()
        {
            //Purpose: update the variable textbox labels with column header strings
            //Inputs: columnHeaders = string[] containing column header strings
            //Outputs: text box labels updated to reflect column headers
            //Plan:
            //Step1: Get first frame for use as a data type template
            //Step2: for each numeric frame entry, assign the associated column header string
            //       to the appropriate data textbox label.
            //Step3: for each string frame entry, assign the associated column header string
            //       to the appropriate string textbox label.

        //Step1: Get first frame for use as a data type template
            Frame firstframe = frames[0];


        //Step2: for each numeric frame entry, assign the associated column header string
        //       to the appropriate data textbox label.
            for (int i = 1; i <= firstframe.double_vals.Count; i++)
            {
                string srch_str = "lbl_Data_" + i.ToString();

                //Debug.WriteLine($"DataPanel contains {DataPanel.Controls.Count} controls");
                foreach (Control ctrl in DataPanel.Controls)
                {
                    //Debug.WriteLine($"{ctrl.Name} has Name {ctrl.Name}");
                    if (ctrl.Name == srch_str)
                    {
                        ctrl.Text = columnHeaders[i + NUM_FIXED_TELEMETRY_COLUMNS - 1];
                        break;
                    }
                }
            }

        //Step3: for each string frame entry, assign the associated column header string
        //       to the appropriate string textbox label.
            for (int i = 1; i <= firstframe.string_vals.Count;i++)
            {
                string srch_str = "lbl_String_" + i.ToString();

                //Debug.WriteLine($"DataPanel contains {DataPanel.Controls.Count} controls");
                foreach (Control ctrl in DataPanel.Controls)
                {
                    //Debug.WriteLine($"{ctrl.Name} has Name {ctrl.Name}");
                    if (ctrl.Name == srch_str)
                    {
                        ctrl.Text = columnHeaders[i + NUM_FIXED_TELEMETRY_COLUMNS + firstframe.double_vals.Count - 1];
                        break;
                    }
                }
            }
        }

        private void btn_OpenInNotepad_Click(object sender, EventArgs e)
        {
            Process.Start("notepad++.exe", "\"" + fileName + "\"");
        }
    }
}
