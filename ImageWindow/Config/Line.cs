using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace ViewWindow.Config
{
    [Serializable]
    public class Line
    {
        private double _rowBegin;
        private double _columnBegin;
        private double _rowEnd;
        private double _columnEnd;

        [XmlElement(ElementName = "RowBegin")]
        public double RowBegin
        {
            get { return this._rowBegin; }
            set { this._rowBegin = value; }
        }

        [XmlElement(ElementName = "ColumnBegin")]
        public double ColumnBegin
        {
            get { return this._columnBegin; }
            set { this._columnBegin = value; }
        }
        [XmlElement(ElementName = "RowEnd")]
        public double RowEnd
        {
            get { return this._rowEnd; }
            set { this._rowEnd = value; }
        }

        [XmlElement(ElementName = "ColumnEnd")]
        public double ColumnEnd
        {
            get { return this._columnEnd; }
            set { this._columnEnd = value; }
        }
        private string color = "yellow";
        [XmlElement(ElementName = "Color")]
        public string Color
        {
            get { return this.color; }
            set { this.color = value; }
        }
        public Line()
        {

        }

        public Line(double rowBegin, double columnBegin, double rowEnd, double columnEnd)
        {
            this._rowBegin = rowBegin;
            this._columnBegin = columnBegin;
            this._rowEnd = rowEnd;
            this._columnEnd = columnEnd;
        }
    }
}
