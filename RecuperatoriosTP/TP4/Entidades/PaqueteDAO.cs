using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Entidades
{
    public static class PaqueteDAO
    {
        #region Atributos

        static SqlCommand comando;
        static SqlConnection conexion;
        
        #endregion

        #region Constructor
        
        /// <summary>
        /// Constructor estatico.
        /// </summary>
        static PaqueteDAO()
        {
            conexion = new SqlConnection(@"Data Source=HOMEDESKTOP\SQLEXPRESS; Initial Catalog = correo-sp-2017;Integrated Security = True");
            comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.Connection = conexion;
        }
        #endregion

        #region Metodo


        /// <summary>
        /// Guardará los datos de un paquete en la base de datos generada.
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static bool Insertar(Paquete p)
        {
            bool returnAux = false;
            try
            {
                comando.CommandText = "INSERT INTO dbo.Paquetes (direccionEntrega,trackingID,alumno) VALUES ('" + p.DireccionEntrega + "','" + p.TrackingID + "','Torretta Pablo')";
                conexion.Open();
                comando.ExecuteNonQuery();
                returnAux = true;
            }
            catch (Exception ex)
            {
                throw new InsertarSQLExcepcion("Se ha producido un error al guardar en la base de datos", ex);
            }
            finally
            {
                if (conexion != null)
                {
                    conexion.Close();
                }
                if (comando != null)
                {
                    comando.Dispose();
                }
            }

            return returnAux;


        }
        #endregion

    }
}
