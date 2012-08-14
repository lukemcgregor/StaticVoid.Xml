using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace StaticVoid.Xml.DataContractSerialiser
{
    public static class DataContractSerialiserExtensions
    {
        public static string Serialise<T>(this T entity) where T : class
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                DataContractSerializer serializer = new DataContractSerializer(typeof(T));
                serializer.WriteObject(memoryStream, entity);
                return Encoding.UTF8.GetString(memoryStream.ToArray());
            }
        }

        public static T Deserialise<T>(this string xml) where T : class
        {
            using (var memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(xml)))
            {
                DataContractSerializer serializer = new DataContractSerializer(typeof(T));
                return (T)serializer.ReadObject(memoryStream);
            }
        }
    }
}
