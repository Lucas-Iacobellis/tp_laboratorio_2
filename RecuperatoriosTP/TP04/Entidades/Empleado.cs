using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Empleado:Persona
    {
        private int idEmpleado;

        private static int indice;
        public int IdEmpleado 
        {
            get { return this.idEmpleado; }
            set { this.idEmpleado = value; } 
        }
        public Empleado()
        {

        }
        public Empleado(string nombre, string apellido, int edad, int dni):base(nombre,apellido,edad,dni)
        {

        }
        public Empleado(string nombre, string apellido, int edad, int dni, int idEmpleado):this(nombre,apellido,edad,dni)
        {
            this.idEmpleado = idEmpleado;
        }
        public override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine("ID Empleado: " + this.IdEmpleado);
            
            return sb.ToString();
        }
        public static bool operator +(List<Empleado> listaEmpleados, Empleado empleado)
        {
            bool retorno = false;

            if (listaEmpleados.Count != 0)
            {
                for (int i = 0; i < listaEmpleados.Count; i++)
                {
                    if (listaEmpleados != empleado)
                    {
                        Negocio.ListaEmpleados.Add(empleado);
                        retorno = true;
                        break;
                    }
                }
            }

            else
            {
                Negocio.ListaEmpleados.Add(empleado);
                retorno = true;
            }

            return retorno;
        }
        public static bool operator -(List<Empleado> listaEmpleados, Empleado empleado)
        {
            bool retorno = false;

            for (int i = 0; i < listaEmpleados.Count; i++)
            {
                if (listaEmpleados == empleado)
                {
                    Negocio.ListaEmpleados.RemoveAt(indice);
                    retorno = true;
                    break;
                }
            }

            return retorno;
        }
        public static bool operator ==(List<Empleado> listaEmpleados, Empleado empleado)
        {
            bool sonIguales = false;

            for (int i = 0; i < listaEmpleados.Count; i++)
            {
                if (listaEmpleados[i].Dni == empleado.Dni || listaEmpleados[i].IdEmpleado == empleado.IdEmpleado)
                {
                    indice = i;
                    sonIguales = true;
                    break;
                }
            }

            return sonIguales;
        }
        public static bool operator !=(List<Empleado> listaEmpleados, Empleado empleado)
        {

            return !(listaEmpleados == empleado);
        }
    }
}
