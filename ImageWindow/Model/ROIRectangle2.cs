using System;
using HalconDotNet;
using System.Xml.Serialization;
using System.Windows.Forms;

namespace ViewWindow.Model
{

	/// <summary>
	/// This class demonstrates one of the possible implementations for a 
	/// (simple) rectangularly shaped ROI. To create this rectangle we use 
	/// a center point (midR, midC), an orientation 'phi' and the half 
	/// edge lengths 'length1' and 'length2', similar to the HALCON 
	/// operator gen_rectangle2(). 
	/// The class ROIRectangle2 inherits from the base class ROI and 
	/// implements (besides other auxiliary methods) all virtual methods 
	/// defined in ROI.cs.
	/// </summary>
    [Serializable]
    public class ROIRectangle2 : ROI
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
        [XmlElement(ElementName = "Phi")]
        public double Phi
        {
            get { return this.phi; }
            set { this.phi = value; }
        }

        [XmlElement(ElementName = "Length1")]
        public double Lenth1
        {
            get { return this.length1; }
            set { this.length1 = value; }
        }

        [XmlElement(ElementName = "Length2")]
        public double Lenth2
        {
            get { return this.length2; }
            set { this.length2 = value; }
        }
		/// <summary>Half length of the rectangle side, perpendicular to phi</summary>
		private double length1;

		/// <summary>Half length of the rectangle side, in direction of phi</summary>
		private double length2;

		/// <summary>Row coordinate of midpoint of the rectangle</summary>
		private double midR;

		/// <summary>Column coordinate of midpoint of the rectangle</summary>
		private double midC;

		/// <summary>Orientation of rectangle defined in radians.</summary>
		private double phi;


		//auxiliary variables
		HTuple rowsInit;
		HTuple colsInit;
	public 	HTuple rows;
    public HTuple cols;

		HHomMat2D hom2D, tmp;

		/// <summary>Constructor</summary>
		public ROIRectangle2()
		{
			NumHandles = 10; // 4 corners +  1 midpoint + 1 rotationpoint			
			activeHandleIdx = 4;
		}

        public ROIRectangle2(double row, double col, double phi, double length1, double length2)
        {
            createRectangle2(row, col, phi, length1, length2);
        }

        public override void createRectangle2(double row, double col, double phi, double length1, double length2)
        {
            base.createRectangle2(row, col, phi, length1, length2);
            this.midR = row;
            this.midC = col;
            this.length1 = length1;
            this.length2 = length2;
            this.phi = phi;

            rowsInit = new HTuple(new double[] {-1.0, -1.0, 1.0, 
												   1.0,  0.0, 0.0 ,0,-1,0,1});
            colsInit = new HTuple(new double[] {-1.0, 1.0,  1.0, 
												  -1.0, 0.0, 1.8 ,-1,0,1,0});
            //order        ul ,  ur,   lr,  ll,   mp, arrowMidpoint
            hom2D = new HHomMat2D();
            tmp = new HHomMat2D();

            updateHandlePos();
        }
        public override void createInitRectangle2(double imageHeight)
        {
            double size = 0;
            if (imageHeight < 300) size = 10;
            else if (imageHeight < 600) size = 20;
            else if (imageHeight < 900) size = 30;
            else if (imageHeight < 1200) size = 40;
            else if (imageHeight < 1500) size = 50;
            else if (imageHeight < 1800) size = 60;
            else if (imageHeight < 2100) size = 70;
            else if (imageHeight < 2400) size = 80;
            else if (imageHeight < 2700) size = 90;
            else if (imageHeight < 3000) size = 100;
            else if (imageHeight < 3300) size = 110;
            else if (imageHeight < 3600) size = 120;
            else if (imageHeight < 3900) size = 130;
            else if (imageHeight < 4200) size = 140;
            else if (imageHeight < 4500) size = 150;
            else if (imageHeight < 4800) size = 160;
            else if (imageHeight < 5100) size = 170;
            else size = 180;
            double length1 = size * 3;
            double length2 = size * 4;

            base.createRectangle2(midR , midC , phi, length1, length2);
            this.midR = midR ;
            this.midC = midC ;
            this.length1 = length1;
            this.length2 = length2;
            this.phi = phi;

            rowsInit = new HTuple(new double[] {-1.0, -1.0, 1.0, 
												   1.0,  0.0, 0.0 ,0,-1,0,1});
            colsInit = new HTuple(new double[] {-1.0, 1.0,  1.0, 
												  -1.0, 0.0, 1.8 ,-1,0,1,0});
            //order        ul ,  ur,   lr,  ll,   mp, arrowMidpoint
            hom2D = new HHomMat2D();
            tmp = new HHomMat2D();

            updateHandlePos();
        }

