using System.Collections.Generic;
using System.Text;
using Validaciones;

namespace Entidades
{
    public class Producto
    {
        private string nombre;
        private float precio;
        private int cantidad;
        private string idProducto;
        private string marca;

        private static int indice;
        public string Nombre 
        {
            get { return this.nombre; }

            set 
            { 
                this.nombre = Validar.ValidarString(value); 
            }
        }
        public float Precio 
        {
            get { return this.precio; }

            set 
            {
                this.precio = Validar.ValidarFloat(value);
            }
        }
        public int Cantidad 
        {
            get { return this.cantidad; }
            set 
            { 
                this.cantidad = Validar.ValidarEntero(value); 
            }
        }
        public string IdProducto 
        {
            get { return this.idProducto; }

            set 
            { 
                this.idProducto = Validar.ValidarString(value); 
            }
        }
        public string Marca 
        {
            get { return this.marca; }

            set 
            { 
                this.marca = Validar.ValidarString(value); 
            }
        }
        public Producto()
        {
            this.Nombre = "Sin nombre";
            this.Precio = -1;
            this.Cantidad = -1;
            this.IdProducto = "-1";
            this.Marca = "Sin marca";
        }
        public Producto(string nombre, float precio, int cantidad,string idProducto, string marca):this()
        {
            this.Nombre = nombre;
            this.Precio = precio;
            this.Cantidad = cantidad;
            this.IdProducto = idProducto;
            this.Marca = marca;
        }
        public virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Nombre: " + this.Nombre);
            sb.AppendLine("Precio: " + this.Precio);
            sb.AppendLine("Cantidad: " + this.Cantidad);
            sb.AppendLine("ID Producto: " + this.IdProducto);
            sb.AppendLine("Marca: " + this.Marca);

            return sb.ToString();
        }
        public static void ProductoRepetidoSuma(Producto producto)
        {
            int acumulador = 0;

            if (Negocio.ListaProductos == producto)
            {
                int cantidadPrevia = CantidadProductoRepetido(Negocio.ListaProductos, producto);
                acumulador = cantidadPrevia + producto.Cantidad;

                Negocio.ListaProductos.RemoveAll(p => p.Nombre == producto.Nombre);

                producto.Cantidad = acumulador;
                producto.Precio = producto.Precio;

                Negocio.ListaProductos.Add(producto);
            }

            else
            {
                Negocio.ListaProductos.Add(producto);
            }
        }
        public static int CantidadProductoRepetido(List<Producto> listaProductos, Producto producto)
        {
            int cantidad = 0;

            for (int i = 0; i < listaProductos.Count; i++)
            {
                if (listaProductos[i].IdProducto == producto.IdProducto)
                {
                    cantidad = cantidad + listaProductos[i].Cantidad;
                    break;
                }
            }

            return cantidad;
        }
        public static int CantidadTotalProductos(List<Venta> list)
        {
            int cantidad = 0;

            foreach (Venta item in list)
            {
                cantidad = cantidad + item.Cantidad;
            }

            return cantidad;
        }
        public static int SumaProductos(List<Venta> list)
        {
            int suma = 0;

            foreach (Venta item in list)
            {
                suma = suma + (int)item.Precio;
            }
            
            return suma;
        }
        public static bool operator +(List<Producto> listaProductos, Producto producto)
        {
            bool retorno = false;

            for (int i = 0; i < listaProductos.Count; i++)
            {
                if (listaProductos != producto)
                {
                    Negocio.ListaProductos.Add(producto);
                    retorno = true;
                    break;
                }
            }

            return retorno;
        }
        public static bool operator -(List<Producto> listaProductos, Producto producto)
        {
            bool retorno = false;

            for (int i = 0; i < listaProductos.Count; i++)
            {
                if (listaProductos == producto)
                {
                    Negocio.ListaProductos.RemoveAt(indice);
                    retorno = true;
                    break;
                }
            }

            return retorno;
        }
        public static bool operator ==(List<Producto> listaProductos, Producto producto) 
        {
            bool sonIguales = false;

            for (int i = 0; i < listaProductos.Count; i++)
            {
                if (listaProductos[i].IdProducto == producto.IdProducto && listaProductos[i].Marca == producto.Marca)
                {
                    indice = i;
                    sonIguales = true;
                    break;
                }
            }

            return sonIguales;
        }
        public static bool operator !=(List<Producto> listaProductos, Producto producto)
        {
            return !(listaProductos == producto);
        }
       
    }
}
