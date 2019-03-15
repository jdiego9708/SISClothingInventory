using System;
using System.Collections.Generic;

using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DClientes
    {
        #region MENSAJE SQL
        private void SqlCon_InfoMessage(object sender, SqlInfoMessageEventArgs e)
        {
            this.Mensaje_respuesta = e.Message;
        }
        #endregion

        #region VARIABLES
        private string mensaje_respuesta;
        public string Mensaje_respuesta
        {
            get
            {
                return mensaje_respuesta;
            }

            set
            {
                mensaje_respuesta = value;
            }
        }
        #endregion

        #region CONSTRUCTOR VACIO
        public DClientes()
        { }
        #endregion

        #region METODO INSERTAR CLIENTES
        public string InsertarClientes(List<string> Variables, out int id_cliente)
        {
            id_cliente = 0;
            int contador = 0;
            //asignamos a una cadena string la variable rpta y la iniciamos en vacía
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            SqlCon.InfoMessage += new SqlInfoMessageEventHandler(SqlCon_InfoMessage);
            SqlCon.FireInfoMessageEventOnUserErrors = true;
            //Capturador de errores
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                //establecer comando
                SqlCommand SqlCmd = new SqlCommand
                {
                    Connection = SqlCon,
                    CommandText = "sp_Insertar_cliente",
                    //Indicamos que es un procedimiento almacenado
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter Id_cliente = new SqlParameter
                {
                    ParameterName = "@Id_cliente",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };
                SqlCmd.Parameters.Add(Id_cliente);

                SqlParameter Nombre_cliente = new SqlParameter
                {
                    ParameterName = "@Nombre_cliente",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 200,
                    Value = Variables[contador].Trim().ToUpper()
                };
                SqlCmd.Parameters.Add(Nombre_cliente);
                contador += 1;

                SqlParameter Telefono_cliente = new SqlParameter
                {
                    ParameterName = "@Telefono_cliente",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = Variables[contador].Trim()
                };
                SqlCmd.Parameters.Add(Telefono_cliente);
                contador += 1;

                SqlParameter Correo_electronico = new SqlParameter
                {
                    ParameterName = "@Correo_electronico",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 500,
                    Value = Variables[contador].Trim()
                };
                SqlCmd.Parameters.Add(Correo_electronico);
                contador += 1;

                //Ejecutamos nuestro comando
                //Se puede ejecutar este metodo pero ya tenemos el mensaje que devuelve sql
                rpta = SqlCmd.ExecuteNonQuery() >= 1 ? "OK" : "NO";

                if (rpta != "OK")
                {
                    if (this.Mensaje_respuesta != null)
                    {
                        rpta = this.Mensaje_respuesta;
                    }
                }
                else
                {
                    id_cliente = Convert.ToInt32(SqlCmd.Parameters["@Id_cliente"].Value);
                }
            }
            //Mostramos posible error que tengamos
            catch (SqlException ex)
            {
                rpta = ex.Message;
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                //Si la cadena SqlCon esta abierta la cerramos
                if (SqlCon.State == ConnectionState.Open)
                    SqlCon.Close();
            }
            return rpta;
        }
        #endregion

        #region METODO EDITAR CLIENTES
        public string EditarClientes(List<string> Variables, int id_cliente)
        {
            int contador = 0;
            //asignamos a una cadena string la variable rpta y la iniciamos en vacía
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            SqlCon.InfoMessage += new SqlInfoMessageEventHandler(SqlCon_InfoMessage);
            SqlCon.FireInfoMessageEventOnUserErrors = true;
            //Capturador de errores
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                //establecer comando
                SqlCommand SqlCmd = new SqlCommand
                {
                    Connection = SqlCon,
                    CommandText = "sp_Editar_cliente",
                    //Indicamos que es un procedimiento almacenado
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter Id_cliente = new SqlParameter
                {
                    ParameterName = "@Id_cliente",
                    SqlDbType = SqlDbType.Int,
                    Value = id_cliente
                };
                SqlCmd.Parameters.Add(Id_cliente);

                SqlParameter Nombre_cliente = new SqlParameter
                {
                    ParameterName = "@Nombre_cliente",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 200,
                    Value = Variables[contador].Trim().ToUpper()
                };
                SqlCmd.Parameters.Add(Nombre_cliente);
                contador += 1;

                SqlParameter Telefono_cliente = new SqlParameter
                {
                    ParameterName = "@Telefono_cliente",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = Variables[contador].Trim()
                };
                SqlCmd.Parameters.Add(Telefono_cliente);
                contador += 1;

                SqlParameter Correo_electronico = new SqlParameter
                {
                    ParameterName = "@Correo_electronico",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 500,
                    Value = Variables[contador].Trim()
                };
                SqlCmd.Parameters.Add(Correo_electronico);
                contador += 1;

                //Ejecutamos nuestro comando
                //Se puede ejecutar este metodo pero ya tenemos el mensaje que devuelve sql
                rpta = SqlCmd.ExecuteNonQuery() >= 1 ? "OK" : "NO";

                if (rpta != "OK")
                {
                    if (this.Mensaje_respuesta != null)
                    {
                        rpta = this.Mensaje_respuesta;
                    }
                }
            }
            //Mostramos posible error que tengamos
            catch (SqlException ex)
            {
                rpta = ex.Message;
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                //Si la cadena SqlCon esta abierta la cerramos
                if (SqlCon.State == ConnectionState.Open)
                    SqlCon.Close();
            }
            return rpta;
        }
        #endregion

        #region METODO BUSCAR CLIENTES
        public static DataTable BuscarClientes(string tipo_busqueda,
            string texto_busqueda, out string rpta)
        {
            rpta = "OK";
            DataTable DtResultado = new DataTable("Clientes");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand Sqlcmd = new SqlCommand
                {
                    Connection = SqlCon,
                    CommandText = "sp_Buscar_cliente",
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter Tipo_busqueda = new SqlParameter
                {
                    ParameterName = "@Tipo_busqueda",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = tipo_busqueda.Trim().ToUpper()
                };
                Sqlcmd.Parameters.Add(Tipo_busqueda);

                SqlParameter Texto_busqueda = new SqlParameter
                {
                    ParameterName = "@Texto_busqueda",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = texto_busqueda.Trim().ToUpper()
                };
                Sqlcmd.Parameters.Add(Texto_busqueda);

                SqlDataAdapter SqlData = new SqlDataAdapter(Sqlcmd);
                SqlData.Fill(DtResultado);

                if (DtResultado.Rows.Count < 1)
                {
                    DtResultado = null;
                }
            }
            catch (SqlException ex)
            {
                rpta = ex.Message;
                DtResultado = null;
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
                DtResultado = null;
            }

            return DtResultado;
        }

        #endregion

        #region METODO INSERTAR DIRECCION CLIENTE
        public string InsertarDireccionClientes(List<string> Variables, out int id_direccion)
        {
            id_direccion = 0;
            int contador = 0;
            //asignamos a una cadena string la variable rpta y la iniciamos en vacía
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            SqlCon.InfoMessage += new SqlInfoMessageEventHandler(SqlCon_InfoMessage);
            SqlCon.FireInfoMessageEventOnUserErrors = true;
            //Capturador de errores
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                //establecer comando
                SqlCommand SqlCmd = new SqlCommand
                {
                    Connection = SqlCon,
                    CommandText = "sp_Insertar_direccion_cliente",
                    //Indicamos que es un procedimiento almacenado
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter Id_direccion = new SqlParameter
                {
                    ParameterName = "@Id_direccion",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };
                SqlCmd.Parameters.Add(Id_direccion);

                SqlParameter Id_cliente = new SqlParameter
                {
                    ParameterName = "@Id_cliente",
                    SqlDbType = SqlDbType.Int,
                    Value = Variables[contador]
                };
                SqlCmd.Parameters.Add(Id_cliente);
                contador += 1;

                SqlParameter CalleCarrera = new SqlParameter
                {
                    ParameterName = "@CalleCarrera",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = Variables[contador].Trim().ToUpper()
                };
                SqlCmd.Parameters.Add(CalleCarrera);
                contador += 1;

                SqlParameter NumCalleCarrera = new SqlParameter
                {
                    ParameterName = "@NumCalleCarrera",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 5,
                    Value = Variables[contador].Trim()
                };
                SqlCmd.Parameters.Add(NumCalleCarrera);
                contador += 1;

                SqlParameter Numero1 = new SqlParameter
                {
                    ParameterName = "@Numero1",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 5,
                    Value = Variables[contador].Trim()
                };
                SqlCmd.Parameters.Add(Numero1);
                contador += 1;

                SqlParameter Numero2 = new SqlParameter
                {
                    ParameterName = "@Numero2",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 5,
                    Value = Variables[contador].Trim()
                };
                SqlCmd.Parameters.Add(Numero2);
                contador += 1;

                SqlParameter Referencias = new SqlParameter
                {
                    ParameterName = "@Referencias",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 5,
                    Value = Variables[contador].Trim()
                };
                SqlCmd.Parameters.Add(Referencias);
                contador += 1;

                //Ejecutamos nuestro comando
                //Se puede ejecutar este metodo pero ya tenemos el mensaje que devuelve sql
                rpta = SqlCmd.ExecuteNonQuery() >= 1 ? "OK" : "NO";

                if (rpta != "OK")
                {
                    if (this.Mensaje_respuesta != null)
                    {
                        rpta = this.Mensaje_respuesta;
                    }
                }
                else
                {
                    id_direccion = Convert.ToInt32(SqlCmd.Parameters["@Id_direccion"].Value);
                }
            }
            //Mostramos posible error que tengamos
            catch (SqlException ex)
            {
                rpta = ex.Message;
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                //Si la cadena SqlCon esta abierta la cerramos
                if (SqlCon.State == ConnectionState.Open)
                    SqlCon.Close();
            }
            return rpta;
        }
        #endregion

        #region METODO EDITAR DIRECCION CLIENTE
        public string EditarDireccionClientes(List<string> Variables, int id_direccion)
        {
            int contador = 0;
            //asignamos a una cadena string la variable rpta y la iniciamos en vacía
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            SqlCon.InfoMessage += new SqlInfoMessageEventHandler(SqlCon_InfoMessage);
            SqlCon.FireInfoMessageEventOnUserErrors = true;
            //Capturador de errores
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                //establecer comando
                SqlCommand SqlCmd = new SqlCommand
                {
                    Connection = SqlCon,
                    CommandText = "sp_Editar_direccion_cliente",
                    //Indicamos que es un procedimiento almacenado
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter Id_direccion = new SqlParameter
                {
                    ParameterName = "@Id_direccion",
                    SqlDbType = SqlDbType.Int,
                    Value = id_direccion
                };
                SqlCmd.Parameters.Add(Id_direccion);

                SqlParameter Id_cliente = new SqlParameter
                {
                    ParameterName = "@Id_cliente",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };
                SqlCmd.Parameters.Add(Id_cliente);
                contador += 1;

                SqlParameter CalleCarrera = new SqlParameter
                {
                    ParameterName = "@CalleCarrera",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = Variables[contador].Trim().ToUpper()
                };
                SqlCmd.Parameters.Add(CalleCarrera);
                contador += 1;

                SqlParameter NumCalleCarrera = new SqlParameter
                {
                    ParameterName = "@NumCalleCarrera",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 5,
                    Value = Variables[contador].Trim()
                };
                SqlCmd.Parameters.Add(NumCalleCarrera);
                contador += 1;

                SqlParameter Numero1 = new SqlParameter
                {
                    ParameterName = "@Numero1",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 5,
                    Value = Variables[contador].Trim()
                };
                SqlCmd.Parameters.Add(Numero1);
                contador += 1;

                SqlParameter Numero2 = new SqlParameter
                {
                    ParameterName = "@Numero2",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 5,
                    Value = Variables[contador].Trim()
                };
                SqlCmd.Parameters.Add(Numero2);
                contador += 1;

                SqlParameter Referencias = new SqlParameter
                {
                    ParameterName = "@Referencias",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 5,
                    Value = Variables[contador].Trim()
                };
                SqlCmd.Parameters.Add(Referencias);
                contador += 1;

                //Ejecutamos nuestro comando
                //Se puede ejecutar este metodo pero ya tenemos el mensaje que devuelve sql
                rpta = SqlCmd.ExecuteNonQuery() >= 1 ? "OK" : "NO";

                if (rpta != "OK")
                {
                    if (this.Mensaje_respuesta != null)
                    {
                        rpta = this.Mensaje_respuesta;
                    }
                }
            }
            //Mostramos posible error que tengamos
            catch (SqlException ex)
            {
                rpta = ex.Message;
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                //Si la cadena SqlCon esta abierta la cerramos
                if (SqlCon.State == ConnectionState.Open)
                    SqlCon.Close();
            }
            return rpta;
        }
        #endregion
    }
}
