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
    public partial class AddCatalogoZonasVenta : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //SecureHttps.UtilizarSSLProtocol();
            ValidarSesion();
            try
            {
                AddZonaVentaBtn.Visible = true;
                EndButton.Visible = false;
                Session["resultadoProceso"] = "0";

                if (!this.IsPostBack)
                {
                    ValidarSesion();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void AddZonaVentaBtn_Click(object sender, EventArgs e)
        {
            lMessage.Text = "";
            int modo = 0;

            try
            {
                CatZonasVentasBehaivor ZonaItem = new CatZonasVentasBehaivor();
                ZonaItem.Connection = ConectionBD;
                List<CatZonasVentaDatos> LstZona = null;
                AddZonaVentaBtn.Visible = true;
                EndButton.Visible = false;

                /***********************************************************************************
                 *  Verificar que la zona que se registra no exista
                 * ********************************************************************************/
                modo = 5; // Modo para revisar zona
                LstZona = ZonaItem.CN_fn_ZonaValidaExista(zonaTxt.Text, modo);
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
                 *  Ingresar datos de la Zona de Ventas nueva
                 * ********************************************************************************/
                modo = 3; // Modo para ingresar zona nueva en el SP
                LstZona = ZonaItem.CN_fn_ZonasVentaInsert(zonaTxt.Text, modo);

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
                AddZonaVentaBtn.Visible = false;

                Session["resultadoProceso"] = "1";
                lMessage.Visible = true;
                lMessage.Text = "Zona de Ventas registrada con éxito. ";

                /***** Ingresar acción en Bitácora ***/
                Bitacorear.Guardar(ID_USUARIO_SESSION, Convert.ToInt32(Session["idrol"]), "AddCatalogoZonasVenta.aspx", "Registrar", "Zona Ventas: [ " + zonaTxt.Text + "] ", ConectionBD);

                //Registrar en notificación el evento y obtener ID
                // Registro nueva Zona Ventas 9
                int tipoNotificacion = 9;
                Inboxfn.RegistrarNotificacion("Registrar Zona Ventas", "Nuevo registro Catálogo Zona Ventas: " + zonaTxt.Text, tipoNotificacion, ConectionBD);
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