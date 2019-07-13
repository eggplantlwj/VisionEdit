using System;
using HalconDotNet;
using ViewWindow;
using System.Collections;

namespace ViewWindow.Model
{

	public delegate void FuncROIDelegate();

	/// <summary>
	/// This class creates and manages ROI objects. It responds 
	/// to  mouse device inputs using the methods mouseDownAction and 
	/// mouseMoveAction. You don't have to know this class in detail when you 
	/// build your own C# project. But you must consider a few things if 
	/// you want to use interactive ROIs in your application: There is a
	/// quite close connection between the ROIController and the HWndCtrl 
	/// class, which means that you must 'register' the ROIController
	/// with the HWndCtrl, so the HWndCtrl knows it has to forward user input
	/// (like mouse events) to the ROIController class.  
	/// The visualization and manipulation of the ROI objects is done 
	/// by the ROIController.
	/// This class provides special support for the matching
	/// applications by calculating a model region from the list of ROIs. For
	/// this, ROIs are added and subtracted according to their sign.
	/// </summary>
	public class ROIController
	{
        public bool EditModel = true;

		/// <summary>
		/// Constant for setting the ROI mode: positive ROI sign.
		/// </summary>
		public const int MODE_ROI_POS           = 21;

		/// <summary>
		/// Constant for setting the ROI mode: negative ROI sign.
		/// </summary>
		public const int MODE_ROI_NEG           = 22;

		/// <summary>
		/// Constant for setting the ROI mode: no model region is computed as
		/// the sum of all ROI objects.
		/// </summary>
		public const int MODE_ROI_NONE          = 23;

		/// <summary>Constant describing an update of the model region</summary>
		public const int EVENT_UPDATE_ROI       = 50;

		public const int EVENT_CHANGED_ROI_SIGN = 51;

		/// <summary>Constant describing an update of the model region</summary>
		public const int EVENT_MOVING_ROI       = 52;

		public const int EVENT_DELETED_ACTROI  	= 53;

		public const int EVENT_DELETED_ALL_ROIS = 54;

		public const int EVENT_ACTIVATED_ROI   	= 55;

		public const int EVENT_CREATED_ROI   	  = 56;


		private ROI     roiMode;
		private int     stateROI;
		private double  currX, currY;


		/// <summary>Index of the active ROI object</summary>
		public int      activeROIidx;
		public int      deletedIdx;

		/// <summary>List containing all created ROI objects so far</summary>
		public ArrayList ROIList;

		/// <summary>
		/// Region obtained by summing up all negative 
		/// and positive ROI objects from the ROIList 
		/// </summary>
		public HRegion ModelROI;

		private string activeCol    = "green";
		private string activeHdlCol = "red";
		private string inactiveCol  = "blue";

		/// <summary>
		/// Reference to the HWndCtrl, the ROI Controller is registered to
		/// </summary>
		public HWndCtrl viewController;

		/// <summary>
		/// Delegate that notifies about changes made in the model region
		/// </summary>
		public IconicDelegate  NotifyRCObserver;

		/// <summary>Constructor</summary>
        protected internal ROIController()
		{
			stateROI = MODE_ROI_NONE;
			ROIList = new ArrayList();
			activeROIidx = -1;
			ModelROI = new HRegion();
			NotifyRCObserver = new IconicDelegate(dummyI);
			deletedIdx = -1;
			currX = currY = -1;
		}

		/// <summary>Registers the HWndCtrl to this ROIController instance</summary>
		public void setViewController(HWndCtrl view)
		{
			viewController = view;
		}

		/// <summary>Gets the ModelROI object</summary>
		public HRegion getModelRegion()
		{
			return ModelROI;
		}

		/// <summary>Gets the List of ROIs created so far</summary>
		public ArrayList getROIList()
		{
			return ROIList;
		}

		/// <summary>Get the active ROI</summary>
		public ROI getActiveROI()
		{
            try
            {
                if (activeROIidx != -1)
                    return ((ROI)ROIList[activeROIidx]);
                return null;
            }
            catch (Exception)
            {
                return null;
            }
		}

