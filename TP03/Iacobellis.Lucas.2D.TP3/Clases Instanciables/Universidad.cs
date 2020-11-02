using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivo;
using Excepciones;

namespace Clases_Instanciables
{
    public class Universidad
    {
        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }

        private List<Alumno> alumnos;
        private List<Profesor> profesores;
        private List<Jornada> jornadas;
        public List<Alumno> Alumnos
        {
            get { return this.alumnos; }
            set { this.alumnos = value; }
        }

        public List<Profesor> Profesores
        {
            get { return this.profesores; }
            set { this.profesores = value; }
        }

        public List<Jornada> Jornadas
        {
            get { return this.jornadas; }
            set { this.jornadas = value; }
        }

        public Jornada this[int i]
        {
            get
            {
                return this.jornadas[i];
            }
            set
            {
                this.jornadas[i] = value;
            }
        }
        public Universidad()
        {
            this.Alumnos = new List<Alumno>();
            this.Profesores = new List<Profesor>();
            this.Jornadas = new List<Jornada>();
        }
        public static bool operator ==(Universidad g, Alumno a)
        {
            foreach (Alumno item in g.Alumnos)
            {
                if (item.DNI == a.DNI)
                {
                    return true;
                }

            }

            return false;
        }
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }
        public static bool operator ==(Universidad g, Profesor p)
        {
            foreach (Jornada jornada in g.Jornadas)
            {
                if (p == jornada.Instructor)
                {
                    return true;
                }

            }

            return false;
        }
        public static bool operator !=(Universidad g, Profesor p)
        {
            return !(g == p);
        }
        public static Profesor operator ==(Universidad u, EClases clase)
        {
            foreach (Profesor profesor in u.Profesores)
            {
                if (profesor == clase)
                {
                    return profesor;
                }

            }

            throw new SinProfesorException();

        }
        public static Profesor operator !=(Universidad u, EClases clase)
        {
            Profesor profesor = null;

            foreach (Profesor p in u.Profesores)
            {
                if (p != clase)
                {
                    return p;
                }

            }

            return profesor;
        }
        public static Universidad operator +(Universidad g, EClases clase)
        {
            Jornada jornada = new Jornada(clase, (g == clase));

            foreach (Alumno alumno in g.Alumnos)
            {
                if (alumno == clase)
                {
                    jornada += alumno;
                }
            }

            g.Jornadas.Add(jornada);

            return g;
        }
        public static Universidad operator +(Universidad u, Alumno a)
        {
            if (u != a)
            {
                u.Alumnos.Add(a);

                return u;
            }

            throw new AlumnoRepetidoException();

        }
        public static Universidad operator +(Universidad u, Profesor i)
        {
            if (u != i)
            {

                u.profesores.Add(i);
            }

            return u;
        }
        private string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("JORNADA: ");

            foreach (Jornada jornada in Jornadas)
            {
                sb.AppendLine(jornada.ToString());
                sb.AppendLine("<---------------------------->:");
            }

            return sb.ToString();
        }
        public override string ToString()
        {
            return MostrarDatos();
        }
        public static bool Guardar(Universidad uni)
        {
            Xml<Universidad> xml = new Xml<Universidad>();

            if (xml.Guardar("Universidad.xml", uni))
            {
                return true;

            }

            return false;
        }
        public static bool Leer()
        {
            Xml<Universidad> xml = new Xml<Universidad>();

            if (xml.Leer("Universidad.xml", out Universidad universidad))
            {
                Console.WriteLine(universidad.ToString());
                return true;
            }

            return false;
        }       
    }
}
