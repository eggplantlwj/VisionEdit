using System;
using ViewWindow;
using System.Collections;
using HalconDotNet;
using ViewROI.Config;
using System.Collections.Generic;

namespace ViewWindow.Model
{
	public delegate void IconicDelegate(int val);
	public delegate void FuncDelegate();

	/// <summary>
	/// This class works as a wrapper class for the HALCON window
	/// HWindow. HWndCtrl is in charge of the visualization.
	/// You can move and zoom the visible image part by using GUI component 
	/// inputs or with the mouse. The class HWndCtrl uses a graphics stack 
	/// to manage the iconic objects for the display. Each object is linked 
	/// to a graphical context, which determines how the object is to be drawn.
	/// The context can be changed by calling changeGraphicSettings().
	/// The graphical "modes" are defined by the class GraphicsContext and 
	/// map most of the dev_set_* operators provided in HDevelop.
	/// </summary>
	public class HWndCtrl
	{
		/// <summary>No action is performed on mouse events</summary>
		public const int MODE_VIEW_NONE       = 10;

		/// <summary>Zoom is performed on mouse events</summary>
		public const int MODE_VIEW_ZOOM       = 11;

		/// <summary>Move is performed on mouse events</summary>
		public const int MODE_VIEW_MOVE       = 12;

		/// <summary>Magnification is performed on mouse events</summary>
		public const int MODE_VIEW_ZOOMWINDOW	= 13;


		public const int MODE_INCLUDE_ROI     = 1;

		public const int MODE_EXCLUDE_ROI     = 2;


		/// <summary>
		/// Constant describes delegate message to signal new image
		/// </summary>
		public const int EVENT_UPDATE_IMAGE   = 31;
		/// <summary>
		/// Constant describes delegate message to signal error
		/// when reading an image from file
		/// </summary>
		public const int ERR_READING_IMG      = 32;
		/// <summary> 
		/// Constant describes delegate message to signal error
		/// when defining a graphical context
		/// </summary>
		public const int ERR_DEFINING_GC      = 33;

		/// <summary> 
		/// Maximum number of HALCON objects that can be put on the graphics 
		/// stack without loss. For each additional object, the first entry 
		/// is removed from the stack again.
		/// </summary>
		private const int MAXNUMOBJLIST       = 2;//原始值为50 实际上2都可以,因这里只是存储背景图片


		private int    stateView;
		private bool   mousePressed = false;
		private double startX,startY;

		/// <summary>HALCON window</summary>
		private HWindowControl viewPort;

		/// <summary>
		/// Instance of ROIController, which manages ROI interaction
		/// </summary>
		public  ROIController roiManager;

		/* dispROI is a flag to know when to add the ROI models to the 
		   paint routine and whether or not to respond to mouse events for 
		   ROI objects */
		private int           dispROI;

        /// <summary>
        /// 缩放事件开关
        /// </summary>
        public bool drawModel = false;
        //开启编辑模式
        public bool EditModel = true;

		/* Basic parameters, like dimension of window and displayed image part */
		private int   windowWidth;
		private int   windowHeight;
		private int   imageWidth;
		private int   imageHeight;

		private int[] CompRangeX;
		private int[] CompRangeY;


		private int    prevCompX, prevCompY;
		private double stepSizeX, stepSizeY;


		/* Image coordinates, which describe the image part that is displayed  
		   in the HALCON window */
		private double ImgRow1, ImgCol1, ImgRow2, ImgCol2;

		/// <summary>Error message when an exception is thrown</summary>
		public string  exceptionText = "";


		/* Delegates to send notification messages to other classes */
		/// <summary>
		/// Delegate to add information to the HALCON window after 
		/// the paint routine has finished
		/// </summary>
		public FuncDelegate   addInfoDelegate;

		/// <summary>
		/// Delegate to notify about failed tasks of the HWndCtrl instance
		/// </summary>
		public IconicDelegate NotifyIconObserver;


		private HWindow ZoomWindow;
		private double  zoomWndFactor;
		private double  zoomAddOn;
		private int     zoomWndSize;


