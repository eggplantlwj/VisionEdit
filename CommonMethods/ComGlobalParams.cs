using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HalconDotNet;

namespace CommonMethods
{
    public class ComGlobalParams
    {
        
        public static HObject inputImageGlobal
        {
            get
            {
                HObject inputImage = new HObject();
                HOperatorSet.ReadImage(out inputImage, @"G:\Outer_HB.bmp");
                return inputImage;
            }
            set
            {

            }
        }
    }
}
