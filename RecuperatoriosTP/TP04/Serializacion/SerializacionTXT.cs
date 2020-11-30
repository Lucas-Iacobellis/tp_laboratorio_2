using System;
using System.IO;
using System.Text;
using Excepciones;
using Interfaces;

namespace Serializacion
{
    public class SerializacionTXT: IArchivo<string>
    {
        public DateTime fechaHora = new DateTime();
        public bool Guardar(string path, string archivo, string datos)
        {
            try
            {
                if (Directory.Exists(path))
                {
                    using (StreamWriter file = new StreamWriter(path + archivo , true, Encoding.UTF8))
                    {
                        file.WriteLine("-----------------------------------------------------");
                        fechaHora = DateTime.Now;
                        file.WriteLine(fechaHora.ToString("dd'/'MM'/'yyyy HH:mm:ss"));
                        file.WriteLine(datos);

                    }

                    return true;
                }

                else
                {
                    Directory.CreateDirectory(path);

                    using (StreamWriter fileNotDirectory = new StreamWriter(path + archivo, true, Encoding.UTF8))
                    {
                        fileNotDirectory.WriteLine("-----------------------------------------------------");
                        fechaHora = DateTime.Now;
                        fileNotDirectory.WriteLine(fechaHora.ToString("dd'/'MM'/'yyyy HH:mm:ss"));
                        fileNotDirectory.WriteLine(datos);
                    }

                    throw new ArchivosException("Ruta del archivo inexistente. Se creo la ruta: " + path);
                }
            }

            catch (ArchivosException ex)
            {
                Guardar(RutaDeArchivos.PATHLOG, archivo, ex.ToString());

                return false;
            }
        }
        public bool Leer(string archivo, out string datos)
        {
            try
            {
                using (StreamReader file = new StreamReader(archivo))
                {
                    datos = file.ReadToEnd();
                }

                return true;
            }
            
            catch (Exception ex)
            {
                throw new ArchivosException(ex);
            }
        }
    }
}
