using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Library.BaseDatos;
using Library.Entidades;
using Library.Common;
using ConstrunetUnlimited.Common;
using ConstrunetUnlimited.Common.Helper;

namespace ConstrunetUnlimited
{
    public partial class AddProyecto5 : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //SecureHttps.UtilizarSSLProtocol();
            ValidarSesion();
            try
            {
                Session["resultadoProceso"] = "0";

                if (!this.IsPostBack)
                {
                    ValidarSesion();
                }
            }
            catch (Exception ex)
            {
                mensajeErrorlbl.Visible = true;
                mensajeErrorlbl.ForeColor = System.Drawing.Color.Red;
                mensajeErrorlbl.Text = "!Error / Load: " + ex.Message + "!";
            }
        }

    }
}