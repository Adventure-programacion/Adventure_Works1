using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Security;
using System.Net;

namespace Adventure_Works
{
    public class Coneccion
    {
        SqlConnection conexion = new SqlConnection();//Permite establcer una conexion con la BD
        SqlCommand cmd = new SqlCommand(); //Permite ejecutar una instruccion SQL
        SqlDataReader leer; //Permite almacenar el resultado de una instruccion se

        public SqlConnection ConectarSQL()
        {
            try
            {
               // string nombreServidor = Dns.GetHostName();
                 //string cadena = "Data source=EVELYN\\GONZALEZ;Initial Catalog=proyecto;Integrated Security=True";
                string cadena= "Data Source=tcp:advenpro.database.windows.net,1433;Initial Catalog=Adventure;User Id=jbalmore@advenpro;Password=Eve75781743";
                // conexion.ConnectionString = "Data Source = " + nombreServidor + "\\SQLEXPRESS; Initial Catalog = proyecto; Integrated Security = True";
                conexion.ConnectionString = cadena;
                //conexion.ConnectionString = "Data source=GBGJ373;Initial Catalog=proyecto;Integrated Security=True";
                conexion.Open();
                return conexion;

            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public void Ingresar(string usuario, string nom, string pas)
        {
            /*
            string nombreServidor = Dns.GetHostName();
            string cadena = "Data source=" + nombreServidor + "//SQLEXPRESS; Initial Catalog=proyecto;Integrated Security=True";
            conexion.ConnectionString = cadena;
            */
            cmd.Connection = ConectarSQL();
            String procedimientoAlmacenado = "ingreso";
            cmd.CommandText = procedimientoAlmacenado;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@usu", SqlDbType.VarChar, 20);
            cmd.Parameters["@usu"].Value = usuario;
            cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 35);
            cmd.Parameters["@nombre"].Value = nom;
            cmd.Parameters.Add("@pas", SqlDbType.VarChar, 20);
            cmd.Parameters["@pas"].Value = pas;
            //conexion.Open(); 
            cmd.ExecuteNonQuery();
            //ConectarSQL().Close();
            conexion.Close();
        }
        public void AgregarComentario(string usuario, string tema, string cuerpo, int IdFoto) {
            cmd.Connection = ConectarSQL();
            String procedimientoAlmacenado = "agregarComentario";
            cmd.CommandText = procedimientoAlmacenado;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@usuario", SqlDbType.VarChar, 20);
            cmd.Parameters["@usuario"].Value = usuario;
            cmd.Parameters.Add("@subject", SqlDbType.VarChar, 30);
            cmd.Parameters["@subject"].Value = tema;
            cmd.Parameters.Add("@body", SqlDbType.VarChar, 50);
            cmd.Parameters["@body"].Value = cuerpo;
            cmd.Parameters.Add("@PhotoID", SqlDbType.Int);
            cmd.Parameters["@PhotoID"].Value = IdFoto;
            //conexion.Open(); 
            cmd.ExecuteNonQuery();
            //ConectarSQL().Close();
            conexion.Close();
        }




        public bool Validar(string user, string pas)
        {
            /*
            string nombreServidor = Dns.GetHostName();
            string cadena = "Data source=" + nombreServidor + "//SQLEXPRESS; Initial Catalog=proyecto;Integrated Security=True";
            conexion.ConnectionString = cadena;
            cmd.Connection = conexion;
            */
            cmd.Connection = ConectarSQL();
            String sql = "buscar";
            cmd.CommandText = sql;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@user", SqlDbType.VarChar, 20);
            cmd.Parameters["@user"].Value = user;
            cmd.Parameters.Add("@pas", SqlDbType.VarChar, 20);
            cmd.Parameters["@pas"].Value = pas;
            //conexion.Open(); El metodo ConectarSQL retorna una conexion abierta
            leer = cmd.ExecuteReader();
            if (leer.HasRows == true)
            {
                return true;
            }
            else
            {
                return false;
            }
            ConectarSQL().Close();

        }
    }
}