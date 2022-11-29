using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Adventure_Works
{
    public partial class index : System.Web.UI.Page
    {
       

        public string usuario()
        {
            string nombre = Request.QueryString["nom"];
            return nombre;
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            lblusuario.Text = usuario();
            ConsultarFotos();
            if (lblusuario.Text == "")
            {
                btnAgregarFoto.Visible = false;
                Hplink.Visible = true;
                Hplink2.Visible = false;
               
            }
            else
            {
                Hplink.Visible = false;
                btnAgregarFoto.Visible = true;
                Hplink2.Visible = true;
            }
        }
        protected void ConsultarFotos() {
            SqlConnection cn = new Coneccion().ConectarSQL();
            SqlCommand cm = new SqlCommand("SELECT TOP(9) PhotoFile, Title, CreatedDate, PhotoID, Owner from Photo ORDER BY PhotoID DESC",cn);
            //cm.CommandText = "SELECT TOP(9) PhotoFile, Title, CreatedDate, PhotoID, Owner from Photo ORDER BY PhotoID DESC";
            cm.CommandType = CommandType.Text;
            cm.Connection = cn;
            DataTable imagenes = new DataTable();
            imagenes.Load(cm.ExecuteReader());
            Repeater1.DataSource = imagenes;
            Repeater1.DataBind();
            cn.Close();
        }

        protected void btnInicio_Click(object sender, EventArgs e)
        {

        }

        protected void btnAgregarFoto_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarImagen.aspx?nom=" + usuario());
        }

        protected void btnInicioSesion_Click(object sender, EventArgs e)
        {
            Response.Redirect("login.aspx");
        }
        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            //Version de todos
            foreach (RepeaterItem item in Repeater1.Items)
            {
                HiddenField id = ((HiddenField)item.FindControl("txtIDfoto"));
                if (id != null)
                {
                    int val = Convert.ToInt32(id.Value);
                    int clave = Convert.ToInt32(e.CommandArgument);
                    if (val == clave)
                    {

                        Response.Redirect("Comentarios.aspx?id=" + val+"&nom="+usuario());
                    }
                }
            }

        }

        protected void btnGaleria_Click(object sender, EventArgs e)
        {
            if (lblusuario.Text == "")
            {
               Response.Redirect("login.aspx");
           
            }
            else
            {
               
            }
        }

        protected void btnPresentacion_Click(object sender, EventArgs e)
        {
            if (lblusuario.Text == "")
            {
                Response.Redirect("login.aspx");

            }
            else
            {

            }
        }
    }
}