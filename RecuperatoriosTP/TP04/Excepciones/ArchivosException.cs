using System;

namespace Excepciones
{
    public class ArchivosException : Exception
    {
        public ArchivosException()
            : base()
        {

        }

        public ArchivosException(string mensaje)
            : base(mensaje)
        {

        }

        public ArchivosException(Exception innerException)
            : base(innerException.Message, innerException)
        {

        }

        public ArchivosException(string mensaje, Exception innerException)
            : base(mensaje, innerException)
        {

        }

    }
}
