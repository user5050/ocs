using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Runtime.Serialization.Formatters.Binary;
using Newtonsoft.Json;

namespace OneCoin.Service.Helper.Serialization
{

    /// <summary>
    /// 序列化帮助类
    /// </summary>
    public class SimpleSerialization
    {
      
        #region Json
        /// <summary>
        /// 对象
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ObjectToJson(object obj)
        {
            if (obj == null) return string.Empty;
            
            return JsonConvert.SerializeObject(obj);
        }

        /// <summary>
        /// 对象
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static object JsonToObject( string str )
        { 
            return JsonConvert.DeserializeObject(str);
        }

        /// <summary>
        /// 对象
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static T JsonToObject<T>( string str )
        {
            return JsonConvert.DeserializeObject<T>(str);
        }
        #endregion

        #region Xml
        /// <summary>
        /// 对象序列化到XML
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ObjectToXml( object obj )
        {
            if( obj == null )
            {
                return string.Empty;
            }

            var setting = new XmlWriterSettings {Encoding = Encoding.UTF8, Indent = true};


            var ser = new System.Xml.Serialization.XmlSerializer( obj.GetType() );

            var stream = new MemoryStream();
            using (var writer = XmlWriter.Create(stream, setting))
            {
                ser.Serialize( writer, obj );
            }
                        
            stream.Position = 0;
            using( var sr = new StreamReader( stream ) )
            {
                return sr.ReadToEnd();
            }
        }

        /// <summary>
        /// XML反序列化回对象
        /// </summary>
        /// <param name="xml"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public static object XmlToObject( string xml, Type t )
        {
            if( xml == null || t == null )
            {
                return null;
            }
            var ser = new System.Xml.Serialization.XmlSerializer( t );

            var xdoc = new XmlDocument();
            xdoc.LoadXml( xml );
            object obj = null;
            if (xdoc.DocumentElement != null)
            {
                using (var reader = new XmlNodeReader(xdoc.DocumentElement))
                {
                    obj = ser.Deserialize(reader);
                }
            }
                
            return obj;
        }


        

        /// <summary>
        /// XML反序列化回对象
        /// </summary>
        /// <param name="xml"></param> 
        /// <returns></returns>
        public static T XmlToObject<T>(string xml)
        {
            T obj = default(T);
            if (xml == null)
            {
                return obj;
            }

            var ser = new System.Xml.Serialization.XmlSerializer(typeof(T));
            var xdoc = new XmlDocument();
            xdoc.LoadXml(xml);
            if (xdoc.DocumentElement != null)
            {
                using (var reader = new XmlNodeReader(xdoc.DocumentElement))
                {
                    obj = (T)ser.Deserialize(reader);
                }
            } 

            return obj;
        }
        #endregion

        #region Binary
        // Methods
        public static byte[] ToBytes( object value )
        {
            if( value == null )
            {
                return null;
            }
            using( var stream = new MemoryStream() )
            {
                new BinaryFormatter().Serialize( stream, value );
                return stream.ToArray();
            }
        }

        public static object ToObject( byte[] serializedObject )
        {
            if( serializedObject == null )
            {
                return null;
            }
            using( var stream = new MemoryStream( serializedObject ) )
            {
                return new BinaryFormatter().Deserialize( stream );
            }
        }
        #endregion 


        public static Dictionary<string,string> ToKeyValue(object value)
        {
            if(value==null) return new Dictionary<string, string>();

            var type = value.GetType();

            return type.GetProperties().ToDictionary(p => p.Name, p => p.GetValue(value).ToString());
        }
    }
}
