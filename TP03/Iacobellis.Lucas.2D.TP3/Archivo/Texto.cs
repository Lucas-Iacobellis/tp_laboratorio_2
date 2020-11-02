using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace Archivo
{
    public class Texto : IArchivo<string>
    {
        public bool Guardar(string archivo, string datos)
        {
            bool aux = false;
            if (!string.IsNullOrEmpty(archivo) && !string.IsNullOrEmpty(datos))
            {
                try
                {
                    string path = AppDomain.CurrentDomain.BaseDirectory;

                    using (StreamWriter sw = new StreamWriter(Path.Combine(path, archivo)))
                    {
                        sw.WriteLine(datos);
                        aux = true;
                    }

                }

                catch (Exception e)
                {
                    throw new ArchivosException(e);
                }
            }

            return aux;
        }
        public bool Leer(string archivo, out string datos)
        {
            bool aux = false;
            datos = "";
            if (!string.IsNullOrEmpty(archivo))
            {
                try
                {
                    string path = AppDomain.CurrentDomain.BaseDirectory;

                    using (StreamReader sw = new StreamReader(Path.Combine(path, archivo)))
                    {
                        datos = sw.ReadToEnd();
                        aux = true;
                    }
                }

                catch (Exception e)
                {
                    throw new ArchivosException(e);
                }
            }

            return aux;
        }


    }
}
