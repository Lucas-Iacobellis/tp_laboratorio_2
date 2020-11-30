using BaseDeDatos;
using Entidades;

namespace CapaDeNegocio
{
    public class CelularNegocio
    {
        public void CargarCelulares()
        {
            ManajedorSQL.CargarListaCelulares();
        }
        public void InsertarCelular(Celular celular)
        {
            ManajedorSQL.InsertCelular(celular);
        }
        public void EliminarCelular(Celular celular)
        {
            ManajedorSQL.DeleteCelular(celular);
        }
        public void ModificarCelular(Celular celular)
        {
            ManajedorSQL.UpdateCelular(celular);
        }
        public bool VerificarCelular(string id)
        {
            return ManajedorSQL.VerificadorDeExistentesCelulares(id);
        }
    }
}
