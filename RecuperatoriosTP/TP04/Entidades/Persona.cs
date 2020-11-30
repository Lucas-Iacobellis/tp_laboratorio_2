using System.Text;
using Validaciones;

namespace Entidades
{
    public abstract class Persona
    {
        protected string nombre;
        protected string apellido;
        protected int edad;
        protected int dni;
        public string Nombre
        {
            get { return this.nombre; }

            set
            {
                this.nombre = Validar.ValidarString(value);       
            }
        }
        public string Apellido
        {
            get { return this.apellido; }

            set
            {
                this.apellido = Validar.ValidarString(value);
            }
        }
        public int Edad
        {
            get { return this.edad; }

            set
            {
                this.edad = Validar.ValidarEntero(value);
            }
        }
        public int Dni
        {
            get { return this.dni; }

            set
            {
                this.dni = Validar.ValidarEntero(value);
            }
        }
        public Persona()
        {
            this.Nombre = "Sin nombre";
            this.Apellido = "Sin apellido";
            this.Edad = 0;
            this.Dni = 0;
        }
        public Persona(string nombre, string apellido, int edad, int dni):this()
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Edad = edad;
            this.Dni = dni;
        }
        public virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Nombre: " + this.Nombre);
            sb.AppendLine("Apellido: " + this.Apellido);
            sb.AppendLine("Edad: " + this.Edad);
            sb.AppendLine("DNI: " + this.Dni);

            return sb.ToString();
        }
    }
}
