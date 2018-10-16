using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace dv607workshop2.models
{
    public static class XmlReader
    {
        public static void GetAllMembers(string file)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(MemberList));
            // FileStream fileStream = new FileStream("register.xml", FileMode.Open);

            // member members = (member)serializer.Deserialize(fileStream);

            // XmlSerializer ser = new XmlSerializer(typeof(Cars));
            // Cars cars;
            using (FileStream fileStream = new FileStream("register.xml", FileMode.Open))
            {
                MemberList cars = (MemberList)serializer.Deserialize(fileStream);
                var a = cars.Members
                    .First();

                Console.WriteLine(a.MemberId);
                Console.WriteLine(a.Name);
            }


        }
    }
}