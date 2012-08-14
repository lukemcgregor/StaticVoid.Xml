using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace StaticVoid.Xml.XmlSerialiser
{
    public static class XmlSerialiserExtentions
    {
        public static string Serialise<T>(this T entity) where T : class
        {
            using (var memoryStream = new MemoryStream())
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                serializer.Serialize(memoryStream, entity);
                return Encoding.UTF8.GetString(memoryStream.ToArray());
            }
        }

        public static T Deserialise<T>(this string xml) where T : class
        {
            using (var memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(xml)))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                return (T)serializer.Deserialize(memoryStream);
            }
        }
    }
}
