using System;
using HalconDotNet;
using System.Xml.Serialization;

namespace ViewWindow.Model
{
	/// <summary>
	/// This class demonstrates one of the possible implementations for a 
	/// circular ROI. ROICircle inherits from the base class ROI and 
	/// implements (besides other auxiliary methods) all virtual methods 
	/// defined in ROI.cs.
	/// </summary>
    [Serializable]
	public class ROICircle : ROI
	{

        [XmlElement(ElementName = "Row")]
        public double Row
        {
            get { return this.midR; }
            set { this.midR = value; }
        }

        [XmlElement(ElementName = "Column")]
        public double Column
        {
            get { return this.midC; }
            set { this.midC = value; }
        }
        [XmlElement(ElementName = "Radius")]
        public double Radius
        {
            get { return this.radius; }
            set { this.radius = value; }
        }


		private double radius;
		private double row1, col1;  // first handle
		private double midR, midC;  // second handle


		public ROICircle()
		{
			NumHandles = 2; // one at corner of circle + midpoint
			activeHandleIdx = 1;
		}

        public ROICircle(double row, double col, double radius)
        {
            createCircle(row, col, radius);
        }

        public override void createCircle(double row, double col, double radius)
        {
            base.createCircle(row, col, radius);
            midR = row;
            midC = col;

            this.radius = radius;

            row1 = midR;
            col1 = midC + radius;
        }

		/// <summary>Creates a new ROI instance at the mouse position</summary>
		public override void createROI(double midX, double midY)
		{
			midR = midY;
			midC = midX;

			radius = 100;

			row1 = midR;
			col1 = midC + radius;
		}

		/// <summary>Paints the ROI into the supplied window</summary>
		/// <param name="window">HALCON window</param>
		public override void draw(HalconDotNet.HWindow window)
		{
			window.DispCircle(midR, midC, radius);
			window.DispRectangle2(row1, col1, 0, 8, 8);
			window.DispRectangle2(midR, midC, 0, 8, 8);
		}

		/// <summary> 
		/// Returns the distance of the ROI handle being
		/// closest to the image point(x,y)
		/// </summary>
		public override double distToClosestHandle(double x, double y)
		{
			double max = 10000;
			double [] val = new double[NumHandles];

			val[0] = HMisc.DistancePp(y, x, row1, col1); // border handle 
			val[1] = HMisc.DistancePp(y, x, midR, midC); // midpoint 

			for (int i=0; i < NumHandles; i++)
			{
				if (val[i] < max)
				{
					max = val[i];
					activeHandleIdx = i;
				}
			}// end of for 
			return val[activeHandleIdx];
		}

		/// <summary> 
		/// Paints the active handle of the ROI object into the supplied window 
		/// </summary>
		public override void displayActive(HalconDotNet.HWindow window)
		{

			switch (activeHandleIdx)
			{
				case 0:
					window.DispRectangle2(row1, col1, 0, 8, 8);
					break;
				case 1:
					window.DispRectangle2(midR, midC, 0, 8, 8);
					break;
			}
		}

		/// <summary>Gets the HALCON region described by the ROI</summary>
		public override HRegion getRegion()
		{
			HRegion region = new HRegion();
			region.GenCircle(midR, midC, radius);
			return region;
		}

		public override double getDistanceFromStartPoint(double row, double col)
		{
			double sRow = midR; // assumption: we have an angle starting at 0.0
			double sCol = midC + 1 * radius;

			double angle = HMisc.AngleLl(midR, midC, sRow, sCol, midR, midC, row, col);

			if (angle < 0)
				angle += 2 * Math.PI;

			return (radius * angle);
		}

		/// <summary>
		/// Gets the model information described by 
		/// the  ROI
		/// </summary> 
		public override HTuple getModelData()
		{
			return new HTuple(new double[] { midR, midC, radius });
		}

		/// <summary> 
		/// Recalculates the shape of the ROI. Translation is 
		/// performed at the active handle of the ROI object 
		/// for the image coordinate (x,y)
		/// </summary>
		public override void moveByHandle(double newX, double newY)
		{
			HTuple distance;
			double shiftX,shiftY;

			switch (activeHandleIdx)
			{
				case 0: // handle at circle border

					row1 = newY;
					col1 = newX;
					HOperatorSet.DistancePp(new HTuple(row1), new HTuple(col1),
											new HTuple(midR), new HTuple(midC),
											out distance);

					radius = distance[0].D;
					break;
				case 1: // midpoint 

					shiftY = midR - newY;
					shiftX = midC - newX;

					midR = newY;
					midC = newX;

					row1 -= shiftY;
					col1 -= shiftX;
					break;
			}
		}
	}//end of class
}//end of namespace
