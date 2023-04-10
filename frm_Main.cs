using ScrollingExample;
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

namespace RobotTelemetryViewer
{
    public partial class frm_Main : Form
    {
        List<Frame> frames = new List<Frame>();
        bool verbose = false;
        bool more_verbose = true;
        bool first_time_pBox_draw = true;//force pBox resize one-time to init scrollbar
        float ZoomFactor = 1;//04/09/23 added to allow zoom in/out using CTRL mousewheel

        //moved to global so can use in ReSize event
        float y_extent_mm = 0;
        float x_extent_mm = 0;

        public frm_Main()
        {
            InitializeComponent();
            LoadTelemetry();
        }
        private void LoadTelemetry()
        {
            GetFrameDataFromRobotTelemetryFile();
            pictureBox1.Invalidate();

        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            int xWidth = pictureBox1.Width;
            int yHeight = pictureBox1.Height;
            Point[] pBoxExtents_mm = { new Point(xWidth, yHeight) };

            //change to mm units with y growng up, origin at bottom
            g.PageUnit = GraphicsUnit.Millimeter;
            g.TransformPoints(CoordinateSpace.Page, CoordinateSpace.Device, pBoxExtents_mm);

            if (more_verbose)
            {
                Debug.WriteLine($"pBox_extents (mm) = ({pBoxExtents_mm[0].X }, {pBoxExtents_mm[0].Y})");
                Debug.WriteLine($"scrollbar max, value = {vScrollBar1.Maximum}, {vScrollBar1.Maximum - vScrollBar1.Value}");
            }

            g.TranslateTransform(0,  vScrollBar1.Maximum - vScrollBar1.Value);
            //g.ScaleTransform(1, -1);
            //g.ScaleTransform(2, -2);
            g.ScaleTransform(ZoomFactor, -ZoomFactor);

            foreach (Frame frame in frames)
            {
                float x = frame.Ldist + frame.Rdist + Frame.ROBOT_WIDTH;

                if (x > x_extent_mm)
                {
                    if (more_verbose)
                    {
                        frame.print();
                        Debug.WriteLine($"replacing {x_extent_mm} with {x}");
                    }

                    x_extent_mm = x;

                }
                frame.draw(20 * frame.Sec, g);//time x20 used as proxy for dist in mm
            }

            y_extent_mm = 20*frames[frames.Count-1].Sec;//Sec used as proxy for mm
        
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
        private bool GetFrameDataFromRobotTelemetryFile()
        {
            bool result = false;

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Debug.WriteLine(ofd.FileName);

                using (StreamReader file = new StreamReader(ofd.FileName))
                {
                    int counter = 0;
                    string ln;

                    while ((ln = file.ReadLine()) != null)
                    {
                        if (verbose)
                        {
                            System.Diagnostics.Debug.WriteLine(ln);
                            counter++;
                        }

                        try
                        {
                            Frame frame = new Frame(ln);
                            frames.Add(frame);

                            if (more_verbose)
                            {
                                frame.print();
                            }

                        }
                        catch (Exception e)
                        {

                            System.Diagnostics.Debug.WriteLine($"failed to add frame to list, message = {e.Message}");
                        }
                    }

                    if (verbose)
                    {
                        System.Diagnostics.Debug.WriteLine($"File has {counter} lines. Added {frames.Count} Frames");
                    }

                    this.Text += ": " + ofd.FileName;
                    lbl_TotFrames.Text = frames.Count.ToString();
                    lbl_TotSec.Text = frames[frames.Count - 1].Sec.ToString();

                    file.Close();
                    result = true;
                }
            }
            return result;
        }
        private void pictureBox1_Resize(object sender, EventArgs e)
        {
            //now adjust vert scrollbar
            Graphics g = pictureBox1.CreateGraphics();
            Point[] pBoxExtents_mm = { new Point(pictureBox1.Width, pictureBox1.Height) };

            //change to mm units with y growng up, origin at bottom
            g.PageUnit = GraphicsUnit.Millimeter;
            g.TransformPoints(CoordinateSpace.Page, CoordinateSpace.Device, pBoxExtents_mm);


            PointF[] data_extent_pt_pix = new PointF[] { new PointF(x_extent_mm, y_extent_mm) };
            g.TransformPoints(CoordinateSpace.Device, CoordinateSpace.Page, data_extent_pt_pix);

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
                Debug.WriteLine($"Zoom factor set to {ZoomFactor}");
                pictureBox1.Invalidate(true);
            }

        }
    }
}
