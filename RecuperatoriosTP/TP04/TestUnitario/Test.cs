using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BaseDeDatos;
using CapaDeNegocio;
using Entidades;
using Excepciones;
using Serializacion;
using Validaciones;
using System.Collections.Generic;

namespace TestUnitario
{
    [TestClass]
    public class Test
    {
        [TestMethod]
        public void AddSmartphone()
        {
            //Agrega un celular a la Base de Datos

            Celular celular = new Celular("J7 Prime", 25000, 10, "10", "Samsung", "5 pulgadas", "Octa Core");
            CelularNegocio celularNegocio = new CelularNegocio();

            celularNegocio.InsertarCelular(celular);
        }

        [TestMethod]
        public void DeleteKeyboard()
        {
            //Primero inserta el teclado en la Base de Datos y despues lo elimina

            Teclado teclado = new Teclado("Teclado12", 350, 12, "13", "Genius", "Estandar");
            TecladoNegocio tecladoNegocio = new TecladoNegocio();

            tecladoNegocio.InsertarTeclado(teclado);
            tecladoNegocio.EliminarTeclado(teclado);


        }

        [TestMethod]
        public void GetClients()
        {
            //Metodo para obtener la lista de clientes de la Base de Datos

            ClienteNegocio clienteNegocio = new ClienteNegocio();
            clienteNegocio.CargarClientes();
        }

        [TestMethod]
        public void ListEmployeesWithData()
        {
            //Verifica que la lista de empleados no sea nula

            List<Empleado> listaEmpleados = new List<Empleado>();

            Empleado empleado1 = new Empleado("Oscar", "Gomez", 40, 33297016);
            Empleado empleado2 = new Empleado("Osvaldo", "Carrascal", 41, 329290157);

            listaEmpleados.Add(empleado1);
            listaEmpleados.Add(empleado2);

            Assert.IsNotNull(listaEmpleados);
        }

        [TestMethod]
        public void SobrecargaSmartphone()
        {
            //Agrega un celular a la listaCelulares mediante la sobrecarga del +

            List<Celular> listaCelulares = new List<Celular>();

            Celular celular1 = new Celular("S8 Plus", 50000, 11, "11", "Samsung", "5.5 pulgadas", "Snapdragon");

            Assert.IsTrue(listaCelulares + celular1);
        }   
    }
}

