using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using Excepciones;
using Interfaces;

namespace Serializacion
{
    public class SerializacionXML<T> : IArchivo<T>
    {
        SerializacionTXT texto;
        public SerializacionXML()
        {
            texto = new SerializacionTXT();
        }
        public bool Guardar(string path, string archivo, T datos)
        {
            try
            {
                XmlSerializer s = new XmlSerializer(typeof(T));

                if (Directory.Exists(path))
                {
                    using (TextWriter writer = new StreamWriter(path + archivo))
                    {
                        s.Serialize(writer, datos);
                    }
                }

                else
                {
                    Directory.CreateDirectory(path);

                    using (TextWriter writer = new StreamWriter(path + archivo))
                    {
                        s.Serialize(writer, datos);
                    }

                    throw new ArchivosException("Ruta del archivo inexistente. Se creo la ruta: " + path + archivo);
                }

                return true;
            }

            catch (ArchivosException ex)
            {
                texto.Guardar(RutaDeArchivos.PATHLOG, "logs.txt", ex.Message);
                return false;
            }
        }
        public bool Leer(string archivo, out T datos)
        {
            try
            {
                XmlSerializer deserializar = new XmlSerializer(typeof(T));

                using (TextReader reader = new StreamReader(archivo))
                {
                    datos = (T)deserializar.Deserialize(reader);
                    DevolucionDeDatos(datos);
                }

                return true;
            }

            catch (ArchivosException ex)
            {
                throw new ArchivosException(ex.Message, ex);
            }

            catch (Exception ex)
            {
                datos = default(T);
                texto.Guardar(RutaDeArchivos.PATHLOG, "logs.txt", ex.Message);
                return false;
            }


        }
        public T DevolucionDeDatos(T datos)
        {
            return datos;
        }
    }
}
