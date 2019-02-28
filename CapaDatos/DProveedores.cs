using System;
using System.Collections.Generic;

using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DProveedores
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
        public DProveedores()
        { }
        #endregion

        #region METODO INSERTAR PROVEEDORES
        public string InsertarProveedores(List<string> Variables, out int id_proveedor)
        {
            id_proveedor = 0;
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
                    CommandText = "sp_Insertar_proveedor",
                    //Indicamos que es un procedimiento almacenado
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter Id_proveedor = new SqlParameter
                {
                    ParameterName = "@Id_proveedor",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };
                SqlCmd.Parameters.Add(Id_proveedor);

                SqlParameter Nombre_proveedor = new SqlParameter
                {
                    ParameterName = "@Nombre_proveedor",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 150,
                    Value = Variables[contador].Trim().ToUpper()
                };
                SqlCmd.Parameters.Add(Nombre_proveedor);
                contador += 1;

                SqlParameter Telefono_proveedor = new SqlParameter
                {
                    ParameterName = "@Telefono_proveedor",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = Variables[contador].Trim()
                };
                SqlCmd.Parameters.Add(Telefono_proveedor);
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
                    id_proveedor = Convert.ToInt32(SqlCmd.Parameters["@Id_proveedor"].Value);
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

        #region METODO EDITAR PROVEEDORES
        public string EditarProveedores(List<string> Variables, int id_proveedor)
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
                    CommandText = "sp_Editar_proveedor",
                    //Indicamos que es un procedimiento almacenado
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter Id_proveedor = new SqlParameter
                {
                    ParameterName = "@Id_proveedor",
                    SqlDbType = SqlDbType.Int,
                    Value = id_proveedor
                };
                SqlCmd.Parameters.Add(Id_proveedor);

                SqlParameter Nombre_proveedor = new SqlParameter
                {
                    ParameterName = "@Nombre_proveedor",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 150,
                    Value = Variables[contador].Trim().ToUpper()
                };
                SqlCmd.Parameters.Add(Nombre_proveedor);
                contador += 1;

                SqlParameter Telefono_proveedor = new SqlParameter
                {
                    ParameterName = "@Telefono_proveedor",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = Variables[contador].Trim()
                };
                SqlCmd.Parameters.Add(Telefono_proveedor);
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

        #region METODO BUSCAR PROVEEDORES
        public static DataTable BuscarProveedores(string tipo_busqueda,
            string texto_busqueda, out string rpta)
        {
            rpta = "OK";
            DataTable DtResultado = new DataTable("Proveedores");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand Sqlcmd = new SqlCommand
                {
                    Connection = SqlCon,
                    CommandText = "sp_Buscar_proveedores",
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
    }
}
