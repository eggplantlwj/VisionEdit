using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
namespace ViewROI.Config
{
    [Serializable]
    class CircularArc
    {
         private double _row;
        private double _column;
        private double _radius;
        private double _startPhi;
        private double _extentPhi;
        [XmlElement(ElementName = "Row")]
        public double Row
        {
            get { return this._row; }
            set { this._row = value; }
        }

        [XmlElement(ElementName = "Column")]
        public double Column
        {
            get { return this._column; }
            set { this._column = value; }
        }
        [XmlElement(ElementName = "Radius")]
        public double Radius
        {
            get { return this._radius; }
            set { this._radius = value; }
        }

        [XmlElement(ElementName = "startPhi")]
        public double StartPhi
        {
            get { return this._startPhi; }
            set { this._startPhi = value; }
        }

        [XmlElement(ElementName = "ExtentPhi")]
        public double ExtentPhi
        {
            get { return this._extentPhi; }
            set { this._extentPhi = value; }
        }

        private string color = "yellow";
        [XmlElement(ElementName = "Color")]
        public string Color
        {
            get { return this.color; }
            set { this.color = value; }
        }
        public CircularArc()
        {

        }

        public CircularArc(double row, double column, double radius,double startPhi, double extentPhi)
        {
            this._row = row;
            this._column = column;
            this._radius = radius;
            this._startPhi = startPhi;
            this._extentPhi = extentPhi;
        }
    }
}
