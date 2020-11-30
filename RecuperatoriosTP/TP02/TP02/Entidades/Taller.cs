using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public sealed class Taller
    {
        List<Vehiculo> vehiculos;
        int espacioDisponible;
        public enum ETipo
        {
            Ciclomotor, 
            Sedan, 
            SUV, 
            Todos
        }
        private Taller()
        {
            this.vehiculos = new List<Vehiculo>();
        }
        public Taller(int espacioDisponible):this()
        {
            this.espacioDisponible = espacioDisponible;
        }
        public override string ToString()
        {
            return Listar(this, ETipo.Todos);
        }
        public static Taller operator +(Taller t, Vehiculo vehiculo)
        {
            if (t.vehiculos.Count < t.espacioDisponible)
            {
                foreach (Vehiculo v in t.vehiculos)
                {
                    if (v == vehiculo)
                    {
                        return t;
                    }

                }

                t.vehiculos.Add(vehiculo);
                return t;
            }

            return t;

        }
        public static Taller operator -(Taller t, Vehiculo vehiculo)
        {
            foreach (Vehiculo v in t.vehiculos)
            {
                if (v == vehiculo)
                {
                    t.vehiculos.Remove(v);
                    return t;
                }
            }

            return t;
        }
        public static string Listar(Taller t, ETipo tipo)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat($"Tenemos {t.vehiculos.Count} lugares ocupados de un total de {t.espacioDisponible} disponibles");
            sb.AppendLine("");
            foreach (Vehiculo v in t.vehiculos)
            {
                switch (tipo)
                {
                    case ETipo.SUV:
                        if(v is Suv)
                        {
                            sb.AppendLine(v.Mostrar());
                        }
                        break;
                    case ETipo.Ciclomotor:
                        if( v is Ciclomotor)
                        {
                            sb.AppendLine(v.Mostrar());
                        }
                        break;
                    case ETipo.Sedan:
                        if(v is Sedan)
                        {
                            sb.AppendLine(v.Mostrar());
                        }
                        break;
                    default:
                        sb.AppendLine(v.Mostrar());
                        break;
                }
            }

            return sb.ToString();
        }      
    }
}
