using BaseDeDatos;
using Entidades;

namespace CapaDeNegocio
{
    public class ClienteNegocio
    {
        public void CargarClientes()
        {
            ManajedorSQL.CargarListaClientes();
        }
        public void InsertarCliente(Cliente cliente)
        {
            ManajedorSQL.InsertCliente(cliente);
        }
        public void EliminarCliente(Cliente cliente)
        {
            ManajedorSQL.DeleteCliente(cliente);
        }
        public void ModificarCliente(Cliente cliente)
        {
            ManajedorSQL.UpdateCliente(cliente);
        }
        public bool VerificarCliente(int id)
        {
            return ManajedorSQL.VerificadorDeExistentesClientes(id);
        }

    }
}