		/// <summary> 
		/// List of HALCON objects to be drawn into the HALCON window. 
		/// The list shouldn't contain more than MAXNUMOBJLIST objects, 
		/// otherwise the first entry is removed from the list.
		/// </summary>
        private ArrayList HObjImageList;

		/// <summary>
		/// Instance that describes the graphical context for the
		/// HALCON window. According on the graphical settings
		/// attached to each HALCON object, this graphical context list 
		/// is updated constantly.
		/// </summary>
		private GraphicsContext	mGC;



		/// <summary> 
		/// Initializes the image dimension, mouse delegation, and the 
		/// graphical context setup of the instance.
		/// </summary>
		/// <param name="view"> HALCON window </param>
        protected internal HWndCtrl(HWindowControl view)
		{
			viewPort = view;
			stateView = MODE_VIEW_NONE;
			windowWidth = viewPort.Size.Width;
			windowHeight = viewPort.Size.Height;

			zoomWndFactor = (double)imageWidth / viewPort.Width;
			zoomAddOn = Math.Pow(0.9, 5);
			zoomWndSize = 150;

			/*default*/
			CompRangeX = new int[] { 0, 100 };
			CompRangeY = new int[] { 0, 100 };

			prevCompX = prevCompY = 0;

			dispROI = MODE_INCLUDE_ROI;//1;

			viewPort.HMouseUp += new HalconDotNet.HMouseEventHandler(this.mouseUp);
			viewPort.HMouseDown += new HalconDotNet.HMouseEventHandler(this.mouseDown);
            viewPort.HMouseWheel += new HalconDotNet.HMouseEventHandler(this.HMouseWheel);
			viewPort.HMouseMove += new HalconDotNet.HMouseEventHandler(this.mouseMoved);

			addInfoDelegate = new FuncDelegate(dummyV);
			NotifyIconObserver = new IconicDelegate(dummy);

			// graphical stack 
			HObjImageList = new ArrayList(20);
			mGC = new GraphicsContext();
			mGC.gcNotification = new GCDelegate(exceptionGC);
		}

        private void HMouseWheel(object sender, HMouseEventArgs e)
        {
            //关闭缩放事件
            if (drawModel)
            {
                return;
            }

            double scale;

            if (e.Delta > 0)
                scale = 0.9;
            else
                scale = 1 / 0.9;

            zoomImage(e.X, e.Y, scale);
 
        }
		/// <summary>
		/// Read dimensions of the image to adjust own window settings
		/// </summary>
		/// <param name="image">HALCON image</param>
		private void setImagePart(HImage image)
		{
			string s;
			int w,h;

			image.GetImagePointer1(out s, out w, out h);
			setImagePart(0, 0, h, w);
		}


		/// <summary>
		/// Adjust window settings by the values supplied for the left 
		/// upper corner and the right lower corner
		/// </summary>
		/// <param name="r1">y coordinate of left upper corner</param>
		/// <param name="c1">x coordinate of left upper corner</param>
		/// <param name="r2">y coordinate of right lower corner</param>
		/// <param name="c2">x coordinate of right lower corner</param>
		private void setImagePart(int r1, int c1, int r2, int c2)
		{
			ImgRow1 = r1;
			ImgCol1 = c1;
			ImgRow2 = imageHeight = r2;
			ImgCol2 = imageWidth = c2;

			System.Drawing.Rectangle rect = viewPort.ImagePart;
			rect.X = (int)ImgCol1;
			rect.Y = (int)ImgRow1;
			rect.Height = (int)imageHeight;
			rect.Width = (int)imageWidth;
			viewPort.ImagePart = rect;
		}


		/// <summary>
		/// Sets the view mode for mouse events in the HALCON window
		/// (zoom, move, magnify or none).
		/// </summary>
		/// <param name="mode">One of the MODE_VIEW_* constants</param>
        protected internal void setViewState(int mode)
		{
			stateView = mode;

			if (roiManager != null)
				roiManager.resetROI();
		}

		/********************************************************************/
		private void dummy(int val)
		{
		}

		private void dummyV()
		{
		}

