using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DArticulos
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
        public DArticulos
() { }
        #endregion

        #region METODO INSERTAR ARTICULOS
        public string InsertarArticulos(List<string> Variables, 
            DataTable imagenes, out int id_articulo)
        {
            id_articulo = 0;
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
                    CommandText = "sp_Insertar_articulo",
                    //Indicamos que es un procedimiento almacenado
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter Id_articulo = new SqlParameter
                {
                    ParameterName = "@Id_articulo",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };
                SqlCmd.Parameters.Add(Id_articulo);

                SqlParameter Id_tipo_articulo = new SqlParameter
                {
                    ParameterName = "@Id_tipo_articulo",
                    SqlDbType = SqlDbType.Int,
                    Value = Variables[contador]
                };
                SqlCmd.Parameters.Add(Id_tipo_articulo);
                contador += 1;

                SqlParameter Nombre_articulo = new SqlParameter
                {
                    ParameterName = "@Nombre_articulo",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 150,
                    Value = Variables[contador].Trim().ToUpper()
                };
                SqlCmd.Parameters.Add(Nombre_articulo);
                contador += 1;

                SqlParameter Id_proveedor = new SqlParameter
                {
                    ParameterName = "@Id_proveedor",
                    SqlDbType = SqlDbType.Int,
                    Value = Variables[contador]
                };
                SqlCmd.Parameters.Add(Id_proveedor);
                contador += 1;

                SqlParameter Cantidad = new SqlParameter
                {
                    ParameterName = "@Cantidad",
                    SqlDbType = SqlDbType.Int,
                    Value = Variables[contador]
                };
                SqlCmd.Parameters.Add(Cantidad);
                contador += 1;

                SqlParameter Tipo_detalle = new SqlParameter
                {
                    ParameterName = "@Tipo_detalle",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = Variables[contador].Trim().ToUpper()
                };
                SqlCmd.Parameters.Add(Tipo_detalle);
                contador += 1;

                SqlParameter Descripcion_articulo = new SqlParameter
                {
                    ParameterName = "@Descripcion_articulo",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 500,
                    Value = Variables[contador].Trim()
                };
                SqlCmd.Parameters.Add(Descripcion_articulo);
                contador += 1;

                SqlParameter Precio_articulo = new SqlParameter
                {
                    ParameterName = "@Precio_articulo",
                    SqlDbType = SqlDbType.Int,
                    Value = Variables[contador]
                };
                SqlCmd.Parameters.Add(Precio_articulo);
                contador += 1;

                SqlParameter Imagen = new SqlParameter("@Imagen", imagenes);
                SqlCmd.Parameters.Add(Imagen);

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
                    id_articulo = Convert.ToInt32(SqlCmd.Parameters["@Id_articulo"].Value);
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

        #region METODO EDITAR ARTICULOS
        public string EditarArticulos(List<string> Variables,
            DataTable imagenes, int id_articulo)
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
                    CommandText = "sp_Insertar_articulo",
                    //Indicamos que es un procedimiento almacenado
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter Id_articulo = new SqlParameter
                {
                    ParameterName = "@Id_articulo",
                    SqlDbType = SqlDbType.Int,
                    Value = id_articulo
                };
                SqlCmd.Parameters.Add(Id_articulo);

                SqlParameter Id_tipo_articulo = new SqlParameter
                {
                    ParameterName = "@Id_tipo_articulo",
                    SqlDbType = SqlDbType.Int,
                    Value = Variables[contador]
                };
                SqlCmd.Parameters.Add(Id_tipo_articulo);
                contador += 1;

                SqlParameter Nombre_articulo = new SqlParameter
                {
                    ParameterName = "@Nombre_articulo",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 150,
                    Value = Variables[contador].Trim().ToUpper()
                };
                SqlCmd.Parameters.Add(Nombre_articulo);
                contador += 1;

                SqlParameter Id_proveedor = new SqlParameter
                {
                    ParameterName = "@Id_proveedor",
                    SqlDbType = SqlDbType.Int,
                    Value = Variables[contador]
                };
                SqlCmd.Parameters.Add(Id_proveedor);
                contador += 1;

                SqlParameter Cantidad = new SqlParameter
                {
                    ParameterName = "@Cantidad",
                    SqlDbType = SqlDbType.Int,
                    Value = Variables[contador]
                };
                SqlCmd.Parameters.Add(Cantidad);
                contador += 1;

                SqlParameter Tipo_detalle = new SqlParameter
                {
                    ParameterName = "@Tipo_detalle",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = Variables[contador].Trim().ToUpper()
                };
                SqlCmd.Parameters.Add(Tipo_detalle);
                contador += 1;

                SqlParameter Descripcion_articulo = new SqlParameter
                {
                    ParameterName = "@Descripcion_articulo",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 500,
                    Value = Variables[contador].Trim()
                };
                SqlCmd.Parameters.Add(Descripcion_articulo);
                contador += 1;

                SqlParameter Precio_articulo = new SqlParameter
                {
                    ParameterName = "@Precio_articulo",
                    SqlDbType = SqlDbType.Int,
                    Value = Variables[contador]
                };
                SqlCmd.Parameters.Add(Precio_articulo);
                contador += 1;

                SqlParameter Imagen = new SqlParameter("@Imagen", imagenes);
                SqlCmd.Parameters.Add(Imagen);

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

        #region METODO BUSCAR ARTICULOS
        public static DataTable BuscarArticulos(string tipo_busqueda, 
            string texto_busqueda, out string rpta)
        {
            rpta = "OK";
            DataTable DtResultado = new DataTable("Articulos");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand Sqlcmd = new SqlCommand
                {
                    Connection = SqlCon,
                    CommandText = "sp_Buscar_articulos",
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
