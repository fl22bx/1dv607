using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace dv607workshop2.models
{

    /// <summary>
    /// Boatclub member
    /// </summary>
    public class Member
    {

        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("personalNumber")]
        public long PersonalNumber { get; set; }

        [XmlElement("boats")]
        public List<Boat> Boats { get; set; }

        [XmlAttribute("Id")]
        public string MemberId { get; set; }


        public Member(string name, long personalNumber)
        {
            Name = name;
            PersonalNumber = personalNumber;
            Guid generator = Guid.NewGuid();
            MemberId = generator.ToString();
            Boats = new List<Boat>();

        }

        public void DeleteBoat(Boat boat)
        {
            Boats.Remove(boat);
        }

        public Member() {}

        public void AddBoat(Boat boat)
        {
            Boats.Add(boat);
        }
    }
}
