using System;
using HalconDotNet;
using System.Xml.Serialization;

namespace ViewWindow.Model
{
	/// <summary>
	/// This class demonstrates one of the possible implementations for a 
	/// linear ROI. ROILine inherits from the base class ROI and 
	/// implements (besides other auxiliary methods) all virtual methods 
	/// defined in ROI.cs.
	/// </summary>
    [Serializable]
    public class ROILine : ROI
	{

        [XmlElement(ElementName = "RowBegin")]
        public double RowBegin
        {
            get { return this.row1; }
            set { this.row1 = value; }
        }

        [XmlElement(ElementName = "ColumnBegin")]
        public double ColumnBegin
        {
            get { return this.col1; }
            set { this.col1 = value; }
        }
        [XmlElement(ElementName = "RowEnd")]
        public double RowEnd
        {
            get { return this.row2; }
            set { this.row2 = value; }
        }

        [XmlElement(ElementName = "ColumnEnd")]
        public double ColumnEnd
        {
            get { return this.col2; }
            set { this.col2 = value; }
        }

		private double row1, col1;   // first end point of line
		private double row2, col2;   // second end point of line
		private double midR, midC;   // midPoint of line

		private HObject arrowHandleXLD;

		public ROILine()
		{
			NumHandles = 3;        // two end points of line
			activeHandleIdx = 2;
			arrowHandleXLD = new HXLDCont();
			arrowHandleXLD.GenEmptyObj();
		}

        public ROILine(double beginRow, double beginCol, double endRow, double endCol)
        {
            createLine(beginRow, beginCol, endRow, endCol);
        }
        
        public override void createLine(double beginRow, double beginCol, double endRow, double endCol)
        {
            base.createLine(beginRow, beginCol, endRow, endCol);
            
            row1 = beginRow;
            col1 = beginCol;
            row2 = endRow;
            col2 = endCol;

            midR = (row1 + row2) / 2.0;
            midC = (col1 + col2) / 2.0;

            updateArrowHandle();
        }

		/// <summary>Creates a new ROI instance at the mouse position.</summary>
		public override void createROI(double midX, double midY)
		{
			midR = midY;
			midC = midX;

			row1 = midR;
			col1 = midC - 50;
			row2 = midR;
			col2 = midC + 50;

			updateArrowHandle();
		}
		/// <summary>Paints the ROI into the supplied window.</summary>
		public override void draw(HalconDotNet.HWindow window)
		{

			window.DispLine(row1, col1, row2, col2);

			window.DispRectangle2(row1, col1, 0, 8, 8);
			window.DispObj(arrowHandleXLD);  //window.DispRectangle2( row2, col2, 0, 25, 25);
			window.DispRectangle2(midR, midC, 0, 8, 8);
		}

		/// <summary> 
		/// Returns the distance of the ROI handle being
		/// closest to the image point(x,y).
		/// </summary>
		public override double distToClosestHandle(double x, double y)
		{

			double max = 10000;
			double [] val = new double[NumHandles];

			val[0] = HMisc.DistancePp(y, x, row1, col1); // upper left 
			val[1] = HMisc.DistancePp(y, x, row2, col2); // upper right 
			val[2] = HMisc.DistancePp(y, x, midR, midC); // midpoint 

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
		/// Paints the active handle of the ROI object into the supplied window. 
		/// </summary>
		public override void displayActive(HalconDotNet.HWindow window)
		{

			switch (activeHandleIdx)
			{
				case 0:
					window.DispRectangle2(row1, col1, 0, 8, 8);
					break;
				case 1:
					window.DispObj(arrowHandleXLD); //window.DispRectangle2(row2, col2, 0, 25, 25);
					break;
				case 2:
					window.DispRectangle2(midR, midC, 0, 8, 8);
					break;
			}
		}

		/// <summary>Gets the HALCON region described by the ROI.</summary>
		public override HRegion getRegion()
		{
			HRegion region = new HRegion();
			region.GenRegionLine(row1, col1, row2, col2);
			return region;
		}

		public override double getDistanceFromStartPoint(double row, double col)
		{
			double distance = HMisc.DistancePp(row, col, row1, col1);
			return distance;
		}
		/// <summary>
		/// Gets the model information described by 
		/// the ROI.
		/// </summary> 
		public override HTuple getModelData()
		{
			return new HTuple(new double[] { row1, col1, row2, col2 });
		}

		/// <summary> 
		/// Recalculates the shape of the ROI. Translation is 
		/// performed at the active handle of the ROI object 
		/// for the image coordinate (x,y).
		/// </summary>
		public override void moveByHandle(double newX, double newY)
		{
			double lenR, lenC;

			switch (activeHandleIdx)
			{
				case 0: // first end point
					row1 = newY;
					col1 = newX;

					midR = (row1 + row2) / 2;
					midC = (col1 + col2) / 2;
					break;
				case 1: // last end point
					row2 = newY;
					col2 = newX;

					midR = (row1 + row2) / 2;
					midC = (col1 + col2) / 2;
					break;
				case 2: // midpoint 
					lenR = row1 - midR;
					lenC = col1 - midC;

					midR = newY;
					midC = newX;

					row1 = midR + lenR;
					col1 = midC + lenC;
					row2 = midR - lenR;
					col2 = midC - lenC;
					break;
			}
		     updateArrowHandle();
		}


		/// <summary> Auxiliary method </summary>
		private void updateArrowHandle()
		{
			double length,dr,dc, halfHW;
			double rrow1, ccol1,rowP1, colP1, rowP2, colP2;

			double headLength = 16;
			double headWidth  = 16;


			arrowHandleXLD.Dispose();
			arrowHandleXLD.GenEmptyObj();

			rrow1 = row1 + (row2 - row1) * 0.9;
			ccol1 = col1 + (col2 - col1) * 0.9;

			length = HMisc.DistancePp(rrow1, ccol1, row2, col2);
			if (length == 0)
				length = -1;

			dr = (row2 - rrow1) / length;
			dc = (col2 - ccol1) / length;

			halfHW = headWidth / 2.0;
			rowP1 = rrow1 + (length - headLength) * dr + halfHW * dc;
			rowP2 = rrow1 + (length - headLength) * dr - halfHW * dc;
			colP1 = ccol1 + (length - headLength) * dc - halfHW * dr;
			colP2 = ccol1 + (length - headLength) * dc + halfHW * dr;

			if (length == -1)
                HOperatorSet.GenContourPolygonXld(out arrowHandleXLD,rrow1, ccol1);
			else
                HOperatorSet.GenContourPolygonXld(out arrowHandleXLD, new HTuple(new double[] { rrow1, row2, rowP1, row2, rowP2, row2 }),
                                                    new HTuple(new double[] { ccol1, col2, colP1, col2, colP2, col2 }));
		}

	}//end of class
}//end of namespace
