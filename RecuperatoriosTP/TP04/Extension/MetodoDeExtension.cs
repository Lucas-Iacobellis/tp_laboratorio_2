using System;

namespace Extension
{
    public static class MetodoDeExtension
    {
        public static string FormatoDateTime(this string idVenta)
        {
            return idVenta + "_" + DateTime.Now.Hour.ToString() + "_" + DateTime.Now.Minute.ToString() + "_" + DateTime.Now.Second.ToString() + "_" + DateTime.Now.Year.ToString() + "_" + DateTime.Now.Month.ToString() + "_" + DateTime.Now.Year.ToString();

        }
    }
}