using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivo;

namespace Clases_Instanciables
{
    public class Jornada
    {
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;
        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }
            set
            {
                this.alumnos = value;
            }
        }

        public Universidad.EClases Clase
        {
            get
            {
                return this.clase;
            }
            set
            {
                this.clase = value;
            }
        }

        public Profesor Instructor
        {
            get
            {
                return this.instructor;
            }
            set
            {
                this.instructor = value;
            }
        }
        private Jornada()
        {
            this.Alumnos = new List<Alumno>();
        }
        public Jornada(Universidad.EClases clase, Profesor instructor):this()
        {
            this.Clase = clase;
            this.Instructor = instructor;
        }
        public static bool operator ==(Jornada j, Alumno a)
        {
            foreach (Alumno item in j.alumnos)
            {
                if (item == a)
                {
                    return true;
                }
            }

            return false;
        }
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a)
            {
                j.alumnos.Add(a);
            }

            return j;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"CLASE DE {this.Clase.ToString()} POR NOMBRE COMPLETO: {this.Instructor}");
            sb.AppendLine("ALUMNOS:");

            foreach (Alumno alumno in Alumnos)
            {
                sb.AppendLine(alumno.ToString());
            }

            return sb.ToString();
        }
        public static bool Guardar(Jornada jornada)
        {
            Texto txt = new Texto();

            return txt.Guardar("Jornada.txt", jornada.ToString());
        }
        public static string Leer()
        {
            Texto txt = new Texto();
            txt.Leer("Jornada.txt", out string aux);

            return aux;
        }

    }
}
