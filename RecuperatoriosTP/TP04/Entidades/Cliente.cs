using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Cliente:Persona
    {
        private int idCliente;

        private static int indice;
        public int IdCliente 
        {
            get { return this.idCliente; }
            set { this.idCliente = value; } 
        }
        public Cliente()
        {

        }
        public Cliente(string nombre, string apellido, int edad, int dni):base(nombre,apellido,edad,dni)
        {

        }
        public Cliente(string nombre, string apellido, int edad, int dni, int idCliente):this(nombre,apellido,edad,dni)
        {
           this.IdCliente = idCliente;
        }
        public override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine("ID Cliente: " + this.IdCliente);

            return sb.ToString();
        }
        public static bool operator +(List<Cliente> listaClientes, Cliente cliente)
        {
            bool retorno = false;

            if (listaClientes.Count != 0)
            {
                for (int i = 0; i < listaClientes.Count; i++)
                {
                    if (listaClientes != cliente)
                    {
                        Negocio.ListaClientes.Add(cliente);
                        retorno = true;
                        break;
                    }
                }
            }

            else
            {
                Negocio.ListaClientes.Add(cliente);
                retorno = true;

            }

            return retorno;
        }
        public static bool operator -(List<Cliente> listaClientes, Cliente cliente)
        {
            bool retorno = false;

            for (int i = 0; i < listaClientes.Count; i++)
            {
                if (listaClientes == cliente)
                {
                    Negocio.ListaClientes.RemoveAt(indice);
                    retorno = true;
                    break;
                }
            }

            return retorno;
        }
        public static bool operator ==(List<Cliente> listaClientes, Cliente cliente)
        {
            bool sonIguales = false;

            for (int i = 0; i < listaClientes.Count; i++)
            {
                if (listaClientes[i].Dni == cliente.Dni || listaClientes[i].IdCliente == cliente.IdCliente)
                {
                    indice = i;
                    sonIguales = true;
                    break;
                }
            }

            return sonIguales;
        }
        public static bool operator !=(List<Cliente> listaClientes, Cliente cliente)
        {

            return !(listaClientes == cliente);
        }
    }
}