		public int getActiveROIIdx()
		{
			return activeROIidx;
		}

		public void setActiveROIIdx(int active)
		{
			activeROIidx = active;
		}

		public int getDelROIIdx()
		{
			return deletedIdx;
		}

		/// <summary>
		/// To create a new ROI object the application class initializes a 
		/// 'seed' ROI instance and passes it to the ROIController.
		/// The ROIController now responds by manipulating this new ROI
		/// instance.
		/// </summary>
		/// <param name="r">
		/// 'Seed' ROI object forwarded by the application forms class.
		/// </param>
		public void setROIShape(ROI r)
		{
			roiMode = r;
			roiMode.setOperatorFlag(stateROI);
		}


		/// <summary>
		/// Sets the sign of a ROI object to the value 'mode' (MODE_ROI_NONE,
		/// MODE_ROI_POS,MODE_ROI_NEG)
		/// </summary>
		public void setROISign(int mode)
		{
			stateROI = mode;

			if (activeROIidx != -1)
			{
				((ROI)ROIList[activeROIidx]).setOperatorFlag(stateROI);
				viewController.repaint();
				NotifyRCObserver(ROIController.EVENT_CHANGED_ROI_SIGN);
			}
		}

		/// <summary>
		/// Removes the ROI object that is marked as active. 
		/// If no ROI object is active, then nothing happens. 
		/// </summary>
		public void removeActive()
		{
			if (activeROIidx != -1)
			{
				ROIList.RemoveAt(activeROIidx);
				deletedIdx = activeROIidx;
				activeROIidx = -1;
				viewController.repaint();
				NotifyRCObserver(EVENT_DELETED_ACTROI);
			}
		}


		/// <summary>
		/// Calculates the ModelROI region for all objects contained 
		/// in ROIList, by adding and subtracting the positive and 
		/// negative ROI objects.
		/// </summary>
		public bool defineModelROI()
		{
			HRegion tmpAdd, tmpDiff, tmp;
			double row, col;

			if (stateROI == MODE_ROI_NONE)
				return true;

			tmpAdd = new HRegion();
			tmpDiff = new HRegion();
      tmpAdd.GenEmptyRegion();
      tmpDiff.GenEmptyRegion();

			for (int i=0; i < ROIList.Count; i++)
			{
				switch (((ROI)ROIList[i]).getOperatorFlag())
				{
					case ROI.POSITIVE_FLAG:
						tmp = ((ROI)ROIList[i]).getRegion();
						tmpAdd = tmp.Union2(tmpAdd);
						break;
					case ROI.NEGATIVE_FLAG:
						tmp = ((ROI)ROIList[i]).getRegion();
						tmpDiff = tmp.Union2(tmpDiff);
						break;
					default:
						break;
				}//end of switch
			}//end of for

			ModelROI = null;

			if (tmpAdd.AreaCenter(out row, out col) > 0)
			{
				tmp = tmpAdd.Difference(tmpDiff);
				if (tmp.AreaCenter(out row, out col) > 0)
					ModelROI = tmp;
			}

			//in case the set of positiv and negative ROIs dissolve 
			if (ModelROI == null || ROIList.Count == 0)
				return false;

			return true;
		}


		/// <summary>
		/// Clears all variables managing ROI objects
		/// </summary>
		public void reset()
		{
			ROIList.Clear();
			activeROIidx = -1;
			ModelROI = null;
			roiMode = null;
			NotifyRCObserver(EVENT_DELETED_ALL_ROIS);
		}


		/// <summary>
		/// Deletes this ROI instance if a 'seed' ROI object has been passed
		/// to the ROIController by the application class.
		/// 
		/// </summary>
		public void resetROI()
		{
			activeROIidx = -1;
			roiMode = null;
		}