		/*******************************************************************/
		private void exceptionGC(string message)
		{
			exceptionText = message;
			NotifyIconObserver(ERR_DEFINING_GC);
		}

		/// <summary>
		/// Paint or don't paint the ROIs into the HALCON window by 
		/// defining the parameter to be equal to 1 or not equal to 1.
		/// </summary>
		public void setDispLevel(int mode)
		{
			dispROI = mode;
		}

		/****************************************************************************/
		/*                          graphical element                               */
		/****************************************************************************/
		private void zoomImage(double x, double y, double scale)
		{
            //关闭缩放事件
            if (drawModel)
            {
                return;
            }

			double lengthC, lengthR;
			double percentC, percentR;
			int    lenC, lenR;

			percentC = (x - ImgCol1) / (ImgCol2 - ImgCol1);
			percentR = (y - ImgRow1) / (ImgRow2 - ImgRow1);

			lengthC = (ImgCol2 - ImgCol1) * scale;
			lengthR = (ImgRow2 - ImgRow1) * scale;

			ImgCol1 = x - lengthC * percentC;
			ImgCol2 = x + lengthC * (1 - percentC);

			ImgRow1 = y - lengthR * percentR;
			ImgRow2 = y + lengthR * (1 - percentR);

			lenC = (int)Math.Round(lengthC);
			lenR = (int)Math.Round(lengthR);

			System.Drawing.Rectangle rect = viewPort.ImagePart;
			rect.X = (int)Math.Round(ImgCol1);
			rect.Y = (int)Math.Round(ImgRow1);
			rect.Width = (lenC > 0) ? lenC : 1;
			rect.Height = (lenR > 0) ? lenR : 1;
			viewPort.ImagePart = rect;

            double _zoomWndFactor = 1;
            _zoomWndFactor = scale * zoomWndFactor;

            if (zoomWndFactor < 0.01 && _zoomWndFactor < zoomWndFactor)
            {
                //超过一定缩放比例就不在缩放
                resetWindow();
                return;
            }
            if (zoomWndFactor > 100 && _zoomWndFactor > zoomWndFactor)
            {
                //超过一定缩放比例就不在缩放
                resetWindow();
                return;
            }
            zoomWndFactor = _zoomWndFactor;



			repaint();
		}

		/// <summary>
		/// Scales the image in the HALCON window according to the 
		/// value scaleFactor
		/// </summary>
		public void zoomImage(double scaleFactor)
		{

			double midPointX, midPointY;

			if (((ImgRow2 - ImgRow1) == scaleFactor * imageHeight) &&
				((ImgCol2 - ImgCol1) == scaleFactor * imageWidth))
			{
				repaint();
				return;
			}

			ImgRow2 = ImgRow1 + imageHeight;
			ImgCol2 = ImgCol1 + imageWidth;

			midPointX = ImgCol1;
			midPointY = ImgRow1;

			zoomWndFactor = (double)imageWidth / viewPort.Width;
			zoomImage(midPointX, midPointY, scaleFactor);
		}


		/// <summary>
		/// Scales the HALCON window according to the value scale
		/// </summary>
		public void scaleWindow(double scale)
		{
			ImgRow1 = 0;
			ImgCol1 = 0;

			ImgRow2 = imageHeight;
			ImgCol2 = imageWidth;

			viewPort.Width = (int)(ImgCol2 * scale);
			viewPort.Height = (int)(ImgRow2 * scale);

			zoomWndFactor = ((double)imageWidth / viewPort.Width);
		}

		/// <summary>
		/// Recalculates the image-window-factor, which needs to be added to 
		/// the scale factor for zooming an image. This way the zoom gets 
		/// adjusted to the window-image relation, expressed by the equation 
		/// imageWidth/viewPort.Width.
		/// </summary>
		public void setZoomWndFactor()
		{
			zoomWndFactor = ((double)imageWidth / viewPort.Width);
		}

		/// <summary>
		/// Sets the image-window-factor to the value zoomF
		/// </summary>
		public void setZoomWndFactor(double zoomF)
		{
			zoomWndFactor = zoomF;
		}

