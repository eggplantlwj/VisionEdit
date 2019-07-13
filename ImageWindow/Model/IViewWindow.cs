using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HalconDotNet;

namespace ViewWindow.Model
{
    interface IViewWindow
    {
        void displayImage(HObject img);
        void resetWindowImage();
        void zoomWindowImage();
        void moveWindowImage();
        void noneWindowImage();
        void genRect1(double row1, double col1, double row2, double col2, ref List<ROI> rois);
        void genRect2(double row, double col, double phi, double length1, double length2, ref List<ROI> rois);
        void genCircle(double row, double col, double radius, ref List<ROI> rois);
        void genCircularArc(double row, double col, double radius,double startPhi, double extentPhi,string direct, ref List<ROI> rois);
        void genLine(double beginRow, double beginCol, double endRow, double endCol, ref List<ROI> rois);
        List<double> smallestActiveROI(out string name,out int index);
        ROI smallestActiveROI(out List<double> data, out int index);
        void selectROI(int index);
        void selectROI(List<ROI> rois, int index);
        void displayROI(List<ROI> rois);
        void removeActiveROI(ref List<ROI> rois);
        void saveROI(List<ROI> rois, string fileNmae);
        void loadROI(string fileName, out List<ROI> rois);
    }
}
