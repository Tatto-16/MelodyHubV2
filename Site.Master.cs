using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace MelodyHub
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["nombre"] == null)
                {
                    Response.Redirect("~/login.aspx", true);
                }
            }
        }
        protected void BtnSalir_Click1(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/login.aspx");
            Context.ApplicationInstance.CompleteRequest();
        }
    }
}