		/*******************************************************************/
		private void moveImage(double motionX, double motionY)
		{
			ImgRow1 += -motionY;
			ImgRow2 += -motionY;

			ImgCol1 += -motionX;
			ImgCol2 += -motionX;

			System.Drawing.Rectangle rect = viewPort.ImagePart;
			rect.X = (int)Math.Round(ImgCol1);
			rect.Y = (int)Math.Round(ImgRow1);
			viewPort.ImagePart = rect;

			repaint();
		}


		/// <summary>
		/// Resets all parameters that concern the HALCON window display 
		/// setup to their initial values and clears the ROI list.
		/// </summary>
        protected internal void resetAll()
		{
			ImgRow1 = 0;
			ImgCol1 = 0;
			ImgRow2 = imageHeight;
			ImgCol2 = imageWidth;

			zoomWndFactor = (double)imageWidth / viewPort.Width;

			System.Drawing.Rectangle rect = viewPort.ImagePart;
			rect.X = (int)ImgCol1;
			rect.Y = (int)ImgRow1;
			rect.Width = (int)imageWidth;
			rect.Height = (int)imageHeight;
			viewPort.ImagePart = rect;


			if (roiManager != null)
				roiManager.reset();
		}

        protected internal void resetWindow()
		{
			ImgRow1 = 0;
			ImgCol1 = 0;
			ImgRow2 = imageHeight;
			ImgCol2 = imageWidth;

			zoomWndFactor = (double)imageWidth / viewPort.Width;

			System.Drawing.Rectangle rect = viewPort.ImagePart;
			rect.X = (int)ImgCol1;
			rect.Y = (int)ImgRow1;
			rect.Width = (int)imageWidth;
			rect.Height = (int)imageHeight;
			viewPort.ImagePart = rect;
		}


		/*************************************************************************/
		/*      			 Event handling for mouse	   	                     */
		/*************************************************************************/
		private void mouseDown(object sender, HalconDotNet.HMouseEventArgs e)
		{
            //关闭缩放事件
            if (drawModel)
            {
                return;
            }

            stateView = MODE_VIEW_MOVE;
			mousePressed = true;
			int activeROIidx = -1;

			if (roiManager != null && (dispROI == MODE_INCLUDE_ROI))
			{
				activeROIidx = roiManager.mouseDownAction(e.X, e.Y);
			}

			if (activeROIidx == -1)
			{
				switch (stateView)
				{
					case MODE_VIEW_MOVE:
						startX = e.X;
						startY = e.Y;
						break;

					case MODE_VIEW_NONE:
						break;
					case MODE_VIEW_ZOOMWINDOW:
						activateZoomWindow((int)e.X, (int)e.Y);
						break;
					default:
						break;
				}
			}
			//end of if
		}

		/*******************************************************************/
		private void activateZoomWindow(int X, int Y)
		{
			double posX, posY;
			int zoomZone;

			if (ZoomWindow != null)
				ZoomWindow.Dispose();

			HOperatorSet.SetSystem("border_width", 10);
			ZoomWindow = new HWindow();

			posX = ((X - ImgCol1) / (ImgCol2 - ImgCol1)) * viewPort.Width;
			posY = ((Y - ImgRow1) / (ImgRow2 - ImgRow1)) * viewPort.Height;

			zoomZone = (int)((zoomWndSize / 2) * zoomWndFactor * zoomAddOn);
			ZoomWindow.OpenWindow((int)posY - (zoomWndSize / 2), (int)posX - (zoomWndSize / 2),
								   zoomWndSize, zoomWndSize,
								   viewPort.HalconID, "visible", "");
			ZoomWindow.SetPart(Y - zoomZone, X - zoomZone, Y + zoomZone, X + zoomZone);
			repaint(ZoomWindow);
			ZoomWindow.SetColor("black");
		}

