using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace dv607workshop2.models
{
    /// <summary>
    /// Handles XMl communication
    /// </summary>
    [XmlRoot("ArrayOfMember")]
    public class XmlHandler
    {
        [XmlElement("Member")]
        public List<Member> Members { get; set; }

        public readonly string _filePath;


        public XmlHandler()
        {
            string directory = Directory.GetCurrentDirectory();
            _filePath = directory + "/register.xml";
        }

        /// <summary>
        /// Creates list from XMl
        /// </summary>
        public void DeSerialize() {
;

            if (!File.Exists(_filePath)) {
                Members = new List<Member>{new Member("test", 000000)};
                Serializ();
                 }
            XmlSerializer serializer = new XmlSerializer(typeof(XmlHandler));
            FileStream fileStream = new FileStream(_filePath, FileMode.Open);
            XmlHandler dataFromXml = (XmlHandler)serializer.Deserialize(fileStream);
            Members = dataFromXml.Members;
        } 


        public void AddMember(Member newMember) 
        {
            Members.Add(newMember);
            Serializ();
            DeSerialize();
        }

        /// <summary>
        /// Writes to Xml
        /// </summary>
        private void Serializ() {

            XmlSerializer serializer = new XmlSerializer(typeof(List<Member>));
            FileStream fileStream = new FileStream(_filePath, FileMode.Create);
            serializer.Serialize(fileStream, Members);
        }

        public void DeleteMember (Member member) {
            Members.Remove(member);
            Serializ();
        }

        public void SaveUpdates() {
            Serializ();
            DeSerialize();
        }

    }
}

