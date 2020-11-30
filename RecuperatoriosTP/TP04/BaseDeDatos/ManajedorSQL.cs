using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Entidades;
using Serializacion;

namespace BaseDeDatos
{
    public static class ManajedorSQL
    {
        static SqlConnection conexion;

        static string queryInsertCliente = "INSERT INTO Clientes (nombre, apellido, edad, dni, idCliente) values (@nombre, @apellido, @edad, @dni, @idCliente)";
        static string queryDeleteCliente = "DELETE FROM Clientes WHERE idCliente = @idCliente";
        static string queryUpdateCliente = "UPDATE Clientes SET nombre = @nombre, apellido = @apellido, edad = @edad, dni = @dni, idCliente = @idCliente WHERE idCliente = @idCliente";

        static string queryInsertEmpleado = "INSERT INTO Empleados (nombre, apellido, edad, dni, idEmpleado) values (@nombre, @apellido, @edad, @dni, @idEmpleado)";
        static string queryDeleteEmpleado = "DELETE FROM Empleados WHERE idEmpleado = @idEmpleado";
        static string queryUpdateEmpleado = "UPDATE Empleados SET nombre = @nombre, apellido = @apellido, edad = @edad, dni = @dni, idEmpleado = @idEmpleado WHERE idEmpleado = @idEmpleado";

        static string queryInsertProducto = "INSERT INTO Productos (nombre, precio, cantidad, idProducto, marca) values (@nombre, @precio, @cantidad, @idProducto, @marca)";
        static string queryDeleteProducto = "DELETE FROM Productos WHERE idProducto = @idProducto";
        static string queryUpdateProducto = "UPDATE Productos SET nombre = @nombre, precio = @precio, cantidad = @cantidad, idProducto = @idProducto, marca = @marca WHERE idProducto = @idProducto";

        static string queryInsertCelular = "INSERT INTO Celulares (nombre, precio, cantidad, idProducto, marca, pantalla, microprocesador) values (@nombre, @precio, @cantidad, @idProducto, @marca, @pantalla, @microprocesador)";
        static string queryDeleteCelular = "DELETE FROM Celulares WHERE idProducto = @idProducto";
        static string queryUpdateCelular = "UPDATE Celulares SET nombre = @nombre, precio = @precio, cantidad = @cantidad, idProducto = @idProducto, marca = @marca, pantalla = @pantalla, microprocesador = @microprocesador WHERE idProducto = @idProducto";

        static string queryInsertTeclado = "INSERT INTO Teclados (nombre, precio, cantidad, idProducto, marca, tipo) values (@nombre, @precio, @cantidad, @idProducto, @marca, @tipo)";
        static string queryDeleteTeclado = "DELETE FROM Teclados WHERE idProducto = @idProducto";
        static string queryUpdateTeclado = "UPDATE Teclados SET nombre = @nombre, precio = @precio, cantidad = @cantidad, idProducto = @idProducto, marca = @marca, tipo = @tipo WHERE idProducto = @idProducto";