        public void raiseMouseup()
        {
            mousePressed = false;

            if (roiManager != null
                && (roiManager.activeROIidx != -1)
                && (dispROI == MODE_INCLUDE_ROI))
            {
                roiManager.NotifyRCObserver(ROIController.EVENT_UPDATE_ROI);
            }
            else if (stateView == MODE_VIEW_ZOOMWINDOW)
            {
                ZoomWindow.Dispose();
            }
        }
		/*******************************************************************/
		private void mouseUp(object sender, HalconDotNet.HMouseEventArgs e)
		{
            //关闭缩放事件
            if (drawModel)
            {
                return;
            }

			mousePressed = false;

			if (roiManager != null
				&& (roiManager.activeROIidx != -1)
				&& (dispROI == MODE_INCLUDE_ROI))
			{
				roiManager.NotifyRCObserver(ROIController.EVENT_UPDATE_ROI);
			}
			else if (stateView == MODE_VIEW_ZOOMWINDOW)
			{
				ZoomWindow.Dispose();
			}
		}

		/*******************************************************************/
		private void mouseMoved(object sender, HalconDotNet.HMouseEventArgs e)
		{
            //关闭缩放事件
            if (drawModel)
            {
                return;
            }

			double motionX, motionY;
			double posX, posY;
			double zoomZone;


			if (!mousePressed)
				return;

			if (roiManager != null && (roiManager.activeROIidx != -1) && (dispROI == MODE_INCLUDE_ROI))
			{
				roiManager.mouseMoveAction(e.X, e.Y);
			}
			else if (stateView == MODE_VIEW_MOVE)
			{
				motionX = ((e.X - startX));
				motionY = ((e.Y - startY));

				if (((int)motionX != 0) || ((int)motionY != 0))
				{
					moveImage(motionX, motionY);
					startX = e.X - motionX;
					startY = e.Y - motionY;
				}
			}
			else if (stateView == MODE_VIEW_ZOOMWINDOW)
			{
				HSystem.SetSystem("flush_graphic", "false");
				ZoomWindow.ClearWindow();


				posX = ((e.X - ImgCol1) / (ImgCol2 - ImgCol1)) * viewPort.Width;
				posY = ((e.Y - ImgRow1) / (ImgRow2 - ImgRow1)) * viewPort.Height;
				zoomZone = (zoomWndSize / 2) * zoomWndFactor * zoomAddOn;

				ZoomWindow.SetWindowExtents((int)posY - (zoomWndSize / 2),
											(int)posX - (zoomWndSize / 2),
											zoomWndSize, zoomWndSize);
				ZoomWindow.SetPart((int)(e.Y - zoomZone), (int)(e.X - zoomZone),
								   (int)(e.Y + zoomZone), (int)(e.X + zoomZone));
				repaint(ZoomWindow);

				HSystem.SetSystem("flush_graphic", "true");
				ZoomWindow.DispLine(-100.0, -100.0, -100.0, -100.0);
			}
		}

		/// <summary>
		/// To initialize the move function using a GUI component, the HWndCtrl
		/// first needs to know the range supplied by the GUI component. 
		/// For the x direction it is specified by xRange, which is 
		/// calculated as follows: GuiComponentX.Max()-GuiComponentX.Min().
		/// The starting value of the GUI component has to be supplied 
		/// by the parameter Init
		/// </summary>
		public void setGUICompRangeX(int[] xRange, int Init)
		{
			int cRangeX;

			CompRangeX = xRange;
			cRangeX = xRange[1] - xRange[0];
			prevCompX = Init;
			stepSizeX = ((double)imageWidth / cRangeX) * (imageWidth / windowWidth);

		}

		/// <summary>
		/// To initialize the move function using a GUI component, the HWndCtrl
		/// first needs to know the range supplied by the GUI component. 
		/// For the y direction it is specified by yRange, which is 
		/// calculated as follows: GuiComponentY.Max()-GuiComponentY.Min().
		/// The starting value of the GUI component has to be supplied 
		/// by the parameter Init
		/// </summary>
		public void setGUICompRangeY(int[] yRange, int Init)
		{
			int cRangeY;

			CompRangeY = yRange;
			cRangeY = yRange[1] - yRange[0];
			prevCompY = Init;
			stepSizeY = ((double)imageHeight / cRangeY) * (imageHeight / windowHeight);
		}


		/// <summary>
		/// Resets to the starting value of the GUI component.
		/// </summary>
		public void resetGUIInitValues(int xVal, int yVal)
		{
			prevCompX = xVal;
			prevCompY = yVal;
		}

