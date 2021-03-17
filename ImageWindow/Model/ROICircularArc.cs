using System;
using HalconDotNet;
using System.Xml.Serialization;
namespace ViewWindow.Model
{

	/// <summary>
	/// This class implements an ROI shaped as a circular
	/// arc. ROICircularArc inherits from the base class ROI and 
	/// implements (besides other auxiliary methods) all virtual methods 
	/// defined in ROI.cs.
	/// </summary>
	public class ROICircularArc : ROI
	{
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

        [XmlElement(ElementName = "StartPhi")]
        public double StartPhi
        {
            get { return this.startPhi; }
            set { this.startPhi = value; }
        }
        [XmlElement(ElementName = "ExtentPhi")]
        public double ExtentPhi
        {
            get { return this.extentPhi; }
            set { this.extentPhi = value; }
        }
		//handles
		private double midR, midC;       // 0. handle: midpoint
		private double sizeR, sizeC;     // 1. handle        
		private double startR, startC;   // 2. handle
		private double extentR, extentC; // 3. handle

		//model data to specify the arc
		private double radius;
		private double startPhi, extentPhi; // -2*PI <= x <= 2*PI

		//display attributes
		private HXLDCont  contour;
		private HXLDCont  arrowHandleXLD;
		private string    circDir;
		private double    TwoPI;
		private double    PI;


		public ROICircularArc()
		{
			NumHandles = 4;         // midpoint handle + three handles on the arc
			activeHandleIdx = 0;
			contour = new HXLDCont();
			circDir = "";

			TwoPI = 2 * Math.PI;
			PI = Math.PI;

			arrowHandleXLD = new HXLDCont();
			arrowHandleXLD.GenEmptyObj();
		}
        public ROICircularArc(double row, double col, double radius, double startPhi, double extentPhi)
        {
            createCircularArc(row, col, radius, startPhi, extentPhi, "positive");
        }

        public override void createCircularArc(double row, double col, double radius, double startPhi, double extentPhi,string direct)
        {
            base.createCircularArc(row, col, radius, startPhi, extentPhi, direct);
            midR = row;
            midC = col;

            this.radius = radius;


            sizeR = midR;
            sizeC = midC - radius;

            this.startPhi = startPhi;
            if (direct == "positive")
            {
                this.extentPhi = extentPhi;
            }
            else
            {
                this.extentPhi = extentPhi;
            }
           // circDir = "positive";
            circDir = direct;
            determineArcHandles();
            updateArrowHandle();
        }
		/// <summary>Creates a new ROI instance at the mouse position</summary>
		public override void createROI(double midX, double midY)
		{
			midR = midY;
			midC = midX;

			radius = 100;

			sizeR = midR;
			sizeC = midC - radius;

			startPhi = PI * 0.25;
			extentPhi = PI * 1.5;
			circDir = "positive";

			determineArcHandles();
			updateArrowHandle();
		}
      
		/// <summary>Paints the ROI into the supplied window</summary>
		/// <param name="window">HALCON window</param>
        public override void draw(HalconDotNet.HWindow window, int imageWidth, int imageHeight)
		{
			contour.Dispose();
			contour.GenCircleContourXld(midR, midC, radius, startPhi,
										(startPhi + extentPhi), circDir, 1.0);
            double littleRecSize = 0;
            if (imageHeight < 300) littleRecSize = 1;
            else if (imageHeight < 600) littleRecSize = 2;
            else if (imageHeight < 900) littleRecSize = 3;
            else if (imageHeight < 1200) littleRecSize = 4;
            else if (imageHeight < 1500) littleRecSize = 5;
            else if (imageHeight < 1800) littleRecSize = 6;
            else if (imageHeight < 2100) littleRecSize = 7;
            else if (imageHeight < 2400) littleRecSize = 8;
            else if (imageHeight < 2700) littleRecSize = 9;
            else if (imageHeight < 3000) littleRecSize = 10;
            else if (imageHeight < 3300) littleRecSize = 11;
            else if (imageHeight < 3600) littleRecSize = 12;
            else if (imageHeight < 3900) littleRecSize = 13;
            else if (imageHeight < 4200) littleRecSize = 14;
            else if (imageHeight < 4500) littleRecSize = 15;
            else if (imageHeight < 4800) littleRecSize = 16;
            else if (imageHeight < 5100) littleRecSize = 17;
            else littleRecSize = 18;

			window.DispObj(contour);
            window.DispRectangle2(sizeR, sizeC, 0, littleRecSize, littleRecSize);
            window.DispRectangle2(midR, midC, 0, littleRecSize, littleRecSize);
            window.DispRectangle2(startR, startC, startPhi, littleRecSize, littleRecSize);
            window.DispRectangle2(extentR , extentC , 0, littleRecSize, littleRecSize);
            window.DispLine(startR, startC, midR, midC);
            window.DispLine(extentR  , extentC , midR, midC);
		}