		/// <summary>Defines the colors for the ROI objects</summary>
		/// <param name="aColor">Color for the active ROI object</param>
		/// <param name="inaColor">Color for the inactive ROI objects</param>
		/// <param name="aHdlColor">
		/// Color for the active handle of the active ROI object
		/// </param>
		public void setDrawColor(string aColor,
								   string aHdlColor,
								   string inaColor)
		{
			if (aColor != "")
				activeCol = aColor;
			if (aHdlColor != "")
				activeHdlCol = aHdlColor;
			if (inaColor != "")
				inactiveCol = inaColor;
		}


		/// <summary>
		/// Paints all objects from the ROIList into the HALCON window
		/// </summary>
		/// <param name="window">HALCON window</param>
        internal void paintData(HalconDotNet.HWindow window)
        {
            window.SetDraw("margin");
            window.SetLineWidth(1);
            if (ROIList.Count > 0)
            {
                window.SetColor(inactiveCol);
                window.SetDraw("margin");
                for (int i = 0; i < ROIList.Count; i++)
                {
                    window.SetLineStyle(((ROI)ROIList[i]).flagLineStyle);
                    ((ROI)ROIList[i]).draw(window);
                }
                if (activeROIidx != -1)
                {
                    window.SetColor(activeCol);
                    window.SetLineStyle(((ROI)ROIList[activeROIidx]).flagLineStyle);
                    ((ROI)ROIList[activeROIidx]).draw(window);

                    window.SetColor(activeHdlCol);
                    ((ROI)ROIList[activeROIidx]).displayActive(window);
                }
            }
        }
        /// <summary>
        /// 以指定颜色显示ROI
        /// </summary>
        /// <param name="window"></param>
        internal void paintData(HalconDotNet.HWindow window,string color)
        {
            window.SetDraw("margin");
            window.SetLineWidth(1);
            if (ROIList.Count > 0)
            {
                window.SetColor(color);
                window.SetDraw("margin");
                for (int i = 0; i < ROIList.Count; i++)
                {
                    window.SetLineStyle(((ROI)ROIList[i]).flagLineStyle);
                    ((ROI)ROIList[i]).draw(window);
                }
                if (activeROIidx != -1)
                {
                    window.SetColor(color);
                    window.SetLineStyle(((ROI)ROIList[activeROIidx]).flagLineStyle);
                    ((ROI)ROIList[activeROIidx]).draw(window);

                    window.SetColor(color);
                    ((ROI)ROIList[activeROIidx]).displayActive(window);
                }
            }
        }

		/// <summary>
		/// Reaction of ROI objects to the 'mouse button down' event: changing
		/// the shape of the ROI and adding it to the ROIList if it is a 'seed'
		/// ROI.
		/// </summary>
		/// <param name="imgX">x coordinate of mouse event</param>
		/// <param name="imgY">y coordinate of mouse event</param>
		/// <returns></returns>
		public int mouseDownAction(double imgX, double imgY)
		{
			int idxROI= -1;
			double max = 10000, dist = 0;
			double epsilon = 35.0;			//maximal shortest distance to one of
			//the handles

			if (roiMode != null)			 //either a new ROI object is created
			{
				roiMode.createROI(imgX, imgY);
				ROIList.Add(roiMode);
				roiMode = null;
				activeROIidx = ROIList.Count - 1;
				viewController.repaint();

				NotifyRCObserver(ROIController.EVENT_CREATED_ROI);
			}
			else if (ROIList.Count > 0)		// ... or an existing one is manipulated
			{
				activeROIidx = -1;

				for (int i =0; i < ROIList.Count; i++)
				{
					dist = ((ROI)ROIList[i]).distToClosestHandle(imgX, imgY);
					if ((dist < max) && (dist < epsilon))
					{
						max = dist;
						idxROI = i;
					}
				}//end of for

				if (idxROI >= 0)
				{
					activeROIidx = idxROI;
					NotifyRCObserver(ROIController.EVENT_ACTIVATED_ROI);
				}

				viewController.repaint();
			}
			return activeROIidx;
		}

