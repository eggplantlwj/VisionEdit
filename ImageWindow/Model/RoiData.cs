using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using HalconDotNet;

namespace ViewWindow.Model
{
    public class RoiData
    {
        private int _id;
        private string _name;
        private Config.Rectangle1 _rectangle1;
        private Config.Rectangle2 _rectangle2;
        private Config.Circle _circle;
        private Config.Line _line;
        
        [XmlElement(ElementName = "ID")]
        public int ID
        {
            get { return this._id; }
            set { this._id = value; }
        }

        [XmlElement(ElementName = "Name")]
        public string Name
        {
            get { return this._name; }
            set { this._name = value; }
        }

        [XmlElement(ElementName = "Rectangle1")]
        public Config.Rectangle1 Rectangle1
        {
            get { return this._rectangle1; }
            set { this._rectangle1 = value; }
        }

        [XmlElement(ElementName = "Rectangle2")]
        public Config.Rectangle2 Rectangle2
        {
            get { return this._rectangle2; }
            set { this._rectangle2 = value; }
        }

        [XmlElement(ElementName = "Circle")]
        public Config.Circle Circle
        {
            get { return this._circle; }
            set { this._circle = value; }
        }

        [XmlElement(ElementName = "Line")]
        public Config.Line Line
        {
            get { return this._line; }
            set { this._line = value; }
        }


        protected internal RoiData()
        {

        }

        protected internal RoiData(int id, ROI roi)
        {
            this._id = id;
            HTuple m_roiData = null;

            m_roiData = roi.getModelData();

            switch (roi.Type)
            {
                case "ROIRectangle1":
                    this._name = "Rectangle1";

                    if (m_roiData != null)
                    {
                        this._rectangle1 = new Config.Rectangle1(m_roiData[0].D, m_roiData[1].D, m_roiData[2].D, m_roiData[3].D);
                        this._rectangle1.Color = roi.Color;
                    }
                    break;
                case "ROIRectangle2":
                    this._name = "Rectangle2";

                    if (m_roiData != null)
                    {
                        this._rectangle2 = new Config.Rectangle2(m_roiData[0].D, m_roiData[1].D, m_roiData[2].D, m_roiData[3].D, m_roiData[4].D);
                        this._rectangle2.Color = roi.Color;
                    }
                    break;
                case "ROICircle":
                    this._name = "Circle";

                    if (m_roiData != null)
                    {
                        this._circle = new Config.Circle(m_roiData[0].D, m_roiData[1].D, m_roiData[2].D);
                        this._circle.Color = roi.Color;
                    }
                    break;
                case "ROILine":
                    this._name = "Line";

                    if (m_roiData != null)
                    {
                        this._line = new Config.Line(m_roiData[0].D, m_roiData[1].D, m_roiData[2].D, m_roiData[3].D);
                        this._line.Color = roi.Color;
                    }
                    break;
                default:
                    break;
            }
        }

        protected internal RoiData(int id, Config.Rectangle1 rectangle1)
        {
            this._id = id;
            this._name = "Rectangle1";
            this._rectangle1 = rectangle1;
        }

        protected internal RoiData(int id, Config.Rectangle2 rectangle2)
        {
            this._id = id;
            this._name = "Rectangle2";
            this._rectangle2 = rectangle2;
        }

        protected internal RoiData(int id, Config.Circle circle)
        {
            this._id = id;
            this._name = "Circle";
            this._circle = circle;
        }

        protected internal RoiData(int id, Config.Line line)
        {
            this._id = id;
            this._name = "Line";
            this._line = line;
        }

    }
}
