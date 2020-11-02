using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Excepciones;

namespace Archivo
{
    public class Xml<T> : IArchivo<T>
    {
        public bool Guardar(string archivo, T datos)
        {
            if (!string.IsNullOrEmpty(archivo) && datos != null)
            {
                try

                {
                    string path = AppDomain.CurrentDomain.BaseDirectory;

                    using (XmlTextWriter xmlWriter = new XmlTextWriter(path + @"\" + archivo, Encoding.UTF8))
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(T));
                        serializer.Serialize(xmlWriter, datos);

                    }

                    return true;
                }

                catch (Exception e)
                {
                    throw new ArchivosException(e);
                }
            }

            return false;
        }

        public bool Leer(string archivo, out T datos)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;

            datos = default(T);
            if (!string.IsNullOrEmpty(archivo) && datos != null)
            {
                try
                {
                    using (XmlTextReader xmlReader = new XmlTextReader(path + @"\" + archivo))
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(T));
                        datos = (T)serializer.Deserialize(xmlReader);
                        return true;

                    }

                }

                catch (Exception e)
                {
                    throw new ArchivosException(e);
                }
            }

            return false;
        }
    }
}
