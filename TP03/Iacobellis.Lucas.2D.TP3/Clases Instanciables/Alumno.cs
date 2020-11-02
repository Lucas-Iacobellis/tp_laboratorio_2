using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases_Abstractas;

namespace Clases_Instanciables
{
    public sealed class Alumno : Universitario
    {
        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado
        }
        private Universidad.EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;

        public Alumno():base() 
        { 
        
        }
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma)
               :base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma
            , EEstadoCuenta estadoCuenta):this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            if (a.claseQueToma == clase && a.estadoCuenta != EEstadoCuenta.Deudor) 
            {
                return true;
            }

            else 
            {
                return false;
            }

        }
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            return !(a == clase);
        }
        public override string ToString()
        {
            string alDia = string.Empty;

            if (this.estadoCuenta == EEstadoCuenta.AlDia)
            {
                alDia = "Cuota al día";
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine($"ESTADO DE CUENTA: {alDia}");
            sb.AppendLine(this.ParticiparEnClase());
            return sb.ToString();
        }
        protected override string MostrarDatos()
        {
            return this.ToString();
        }
        protected override string ParticiparEnClase()
        {
            return $"TOMA CLASES DE {claseQueToma}";
        }

    }
}
