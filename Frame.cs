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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ScrollingExample
{

    public class Frame
    {
        //float sec, ldist, rdist, fwdpos, rearpos, hdgdeg;

        public enum TRKDIR
        {
            TRK_NONE = 0,
            TRK_LEFT, 
            TRK_RIGHT
        }

        private TRKDIR trkdir;
        private float sec;
        private float ldist;
        private float rdist;
        private float fwdpos;
        private float rearpos;
        private float hdgdeg;
        private string anomalyCode;
        private int wrongWallCount;

        public int WrongWallCount
        {
            get { return wrongWallCount; }
            set { wrongWallCount = value; }
        }

        public TRKDIR TrackDir
        {
            get { return trkdir; }
            set { trkdir = value; }
        }
        public float Hdgdeg
        {
            get { return hdgdeg; }
            set { hdgdeg = value; }
        }
        public float Rearpos
        {
            get { return rearpos; }
            set { rearpos = value; }
        }
        public float Fwdpos
        {
            get { return fwdpos; }
            set { fwdpos = value; }
        }
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
        public string AnomalyCode
        {
            get { return anomalyCode; }
            set { anomalyCode = value; }
        }

        public string[] AnomalyCodeStrArray = new string[] { "\"NONE\", \"STUCK_AHEAD\", \"STUCK_BEHIND\", " +
            "\"OBSTACLE_AHEAD\", \"WALL_OFFSET_DIST_AHEAD\",\"OBSTACLE_BEHIND\", \"OPEN_CORNER\", " +
            "\"DEAD_BATTERY\", \"CHARGER_CONNECTED\", \"OPEN_DOORWAY\", \"WRONG_WALL\"" };

        //geometry in mm
        //public static int MAX_LR_DIST = 200;
        public static int MAX_LR_DIST = 400;//05/02/23
        public static int ROBOT_WIDTH = 20;
        public static int ROBOT_HEIGHT = 15;

        static float last_good_ldist = 0;
        static float last_good_rdist = 0;



        public Frame(float s, float l, float r, float f, float rear, float h, TRKDIR dir, string anomalycode)
        {
            sec = s;
            ldist = l;
            rdist = r;
            fwdpos = f;
            rearpos = rear;
            hdgdeg = h;
            trkdir = dir;
        }

        //04/09/23 added TRKDIR property to frame as last item in line
        public Frame(String line, string curTrackStr)
        {
            try
            {
                String[] pieces = line.Split('\t');

                sec = Convert.ToSingle(pieces[0]);
                ldist = Convert.ToSingle(pieces[1]);
                rdist = Convert.ToSingle(pieces[2]);
                fwdpos = Convert.ToSingle(pieces[3]);
                rearpos = Convert.ToSingle(pieces[4]);
                hdgdeg = Convert.ToSingle(pieces[7]);
                wrongWallCount = Convert.ToInt16(pieces[8]);
                anomalyCode = pieces[9];

                //track direction takes more work
                if (curTrackStr == "TRK_LEFT")
                {
                    trkdir = TRKDIR.TRK_LEFT;
                }
                else if (curTrackStr == "TRK_RIGHT")
                {
                    trkdir = TRKDIR.TRK_RIGHT;
                }
                else
                {
                    Debug.WriteLine($"pieces[8] ({pieces[8]} was not recognized as a TRKDIR enum option");
                    trkdir = TRKDIR.TRK_NONE;
                }



            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine($"Failed to construct Frame object with error {e.Message}");
                System.Diagnostics.Debug.WriteLine($"offending line was {line}");
                throw new ArgumentOutOfRangeException();
            }
        }
        public void print()
        {
            System.Diagnostics.Debug.Print($"{sec}\t{ldist}\t{rdist}\t{fwdpos}\t{rearpos}\t{hdgdeg}");
        }

        //void draw(float yloc)
        //public void draw(float yloc, Graphics g)
        public void draw(float yloc, Graphics g, bool bIsSelected)
        {
            //04/09/23 robot colored red for TRK_LEFT, green for TRK_RIGHT, black for TRK_NEITHER
            Pen RobotPen = new Pen(Color.Gray);
            Pen SelectPen = new Pen(Color.Red);
            Pen LeftPen = new Pen(Color.Yellow);
            Pen RightPen = new Pen(Color.Green);
            Pen TooFarPen = new Pen(Color.Gray);

            switch (trkdir)
            {
                case TRKDIR.TRK_NONE:
                    RobotPen.Color = Color.Gray;
                    break;
                case TRKDIR.TRK_LEFT:
                    RobotPen.Color = Color.Blue;
                    break;
                case TRKDIR.TRK_RIGHT:
                    RobotPen.Color = Color.Green;
                    break;
                default:
                    break;
            }

            //04/11/23 try at highlighting a selected frame
            if ( bIsSelected )
            {
                RobotPen = SelectPen;
            }

            GraphicsState transState = g.Save();
            g.TranslateTransform(0, (int)(yloc));//04/08/23 moved the '20*' from here to frm_main so more obvious

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

                    if (bIsSelected)
                    {
                        g.DrawEllipse(SelectPen, ldist + ROBOT_WIDTH + rdist, 0, 3, 3);
                    }
                }
                else
                {
                    g.DrawEllipse(TooFarPen, ldist + ROBOT_WIDTH + rdist, 0, 3, 3);
                }

                //draw rectangle rotated by hdgdeg deg
                g.TranslateTransform(ldist, 0);
                g.RotateTransform(-hdgdeg);
                g.DrawRectangle(RobotPen, 0, 0, 20, 10);

                last_good_ldist = ldist;

            }
            else if (ldist >= MAX_LR_DIST && rdist < MAX_LR_DIST)
            {
                g.DrawEllipse(RightPen, last_good_ldist + ROBOT_WIDTH + rdist, 0, 3, 3);
                g.DrawRectangle(TooFarPen, 0, 0, 1, 3);
            }

            g.Restore(transState);

            //another try at upright text
            GraphicsState txt_transState = g.Save();

            g.TranslateTransform(0, (int)(yloc));//04/08/23 moved the '20*' from here to frm_main so more obvious
            g.ScaleTransform(1, -1);
            Brush brush = new SolidBrush(Color.Black);
            float sec = yloc / 20;
            g.DrawString(sec.ToString(), new Font("Arial", 8), brush, new PointF(0, 0));
            g.Restore(txt_transState);

            //g.Restore(transState);

        }
    }

    //void drawArrow(int cx, int cy, int len, float angle){
    //  pushMatrix();
    //  translate(cx, cy);
    //  rotate(radians(angle));
    //  line(0,0,len, 0);
    //  line(len, 0, len - 8, -8);
    //  line(len, 0, len - 8, 8);
    //  popMatrix();
    //}
}
