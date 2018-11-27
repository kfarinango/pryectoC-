using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace WebApplication1.Models
{
    public class LibroVisitas
    {
        SqlConnection cnnConexion = null;
        SqlCommand cmdComando = null;
        //SqlDataAdapter daAdaptador = null;
        //DataTable dtRegresa = null;

        string strCadenaConexion = string.Empty;
        //Constructor de la clase
        public LibroVisitas()
        {
            strCadenaConexion = @"Data Source=.;Initial Catalog=mvc_web_comentariodb;Persist Security Info=True;User ID=sa;Password=Uisrael2018";
        }
        public void EjecutarSP(SqlParameter[] parParameter, string nombreSP)
        {
            try
            {
                //Instanciamos el objeto conexion con la cadena de conexion
                cnnConexion = new SqlConnection(strCadenaConexion);
                //Instanciamos el objeto comando con el nombreSP  y conexion a utilizar
                cmdComando = new SqlCommand();
                cmdComando.Connection = cnnConexion;
                //Abrimos la conexion
                cnnConexion.Open();
                //Asignamos el tipo comando a ejecutar
                cmdComando.CommandType = CommandType.StoredProcedure;
                //Asignamos el nombre del store procedure
                cmdComando.CommandText = nombreSP;
                //agregamos los parametros a ejecutar
                cmdComando.Parameters.AddRange(parParameter);
                //Ejecutamos el TSQL enn el servidor
                cmdComando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                cnnConexion.Dispose();
                cmdComando.Dispose();
            }



        }
    }
}