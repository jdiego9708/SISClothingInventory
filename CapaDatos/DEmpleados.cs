using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DEmpleados
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
        public DEmpleados()
        { }
        #endregion

        #region METODO INSERTAR EMPLEADOS
        public string InsertarEmpleados(List<string> Variables, out int id_empleado)
        {
            id_empleado = 0;
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
                    CommandText = "sp_Insertar_empleado",
                    //Indicamos que es un procedimiento almacenado
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter Id_empleado = new SqlParameter
                {
                    ParameterName = "@Id_empleado",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };
                SqlCmd.Parameters.Add(Id_empleado);

                SqlParameter Nombre_empleado = new SqlParameter
                {
                    ParameterName = "@Nombre_empleado",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 200,
                    Value = Variables[contador].Trim().ToUpper()
                };
                SqlCmd.Parameters.Add(Nombre_empleado);
                contador += 1;

                SqlParameter Telefono_empleado = new SqlParameter
                {
                    ParameterName = "@Telefono_empleado",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = Variables[contador].Trim()
                };
                SqlCmd.Parameters.Add(Telefono_empleado);
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

                SqlParameter Cargo = new SqlParameter
                {
                    ParameterName = "@Cargo",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = Variables[contador].Trim()
                };
                SqlCmd.Parameters.Add(Cargo);
                contador += 1;

                SqlParameter Password = new SqlParameter
                {
                    ParameterName = "@Password",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 15,
                    Value = Variables[contador].Trim()
                };
                SqlCmd.Parameters.Add(Password);
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
                    id_empleado = Convert.ToInt32(SqlCmd.Parameters["@Id_empleado"].Value);
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

        #region METODO EDITAR EMPLEADOS
        public string EditarEmpleados(List<string> Variables, int id_empleado)
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
                    CommandText = "sp_Editar_empleado",
                    //Indicamos que es un procedimiento almacenado
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter Id_empleado = new SqlParameter
                {
                    ParameterName = "@Id_empleado",
                    SqlDbType = SqlDbType.Int,
                    Value = id_empleado
                };
                SqlCmd.Parameters.Add(Id_empleado);

                SqlParameter Nombre_empleado = new SqlParameter
                {
                    ParameterName = "@Nombre_empleado",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 200,
                    Value = Variables[contador].Trim().ToUpper()
                };
                SqlCmd.Parameters.Add(Nombre_empleado);
                contador += 1;

                SqlParameter Telefono_empleado = new SqlParameter
                {
                    ParameterName = "@Telefono_empleado",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = Variables[contador].Trim()
                };
                SqlCmd.Parameters.Add(Telefono_empleado);
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

                SqlParameter Cargo = new SqlParameter
                {
                    ParameterName = "@Cargo",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = Variables[contador].Trim()
                };
                SqlCmd.Parameters.Add(Cargo);
                contador += 1;

                SqlParameter Password = new SqlParameter
                {
                    ParameterName = "@Password",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 15,
                    Value = Variables[contador].Trim()
                };
                SqlCmd.Parameters.Add(Password);
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

        #region METODO BUSCAR EMPLEADOS
        public static DataTable BuscarEmpleados(string tipo_busqueda,
            string texto_busqueda, out string rpta)
        {
            rpta = "OK";
            DataTable DtResultado = new DataTable("Empleados");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand Sqlcmd = new SqlCommand
                {
                    Connection = SqlCon,
                    CommandText = "sp_Buscar_empleado",
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

        #region METODO LOGIN
        public static DataTable Login(string usuario,
            string password, out string rpta)
        {
            rpta = "OK";
            DataTable DtResultado = new DataTable("Empleado");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand Sqlcmd = new SqlCommand
                {
                    Connection = SqlCon,
                    CommandText = "sp_Login",
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter Usuario = new SqlParameter
                {
                    ParameterName = "@Usuario",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = usuario.Trim()
                };
                Sqlcmd.Parameters.Add(Usuario);

                SqlParameter Clave = new SqlParameter
                {
                    ParameterName = "@Clave",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 15,
                    Value = password.Trim()
                };
                Sqlcmd.Parameters.Add(Clave);

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
