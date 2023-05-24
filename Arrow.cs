using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RobotTelemetryViewer.Frame;

namespace RobotTelemetryViewer
{
    internal class Arrow
    {
		private int stemlengthMM;

		public int StemLength
		{
			get { return stemlengthMM; }
			set { stemlengthMM = value; }
		}

		private float headangledeg;

		public float HeadAngDeg
		{
			get { return headangledeg; }
			set { headangledeg = value; }
		}

		private int headlengthMM;

		public int HeadLength
		{
			get { return headlengthMM; }
			set { headlengthMM = value; }
		}

        //private TRKDIR trkdir;
        //public TRKDIR TrackDir
        //{
        //    get { return trkdir; }
        //    set { trkdir = value; }
        //}

        private const int Default_Head_Length_MM = 3;
		private const int Default_Stem_Length_MM = 5;
		private const int Default_Head_Angle_Deg = 30;

		public Arrow(int stemlengthMM = Default_Stem_Length_MM, 
			float headangledeg = Default_Head_Angle_Deg,
            int headlengthMM = Default_Head_Length_MM)
        {
            this.stemlengthMM = stemlengthMM;
            this.headangledeg = headangledeg;
            this.headlengthMM = headlengthMM;
        }

		public void Draw(Pen pen, float yloc, Graphics g)
		{
            //arrow is drawn with the stem aligned with the view's Y (vertical) axis
			Point s1 = new Point(0,0);
			Point s2 = new Point(0,stemlengthMM);
			g.DrawLine(pen, s1, s2);

			Point h1 = s2;
			double headangrad = Math.PI * (headangledeg / 180.0);
			double coslen = headlengthMM * Math.Cos((double)headangrad);
			double sinlen = headlengthMM * Math.Sin((double)headangrad);
			Point h2 = new Point(s2.X - (int)sinlen, s2.Y-(int)coslen);
            g.DrawLine(pen, h2, s2);
            g.DrawLine(pen, new Point(-h2.X, h2.Y), s2);
        }
    }
}
