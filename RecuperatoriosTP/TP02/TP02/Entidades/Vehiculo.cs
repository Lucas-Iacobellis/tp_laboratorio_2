using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
#pragma warning disable CS0660
#pragma warning disable CS0661

    public abstract class Vehiculo
    {
        public enum EMarca
        {
            Chevrolet, 
            Ford, 
            Renault, 
            Toyota, 
            BMW,
            Honda, 
            HarleyDavidson
        }
        public enum ETamanio
        {
            Chico, 
            Mediano, 
            Grande
        }
        
        EMarca marca;
        string chasis;
        ConsoleColor color;
        public Vehiculo(string chasis, EMarca marca, ConsoleColor color)
        {
            this.chasis = chasis;
            this.marca = marca;
            this.color = color;
        }
        public abstract ETamanio Tamanio { get; }
        public virtual string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"CHASIS: {this.chasis}");
            sb.AppendLine($"MARCA: {this.marca.ToString()}");
            sb.AppendLine($"COLOR: {this.color.ToString()}");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
        
        public static explicit operator string (Vehiculo p)
        {
            return p.Mostrar();
        }
        public static bool operator ==(Vehiculo v1, Vehiculo v2)
        {
            return (v1.chasis == v2.chasis);
        }
        public static bool operator !=(Vehiculo v1, Vehiculo v2)
        {
            return !(v1.chasis == v2.chasis);
        }
    }
}
