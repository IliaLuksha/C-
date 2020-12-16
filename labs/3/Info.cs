using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml;
using System.IO;
using System.IO.Compression;

namespace WindowsService1
{
    class Info
    {
        [JsonPropertyName("TargetDirectory")]
        internal string Target { get; set; }
        [JsonPropertyName("SourseDirectory")]
        internal string Source { get; set; }

        public Info()
        {
            Target = @"C:\\Users\\User\\Desktop\\TargetDirectory\\";
            Source = @"C:\\Users\\User\\Desktop\\SourceDirectory\\";
        }
    }
    class Confik
    {
        public Info XML()
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(@"C:\\Users\\User\\Desktop\\XML.xml");
            XmlElement xRoot = xDoc.DocumentElement;
            // обход всех узлов в корневом элементе
            Info information = new Info();

            foreach (XmlNode xnode in xRoot)
            {
                if (xnode.Name == "TargetDirectory")
                {
                    information.Source = xnode.InnerText;
                }


                if (xnode.Name == "SourceDirectory")
                {
                    information.Target = xnode.InnerText;
                }
            }

            return information;

        }

        public Info JSON()
        {
            string setup;
            using (var stream = new StreamReader(@"C:\\Users\\User\\Desktop\\JSON.json"))
            {
                setup = stream.ReadToEnd();
            }

            Info information = JsonSerializer.Deserialize<Info>(setup);
            return information;
        }
    }
}
