using BaseDeDatos;
using Entidades;

namespace CapaDeNegocio
{
    public class EmpleadoNegocio
    {
        public void CargarEmpleados()
        {
            ManajedorSQL.CargarListaEmpleados();
        }
        public void InsertarEmpleado(Empleado empleado)
        {
            ManajedorSQL.InsertEmpleado(empleado);
        }
        public void EliminarEmpleado(Empleado empleado)
        {
            ManajedorSQL.DeleteEmpleado(empleado);
        }
        public void ModificarEmpleado(Empleado empleado)
        {
            ManajedorSQL.UpdateEmpleado(empleado);
        }
        public bool VerificarEmpleado(int id)
        {
            return ManajedorSQL.VerificadorDeExistentesEmpleados(id);
        }
    }
}