		/// <summary>
		/// Moves the image by the value valX supplied by the GUI component
		/// </summary>
		public void moveXByGUIHandle(int valX)
		{
			double motionX;

			motionX = (valX - prevCompX) * stepSizeX;

			if (motionX == 0)
				return;

			moveImage(motionX, 0.0);
			prevCompX = valX;
		}


		/// <summary>
		/// Moves the image by the value valY supplied by the GUI component
		/// </summary>
		public void moveYByGUIHandle(int valY)
		{
			double motionY;

			motionY = (valY - prevCompY) * stepSizeY;

			if (motionY == 0)
				return;

			moveImage(0.0, motionY);
			prevCompY = valY;
		}

		/// <summary>
		/// Zooms the image by the value valF supplied by the GUI component
		/// </summary>
		public void zoomByGUIHandle(double valF)
		{
			double x, y, scale;
			double prevScaleC;



			x = (ImgCol1 + (ImgCol2 - ImgCol1) / 2);
			y = (ImgRow1 + (ImgRow2 - ImgRow1) / 2);

			prevScaleC = (double)((ImgCol2 - ImgCol1) / imageWidth);
			scale = ((double)1.0 / prevScaleC * (100.0 / valF));

			zoomImage(x, y, scale);
		}

		/// <summary>
		/// Triggers a repaint of the HALCON window
		/// </summary>
		public void repaint()
		{
			repaint(viewPort.HalconWindow);
		}
        public void repaint(string color)
        {
            repaint(viewPort.HalconWindow ,color );
        }

		/// <summary>
		/// Repaints the HALCON window 'window'
		/// </summary>
		public void repaint(HalconDotNet.HWindow window)
		{
            try
            {


			    int count = HObjImageList.Count;
			    HObjectEntry entry;

			    HSystem.SetSystem("flush_graphic", "false");
			    window.ClearWindow();
			    mGC.stateOfSettings.Clear();

                //显示图片
			    for (int i=0; i < count; i++)
			    {
				    entry = ((HObjectEntry)HObjImageList[i]);
				    mGC.applyContext(window, entry.gContext);
				    window.DispObj(entry.HObj);

			    }

                //显示region
                showHObjectList();


			    addInfoDelegate();

			    if (roiManager != null && (dispROI == MODE_INCLUDE_ROI))
				    roiManager.paintData(window);


			    HSystem.SetSystem("flush_graphic", "true");

                //注释了下面语句,会导致窗口无法实现缩放和拖动
                window.SetColor("black");
                window.DispLine(-100.0, -100.0, -101.0, -101.0);

            }
            catch (Exception)
            {

            }
		}
        public void repaint(HalconDotNet.HWindow window,string color)
        {
            try
            {


                int count = HObjImageList.Count;
                HObjectEntry entry;

                HSystem.SetSystem("flush_graphic", "false");
                window.ClearWindow();
                mGC.stateOfSettings.Clear();

                //显示图片
                for (int i = 0; i < count; i++)
                {
                    entry = ((HObjectEntry)HObjImageList[i]);
                    mGC.applyContext(window, entry.gContext);
                    window.DispObj(entry.HObj);

                }

                //显示region
                showHObjectList();


                addInfoDelegate();

                if (roiManager != null && (dispROI == MODE_INCLUDE_ROI))
                    roiManager.paintData(window,color );


                HSystem.SetSystem("flush_graphic", "true");

                //注释了下面语句,会导致窗口无法实现缩放和拖动
                window.SetColor("black");
                window.DispLine(-100.0, -100.0, -101.0, -101.0);

            }
            catch (Exception)
            {

            }
        }



		/********************************************************************/
		/*                      GRAPHICSSTACK                               */
		/********************************************************************/

