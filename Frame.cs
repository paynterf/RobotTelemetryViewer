using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static RobotTelemetryViewer.Frame;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace RobotTelemetryViewer
{
    public class Frame
    {
        //05/15/23 experiment with variable numbers of controls on main form

        //float sec, ldist, rdist, fwdpos, rearpos, hdgdeg;

        public enum TRKDIR
        {
            TRK_NONE = 0,
            TRK_LEFT,
            TRK_RIGHT
        }

        //private TRKDIR trkdir;
        private float sec;
        private float ldist;
        private float rdist;
        private float hdgdeg;
        private string trkstr;

        public string TrackString
        {
            get { return trkstr; }
            set { trkstr = value; }
        }


        public float Hdgdeg
        {
            get { return hdgdeg; }
            set { hdgdeg = value; }
        }


        //public List<double> double_vals;
        //public List<string> string_vals;
        public Dictionary<int, double> double_vals = new Dictionary<int, double>();
        public Dictionary<int, string> string_vals = new Dictionary<int, string>();

        public float Rdist
        {
            get { return rdist; }
            set { rdist = value; }
        }
        public float Ldist
        {
            get { return ldist; }
            set { ldist = value; }
        }
        public float Sec
        {
            get { return sec; }
            set { sec = value; }
        }


        //geometry in mm
        //public static int MAX_LR_DIST = 200;
        //public static int MAX_LR_DIST = 400;//05/02/23
        public static int MAX_LR_DIST = 100;//05/23/23
        public static int ROBOT_WIDTH = 20;
        public static int ROBOT_HEIGHT = 15;

        static float last_good_ldist = 0;
        static float last_good_rdist = 0;

        public Frame(string line, string curTrackStr)
        {
            try
            {
                string[] pieces = line.Split('\t');

                //05/15/23 these first three are 'fixed' - always the first 5 items in telemetry
                sec = Convert.ToSingle(pieces[0]);
                ldist = Convert.ToSingle(pieces[1]);
                rdist = Convert.ToSingle(pieces[2]);
                hdgdeg = Convert.ToSingle(pieces[3]);
                trkstr = curTrackStr;

                //05/15/23 all the rest are either numerical 'Data_x', or
                //strings 'String_x'
                int dta = 1; //variable data value index
                int str = 1; //variable string value index
                for (int i = frm_Main.NUM_FIXED_TELEMETRY_COLUMNS; i < pieces.Length; i++)
                {
                    string s = pieces[i];

                    if (double.TryParse(s, out double dbl_val)) 
                    {
                        double_vals.Add(dta++, dbl_val);
                    }
                    else 
                    {
                        string_vals.Add(str++, s); 
                    }

                }

                if (frm_Main.verbose)
                {
                    for (int i = 1; i <= double_vals.Count; i++)
                    {
                        Debug.WriteLine($"double_val[{i}] = {double_vals[i]}");
                    }
                    for (int i = 1; i <= string_vals.Count; i++)
                    {
                        Debug.WriteLine($"string_val[{i}] = {string_vals[i]}");
                    }
                }
            }
            catch (Exception e)
            {
                //if (frm_Main.more_verbose)
                //{
                //    Debug.WriteLine($"Failed to construct Frame object with error {e.Message}");
                //    Debug.WriteLine($"offending line was {line}");
                //}
                throw new ArgumentOutOfRangeException();
            }
        }
        public void print()
        {
            Debug.Print($"{sec}\t{ldist}\t{rdist}\t{hdgdeg}");
        }

        //void draw(float yloc)
        //public void draw(float yloc, Graphics g)
        public void draw(float yloc, Graphics g, bool bIsSelected)
        {
            //04/09/23 robot colored red for TRK_LEFT, green for TRK_RIGHT, black for TRK_NEITHER
            Pen ArrowPen = new Pen(Color.Gray);
            Pen SelectPen = new Pen(Color.Red);
            Pen LeftPen = new Pen(Color.Yellow);
            Pen RightPen = new Pen(Color.Green);
            Pen TooFarPen = new Pen(Color.Gray);

            if ( bIsSelected )
            {
                ArrowPen.Color = Color.Red;
                LeftPen.Color = Color.Red;
                RightPen.Color = Color.Red;
                TooFarPen.Color = Color.Red;
            }

            Arrow myArrow = new Arrow();
            float Arrow_Xpos = 0;

            GraphicsState transState = g.Save();
            g.TranslateTransform(0, (int)yloc);//move drawing location up to latest point

            switch (trkstr)
            {
                case "TRK_LEFT":
                    ArrowPen.Color = Color.Blue;

                    //04/11/23 try at highlighting a selected frame
                    if (bIsSelected)
                    {
                        ArrowPen.Color = Color.Red;
                    }

                    Arrow_Xpos = ldist;

                    if (ldist < MAX_LR_DIST)
                    {
                        g.DrawRectangle(LeftPen, 0, 0, 1, 3);//wall symbol; used to be an ellipse

                        if (bIsSelected)
                        {
                            g.DrawRectangle(SelectPen, 0, 0, 1, 3);//wall symbol; used to be an ellipse
                        }

                        //right-hand border takes more work
                        if (rdist < MAX_LR_DIST)
                        {
                            g.DrawEllipse(RightPen, ldist + ROBOT_WIDTH + rdist, 0, 3, 3);

                            //if (bIsSelected)
                            //{
                            //    g.DrawEllipse(SelectPen, ldist + ROBOT_WIDTH + rdist, 0, 3, 3);
                            //}
                        }
                        else
                        {
                            g.DrawEllipse(TooFarPen, ldist + ROBOT_WIDTH + rdist, 0, 3, 3);
                        }

                        //draw rectangle rotated by hdgdeg deg
                        //g.TranslateTransform(ldist, 0);
                        g.TranslateTransform(Arrow_Xpos, 0);
                        g.RotateTransform(-hdgdeg);
                        //g.DrawRectangle(ArrowPen, 0, 0, 20, 10);
                        myArrow.Draw(ArrowPen, yloc, g);

                        last_good_ldist = ldist;

                    }

                    break;
                case "TRK_RIGHT":
                    ArrowPen.Color = Color.Green;

                    if (bIsSelected)
                    {
                        ArrowPen.Color = Color.Red;
                    }
                    Arrow_Xpos = 10;

                    //if (rdist < MAX_LR_DIST)
                    {
                        //if (bIsSelected)
                        //{
                        //    g.DrawEllipse(SelectPen, rdist, 0, 3, 3);
                        //    g.DrawRectangle(SelectPen, 0, 0, 1, 3);
                        //}
                        //else
                        {
                            g.DrawEllipse(RightPen, rdist, 0, 3, 3);
                            g.DrawRectangle(RightPen, 0, 0, 1, 3);
                        }
                    }

                    //draw rectangle rotated by hdgdeg deg
                    g.TranslateTransform(Arrow_Xpos, 0);
                    g.RotateTransform(-hdgdeg);
                    myArrow.Draw(ArrowPen, yloc, g);

                    break;
                default:
                    ArrowPen.Color = Color.Gray;
                    break;
            }

            g.Restore(transState);

            //another try at upright text
            GraphicsState txt_transState = g.Save();

            g.TranslateTransform(0, (int)yloc);//04/08/23 moved the '20*' from here to frm_main so more obvious
            g.ScaleTransform(1, -1);
            Brush brush = new SolidBrush(Color.Black);
            float sec = yloc / 20;
            g.DrawString(sec.ToString(), new Font("Arial", 8), brush, new PointF(0, 0));
            g.Restore(txt_transState);

            //g.Restore(transState);

        }
    }
}
