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
    public partial class AddCatalogoProspecto : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //SecureHttps.UtilizarSSLProtocol();
            ValidarSesion();
            try
            {
                AddProspectoBtn.Visible = true;
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

        protected void AddProspectoBtn_Click(object sender, EventArgs e)
        {
            lMessage.Text = "";
            int modo = 0;

            try
            {
                CatProspectoBehaivor ProspectoItem = new CatProspectoBehaivor();
                ProspectoItem.Connection = ConectionBD;
                List<CatProspectoDatos> ProspectoLst = null;
                AddProspectoBtn.Visible = true;
                EndButton.Visible = false;

                /***********************************************************************************
                 *  Verificar que el prospecto proyecto que se registra no exista
                 * ********************************************************************************/
                modo = 5; // Modo para revisar registro
                ProspectoLst = ProspectoItem.CN_fn_ProspectoValidaExista(prospectotxt.Text, modo);
                if (ProspectoLst.Count > 0 && ProspectoLst[0].IdProspecto > -1)
                {
                    lMessage.Visible = true;
                    lMessage2.Text = "Este Prospecto de Proyecto ya está registrado, revise la información de favor.";
                    Session["resultadoProceso"] = "2";
                    return;
                }
                else
                {
                    lMessage.Text = "Adelante";
                    lMessage.Visible = false;
                }

                /***********************************************************************************
                 *  Ingresar datos del Prospecto de proyecto
                 * ********************************************************************************/
                modo = 3; // Modo para ingresar prospecto de proyecto nuevo en el SP
                ProspectoLst = ProspectoItem.CN_fn_ProspectoInsert(prospectotxt.Text, modo);

                if (ProspectoLst.Count > 0)
                {
                    Id = ProspectoLst[0].IdProspecto;
                }

                /***************************************************************************************************************
                 * Pantalla de registro
                 * ************************************************************************************************************/
                prospectotxt.Enabled = false;
                CancelButton.Visible = false;
                EndButton.Visible = true;
                AddProspectoBtn.Visible = false;

                Session["resultadoProceso"] = "1";
                lMessage.Visible = true;
                lMessage.Text = "Prospecto de Proyecto registrado con éxito. ";

                /***** Ingresar acción en Bitácora ***/
                Bitacorear.Guardar(ID_USUARIO_SESSION, Convert.ToInt32(Session["idrol"]), "AddCatalogoProspecto.aspx", "Registrar", "Prospecto de Proyecto: [ " + prospectotxt.Text + "] ", ConectionBD);

                //Registrar en notificación el evento y obtener ID
                // Registro nueva Prospecto de Proyecto: 16
                int tipoNotificacion = 16;
                Inboxfn.RegistrarNotificacion("Registrar Prospecto de Proyecto", "Nuevo registro Catálogo Prospecto de Proyecto: " + prospectotxt.Text, tipoNotificacion, ConectionBD);
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