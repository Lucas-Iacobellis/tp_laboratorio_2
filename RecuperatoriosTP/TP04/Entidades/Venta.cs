using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validaciones;

namespace Entidades
{
    public class Venta : Producto
    {
        private int idVenta;
        private string tipo;
        private string pantalla;
        private string microprocesador;
        private static int indice;
        public int IdVenta
        {
            get { return this.idVenta; }
            set { this.idVenta = value; }
        }

        public string Tipo
        {
            get { return this.tipo; }

            set
            {
                this.tipo = Validar.ValidarString(value);
            }
        }
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
        public Venta(string nombre, float precio, int cantidad, string idProducto, int idVenta, string marca, string pTipo = "", string pPantalla = "", string pMicroprocesador = "") : base(nombre, precio, cantidad, idProducto, marca)
        {
            this.IdVenta = idVenta;
            this.Tipo = pTipo;
            this.Pantalla = pPantalla;
            this.Microprocesador = pMicroprocesador;
        }
        public static bool operator ==(List<Venta> listaVenta, Venta venta)
        {
            bool sonIguales = false;

            for (int i = 0; i < listaVenta.Count; i++)
            {
              
                    if (listaVenta[i].idVenta == venta.idVenta)
                    {
                        indice = i;
                        sonIguales = true;
                        break;
                    }
            }

            return sonIguales;
        }
        public static bool operator !=(List<Venta> listaVenta, Venta teclado)
        {
            return !(listaVenta == teclado);
        }
    }
}