		/// <summary> 
		/// Returns the distance of the ROI handle being
		/// closest to the image point(x,y)
		/// </summary>
		public override double distToClosestHandle(double x, double y)
		{
			double max = 10000;
			double [] val = new double[NumHandles];

			val[0] = HMisc.DistancePp(y, x, midR, midC);       // midpoint 
			val[1] = HMisc.DistancePp(y, x, sizeR, sizeC);     // border handle 
			val[2] = HMisc.DistancePp(y, x, startR, startC);   // border handle 
			val[3] = HMisc.DistancePp(y, x, extentR, extentC); // border handle 

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
        public override void displayActive(HalconDotNet.HWindow window, int imageWidth, int imageHeight)
		{
            double littleRecSize = 0;
            if (imageHeight < 300) littleRecSize = 1;
            else if (imageHeight < 600) littleRecSize = 2;
            else if (imageHeight < 900) littleRecSize = 3;
            else if (imageHeight < 1200) littleRecSize = 4;
            else if (imageHeight < 1500) littleRecSize = 5;
            else if (imageHeight < 1800) littleRecSize = 6;
            else if (imageHeight < 2100) littleRecSize = 7;
            else if (imageHeight < 2400) littleRecSize = 8;
            else if (imageHeight < 2700) littleRecSize = 9;
            else if (imageHeight < 3000) littleRecSize = 10;
            else if (imageHeight < 3300) littleRecSize = 11;
            else if (imageHeight < 3600) littleRecSize = 12;
            else if (imageHeight < 3900) littleRecSize = 13;
            else if (imageHeight < 4200) littleRecSize = 14;
            else if (imageHeight < 4500) littleRecSize = 15;
            else if (imageHeight < 4800) littleRecSize = 16;
            else if (imageHeight < 5100) littleRecSize = 17;
            else littleRecSize = 18;

			switch (activeHandleIdx)
			{
				case 0:
                    window.DispRectangle2(midR, midC, 0, littleRecSize, littleRecSize);
					break;
				case 1:
                    window.DispRectangle2(sizeR, sizeC, 0, littleRecSize, littleRecSize);
					break;
				case 2:
                    window.DispRectangle2(startR, startC, startPhi, littleRecSize, littleRecSize);
					break;
				case 3:
                    window.DispRectangle2(extentR , extentC , 0, littleRecSize, littleRecSize);
					break;
			}
		}

		/// <summary> 
		/// Recalculates the shape of the ROI. Translation is 
		/// performed at the active handle of the ROI object 
		/// for the image coordinate (x,y)
		/// </summary>
        public override void moveByHandle(double newX, double newY, HWindowControl window)
		{
			HTuple distance;
			double dirX, dirY, prior, next, valMax, valMin;

			switch (activeHandleIdx)
			{
				case 0: // midpoint 
					dirY = midR - newY;
					dirX = midC - newX;

					midR = newY;
					midC = newX;

					sizeR -= dirY;
					sizeC -= dirX;

					determineArcHandles();
					break;

				case 1: // handle at circle border                  
					sizeR = newY;
					sizeC = newX;

					HOperatorSet.DistancePp(new HTuple(sizeR), new HTuple(sizeC),
											new HTuple(midR), new HTuple(midC), out distance);
					radius = distance[0].D;
					determineArcHandles();
					break;

				case 2: // start handle for arc                
					dirY = newY - midR;
					dirX = newX - midC;

					startPhi = Math.Atan2(-dirY, dirX);

					if (startPhi < 0)
						startPhi = PI + (startPhi + PI);

					setStartHandle();
					prior = extentPhi;
					extentPhi = HMisc.AngleLl(midR, midC, startR, startC, midR, midC, extentR, extentC);

					if (extentPhi < 0 && prior > PI * 0.8)
						extentPhi = (PI + extentPhi) + PI;
					else if (extentPhi > 0 && prior < -PI * 0.7)
						extentPhi = -PI - (PI - extentPhi);

					break;

				case 3: // end handle for arc
					dirY = newY - midR;
					dirX = newX - midC;

					prior = extentPhi;
					next = Math.Atan2(-dirY, dirX);

					if (next < 0)
						next = PI + (next + PI);

					if (circDir == "positive" && startPhi >= next)
						extentPhi = (next + TwoPI) - startPhi;
					else if (circDir == "positive" && next > startPhi)
						extentPhi = next - startPhi;
					else if (circDir == "negative" && startPhi >= next)
						extentPhi = -1.0 * (startPhi - next);
					else if (circDir == "negative" && next > startPhi)
						extentPhi = -1.0 * (startPhi + TwoPI - next);

					valMax = Math.Max(Math.Abs(prior), Math.Abs(extentPhi));
					valMin = Math.Min(Math.Abs(prior), Math.Abs(extentPhi));

					if ((valMax - valMin) >= PI)
						extentPhi = (circDir == "positive") ? -1.0 * valMin : valMin;

					setExtentHandle();
					break;
			}

			circDir = (extentPhi < 0) ? "negative" : "positive";
			updateArrowHandle();
		}

		/// <summary>Gets the HALCON region described by the ROI</summary>
		public override HRegion getRegion()
		{
			HRegion region;
			contour.Dispose();
			contour.GenCircleContourXld(midR, midC, radius, startPhi, (startPhi + extentPhi), circDir, 1.0);
			region = new HRegion(contour);
			return region;
		}

		/// <summary>
		/// Gets the model information described by the ROI
		/// </summary> 
		public override HTuple getModelData()
		{
			return new HTuple(new double[] { midR, midC, radius, startPhi, extentPhi });
		}

		/// <summary>
		/// Auxiliary method to determine the positions of the second and
		/// third handle.
		/// </summary>
		private void determineArcHandles()
		{
			setStartHandle();
			setExtentHandle();
		}

		/// <summary> 
		/// Auxiliary method to recalculate the start handle for the arc 
		/// </summary>
		private void setStartHandle()
		{
			startR = midR - radius * Math.Sin(startPhi);
			startC = midC + radius * Math.Cos(startPhi);
		}

		/// <summary>
		/// Auxiliary method to recalculate the extent handle for the arc
		/// </summary>
		private void setExtentHandle()
		{
			extentR = midR - radius * Math.Sin(startPhi + extentPhi);
			extentC = midC + radius * Math.Cos(startPhi + extentPhi);
		}

		/// <summary>
		/// Auxiliary method to display an arrow at the extent arc position
		/// </summary>
		private void updateArrowHandle()
		{
			double row1, col1, row2, col2;
			double rowP1, colP1, rowP2, colP2;
			double length,dr,dc, halfHW, sign, angleRad;
			double headLength = 15;
			double headWidth  = 15;

			arrowHandleXLD.Dispose();
			arrowHandleXLD.GenEmptyObj();

			row2 = extentR;
			col2 = extentC;
			angleRad = (startPhi + extentPhi) + Math.PI * 0.5;

			sign = (circDir == "negative") ? -1.0 : 1.0;
			row1 = row2 + sign * Math.Sin(angleRad) * 20;
			col1 = col2 - sign * Math.Cos(angleRad) * 20;

			length = HMisc.DistancePp(row1, col1, row2, col2);
			if (length == 0)
				length = -1;

			dr = (row2 - row1) / length;
			dc = (col2 - col1) / length;

			halfHW = headWidth / 2.0;
			rowP1 = row1 + (length - headLength) * dr + halfHW * dc;
			rowP2 = row1 + (length - headLength) * dr - halfHW * dc;
			colP1 = col1 + (length - headLength) * dc - halfHW * dr;
			colP2 = col1 + (length - headLength) * dc + halfHW * dr;

			if (length == -1)
				arrowHandleXLD.GenContourPolygonXld(row1, col1);
			else
				arrowHandleXLD.GenContourPolygonXld(new HTuple(new double[] { row1, row2, rowP1, row2, rowP2, row2 }),
					new HTuple(new double[] { col1, col2, colP1, col2, colP2, col2 }));
		}

	}//end of class
}//end of namespace