        static string queryInsertVenta = "INSERT INTO Ventas (nombre, precio, cantidad, idProducto, idVenta, marca, tipo, pantalla, microprocesador) values (@nombre, @precio, @cantidad, @idProducto, @idVenta, @marca, @tipo, @pantalla, @microprocesador)";
        static string queryDeleteVenta = "DELETE FROM Ventas WHERE idVenta = @idVenta";
        static string queryUpdateVenta = "UPDATE Ventas SET nombre = @nombre, precio = @precio, cantidad = @cantidad, idProducto = @idProducto, idVenta = @idVenta, marca = @marca, tipo = @tipo, pantalla = @pantalla, microprocesador = @microprocesador WHERE idVenta = @idVenta";
        static ManajedorSQL()
        {
            conexion = new SqlConnection(@"Data Source = .\SQLEXPRESS; Initial Catalog = SistemaDeVentas; Integrated Security = True;");
        }
        public static List<Cliente> ObtenerClientes()
        {
            List<Cliente> auxClientes = new List<Cliente>();

            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;
            comando.CommandType = CommandType.Text;
            comando.CommandText = "SELECT * From Clientes";

            if (conexion.State != ConnectionState.Open)
                conexion.Open();

            SqlDataReader datosClientes = comando.ExecuteReader();

            while (datosClientes.Read())
            {
                auxClientes.Add(new Cliente(datosClientes["Nombre"].ToString(), datosClientes["Apellido"].ToString(), int.Parse(datosClientes["Edad"].ToString()), int.Parse(datosClientes["DNI"].ToString()), int.Parse(datosClientes["IdCliente"].ToString())));
            }

            if (conexion.State != ConnectionState.Closed)
                conexion.Close();

            return auxClientes;
        }
        public static void CargarListaClientes()
        {
            Negocio.ListaClientes = ManajedorSQL.ObtenerClientes();
        }
        public static void InsertCliente(Cliente cliente)
        {
            try
            {
                if (conexion.State != ConnectionState.Open)
                    conexion.Open();

                int filasAfectadas = 0;

                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;

                comando.Parameters.Clear();

                comando.CommandText = queryInsertCliente;
                comando.Parameters.Add(new SqlParameter("Nombre", cliente.Nombre));
                comando.Parameters.Add(new SqlParameter("Apellido", cliente.Apellido));
                comando.Parameters.Add(new SqlParameter("Edad", cliente.Edad));
                comando.Parameters.Add(new SqlParameter("DNI", cliente.Dni));
                comando.Parameters.Add(new SqlParameter("IdCliente", cliente.IdCliente));

                filasAfectadas = comando.ExecuteNonQuery();

                if (filasAfectadas == 0)
                {
                    throw new Exception("No se insertó ninguna fila de la tabla");
                }
            }

            catch (Exception ex)
            {
                SerializacionTXT texto = new SerializacionTXT();
                texto.Guardar(RutaDeArchivos.PATHLOG, "logs.txt", ex.ToString());
            }

            finally
            {
                conexion.Close();
            }
        }
        public static void DeleteCliente(Cliente cliente)
        {
            try
            {
                if (conexion.State != ConnectionState.Open)
                    conexion.Open();

                int filasAfectadas = 0;

                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;

                comando.Parameters.Clear();

                comando.CommandText = queryDeleteCliente;
                comando.Parameters.Add(new SqlParameter("Nombre", cliente.Nombre));
                comando.Parameters.Add(new SqlParameter("Apellido", cliente.Apellido));
                comando.Parameters.Add(new SqlParameter("Edad", cliente.Edad));
                comando.Parameters.Add(new SqlParameter("DNI", cliente.Dni));
                comando.Parameters.Add(new SqlParameter("IdCliente", cliente.IdCliente));

                filasAfectadas = comando.ExecuteNonQuery();

                if (filasAfectadas == 0)
                {
                    throw new Exception("No se eliminó ninguna fila de la tabla");
                }
            }

            catch (Exception ex)
            {
                SerializacionTXT texto = new SerializacionTXT();
                texto.Guardar(RutaDeArchivos.PATHLOG, "logs.txt", ex.ToString());
            }

            finally
            {
                conexion.Close();
            }
        }
        public static void UpdateCliente(Cliente cliente)
        {
            try
            {
                if (conexion.State != ConnectionState.Open)
                    conexion.Open();

                int filasAfectadas = 0;

                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;

                comando.Parameters.Clear();

                comando.CommandText = queryUpdateCliente;
                comando.Parameters.Add(new SqlParameter("Nombre", cliente.Nombre));
                comando.Parameters.Add(new SqlParameter("Apellido", cliente.Apellido));
                comando.Parameters.Add(new SqlParameter("Edad", cliente.Edad));
                comando.Parameters.Add(new SqlParameter("DNI", cliente.Dni));
                comando.Parameters.Add(new SqlParameter("IdCliente", cliente.IdCliente));

                filasAfectadas = comando.ExecuteNonQuery();

                if (filasAfectadas == 0)
                {
                    throw new Exception("No se modificó ninguna fila de la tabla");
                }
            }

            catch (Exception ex)
            {
                SerializacionTXT texto = new SerializacionTXT();
                texto.Guardar(RutaDeArchivos.PATHLOG, "logs.txt", ex.ToString());
            }

            finally
            {
                conexion.Close();
            }
        }
        public static List<Empleado> ObtenerEmpleados()
        {
            List<Empleado> auxEmpleados = new List<Empleado>();

            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;
            comando.CommandType = CommandType.Text;
            comando.CommandText = "SELECT * From Empleados";

            if (conexion.State != ConnectionState.Open)
                conexion.Open();

            SqlDataReader datosEmpleados = comando.ExecuteReader();

            while (datosEmpleados.Read())
            {
                auxEmpleados.Add(new Empleado(datosEmpleados["Nombre"].ToString(), datosEmpleados["Apellido"].ToString(), int.Parse(datosEmpleados["Edad"].ToString()), int.Parse(datosEmpleados["DNI"].ToString()), int.Parse(datosEmpleados["IdEmpleado"].ToString())));
            }

            if (conexion.State != ConnectionState.Closed)
                conexion.Close();

            return auxEmpleados;
        }
        public static void CargarListaEmpleados()
        {
            Negocio.ListaEmpleados = ManajedorSQL.ObtenerEmpleados();
        }
        public static void InsertEmpleado(Empleado empleado)
        {
            try
            {
                if (conexion.State != ConnectionState.Open)
                    conexion.Open();

                int filasAfectadas = 0;

                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;

                comando.Parameters.Clear();

                comando.CommandText = queryInsertEmpleado;
                comando.Parameters.Add(new SqlParameter("Nombre", empleado.Nombre));
                comando.Parameters.Add(new SqlParameter("Apellido", empleado.Apellido));
                comando.Parameters.Add(new SqlParameter("Edad", empleado.Edad));
                comando.Parameters.Add(new SqlParameter("DNI", empleado.Dni));
                comando.Parameters.Add(new SqlParameter("IdEmpleado", empleado.IdEmpleado));

                filasAfectadas = comando.ExecuteNonQuery();

                if (filasAfectadas == 0)
                {
                    throw new Exception("No se insertó ninguna fila de la tabla");
                }
            }

            catch (Exception ex)
            {
                SerializacionTXT texto = new SerializacionTXT();
                texto.Guardar(RutaDeArchivos.PATHLOG, "logs.txt", ex.ToString());
            }

            finally
            {
                conexion.Close();
            }
        }
        public static void DeleteEmpleado(Empleado empleado)
        {
            try
            {
                if (conexion.State != ConnectionState.Open)
                    conexion.Open();

                int filasAfectadas = 0;

                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;

                comando.Parameters.Clear();

                comando.CommandText = queryDeleteEmpleado;
                comando.Parameters.Add(new SqlParameter("Nombre", empleado.Nombre));
                comando.Parameters.Add(new SqlParameter("Apellido", empleado.Apellido));
                comando.Parameters.Add(new SqlParameter("Edad", empleado.Edad));
                comando.Parameters.Add(new SqlParameter("DNI", empleado.Dni));
                comando.Parameters.Add(new SqlParameter("IdEmpleado", empleado.IdEmpleado));

                filasAfectadas = comando.ExecuteNonQuery();

                if (filasAfectadas == 0)
                {
                    throw new Exception("No se eliminó ninguna fila de la tabla");
                }
            }

            catch (Exception ex)
            {
                SerializacionTXT texto = new SerializacionTXT();
                texto.Guardar(RutaDeArchivos.PATHLOG, "logs.txt", ex.ToString());
            }

            finally
            {
                conexion.Close();
            }
        }
        public static void UpdateEmpleado(Empleado empleado)
        {
            try
            {
                if (conexion.State != ConnectionState.Open)
                    conexion.Open();

                int filasAfectadas = 0;

                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;

                comando.Parameters.Clear();

                comando.CommandText = queryUpdateEmpleado;
                comando.Parameters.Add(new SqlParameter("Nombre", empleado.Nombre));
                comando.Parameters.Add(new SqlParameter("Apellido", empleado.Apellido));
                comando.Parameters.Add(new SqlParameter("Edad", empleado.Edad));
                comando.Parameters.Add(new SqlParameter("DNI", empleado.Dni));
                comando.Parameters.Add(new SqlParameter("IdEmpleado", empleado.IdEmpleado));

                filasAfectadas = comando.ExecuteNonQuery();

                if (filasAfectadas == 0)
                {
                    throw new Exception("No se modificó ninguna fila de la tabla");
                }
            }

            catch (Exception ex)
            {
                SerializacionTXT texto = new SerializacionTXT();
                texto.Guardar(RutaDeArchivos.PATHLOG, "logs.txt", ex.ToString());
            }

            finally
            {
                conexion.Close();
            }
        }
        public static List<Producto> ObtenerProductos()
        {
            List<Producto> auxProductos = new List<Producto>();

            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;
            comando.CommandType = CommandType.Text;
            comando.CommandText = "SELECT * From Productos";

            if (conexion.State != ConnectionState.Open)
                conexion.Open();

            SqlDataReader datosProductos = comando.ExecuteReader();

            while (datosProductos.Read())
            {
                auxProductos.Add(new Producto(datosProductos["Nombre"].ToString(), float.Parse(datosProductos["Precio"].ToString()), int.Parse(datosProductos["Cantidad"].ToString()), datosProductos["IdProducto"].ToString(), datosProductos["Marca"].ToString()));
            }

            if (conexion.State != ConnectionState.Closed)
                conexion.Close();

            return auxProductos;
        }
        public static void CargarListaProductos()
        {
            Negocio.ListaProductos = ManajedorSQL.ObtenerProductos();
        }
        public static void InsertProducto(Producto producto)
        {
            try
            {
                if (conexion.State != ConnectionState.Open)
                    conexion.Open();

                int filasAfectadas = 0;

                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;

                comando.Parameters.Clear();

                comando.CommandText = queryInsertProducto;
                comando.Parameters.Add(new SqlParameter("Nombre", producto.Nombre));
                comando.Parameters.Add(new SqlParameter("Precio", producto.Precio));
                comando.Parameters.Add(new SqlParameter("Cantidad", producto.Cantidad));
                comando.Parameters.Add(new SqlParameter("IdProducto", producto.IdProducto));
                comando.Parameters.Add(new SqlParameter("Marca", producto.Marca));

                filasAfectadas = comando.ExecuteNonQuery();

                if (filasAfectadas == 0)
                {
                    throw new Exception("No se insertó ninguna fila de la tabla");
                }
            }

            catch (Exception ex)
            {
                SerializacionTXT texto = new SerializacionTXT();
                texto.Guardar(RutaDeArchivos.PATHLOG, "logs.txt", ex.ToString());
            }

            finally
            {
                conexion.Close();
            }
        }
        public static void DeleteProducto(Producto producto)
        {
            try
            {
                if (conexion.State != ConnectionState.Open)
                    conexion.Open();

                int filasAfectadas = 0;

                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;

                comando.Parameters.Clear();

                comando.CommandText = queryDeleteProducto;
                comando.Parameters.Add(new SqlParameter("Nombre", producto.Nombre));
                comando.Parameters.Add(new SqlParameter("Precio", producto.Precio));
                comando.Parameters.Add(new SqlParameter("Cantidad", producto.Cantidad));
                comando.Parameters.Add(new SqlParameter("IdProducto", producto.IdProducto));
                comando.Parameters.Add(new SqlParameter("Marca", producto.Marca));

                filasAfectadas = comando.ExecuteNonQuery();

                if (filasAfectadas == 0)
                {
                    throw new Exception("No se eliminó ninguna fila de la tabla");
                }
            }

            catch (Exception ex)
            {
                SerializacionTXT texto = new SerializacionTXT();
                texto.Guardar(RutaDeArchivos.PATHLOG, "logs.txt", ex.ToString());
            }

            finally
            {
                conexion.Close();
            }
        }
        public static void UpdateProducto(Producto producto)
        {
            try
            {
                if (conexion.State != ConnectionState.Open)
                    conexion.Open();

                int filasAfectadas = 0;

                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;

                comando.Parameters.Clear();

                comando.CommandText = queryUpdateProducto;
                comando.Parameters.Add(new SqlParameter("Nombre", producto.Nombre));
                comando.Parameters.Add(new SqlParameter("Precio", producto.Precio));
                comando.Parameters.Add(new SqlParameter("Cantidad", producto.Cantidad));
                comando.Parameters.Add(new SqlParameter("IdProducto", producto.IdProducto));
                comando.Parameters.Add(new SqlParameter("Marca", producto.Marca));

                filasAfectadas = comando.ExecuteNonQuery();

                if (filasAfectadas == 0)
                {
                    throw new Exception("No se modificó ninguna fila de la tabla");
                }
            }

            catch (Exception ex)
            {
                SerializacionTXT texto = new SerializacionTXT();
                texto.Guardar(RutaDeArchivos.PATHLOG, "logs.txt", ex.ToString());
            }

            finally
            {
                conexion.Close();
            }
        }
        public static List<Celular> ObtenerCelulares()
        {
            List<Celular> auxCelulares = new List<Celular>();

            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;
            comando.CommandType = CommandType.Text;
            comando.CommandText = "SELECT * From Celulares";

            if (conexion.State != ConnectionState.Open)
                conexion.Open();

            SqlDataReader datosCelulares = comando.ExecuteReader();

            while (datosCelulares.Read())
            {
                auxCelulares.Add(new Celular(datosCelulares["Nombre"].ToString(), float.Parse(datosCelulares["Precio"].ToString()), int.Parse(datosCelulares["Cantidad"].ToString()), datosCelulares["IdProducto"].ToString(), datosCelulares["Marca"].ToString(), datosCelulares["Pantalla"].ToString(), datosCelulares["Microprocesador"].ToString()));
            }

            if (conexion.State != ConnectionState.Closed)
                conexion.Close();

            return auxCelulares;
        }
        public static void CargarListaCelulares()
        {
            Negocio.ListaCelulares = ManajedorSQL.ObtenerCelulares();
        }
        public static void InsertCelular(Celular celular)
        {
            try
            {
                if (conexion.State != ConnectionState.Open)
                    conexion.Open();

                int filasAfectadas = 0;

                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;

                comando.Parameters.Clear();

                comando.CommandText = queryInsertCelular;
                comando.Parameters.Add(new SqlParameter("Nombre", celular.Nombre));
                comando.Parameters.Add(new SqlParameter("Precio", celular.Precio));
                comando.Parameters.Add(new SqlParameter("Cantidad", celular.Cantidad));
                comando.Parameters.Add(new SqlParameter("IdProducto", celular.IdProducto));
                comando.Parameters.Add(new SqlParameter("Marca", celular.Marca));
                comando.Parameters.Add(new SqlParameter("Pantalla", celular.Pantalla));
                comando.Parameters.Add(new SqlParameter("Microprocesador", celular.Microprocesador));

                filasAfectadas = comando.ExecuteNonQuery();

                if (filasAfectadas == 0)
                {
                    throw new Exception("No se insertó ninguna fila de la tabla");
                }
            }

            catch (Exception ex)
            {
                SerializacionTXT texto = new SerializacionTXT();
                texto.Guardar(RutaDeArchivos.PATHLOG, "logs.txt", ex.ToString());
            }

            finally
            {
                conexion.Close();
            }
        }
        public static void DeleteCelular(Celular celular)
        {
            try
            {
                if (conexion.State != ConnectionState.Open)
                    conexion.Open();

                int filasAfectadas = 0;

                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;

                comando.Parameters.Clear();

                comando.CommandText = queryDeleteCelular;
                comando.Parameters.Add(new SqlParameter("Nombre", celular.Nombre));
                comando.Parameters.Add(new SqlParameter("Precio", celular.Precio));
                comando.Parameters.Add(new SqlParameter("Cantidad", celular.Cantidad));
                comando.Parameters.Add(new SqlParameter("IdProducto", celular.IdProducto));
                comando.Parameters.Add(new SqlParameter("Marca", celular.Marca));
                comando.Parameters.Add(new SqlParameter("Pantalla", celular.Pantalla));
                comando.Parameters.Add(new SqlParameter("Microprocesador", celular.Microprocesador));

                filasAfectadas = comando.ExecuteNonQuery();

                if (filasAfectadas == 0)
                {
                    throw new Exception("No se eliminó ninguna fila de la tabla");
                }
            }

            catch (Exception ex)
            {
                SerializacionTXT texto = new SerializacionTXT();
                texto.Guardar(RutaDeArchivos.PATHLOG, "logs.txt", ex.ToString());
            }

            finally
            {
                conexion.Close();
            }
        }
        public static void UpdateCelular(Celular celular)
        {
            try
            {
                if (conexion.State != ConnectionState.Open)
                    conexion.Open();

                int filasAfectadas = 0;

                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;

                comando.Parameters.Clear();

                comando.CommandText = queryUpdateCelular;
                comando.Parameters.Add(new SqlParameter("Nombre", celular.Nombre));
                comando.Parameters.Add(new SqlParameter("Precio", celular.Precio));
                comando.Parameters.Add(new SqlParameter("Cantidad", celular.Cantidad));
                comando.Parameters.Add(new SqlParameter("IdProducto", celular.IdProducto));
                comando.Parameters.Add(new SqlParameter("Marca", celular.Marca));
                comando.Parameters.Add(new SqlParameter("Pantalla", celular.Pantalla));
                comando.Parameters.Add(new SqlParameter("Microprocesador", celular.Microprocesador));

                filasAfectadas = comando.ExecuteNonQuery();

                if (filasAfectadas == 0)
                {
                    throw new Exception("No se modificó ninguna fila de la tabla");
                }
            }

            catch (Exception ex)
            {
                SerializacionTXT texto = new SerializacionTXT();
                texto.Guardar(RutaDeArchivos.PATHLOG, "logs.txt", ex.ToString());
            }

            finally
            {
                conexion.Close();
            }
        }
        public static List<Teclado> ObtenerTeclados()
        {
            List<Teclado> auxTeclados = new List<Teclado>();

            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;
            comando.CommandType = CommandType.Text;
            comando.CommandText = "SELECT * From Teclados";

            if (conexion.State != ConnectionState.Open)
                conexion.Open();

            SqlDataReader datosTeclados = comando.ExecuteReader();

            while (datosTeclados.Read())
            {
                auxTeclados.Add(new Teclado(datosTeclados["Nombre"].ToString(), float.Parse(datosTeclados["Precio"].ToString()), int.Parse(datosTeclados["Cantidad"].ToString()), datosTeclados["IdProducto"].ToString(), datosTeclados["Marca"].ToString(), datosTeclados["Tipo"].ToString()));
            }

            if (conexion.State != ConnectionState.Closed)
                conexion.Close();

            return auxTeclados;
        }
        public static void CargarListaTeclados()
        {
            Negocio.ListaTeclados = ManajedorSQL.ObtenerTeclados();
        }
        public static void InsertTeclado(Teclado teclado)
        {
            try
            {
                if (conexion.State != ConnectionState.Open)
                    conexion.Open();

                int filasAfectadas = 0;

                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;

                comando.Parameters.Clear();

                comando.CommandText = queryInsertTeclado;
                comando.Parameters.Add(new SqlParameter("Nombre", teclado.Nombre));
                comando.Parameters.Add(new SqlParameter("Precio", teclado.Precio));
                comando.Parameters.Add(new SqlParameter("Cantidad", teclado.Cantidad));
                comando.Parameters.Add(new SqlParameter("IdProducto", teclado.IdProducto));
                comando.Parameters.Add(new SqlParameter("Marca", teclado.Marca));
                comando.Parameters.Add(new SqlParameter("Tipo", teclado.Tipo));

                filasAfectadas = comando.ExecuteNonQuery();

                if (filasAfectadas == 0)
                {
                    throw new Exception("No se insertó ninguna fila de la tabla");
                }
            }

            catch (Exception ex)
            {
                SerializacionTXT texto = new SerializacionTXT();
                texto.Guardar(RutaDeArchivos.PATHLOG, "logs.txt", ex.ToString());
            }

            finally
            {
                conexion.Close();
            }
        }
        public static void DeleteTeclado(Teclado teclado)
        {
            try
            {
                if (conexion.State != ConnectionState.Open)
                    conexion.Open();

                int filasAfectadas = 0;

                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;

                comando.Parameters.Clear();

                comando.CommandText = queryDeleteTeclado;
                comando.Parameters.Add(new SqlParameter("Nombre", teclado.Nombre));
                comando.Parameters.Add(new SqlParameter("Precio", teclado.Precio));
                comando.Parameters.Add(new SqlParameter("Cantidad", teclado.Cantidad));
                comando.Parameters.Add(new SqlParameter("IdProducto", teclado.IdProducto));
                comando.Parameters.Add(new SqlParameter("Marca", teclado.Marca));
                comando.Parameters.Add(new SqlParameter("Tipo", teclado.Tipo));

                filasAfectadas = comando.ExecuteNonQuery();

                if (filasAfectadas == 0)
                {
                    throw new Exception("No se eliminó ninguna fila de la tabla");
                }
            }

            catch (Exception ex)
            {
                SerializacionTXT texto = new SerializacionTXT();
                texto.Guardar(RutaDeArchivos.PATHLOG, "logs.txt", ex.ToString());
            }

            finally
            {
                conexion.Close();
            }

        }
        public static void UpdateTeclado(Teclado teclado)
        {
            try
            {
                if (conexion.State != ConnectionState.Open)
                    conexion.Open();

                int filasAfectadas = 0;

                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;

                comando.Parameters.Clear();

                comando.CommandText = queryUpdateTeclado;
                comando.Parameters.Add(new SqlParameter("Nombre", teclado.Nombre));
                comando.Parameters.Add(new SqlParameter("Precio", teclado.Precio));
                comando.Parameters.Add(new SqlParameter("Cantidad", teclado.Cantidad));
                comando.Parameters.Add(new SqlParameter("IdProducto", teclado.IdProducto));
                comando.Parameters.Add(new SqlParameter("Marca", teclado.Marca));
                comando.Parameters.Add(new SqlParameter("Tipo", teclado.Tipo));

                filasAfectadas = comando.ExecuteNonQuery();

                if (filasAfectadas == 0)
                {
                    throw new Exception("No se modificó ninguna fila de la tabla");
                }
            }

            catch (Exception ex)
            {
                SerializacionTXT texto = new SerializacionTXT();
                texto.Guardar(RutaDeArchivos.PATHLOG, "logs.txt", ex.ToString());
            }

            finally
            {
                conexion.Close();
            }
        }
        public static List<Venta> ObtenerVentas()
        {
            List<Venta> auxVentas = new List<Venta>();

            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;
            comando.CommandType = CommandType.Text;
            comando.CommandText = "SELECT * From Ventas";

            if (conexion.State != ConnectionState.Open)
                conexion.Open();

            SqlDataReader datosVentas = comando.ExecuteReader();

            while (datosVentas.Read())
            {
                auxVentas.Add(new Venta(datosVentas["Nombre"].ToString(), float.Parse(datosVentas["Precio"].ToString()), int.Parse(datosVentas["Cantidad"].ToString()), datosVentas["IdProducto"].ToString(), int.Parse(datosVentas["IdVenta"].ToString()), datosVentas["Marca"].ToString(), datosVentas["Tipo"].ToString(), datosVentas["Pantalla"].ToString(), datosVentas["Microprocesador"].ToString()));
            }

            if (conexion.State != ConnectionState.Closed)
                conexion.Close();

            return auxVentas;
        }
        public static void CargarListaVentas()
        {
            Negocio.ListaVentas = ManajedorSQL.ObtenerVentas();
        }
        public static void InsertVenta(Venta venta)
        {
            try
            {
                if (conexion.State != ConnectionState.Open)
                    conexion.Open();

                int filasAfectadas = 0;

                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;

                comando.Parameters.Clear();

                comando.CommandText = queryInsertVenta;
                comando.Parameters.Add(new SqlParameter("Nombre", venta.Nombre));
                comando.Parameters.Add(new SqlParameter("Precio", venta.Precio));
                comando.Parameters.Add(new SqlParameter("Cantidad", venta.Cantidad));
                comando.Parameters.Add(new SqlParameter("IdProducto", venta.IdProducto));
                comando.Parameters.Add(new SqlParameter("IdVenta", venta.IdVenta));
                comando.Parameters.Add(new SqlParameter("Marca", venta.Marca));
                comando.Parameters.Add(new SqlParameter("Tipo", venta.Tipo));
                comando.Parameters.Add(new SqlParameter("Pantalla", venta.Pantalla));
                comando.Parameters.Add(new SqlParameter("Microprocesador", venta.Microprocesador));

                filasAfectadas = comando.ExecuteNonQuery();

                if (filasAfectadas == 0)
                {
                    throw new Exception("No se insertó ninguna fila de la tabla");
                }
            }

            catch (Exception ex)
            {
                SerializacionTXT texto = new SerializacionTXT();
                texto.Guardar(RutaDeArchivos.PATHLOG, "logs.txt", ex.ToString());
            }

            finally
            {
                conexion.Close();
            }
        }
        public static void DeleteVenta(Venta venta)
        {
            try
            {
                if (conexion.State != ConnectionState.Open)
                    conexion.Open();

                int filasAfectadas = 0;

                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;

                comando.Parameters.Clear();

                comando.CommandText = queryDeleteVenta;
                comando.Parameters.Add(new SqlParameter("Nombre", venta.Nombre));
                comando.Parameters.Add(new SqlParameter("Precio", venta.Precio));
                comando.Parameters.Add(new SqlParameter("Cantidad", venta.Cantidad));
                comando.Parameters.Add(new SqlParameter("IdProducto", venta.IdProducto));
                comando.Parameters.Add(new SqlParameter("IdVenta", venta.IdVenta));
                comando.Parameters.Add(new SqlParameter("Marca", venta.Marca));
                comando.Parameters.Add(new SqlParameter("Tipo", venta.Tipo));
                comando.Parameters.Add(new SqlParameter("Pantalla", venta.Pantalla));
                comando.Parameters.Add(new SqlParameter("Microprocesador", venta.Microprocesador));

                filasAfectadas = comando.ExecuteNonQuery();

                if (filasAfectadas == 0)
                {
                    throw new Exception("No se eliminó ninguna fila de la tabla");
                }
            }

            catch (Exception ex)
            {
                SerializacionTXT texto = new SerializacionTXT();
                texto.Guardar(RutaDeArchivos.PATHLOG, "logs.txt", ex.ToString());
            }

            finally
            {
                conexion.Close();
            }

        }
        public static void UpdateVenta(Venta venta)
        {
            try
            {
                if (conexion.State != ConnectionState.Open)
                    conexion.Open();

                int filasAfectadas = 0;

                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;

                comando.Parameters.Clear();

                comando.CommandText = queryUpdateVenta;
                comando.Parameters.Add(new SqlParameter("Nombre", venta.Nombre));
                comando.Parameters.Add(new SqlParameter("Precio", venta.Precio));
                comando.Parameters.Add(new SqlParameter("Cantidad", venta.Cantidad));
                comando.Parameters.Add(new SqlParameter("IdProducto", venta.IdProducto));
                comando.Parameters.Add(new SqlParameter("IdVenta", venta.IdVenta));
                comando.Parameters.Add(new SqlParameter("Marca", venta.Marca));
                comando.Parameters.Add(new SqlParameter("Tipo", venta.Tipo));
                comando.Parameters.Add(new SqlParameter("Pantalla", venta.Pantalla));
                comando.Parameters.Add(new SqlParameter("Microprocesador", venta.Microprocesador));

                filasAfectadas = comando.ExecuteNonQuery();

                if (filasAfectadas == 0)
                {
                    throw new Exception("No se modificó ninguna fila de la tabla");
                }
            }

            catch (Exception ex)
            {
                SerializacionTXT texto = new SerializacionTXT();
                texto.Guardar(RutaDeArchivos.PATHLOG, "logs.txt", ex.ToString());
            }

            finally
            {
                conexion.Close();
            }
        }