		/// <summary>
		/// Reaction of ROI objects to the 'mouse button move' event: moving
		/// the active ROI.
		/// </summary>
		/// <param name="newX">x coordinate of mouse event</param>
		/// <param name="newY">y coordinate of mouse event</param>
		public void mouseMoveAction(double newX, double newY)
		{
            try
            {
                if(EditModel ==false) return;
                if ((newX == currX) && (newY == currY))
                    return;

                ((ROI)ROIList[activeROIidx]).moveByHandle(newX, newY);
                viewController.repaint();
                currX = newX;
                currY = newY;
                NotifyRCObserver(ROIController.EVENT_MOVING_ROI);
            }
            catch (Exception)
            {
               //没有显示roi的时候 移动鼠标会报错
            }

		}


		/***********************************************************/
		public void dummyI(int v)
		{
		}

        /*****************************/
        /// <summary>
        /// 在指定位置显示ROI--Rectangle1
        /// </summary>
        /// <param name="row1"></param>
        /// <param name="col1"></param>
        /// <param name="row2"></param>
        /// <param name="col2"></param>
        /// <param name="rois"></param>
        public void displayRect1(string color, double row1, double col1, double row2, double col2)
        {
            setROIShape(new ROIRectangle1());
            
            if (roiMode != null)			 //either a new ROI object is created
            {
                roiMode.createRectangle1(row1, col1, row2, col2);
                roiMode.Type = roiMode.GetType().Name;
                roiMode.Color = color;
                ROIList.Add(roiMode);
                roiMode = null;
                activeROIidx = ROIList.Count - 1;
                viewController.repaint("blue");

                NotifyRCObserver(ROIController.EVENT_CREATED_ROI);
            }
        }
        /// <summary>
        /// 在指定位置显示ROI--Rectangle2
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="phi"></param>
        /// <param name="length1"></param>
        /// <param name="length2"></param>
        /// <param name="rois"></param>
        public void displayRect2(string color,double row, double col, double phi, double length1, double length2)
        {
            setROIShape(new ROIRectangle2());

            if (roiMode != null)			 //either a new ROI object is created
            {
                roiMode.createRectangle2(row, col, phi, length1, length2);
                roiMode.Type = roiMode.GetType().Name;
                roiMode.Color = color;
                ROIList.Add(roiMode);
                roiMode = null;
                activeROIidx = ROIList.Count - 1;
                viewController.repaint();

                NotifyRCObserver(ROIController.EVENT_CREATED_ROI);
            }
        }
        /// <summary>
        /// 在指定位置生成ROI--Circle
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="radius"></param>
        /// <param name="rois"></param>
        public void displayCircle(string color, double row, double col, double radius)
        {
            setROIShape(new ROICircle());
            
            if (roiMode != null)			 //either a new ROI object is created
            {
                roiMode.createCircle(row, col, radius);
                roiMode.Type = roiMode.GetType().Name;
                roiMode.Color = color;
                ROIList.Add(roiMode);
                roiMode = null;
                activeROIidx = ROIList.Count - 1;
                viewController.repaint();

                NotifyRCObserver(ROIController.EVENT_CREATED_ROI);
            }
        }

        public void displayCircularArc(string color, double row, double col, double radius, double startPhi, double extentPhi)
        {
            setROIShape(new ROICircle());

            if (roiMode != null)			 //either a new ROI object is created
            {
                roiMode.createCircularArc(row, col, radius, startPhi, extentPhi, "positive");
                roiMode.Type = roiMode.GetType().Name;
                roiMode.Color = color;
                ROIList.Add(roiMode);
                roiMode = null;
                activeROIidx = ROIList.Count - 1;
                viewController.repaint();

                NotifyRCObserver(ROIController.EVENT_CREATED_ROI);
            }
        }

