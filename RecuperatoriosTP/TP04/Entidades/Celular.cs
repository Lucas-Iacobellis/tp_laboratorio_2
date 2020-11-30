using System.Collections.Generic;
using System.Text;
using Validaciones;

namespace Entidades
{
    public class Celular : Producto
    {
        private string pantalla;
        private string microprocesador;

        private static int indice;
        public string Pantalla
        {
            get { return this.pantalla; }

            set
            {
                this.pantalla = Validar.ValidarString(value);
            }
        }
        public string Microprocesador
        {
            get { return this.microprocesador; }

            set
            {
                this.microprocesador = Validar.ValidarString(value);
            }
        }

        public Celular()
        {
            this.Nombre = "Sin nombre";
            this.Precio = -1;
            this.Cantidad = -1;
            this.IdProducto = "-1";
            this.Marca = "Sin marca";
            this.Pantalla = "Sin pantalla";
            this.Microprocesador = "Sin microprocesador";
        }
        public Celular(string nombre, float precio, int cantidad, string idProducto, string marca, string pantalla, string microprocesador) : this()
        {
            this.Nombre = nombre;
            this.Precio = precio;
            this.Cantidad = cantidad;
            this.IdProducto = idProducto;
            this.Marca = marca;
            this.Pantalla = pantalla;
            this.Microprocesador = microprocesador;
        }
        public override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine("Pantalla: " + this.Pantalla);
            sb.AppendLine("Microprocesador: " + this.Microprocesador);
            return sb.ToString();
        }
        public static void CelularRepetidoSuma(Celular celular)
        {
            int acumulador = 0;

            if (Negocio.ListaCelulares == celular)
            {
                int cantidadPrevia = CantidadCelularRepetido(Negocio.ListaCelulares, celular);
                acumulador = cantidadPrevia + celular.Cantidad;

                Negocio.ListaProductos.RemoveAll(c => c.Nombre == celular.Nombre);

                celular.Cantidad = acumulador;
                celular.Precio = celular.Precio;

                Negocio.ListaProductos.Add(celular);
            }

            else
            {
                Negocio.ListaProductos.Add(celular);
            }
        }
        public static int CantidadCelularRepetido(List<Celular> listaCelulares, Celular celular)
        {
            int cantidad = 0;

            for (int i = 0; i < listaCelulares.Count; i++)
            {
                if (listaCelulares[i].IdProducto == celular.IdProducto)
                {
                    cantidad = cantidad + listaCelulares[i].Cantidad;
                    break;
                }
            }

            return cantidad;
        }
        public static int CantidadTotalCelulares()
        {
            int cantidad = 0;

            for (int i = 0; i < Negocio.ListaVentas.Count; i++)
            {
                if (Negocio.ListaVentas[i].Microprocesador!= "" && Negocio.ListaVentas[i].Pantalla != "")
                {
                    cantidad = cantidad + Negocio.ListaVentas[i].Cantidad;
                }

            }

            return cantidad;
        }
        public static float SumaCelulares()
        {
            float suma = 0;

            for (int i = 0; i < Negocio.ListaVentas.Count; i++)
            {
                if (Negocio.ListaVentas[i].Microprocesador != "" && Negocio.ListaVentas[i].Pantalla != "")
                {

                    suma = suma + Negocio.ListaVentas[i].Precio;
                }
            }                
            

            return suma;
        }
        public static bool operator +(List<Celular> listaCelulares, Celular celular)
        {
            bool retorno = false;

            if (listaCelulares.Count != 0)
            {
                for (int i = 0; i < listaCelulares.Count; i++)
                {
                    if (listaCelulares != celular)
                    {
                        Negocio.ListaCelulares.Add(celular);
                        retorno = true;
                        break;
                    }
                }
            }

            else
            {
                Negocio.ListaCelulares.Add(celular);
                retorno = true;
            }
            

            return retorno;
        }
        public static bool operator -(List<Celular> listaCelulares, Celular celular)
        {
            bool retorno = false;

            for (int i = 0; i < listaCelulares.Count; i++)
            {
                if (listaCelulares == celular)
                {
                    Negocio.ListaCelulares.RemoveAt(indice);
                    retorno = true;
                    break;
                }
            }

            return retorno;
        }
        public static bool operator ==(List<Celular> listaCelulares, Celular celular)
        {
            bool sonIguales = false;

            for (int i = 0; i < listaCelulares.Count; i++)
            {
                if (listaCelulares[i].IdProducto == celular.IdProducto && listaCelulares[i].Marca == celular.Marca)
                {
                    indice = i;
                    sonIguales = true;
                    break;
                }
            }

            return sonIguales;
        }
        public static bool operator !=(List<Celular> listaCelulares, Celular celular)
        {
            return !(listaCelulares == celular);
        }
    }
}
