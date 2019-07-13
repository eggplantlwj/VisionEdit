using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace ViewWindow.Config
{
    [Serializable]
    public class Circle
    {
        private double _row;
        private double _column;
        private double _radius;
       
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

        private string color = "yellow";
        [XmlElement(ElementName = "Color")]
        public string Color
        {
            get { return this.color; }
            set { this.color = value; }
        }
        public Circle()
        {

        }

        public Circle(double row, double column, double radius)
        {
            this._row = row;
            this._column = column;
            this._radius = radius;
        }
    }
}