		/// <summary>Creates a new ROI instance at the mouse position</summary>
		/// <param name="midX">
		/// x (=column) coordinate for interactive ROI
		/// </param>
		/// <param name="midY">
		/// y (=row) coordinate for interactive ROI
		/// </param>
		public override void createROI(double midX, double midY)
		{
			midR = midY;
			midC = midX;

			length1 = 100;
			length2 = 50;

			phi = 0.0;

			rowsInit = new HTuple(new double[] {-1.0, -1.0, 1.0, 
												   1.0,  0.0, 0.0 });
			colsInit = new HTuple(new double[] {-1.0, 1.0,  1.0, 
												  -1.0, 0.0, 1.8 });
			//order        ul ,  ur,   lr,  ll,   mp, arrowMidpoint
			hom2D = new HHomMat2D();
			tmp = new HHomMat2D();

			updateHandlePos();
		}

		/// <summary>Paints the ROI into the supplied window</summary>
		/// <param name="window">HALCON window</param>
        public override void draw(HalconDotNet.HWindow window, int imageWidth, int imageHeight)
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

            if (littleRecSize % 2 != 0)
                littleRecSize++;

            HOperatorSet.SetDraw(window, "margin");
         
			window.DispRectangle2(midR, midC, -phi, length1, length2);
            HOperatorSet.SetDraw(window, "fill");

            for (int i = 0; i < NumHandles; i++)
            {
                window.DispRectangle2(rows[i].D, cols[i].D, -phi, littleRecSize, littleRecSize);
                Application.DoEvents();
            }

