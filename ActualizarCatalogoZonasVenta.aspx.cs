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
    public partial class ActualizarCatalogoZonasVenta : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //SecureHttps.UtilizarSSLProtocol();
            ValidarSesion();
            try
            {
                UpdateZonaVentaBtn.Visible = true;
                EndButton.Visible = false;
                Id = -1;
                if (!string.IsNullOrEmpty(this.Request.QueryString["Idzona"]))
                {
                    Id = Convert.ToInt32(this.Request.QueryString["Idzona"]);
                    Session["IdZona"] = Id;
                }
                if (!this.IsPostBack)
                {
                    CargarZonaVenta(Id);
                }
                Session["resultadoProceso"] = "0";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void CargarZonaVenta(int IdZonaVenta)
        {
            try
            {
                CatZonasVentasBehaivor ZonaItem = new CatZonasVentasBehaivor();
                ZonaItem.Connection = ConectionBD;
                int modo = 2;
                List<CatZonasVentaDatos> LstZona = ZonaItem.CN_fn_ZonasVentaSel(IdZonaVenta, modo);
                if (LstZona.Count > 0 )
                {
                    zonaTxt.Text = LstZona[0].zonaVenta;
                }
            }
            catch (Exception ex)
            {
                throw ex;
                //ShowMessageClient(ex.Message);
            }
        }

        protected void UpdateZonaVentaBtn_Click(object sender, EventArgs e)
        {
            lMessage.Text = "";
            int modo = 0;

            try
            {
                CatZonasVentasBehaivor ZonaItem = new CatZonasVentasBehaivor();
                ZonaItem.Connection = ConectionBD;
                List<CatZonasVentaDatos> LstZona = null;
                UpdateZonaVentaBtn.Visible = true;
                EndButton.Visible = false;

                /***********************************************************************************
                 *  Verificar que la zona que se registra no exista ni esté vacía
                 * ********************************************************************************/
                if (zonaTxt.Text == "")
                {
                    lMessage.Visible = true;
                    lMessage2.Text = "La zona de ventas debe tener un valor, revise la información de favor.";
                    Session["resultadoProceso"] = "2";
                    return;
                }
                modo = 5; // Modo para revisar zona
                LstZona = ZonaItem.CN_fn_ZonaValidaNoPIX(zonaTxt.Text, Convert.ToInt16(Session["IdZona"]), modo);
                if (LstZona.Count > 0 && LstZona[0].IdZonaVenta > -1)
                {
                    lMessage.Visible = true;
                    lMessage2.Text = "Esta Zona de Ventas ya está registrada, revise la información de favor.";
                    Session["resultadoProceso"] = "2";
                    return;
                }
                else
                {
                    lMessage.Text = "Adelante";
                    lMessage.Visible = false;
                }

                /***********************************************************************************
                 *  Actualizar datos de la Zona de Ventas 
                 * ********************************************************************************/
                modo = 4; // Modo para actualizar zona nueva en el SP
                LstZona = ZonaItem.CN_fn_ZonasVentaUpdate(Convert.ToInt16(Session["IdZona"]), zonaTxt.Text, Convert.ToInt16(CmbActivo.SelectedValue), modo);

                if (LstZona.Count > 0)
                {
                    Id = LstZona[0].IdZonaVenta;
                }

                /***************************************************************************************************************
                 * Pantalla de Usuario Registrado
                 * ************************************************************************************************************/
                zonaTxt.Enabled = false;
                CancelButton.Visible = false;
                EndButton.Visible = true;
                UpdateZonaVentaBtn.Visible = false;

                Session["resultadoProceso"] = "1";
                lMessage.Visible = true;
                lMessage.Text = "Zona de Ventas actualizada con éxito. ";

                /***** Ingresar acción en Bitácora ***/
                Bitacorear.Guardar(ID_USUARIO_SESSION, Convert.ToInt32(Session["idrol"]), "ActualizarCatalogoZonasVenta.aspx", "Actualizar", "Zona Ventas: [ " + zonaTxt.Text + "] ", ConectionBD);

                //Registrar en notificación el evento y obtener ID
                // Registro nueva Zona Ventas 9
                int tipoNotificacion = 9;
                Inboxfn.RegistrarNotificacion("Actualizar Zona Ventas", "Actualizado registro Catálogo Zona Ventas: " + zonaTxt.Text, tipoNotificacion, ConectionBD);
                // Obtener último ID Notificación registrado
                int IDLastNotification = 0;
                IDLastNotification = Inboxfn.ObtenerIDNotificacion(ConectionBD);
                //Envio a inbox x Usuario
                Inboxfn.RegistrarNotificacionxUsuario(ID_USUARIO_SESSION, IDLastNotification, 1, ConectionBD);

            }
            catch (Exception ex)
            {
                throw ex;
                //ShowMessageClient(ex.Message);
            }
        }
    }
}