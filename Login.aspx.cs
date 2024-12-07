using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace MelodyHub
{
    public partial class login : System.Web.UI.Page
    {
        String cadenaConexion = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnIngresar_Click(object sender, EventArgs e)
        {
            String nombre = txtUsuario.Text;
            String contrasena = txtPassword.Text;
            using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
            {
                try
                {
                    String sql = "SELECT contrasena FROM usuario WHERE nombre=@nombre and contrasena=@contrasena";
                    conexion.Open();
                    MySqlCommand comando = new MySqlCommand(sql, conexion);
                    comando.Parameters.AddWithValue("@nombre", nombre);
                    comando.Parameters.AddWithValue("@contrasena", contrasena);
                    MySqlDataReader lector = comando.ExecuteReader();
                    if (lector.HasRows)
                    {
                        Session["nombre"] = nombre;
                        Response.Redirect("inicio.aspx", false);
                    }
                    else
                    {
                        lblEstado.Text = "El usuario no se encuentra en la BD";
                    }
                    conexion.Close();
                }
                catch (Exception ex)
                {
                    lblEstado.Text = "Error en la conexión: " + ex.Message;
                }
            }
        }
    }
}