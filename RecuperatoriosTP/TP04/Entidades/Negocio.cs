using System.Collections.Generic;

namespace Entidades
{
    public static class Negocio
    {
        private static List<Cliente> listaClientes;
        private static List<Empleado> listaEmpleados;
        private static List<Producto> listaProductos;
        private static List<Celular> listCelulares;
        private static List<Teclado> listTeclados;
        private static List<Venta> listaVentas;

        private static bool todoBorradoClientes;
        private static bool todoBorradoEmpleados;
        private static bool todoBorradoProductos;
        public static List<Cliente> ListaClientes 
        {
            get { return Negocio.listaClientes; }
            set { Negocio.listaClientes = value; }
        }
        public static List<Empleado> ListaEmpleados 
        {
            get { return Negocio.listaEmpleados; }
            set { Negocio.listaEmpleados = value; }
        }
        public static List<Producto> ListaProductos 
        {
            get { return Negocio.listaProductos; }
            set { Negocio.listaProductos = value; }
        }
        public static List<Celular> ListaCelulares
        {
            get { return Negocio.listCelulares; }
            set { Negocio.listCelulares= value; }
        }

        public static List<Teclado> ListaTeclados
        {
            get { return Negocio.listTeclados; }
            set { Negocio.listTeclados = value; }
        }
        public static List<Venta> ListaVentas
        {
            get { return Negocio.listaVentas; }
            set { Negocio.listaVentas = value; }
        }
        public static bool TodoBorradoClientes 
        {
            get { return Negocio.todoBorradoClientes; }
            set { Negocio.todoBorradoClientes = value; } 
        }

        public static bool TodoBorradoEmpleados
        {
            get { return Negocio.todoBorradoEmpleados; }
            set { Negocio.todoBorradoEmpleados = value; }
        }
        public static bool TodoBorradoProductos
        {
            get { return Negocio.todoBorradoProductos; }
            set { Negocio.todoBorradoProductos = value; }
        }

        static Negocio()
        {
            Negocio.ListaClientes = new List<Cliente>();
            Negocio.ListaEmpleados = new List<Empleado>();
            Negocio.ListaProductos = new List<Producto>();
            Negocio.ListaCelulares = new List<Celular>();
            Negocio.ListaTeclados = new List<Teclado>();
            Negocio.ListaVentas = new List<Venta>();
        }
        //public static int TotalStock() 
        //{
        //    int acumulador = 0;

        //    foreach (var item in Negocio.ListaProductos)
        //    {
        //        acumulador = acumulador + item.Cantidad;
        //    }

        //    return acumulador;
        //}

        //public static int TotalStockVentas()
        //{
        //    int acumulador = 0;

        //    foreach (var item in Negocio.listaVentas)
        //    {
        //        acumulador = acumulador + item.Cantidad;
        //    }

        //    return acumulador;
        //}

    }
}