        /// <summary>
        /// 在指定位置显示ROI--Line
        /// </summary>
        /// <param name="beginRow"></param>
        /// <param name="beginCol"></param>
        /// <param name="endRow"></param>
        /// <param name="endCol"></param>
        /// <param name="rois"></param>
        public void displayLine(string color, double beginRow, double beginCol, double endRow, double endCol)
        {
            this.setROIShape(new ROILine());

            if (roiMode != null)			 //either a new ROI object is created
            {
                roiMode.createLine(beginRow, beginCol, endRow, endCol);
                roiMode.Type = roiMode.GetType().Name;
                roiMode.Color = color;
                ROIList.Add(roiMode);
                roiMode = null;
                activeROIidx = ROIList.Count - 1;
                viewController.repaint();

                NotifyRCObserver(ROIController.EVENT_CREATED_ROI);
            }
        }
        /// <summary>
        /// 在指定位置生成ROI--Rectangle1
        /// </summary>
        /// <param name="row1"></param>
        /// <param name="col1"></param>
        /// <param name="row2"></param>
        /// <param name="col2"></param>
        /// <param name="rois"></param>
        public void genRect1(double row1, double col1, double row2, double col2, ref System.Collections.Generic.List<ROI> rois)
        {
            setROIShape(new ROIRectangle1());

            if (rois == null)
            {
                rois = new System.Collections.Generic.List<ROI>();
            }

            if (roiMode != null)			 //either a new ROI object is created
            {
                roiMode.createRectangle1(row1, col1, row2, col2);
                roiMode.Type = roiMode.GetType().Name;
                rois.Add(roiMode);
                ROIList.Add(roiMode);
                roiMode = null;
                activeROIidx = ROIList.Count - 1;
                viewController.repaint();

                NotifyRCObserver(ROIController.EVENT_CREATED_ROI);
            }
        }
        /// <summary>
        /// 在指定位置生成ROI--Rectangle2
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="phi"></param>
        /// <param name="length1"></param>
        /// <param name="length2"></param>
        /// <param name="rois"></param>
        public void genRect2(double row, double col, double phi, double length1, double length2, ref System.Collections.Generic.List<ROI> rois)
        {
            setROIShape(new ROIRectangle2());

            if (rois == null)
            {
                rois = new System.Collections.Generic.List<ROI>();
            }

            if (roiMode != null)			 //either a new ROI object is created
            {
                roiMode.createRectangle2(row, col, phi, length1, length2);
                roiMode.Type = roiMode.GetType().Name;
                rois.Add(roiMode);
                ROIList.Add(roiMode);
                roiMode = null;
                activeROIidx = ROIList.Count - 1;
                viewController.repaint();

                NotifyRCObserver(ROIController.EVENT_CREATED_ROI);
            }
        }
        /// <summary>
        /// 在指定位置生成ROI--Circle
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="radius"></param>
        /// <param name="rois"></param>
        public void genCircle(double row, double col, double radius, ref System.Collections.Generic.List<ROI> rois)
        {
            setROIShape(new ROICircle());

            if (rois == null)
            {
                rois = new System.Collections.Generic.List<ROI>();
            }

            if (roiMode != null)			 //either a new ROI object is created
            {
                roiMode.createCircle(row, col, radius);
                roiMode.Type = roiMode.GetType().Name;
                rois.Add(roiMode);
                ROIList.Add(roiMode);
                roiMode = null;
                activeROIidx = ROIList.Count - 1;
                viewController.repaint();

                NotifyRCObserver(ROIController.EVENT_CREATED_ROI);
            }
        }

