using System;

namespace Excepciones
{
    public class EnteroInvalidoException : Exception
    {
        public EnteroInvalidoException()
            : base()
        {

        }

        public EnteroInvalidoException(string mensaje)
            : base(mensaje)
        {

        }

        public EnteroInvalidoException(Exception innerException)
            : base(innerException.Message, innerException)
        {

        }

        public EnteroInvalidoException(string mensaje, Exception innerException)
            : base(mensaje, innerException)
        {

        }

    }
}
