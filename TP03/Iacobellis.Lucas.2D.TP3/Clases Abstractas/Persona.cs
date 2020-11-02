using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace Clases_Abstractas
{
    public abstract class Persona
    {
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }

        private string nombre;
        private string apellido;
        private ENacionalidad nacionalidad;
        private int dni;
        public string Nombre
        {
            get { return this.nombre; }
            set { this.nombre = ValidarNombreApellido(value); }
        }
        public string Apellido
        {
            get { return this.apellido; }
            set { this.apellido = ValidarNombreApellido(value); ; }
        }
        public ENacionalidad Nacionalidad
        {
            get { return this.nacionalidad; }
            set { this.nacionalidad = value; }
        }
        public int DNI
        {
            get { return this.dni; }

            set
            {
                this.dni = ValidarDni(this.Nacionalidad, value);
            }
        }
        public string StringToDni
        {
            set
            {
                this.dni = ValidarDni(this.Nacionalidad, value);
            }
        }
        public Persona() 
        { 
        
        }
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
               :this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
               :this(nombre, apellido, nacionalidad)
        {
            this.StringToDni = dni;
        }
        private int ValidarDni(ENacionalidad nacionalidad, int dni)
        {
            if (nacionalidad == ENacionalidad.Argentino && dni >= 1 && dni <= 89999999 || nacionalidad == ENacionalidad.Extranjero && dni > 89999999 && dni <= 99999999)
            {
                return dni;
            }

            throw new NacionalidadInvalidaException();

        }
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            if (!string.IsNullOrEmpty(dato) && int.TryParse(dato, out int datoInt))
            {
                return ValidarDni(nacionalidad, datoInt);
            }
            else
            {
                throw new DniInvalidoException();
            }
        }
        private string ValidarNombreApellido(string dato)
        {
            if (!string.IsNullOrEmpty(dato) && !string.IsNullOrWhiteSpace(dato))
            {
                return dato;
            }

            else
            {
                return "Desconocido";
            }

        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("NOMBRE COMPLETO: " + this.Apellido + ", " + this.Nombre);
            sb.AppendLine("NACIONALIDAD: " + this.Nacionalidad.ToString());
            sb.AppendLine("DNI: " + this.DNI.ToString());
            return sb.ToString();
        }
    }
}
