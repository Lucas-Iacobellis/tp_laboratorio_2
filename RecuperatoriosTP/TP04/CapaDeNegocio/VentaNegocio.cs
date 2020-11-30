using BaseDeDatos;
using Entidades;

namespace CapaDeNegocio
{
    public class VentaNegocio
    {
        public void CargarVentas()
        {
            ManajedorSQL.CargarListaVentas();
        }
        public void InsertarVenta(Venta venta)
        {
            ManajedorSQL.InsertVenta(venta);
        }
        public void EliminarVenta(Venta venta)
        {
            ManajedorSQL.DeleteVenta(venta);
        }
        public void ModificarVenta(Venta venta)
        {
            ManajedorSQL.UpdateVenta(venta);
        }
        public bool VerificarVenta(string idProducto, int idVenta)
        {
            return ManajedorSQL.VerificadorDeExistentesVenta(idProducto, idVenta);
        }
        public  int NewIdVentas()
        {
            return ManajedorSQL.NewIdVentas();
        }     
    }
}