        public static bool VerificadorDeExistentesClientes(int id)
        {
            try
            {
                List<Cliente> auxClientes = new List<Cliente>();
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = "SELECT * From Clientes WHERE IdCliente ='" + id + "'";

                if (conexion.State != ConnectionState.Open)
                    conexion.Open();

                SqlDataReader datosClientes = comando.ExecuteReader();

                while (datosClientes.Read())
                {
                    auxClientes.Add(new Cliente(datosClientes["Nombre"].ToString(), datosClientes["Apellido"].ToString(), int.Parse(datosClientes["Edad"].ToString()), int.Parse(datosClientes["DNI"].ToString()), int.Parse(datosClientes["IdCliente"].ToString())));
                }

                if (auxClientes.Count != 0)
                {
                    return false;
                }

            }

            catch (Exception ex)
            {
                string message = ex.Message;
                throw new Exception("Problemas con el id " + message);
            }

            finally
            {
                if (conexion.State != ConnectionState.Closed)
                    conexion.Close();
            }

            return true;
        }
        public static bool VerificadorDeExistentesEmpleados(int id)
        {
            try
            {
                List<Empleado> auxEmpleados = new List<Empleado>();
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = "SELECT * From Empleados WHERE IdEmpleado ='" + id + "'";

                if (conexion.State != ConnectionState.Open)
                    conexion.Open();

                SqlDataReader datosEmpleados = comando.ExecuteReader();

                while (datosEmpleados.Read())
                {
                    auxEmpleados.Add(new Empleado(datosEmpleados["Nombre"].ToString(), datosEmpleados["Apellido"].ToString(), int.Parse(datosEmpleados["Edad"].ToString()), int.Parse(datosEmpleados["DNI"].ToString()), int.Parse(datosEmpleados["IdEmpleado"].ToString())));
                }

                if (auxEmpleados.Count != 0)
                {
                    return false;
                }

            }

            catch (Exception ex)
            {
                string message = ex.Message;
                throw new Exception("Problemas con el id " + message);
            }

            finally
            {
                if (conexion.State != ConnectionState.Closed)
                    conexion.Close();
            }

            return true;
        }
        public static bool VerificadorDeExistentesCelulares(string id)
        {
            try
            {
                List<Celular> auxCelulares = new List<Celular>();
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = "SELECT * From Celulares WHERE IdProducto ='" + id + "'";

                if (conexion.State != ConnectionState.Open)
                    conexion.Open();

                SqlDataReader datosCelulares = comando.ExecuteReader();

                while (datosCelulares.Read())
                {
                    auxCelulares.Add(new Celular(datosCelulares["Nombre"].ToString(), float.Parse(datosCelulares["Precio"].ToString()), int.Parse(datosCelulares["Cantidad"].ToString()), datosCelulares["IdProducto"].ToString(), datosCelulares["Marca"].ToString(), datosCelulares["Pantalla"].ToString(), datosCelulares["Microprocesador"].ToString()));
                }

                if (auxCelulares.Count != 0)
                {
                    return false;
                }

            }

            catch (Exception ex)
            {
                string message = ex.Message;
                throw new Exception("Problemas con el id " + message);
            }

            finally
            {
                if (conexion.State != ConnectionState.Closed)
                    conexion.Close();
            }

            return true;
        }
        public static bool VerificadorDeExistentesTeclados(string id)
        {
            try
            {
                List<Teclado> auxTeclados = new List<Teclado>();
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = "SELECT * From Teclados WHERE IdProducto ='" + id + "'";

                if (conexion.State != ConnectionState.Open)
                    conexion.Open();

                SqlDataReader datosTeclados = comando.ExecuteReader();

                while (datosTeclados.Read())
                {
                    auxTeclados.Add(new Teclado(datosTeclados["Nombre"].ToString(), float.Parse(datosTeclados["Precio"].ToString()), int.Parse(datosTeclados["Cantidad"].ToString()), datosTeclados["IdProducto"].ToString(), datosTeclados["Marca"].ToString(), datosTeclados["Tipo"].ToString()));
                }

                if (auxTeclados.Count != 0)
                {
                    return false;
                }

            }

            catch (Exception ex)
            {
                string message = ex.Message;
                throw new Exception("Problemas con el id " + message);
            }

            finally
            {
                if (conexion.State != ConnectionState.Closed)
                    conexion.Close();
            }

            return true;
        }
        public static bool VerificadorDeExistentesVenta(string idProducto, int idVenta)
        {
            try
            {
                List<Venta> auxVentas = new List<Venta>();
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = "SELECT * From Ventas WHERE IdProducto ='" + idProducto + "' AND IdVenta = '" + idVenta + "'";

                if (conexion.State != ConnectionState.Open)
                    conexion.Open();

                SqlDataReader datosVentas = comando.ExecuteReader();

                while (datosVentas.Read())
                {
                    auxVentas.Add(new Venta(datosVentas["Nombre"].ToString(), float.Parse(datosVentas["Precio"].ToString()), int.Parse(datosVentas["Cantidad"].ToString()), datosVentas["IdProducto"].ToString(), int.Parse(datosVentas["IdVenta"].ToString()), datosVentas["Marca"].ToString(), datosVentas["Tipo"].ToString(), datosVentas["Pantalla"].ToString(), datosVentas["Microprocesador"].ToString()));
                }

                if (auxVentas.Count != 0)
                {
                    return false;
                }

            }

            catch (Exception ex)
            {
                string message = ex.Message;
                throw new Exception("Problemas con el id " + message);
            }

            finally
            {
                if (conexion.State != ConnectionState.Closed)
                    conexion.Close();
            }

            return true;
        }
        public static int NewIdVentas()
        {
            try
            {
               
                int IdVentas = 0;
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = "  SELECT MAX(IdVenta) as Id FROM  Ventas";

                if (conexion.State != ConnectionState.Open)
                    conexion.Open();

                SqlDataReader datosVenta = comando.ExecuteReader();

                while (datosVenta.Read())
                {
                    IdVentas = Convert.ToInt32(datosVenta["Id"]) + 1;
                }

                return IdVentas;

            }

            catch (Exception ex)
            {
                string message = ex.Message;
                throw new Exception("Problemas con el id " + message);
            }

            finally
            {
                if (conexion.State != ConnectionState.Closed)
                    conexion.Close();
            }
         
        }
    }
}