		/// <summary>
		/// Adds an iconic object to the graphics stack similar to the way
		/// it is defined for the HDevelop graphics stack.
		/// </summary>
		/// <param name="obj">Iconic object</param>
		public void addIconicVar(HObject img)
		{
            //先把HObjImageList给全部释放了,源代码 会出现内存泄漏问题
            for (int i = 0; i < HObjImageList.Count; i++)
            {
                 ((HObjectEntry)HObjImageList[i]).clear();
            }


			HObjectEntry entry;

			if (img == null)
				return;
            
            HTuple classValue=null;
            HOperatorSet.GetObjClass(img, out classValue);
            if (!classValue.S.Equals("image"))
            {
                return;
            }
            
            HImage obj = new HImage(img);

			if (obj is HImage)
            {
				double r, c;
				int h, w, area;
				string s;

				area = ((HImage)obj).GetDomain().AreaCenter(out r, out c);
				((HImage)obj).GetImagePointer1(out s, out w, out h);

				if (area == (w * h))
				{
					clearList();

					if ((h != imageHeight) || (w != imageWidth))
					{
						imageHeight = h;
						imageWidth = w;
						zoomWndFactor = (double)imageWidth / viewPort.Width;
						setImagePart(0, 0, h, w);
					}
				}//if
			}//if

			entry = new HObjectEntry(obj, mGC.copyContextList());

			HObjImageList.Add(entry);

            //每当传入背景图的时候 都清空HObjectList
            clearHObjectList();

            if (HObjImageList.Count > MAXNUMOBJLIST)
            {
                //需要自己手动释放
                ((HObjectEntry)HObjImageList[0]).clear();
                HObjImageList.RemoveAt(1);
            }
				
		}


		/// <summary>
		/// Clears all entries from the graphics stack 
		/// </summary>
		public void clearList()
		{
			HObjImageList.Clear();
		}

		/// <summary>
		/// Returns the number of items on the graphics stack
		/// </summary>
		public int getListCount()
		{
			return HObjImageList.Count;
		}

		/// <summary>
		/// Changes the current graphical context by setting the specified mode
		/// (constant starting by GC_*) to the specified value.
		/// </summary>
		/// <param name="mode">
		/// Constant that is provided by the class GraphicsContext
		/// and describes the mode that has to be changed, 
		/// e.g., GraphicsContext.GC_COLOR
		/// </param>
		/// <param name="val">
		/// Value, provided as a string, 
		/// the mode is to be changed to, e.g., "blue" 
		/// </param>
		public void changeGraphicSettings(string mode, string val)
		{
			switch (mode)
			{
				case GraphicsContext.GC_COLOR:
					mGC.setColorAttribute(val);
					break;
				case GraphicsContext.GC_DRAWMODE:
					mGC.setDrawModeAttribute(val);
					break;
				case GraphicsContext.GC_LUT:
					mGC.setLutAttribute(val);
					break;
				case GraphicsContext.GC_PAINT:
					mGC.setPaintAttribute(val);
					break;
				case GraphicsContext.GC_SHAPE:
					mGC.setShapeAttribute(val);
					break;
				default:
					break;
			}
		}

		/// <summary>
		/// Changes the current graphical context by setting the specified mode
		/// (constant starting by GC_*) to the specified value.
		/// </summary>
		/// <param name="mode">
		/// Constant that is provided by the class GraphicsContext
		/// and describes the mode that has to be changed, 
		/// e.g., GraphicsContext.GC_LINEWIDTH
		/// </param>
		/// <param name="val">
		/// Value, provided as an integer, the mode is to be changed to, 
		/// e.g., 5 
		/// </param>
		public void changeGraphicSettings(string mode, int val)
		{
			switch (mode)
			{
				case GraphicsContext.GC_COLORED:
					mGC.setColoredAttribute(val);
					break;
				case GraphicsContext.GC_LINEWIDTH:
					mGC.setLineWidthAttribute(val);
					break;
				default:
					break;
			}
		}

		/// <summary>
		/// Changes the current graphical context by setting the specified mode
		/// (constant starting by GC_*) to the specified value.
		/// </summary>
		/// <param name="mode">
		/// Constant that is provided by the class GraphicsContext
		/// and describes the mode that has to be changed, 
		/// e.g.,  GraphicsContext.GC_LINESTYLE
		/// </param>
		/// <param name="val">
		/// Value, provided as an HTuple instance, the mode is 
		/// to be changed to, e.g., new HTuple(new int[]{2,2})
		/// </param>
		public void changeGraphicSettings(string mode, HTuple val)
		{
			switch (mode)
			{
				case GraphicsContext.GC_LINESTYLE:
					mGC.setLineStyleAttribute(val);
					break;
				default:
					break;
			}
		}

