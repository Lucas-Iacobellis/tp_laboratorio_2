using System;

namespace Excepciones
{
    public class FloatInvalidoException : Exception
    {
        public FloatInvalidoException()
            : base()
        {

        }

        public FloatInvalidoException(string mensaje)
            : base(mensaje)
        {

        }

        public FloatInvalidoException(Exception innerException)
            : base(innerException.Message, innerException)
        {

        }

        public FloatInvalidoException(string mensaje, Exception innerException)
            : base(mensaje, innerException)
        {

        }

    }
}
