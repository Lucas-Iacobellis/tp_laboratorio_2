namespace Interfaces
{
    public interface IArchivo<T>
    {
         bool Guardar(string path, string archivo, T datos);
         bool Leer(string archivo, out T datos);
    }
}