		/// <summary>
		/// Clears all entries from the graphical context list
		/// </summary>
		public void clearGraphicContext()
		{
			mGC.clear();
		}

		/// <summary>
		/// Returns a clone of the graphical context list (hashtable)
		/// </summary>
		public Hashtable getGraphicContext()
		{
			return mGC.copyContextList();
		}

        /// <summary>
        /// Registers an instance of an ROIController with this window 
        /// controller (and vice versa).
        /// </summary>
        /// <param name="rC"> 
        /// Controller that manages interactive ROIs for the HALCON window 
        /// </param>
        protected internal void setROIController(ROIController rC)
        {
            roiManager = rC;
            rC.setViewController(this);
            this.setViewState(HWndCtrl.MODE_VIEW_NONE);
        }
        /// <summary>
        /// 添加设定显示的图像
        /// </summary>
        /// <param name="image"></param>
        protected internal void addImageShow(HObject image)
        {
            addIconicVar(image);
        }


        #region 再次显示region和 xld

        /// <summary>
        /// hObjectList用来存储存入的HObject
        /// </summary>
        private List<HObjectWithColor> hObjectList = new List<HObjectWithColor>();

        /// <summary>
        /// 默认红颜色显示
        /// </summary>
        /// <param name="hObj">传入的region.xld,image</param>
        public void DispObj(HObject hObj)
        {
            DispObj(hObj, null);
        }

        /// <summary>
        /// 重新开辟内存保存 防止被传入的HObject在其他地方dispose后,不能重现
        /// </summary>
        /// <param name="hObj">传入的region.xld,image</param>
        /// <param name="color">颜色</param>
        public void DispObj(HObject hObj, string color)
        {
            lock (this)
            {
                //显示指定的颜色
                if (color != null)
                {
                    HOperatorSet.SetColor(viewPort.HalconWindow, color);
                }
                else
                {
                    HOperatorSet.SetColor(viewPort.HalconWindow, "red");
                }


                if (hObj != null && hObj.IsInitialized())
                {
                    //
                    HObject temp = new HObject(hObj);
                    //
                    hObjectList.Add(new HObjectWithColor(temp, color));

                    viewPort.HalconWindow.DispObj(temp);

                }

                //恢复默认的红色
                HOperatorSet.SetColor(viewPort.HalconWindow, "red");
            }
        }

        /// <summary>
        /// 每次传入新的背景Image时,清空hObjectList,避免内存没有被释放
        /// </summary>
        public void clearHObjectList()
        {

            foreach (HObjectWithColor hObjectWithColor in hObjectList)
            {
                hObjectWithColor.HObject.Dispose();
            }

            hObjectList.Clear();
        }

        /// <summary>
        /// 将hObjectList中的HObject,按照先后顺序显示出来
        /// </summary>
        private void showHObjectList()
        {
            try
            {
                foreach (HObjectWithColor hObjectWithColor in hObjectList)
                {
                    if (hObjectWithColor.Color != null)
                    {
                        HOperatorSet.SetColor(viewPort.HalconWindow, hObjectWithColor.Color);
                    }
                    else
                    {
                        HOperatorSet.SetColor(viewPort.HalconWindow, "red");
                    }
                    if (hObjectWithColor != null && hObjectWithColor.HObject.IsInitialized())
                    {
                        viewPort.HalconWindow.DispObj(hObjectWithColor.HObject);

                        //恢复默认的红色
                        HOperatorSet.SetColor(viewPort.HalconWindow, "red");
                    }
                }
            }
            catch (Exception e)
            {
                //有时候hobj被dispose了,但是其本身不为null,此时则报错. 已经使用IsInitialized解决了 
            }
        }

        #endregion



    }//end of class
}//end of namespace