			window.DispArrow(midR, midC, midR + (Math.Sin(phi) * length1 * 1.8),
                midC + (Math.Cos(phi) * length1 * 1.8), littleRecSize);

		}

		/// <summary> 
		/// Returns the distance of the ROI handle being
		/// closest to the image point(x,y)
		/// </summary>
		/// <param name="x">x (=column) coordinate</param>
		/// <param name="y">y (=row) coordinate</param>
		/// <returns> 
		/// Distance of the closest ROI handle.
		/// </returns>
		public override double distToClosestHandle(double x, double y)
		{
			double max = 10000;
			double [] val = new double[NumHandles];


			for (int i=0; i < NumHandles; i++)
				val[i] = HMisc.DistancePp(y, x, rows[i].D, cols[i].D);

			for (int i=0; i < NumHandles; i++)
			{
				if (val[i] < max)
				{
					max = val[i];
					activeHandleIdx = i;
				}
			}
			return val[activeHandleIdx];
		}

		/// <summary> 
		/// Paints the active handle of the ROI object into the supplied window
		/// </summary>
		/// <param name="window">HALCON window</param>
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

            if (littleRecSize % 2 != 0)
                littleRecSize++;


			window.DispRectangle2(rows[activeHandleIdx].D,
								  cols[activeHandleIdx].D,
                                  -phi, littleRecSize, littleRecSize);

			if (activeHandleIdx == 5)
				window.DispArrow(midR, midC,
								 midR + (Math.Sin(phi) * length1 * 1.8),
								 midC + (Math.Cos(phi) * length1 * 1.8),
                                 littleRecSize);
		}


		/// <summary>Gets the HALCON region described by the ROI</summary>
		public override HRegion getRegion()
		{
			HRegion region = new HRegion();
			region.GenRectangle2(midR, midC, -phi, length1, length2);
			return region;
		}

		/// <summary>
		/// Gets the model information described by 
		/// the interactive ROI
		/// </summary> 
		public override HTuple getModelData()
		{
			return new HTuple(new double[] { midR, midC, phi, length1, length2 });
		}
        public override HTuple getRowsData()
        {
            return new HTuple(rows);
        }
        public override HTuple getColsData()
        {
            return new HTuple(cols );
        }

		/// <summary> 
		/// Recalculates the shape of the ROI instance. Translation is 
		/// performed at the active handle of the ROI object 
		/// for the image coordinate (x,y)
		/// </summary>
		/// <param name="newX">x mouse coordinate</param>
		/// <param name="newY">y mouse coordinate</param>
        public override void moveByHandle(double newX, double newY, HWindowControl window)
		{
			double vX, vY, x=0, y=0;

			switch (activeHandleIdx)
			{
				case 0:
				case 1:
				case 2:
				case 3:
             
					tmp = hom2D.HomMat2dInvert();
					x = tmp.AffineTransPoint2d(newX, newY, out y);

					length2 = Math.Abs(y);
					length1 = Math.Abs(x);

					checkForRange(x, y);
                    window.Cursor = System.Windows.Forms.Cursors.Hand  ;
					break;
				case 4:
					midC = newX;
					midR = newY;
                    window.Cursor = System.Windows.Forms.Cursors.SizeAll ;
					break;
				case 5:
					vY = newY - rows[4].D;
					vX = newX - cols[4].D;
					phi = Math.Atan2(vY, vX);
                    window.Cursor = System.Windows.Forms.Cursors.Hand;
					break;
                case 7:
                case 9:
                          		tmp = hom2D.HomMat2dInvert();
					x = tmp.AffineTransPoint2d(newX, newY, out y);

				
				
                    length2 = Math.Abs(y);

					checkForRange(x, y);
                    window.Cursor = System.Windows.Forms.Cursors.Hand;
					break;
                case 6:
                case 8:
                    		tmp = hom2D.HomMat2dInvert();
					x = tmp.AffineTransPoint2d(newX, newY, out y);


                    length1 = Math.Abs(x);
					checkForRange(x, y);
                    window.Cursor = System.Windows.Forms.Cursors.Hand;
					break;
			}
			updateHandlePos();
		}//end of method


		/// <summary>
		/// Auxiliary method to recalculate the contour points of 
		/// the rectangle by transforming the initial row and 
		/// column coordinates (rowsInit, colsInit) by the updated
		/// homography hom2D
		/// </summary>
		private void updateHandlePos()
		{
			hom2D.HomMat2dIdentity();
			hom2D = hom2D.HomMat2dTranslate(midC, midR);
			hom2D = hom2D.HomMat2dRotateLocal(phi);
			tmp = hom2D.HomMat2dScaleLocal(length1, length2);
			cols = tmp.AffineTransPoint2d(colsInit, rowsInit, out rows);
		}


		/* This auxiliary method checks the half lengths 
		 * (length1, length2) using the coordinates (x,y) of the four 
		 * rectangle corners (handles 0 to 3) to avoid 'bending' of 
		 * the rectangular ROI at its midpoint, when it comes to a
		 * 'collapse' of the rectangle for length1=length2=0.
		 * */
		private void checkForRange(double x, double y)
		{
			switch (activeHandleIdx)
			{
				case 0:
					if ((x < 0) && (y < 0))
						return;
					if (x >= 0) length1 = 0.01;
					if (y >= 0) length2 = 0.01;
					break;
				case 1:
					if ((x > 0) && (y < 0))
						return;
					if (x <= 0) length1 = 0.01;
					if (y >= 0) length2 = 0.01;
					break;
				case 2:
					if ((x > 0) && (y > 0))
						return;
					if (x <= 0) length1 = 0.01;
					if (y <= 0) length2 = 0.01;
					break;
				case 3:
					if ((x < 0) && (y > 0))
						return;
					if (x >= 0) length1 = 0.01;
					if (y <= 0) length2 = 0.01;
					break;
				default:
					break;
			}
		}
	}//end of class
}//end of namespace