        public void genCircularArc(double row, double col, double radius, double startPhi, double extentPhi, string direct, ref System.Collections.Generic.List<ROI> rois)
        {
            setROIShape(new ROICircularArc());

            if (rois == null)
            {
                rois = new System.Collections.Generic.List<ROI>();
            }

            if (roiMode != null)			 //either a new ROI object is created
            {
                roiMode.createCircularArc(row, col, radius, startPhi, extentPhi, direct);
                roiMode.Type = roiMode.GetType().Name;
                rois.Add(roiMode);
                ROIList.Add(roiMode);
                roiMode = null;
                activeROIidx = ROIList.Count - 1;
                viewController.repaint();

                NotifyRCObserver(ROIController.EVENT_CREATED_ROI);
            }
        }
        /// <summary>
        /// 在指定位置生成ROI--Line
        /// </summary>
        /// <param name="beginRow"></param>
        /// <param name="beginCol"></param>
        /// <param name="endRow"></param>
        /// <param name="endCol"></param>
        /// <param name="rois"></param>
        protected internal void genLine(double beginRow, double beginCol, double endRow, double endCol, ref System.Collections.Generic.List<ROI> rois)
        {
            this.setROIShape(new ROILine());

            if (rois == null)
            {
                rois = new System.Collections.Generic.List<ROI>();
            }

            if (roiMode != null)			 //either a new ROI object is created
            {
                roiMode.createLine(beginRow, beginCol, endRow, endCol);
                roiMode.Type = roiMode.GetType().Name;
                rois.Add(roiMode);
                ROIList.Add(roiMode);
                roiMode = null;
                activeROIidx = ROIList.Count - 1;
                viewController.repaint();

                NotifyRCObserver(ROIController.EVENT_CREATED_ROI);
            }
        }
        /// <summary>
        /// 获取当前选中ROI的信息
        /// </summary>
        /// <returns></returns>
        protected internal System.Collections.Generic.List<double> smallestActiveROI(out string name, out int index)
        {
            name = "";
            int activeROIIdx = this.getActiveROIIdx();
            index = activeROIIdx;
            if (activeROIIdx > -1)
            {
                ROI region = this.getActiveROI();
                Type type = region.GetType();
                name = type.Name;

                HTuple smallest = region.getModelData();
                System.Collections.Generic.List<double> resual = new System.Collections.Generic.List<double>();
                for (int i = 0; i < smallest.Length; i++)
                {
                    resual.Add(smallest[i].D);
                }

                return resual;
            }
            else
            {
                return null;
            }
        }

        protected internal ROI smallestActiveROI(out System.Collections.Generic.List<double> data, out int index)
        {
            try
            {
                int activeROIIdx = this.getActiveROIIdx();
                index = activeROIIdx;
                data = new System.Collections.Generic.List<double>();

                if (activeROIIdx > -1)
                {
                    ROI region = this.getActiveROI();
                    Type type = region.GetType();

                    HTuple smallest = region.getModelData();

                    for (int i = 0; i < smallest.Length; i++)
                    {
                        data.Add(smallest[i].D);
                    }

                    return region;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception)
            {
                data = null;
                index = 0;
                return null;
            }
        }

        /// <summary>
        /// 删除当前选中ROI
        /// </summary>
        /// <param name="roi"></param>
        protected internal void removeActiveROI(ref System.Collections.Generic.List<ROI> roi)
        {
            int activeROIIdx = this.getActiveROIIdx();
            if (activeROIIdx > -1)
            {
                this.removeActive();
                roi.RemoveAt(activeROIIdx);
            }
        }
        /// <summary>
        /// 选中激活ROI
        /// </summary>
        /// <param name="index"></param>
        protected internal void selectROI(int index)
        {
            this.activeROIidx = index;
            this.NotifyRCObserver(ROIController.EVENT_ACTIVATED_ROI);
            this.viewController.repaint();
        }
        /// <summary>
        /// 复位窗口显示
        /// </summary>
        protected internal void resetWindowImage()
        {
            //this.viewController.resetWindow();
            this.viewController.repaint();
        }

        protected internal void zoomWindowImage()
        {
            this.viewController.setViewState(HWndCtrl.MODE_VIEW_ZOOM);
        }

        protected internal void moveWindowImage()
        {
            this.viewController.setViewState(HWndCtrl.MODE_VIEW_MOVE);	
        }

        protected internal void noneWindowImage()
        {
            this.viewController.setViewState(HWndCtrl.MODE_VIEW_NONE);
        }
	}//end of class
}//end of namespace
