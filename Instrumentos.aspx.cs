using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MelodyHub.instrumentos
{
    public partial class Instrumentos : System.Web.UI.Page
    {
        String cadenaConexion = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadInstrumentos();
            }
        }

        private void LoadInstrumentos()
        {
            using (SqlConnection conn = new SqlConnection(cadenaConexion))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM instrumento", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvInstrumentos.DataSource = dt;
                gvInstrumentos.DataBind();
            }
        }

        protected void gvInstrumentos_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            gvInstrumentos.EditIndex = e.NewEditIndex;
            LoadInstrumentos();
        }

        protected void gvInstrumentos_RowCancelingEdit(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
        {
            gvInstrumentos.EditIndex = -1;
            LoadInstrumentos();
        }

        protected void gvInstrumentos_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
        {
            int id = Convert.ToInt32(gvInstrumentos.DataKeys[e.RowIndex].Value);
            string tipo = ((TextBox)gvInstrumentos.Rows[e.RowIndex].Cells[1].Controls[0]).Text;
            string marca = ((TextBox)gvInstrumentos.Rows[e.RowIndex].Cells[2].Controls[0]).Text;
            string modelo = ((TextBox)gvInstrumentos.Rows[e.RowIndex].Cells[3].Controls[0]).Text;

            using (SqlConnection conn = new SqlConnection(cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("UPDATE instrumento SET tipo_instrumento=@Tipo, marca=@Marca, modelo=@Modelo WHERE id_instrumento=@Id", conn);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Parameters.AddWithValue("@Tipo", tipo);
                cmd.Parameters.AddWithValue("@Marca", marca);
                cmd.Parameters.AddWithValue("@Modelo", modelo);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            gvInstrumentos.EditIndex = -1;
            LoadInstrumentos();
        }

        protected void gvInstrumentos_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(gvInstrumentos.DataKeys[e.RowIndex].Value);

            using (SqlConnection conn = new SqlConnection(cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM instrumento WHERE id_instrumento=@Id", conn);
                cmd.Parameters.AddWithValue("@Id", id);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            LoadInstrumentos();
        }

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            // Implementación para agregar un nuevo instrumento.
        }
    }
}