using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace ViewWindow.Config
{
    [Serializable]
    public class Rectangle2
    {
        private double _row;
        private double _column;
        private double _phi;
        private double _lenth1;
        private double _lenth2;

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
        [XmlElement(ElementName = "Phi")]
        public double Phi
        {
            get { return this._phi; }
            set { this._phi = value; }
        }

        [XmlElement(ElementName = "Lenth1")]
        public double Lenth1
        {
            get { return this._lenth1; }
            set { this._lenth1 = value; }
        }

        [XmlElement(ElementName = "Lenth2")]
        public double Lenth2
        {
            get { return this._lenth2; }
            set { this._lenth2 = value; }
        }
        private string color = "yellow";

        [XmlElement(ElementName = "Color")]
        public string Color
        {
            get { return this.color; }
            set { this.color = value; }
        }
        public Rectangle2()
        {

        }

        public Rectangle2(double row, double column, double phi, double lenth1, double lenth2)
        {
            this._row = row;
            this._column = column;
            this._phi = phi;
            this._lenth1 = lenth1;
            this._lenth2 = lenth2;
        }
    }
}
