using System;

namespace Serializacion
{
    public static class RutaDeArchivos
    {
        public static string PATHLOG = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Iacobellis.Lucas.2D.TP04\\Logs\\";
        public static string PATHCOMPRASTXT = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Iacobellis.Lucas.2D.TP04\\Compras\\";
        public static string PATHVENTASTXT = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Iacobellis.Lucas.2D.TP04\\Ventas\\";
    }
}