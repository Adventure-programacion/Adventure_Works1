using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Adventure_Works
{
    public partial class Comentarios : System.Web.UI.Page
    {
        public string usuario()
        {
            string nombre = Request.QueryString["nom"];
            return nombre;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            string ID = Request.QueryString["id"];

            

            SqlConnection cn = new Coneccion().ConectarSQL();
            SqlCommand cm = new SqlCommand();
            cm.CommandText = "SELECT Owner,PhotoFile, Title, CreatedDate, Descripcion from Photo where PhotoID = " + ID;
            cm.CommandType = CommandType.Text;
            cm.Connection = cn;
            DataTable imagenes = new DataTable();
            imagenes.Load(cm.ExecuteReader());
            Repeater2.DataSource = imagenes;
            Repeater2.DataBind();
            cn.Close();
            cargarComentarios();
            /*
            
            //ScriptManager.RegisterStartupScript(this, this.GetType(),
              //     "alert", "alert(" + ID + ");", true);
            
            SqlConnection cn = new Coneccion().ConectarSQL();
            SqlCommand cm = new SqlCommand();
            cm.CommandText = "SELECT PhotoFile from Photo where PhotoID =" + ID;
            cm.CommandType = CommandType.Text;
            cm.Connection = cn;
            byte[] byteImage = (byte[])cm.ExecuteScalar();

            if (byteImage != null) {
                Response.ContentType = "image/jpg";
                Response.Expires = 0;
                Response.Buffer = true;
                Response.Clear();
                Response.BinaryWrite(byteImage);
                Response.End();
            }
            cn.Close();
            */

        }
        protected void cargarComentarios() {
            string ID = Request.QueryString["id"];
            SqlConnection cn = new Coneccion().ConectarSQL();
            SqlCommand cm = new SqlCommand();
            cm.CommandText = "SELECT Usuario, Subject, Body from Comentario where PhotoID = " + ID+ " ORDER BY CommentID DESC";
            //"SELECT Usuario, Subject, Body from Comentario where PhotoID = " + ID;
            cm.CommandType = CommandType.Text;
            cm.Connection = cn;
            DataTable comentarios = new DataTable();
            comentarios.Load(cm.ExecuteReader());
            Repeater3.DataSource = comentarios;
            Repeater3.DataBind();
            cn.Close();
        }

        protected void BtnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }

        protected void btnAgregarComentario_Click(object sender, EventArgs e)
        {
            if (usuario() == "")
            {
                Response.Redirect("login.aspx");
            }
            else
            {
                cajaComentario.Visible = true;
            }
        }

        Coneccion con = new Coneccion();

        protected void btnAceptarComentario_Click(object sender, EventArgs e)
        {
            //con.Ingresar(txtuser.Text, txtnom.Text, txtpas.Text);
            //con.AgregarComentario(int IdComent, string usuario, string tema, string cuerpo, int IdFoto)
            string nombre = Request.QueryString["nom"];
            int ID = Convert.ToInt32(Request.QueryString["id"]);
            con.AgregarComentario(nombre, txtTema.Text, txtComentario.Value, ID);
            cajaComentario.Visible = false;
            cargarComentarios();
        }
    }
}