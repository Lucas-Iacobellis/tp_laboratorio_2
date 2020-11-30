using System.Collections.Generic;
using System.Text;
using Validaciones;

namespace Entidades
{
    public class Teclado : Producto
    {
        private string tipo;

        private static int indice;
        public string Tipo
        {
            get { return this.tipo; }

            set
            {
                this.tipo = Validar.ValidarString(value);
            }
        }

        public Teclado()
        {
            this.Nombre = "Sin nombre";
            this.Precio = -1;
            this.Cantidad = -1;
            this.IdProducto = "-1";
            this.Marca = "Sin marca";
            this.Tipo = "Sin tipo";
        }
        public Teclado(string nombre, float precio, int cantidad, string idProducto, string marca, string tipo) : this()
        {
            this.Nombre = nombre;
            this.Precio = precio;
            this.Cantidad = cantidad;
            this.IdProducto = idProducto;
            this.Marca = marca;
            this.Tipo = tipo;
        }
        public override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine("Tipo: " + this.Tipo);
            return sb.ToString();
        }
        public static void TecladoRepetidoSuma(Teclado teclado)
        {
            int acumulador = 0;

            if (Negocio.ListaTeclados == teclado)
            {
                int cantidadPrevia = CantidadTecladoRepetido(Negocio.ListaTeclados, teclado);
                acumulador = cantidadPrevia + teclado.Cantidad;

                Negocio.ListaProductos.RemoveAll(t => t.Nombre == teclado.Nombre);

                teclado.Cantidad = acumulador;
                teclado.Precio = teclado.Precio;

                Negocio.ListaProductos.Add(teclado);
            }

            else
            {
                Negocio.ListaProductos.Add(teclado);
            }
        }
        public static int CantidadTecladoRepetido(List<Teclado> listaTeclados, Teclado teclado)
        {
            int cantidad = 0;

            for (int i = 0; i < listaTeclados.Count; i++)
            {
                if (listaTeclados[i].IdProducto == teclado.IdProducto)
                {
                    cantidad = cantidad + listaTeclados[i].Cantidad;
                    break;
                }
            }

            return cantidad;
        }
        public static int CantidadTotalTeclados()
        {
            int cantidad = 0;


            for (int i = 0; i< Negocio.ListaVentas.Count; i++)
            {
                if (Negocio.ListaVentas[i].Tipo != "")
                {
                    cantidad = cantidad + Negocio.ListaVentas[i].Cantidad;
                }

                
            }



            return cantidad;
        }
        public static float SumaTeclados()
        {
            float suma = 0;

            for (int i = 0; i < Negocio.ListaVentas.Count; i++)
            {
                if (Negocio.ListaVentas[i].Tipo!= "" )
                {
                    suma = suma + Negocio.ListaVentas[i].Precio;
                }
                
            }

            return suma;
        }
        public static bool operator +(List<Teclado> listaTeclados, Teclado teclado)
        {
            bool retorno = false;

            if (listaTeclados.Count != 0)
            {
                for (int i = 0; i < listaTeclados.Count; i++)
                {
                    if (listaTeclados != teclado)
                    {
                        Negocio.ListaTeclados.Add(teclado);
                        retorno = true;
                        break;
                    }
                }
            }
            else
            {
                Negocio.ListaTeclados.Add(teclado);
                retorno = true;
            }

            return retorno;
        }
        public static bool operator -(List<Teclado> listaTeclados, Teclado teclado)
        {
            bool retorno = false;

            for (int i = 0; i < listaTeclados.Count; i++)
            {
                if (listaTeclados == teclado)
                {
                    listaTeclados.RemoveAt(indice);
                    retorno = true;
                    break;
                }
            }

            return retorno;
        }
        public static bool operator ==(List<Teclado> listaTeclados, Teclado teclado)
        {
            bool sonIguales = false;

            for (int i = 0; i < listaTeclados.Count; i++)
            {
                if (listaTeclados[i].IdProducto == teclado.IdProducto && listaTeclados[i].Marca == teclado.Marca)
                {
                    indice = i;
                    sonIguales = true;
                    break;
                }
            }

            return sonIguales;
        }
        public static bool operator !=(List<Teclado> listaTeclados, Teclado teclado)
        {
            return !(listaTeclados == teclado);
        }
    }
}