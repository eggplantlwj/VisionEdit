using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace ViewWindow.Config
{
    [Serializable]
    public class Rectangle1
    {
        private double _row1;
        private double _column1;
        private double _row2;
        private double _column2;

        [XmlElement(ElementName = "Row1")]
        public double Row1
        {
            get { return this._row1; }
            set { this._row1 = value; }
        }

        [XmlElement(ElementName = "Column1")]
        public double Column1
        {
            get { return this._column1; }
            set { this._column1 = value; }
        }

        [XmlElement(ElementName = "Row2")]
        public double Row2
        {
            get { return this._row2; }
            set { this._row2 = value; }
        }

        [XmlElement(ElementName = "Column2")]
        public double Column2
        {
            get { return this._column2; }
            set { this._column2 = value; }
        }
        private string color = "yellow";
        [XmlElement(ElementName = "Color")]
        public string Color
        {
            get { return this.color; }
            set { this.color = value; }
        }
        public Rectangle1()
        {

        }

        public Rectangle1(double row1, double column1, double row2, double column2)
        {
            this._row1 = row1;
            this._column1 = column1;
            this._row2 = row2;
            this._column2 = column2;
        }

    }
}
