using System;
using System.Xml.Serialization;

namespace dv607workshop2.models
{
    /// <summary>
    /// New Boat
    /// </summary>
    public class Boat
    {
        private string _type;
        private string _length;

        [XmlElement("type")]
        public string Type { get => _type; set => _type = value; }

        [XmlElement("lenght")]
        public string Length { get => _length; set => _length = value; }

        public Boat(string type, string length)
        {
            _type = type;
            _length = length;
        }

       public Boat()
        {

        }
    }
}
