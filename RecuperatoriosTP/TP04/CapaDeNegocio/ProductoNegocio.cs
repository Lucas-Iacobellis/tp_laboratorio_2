using BaseDeDatos;
using Entidades;

namespace CapaDeNegocio
{
    public class ProductoNegocio
    {
        public void CargarProductos() 
        {
            ManajedorSQL.CargarListaProductos();
        }
        public void InsertarProducto(Producto producto)
        {
            ManajedorSQL.InsertProducto(producto);
        }
        public void EliminarProducto(Producto producto)
        {
            ManajedorSQL.DeleteProducto(producto);
        }
        public void ModificarProducto(Producto producto)
        {
            ManajedorSQL.UpdateProducto(producto);
        }       
    }
}
