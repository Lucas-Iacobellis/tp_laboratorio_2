using BaseDeDatos;
using Entidades;

namespace CapaDeNegocio
{
    public class TecladoNegocio
    {
        public void CargarTeclados()
        {
            ManajedorSQL.CargarListaTeclados();
        }
        public void InsertarTeclado(Teclado teclado)
        {
            ManajedorSQL.InsertTeclado(teclado);
        }
        public void EliminarTeclado(Teclado teclado)
        {
            ManajedorSQL.DeleteTeclado(teclado);
        }
        public void ModificarTeclado(Teclado teclado)
        {
            ManajedorSQL.UpdateTeclado(teclado);
        }
        public bool VerificarTeclado(string id) 
        {
            return ManajedorSQL.VerificadorDeExistentesTeclados(id);
        }
    }
}
