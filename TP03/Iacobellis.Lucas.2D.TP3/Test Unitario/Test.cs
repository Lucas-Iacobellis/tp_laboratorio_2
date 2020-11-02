using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Archivo;
using Clases_Abstractas;
using Clases_Instanciables;
using Excepciones;

namespace Test_Unitario
{
    [TestClass]
    public class Test
    {
        //Prueba que lance la excepcion SinProfesorException

        [TestMethod]
        [ExpectedException(typeof(SinProfesorException))]
        public void TestSinProfesorException()
        {
            Universidad uni = new Universidad();
            Alumno a1 = new Alumno(1, "Juan", "Lopez", "12234456", Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion, Alumno.EEstadoCuenta.Becado);
            uni += Universidad.EClases.SPD;
        }

        //Prueba que lance la excepcion NacionalidadInvalidaException

        [TestMethod]
        [ExpectedException(typeof(NacionalidadInvalidaException))]
        public void TestDniException()
        {

            Alumno a1 = new Alumno(1, "Juan", "Lopez", "0",
            Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion,
            Alumno.EEstadoCuenta.Becado);
        }

        //Verifica si se agrega un Alumno a la Universidad
        //Si devuelve true es porque se agrego a la lista

        [TestMethod]
        public void TestAgregarAlumno()
        {
            Universidad uni = new Universidad();
            Alumno alumno1 = new Alumno(1, "Juan", "Lopez", "12234456", Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion, Alumno.EEstadoCuenta.Becado);
            uni.Alumnos.Add(alumno1);

            Assert.IsTrue(uni.Alumnos.Count != 0);

        }
    }
}
