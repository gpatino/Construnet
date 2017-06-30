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
    public partial class ActualizarCatalogoProspecto : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //SecureHttps.UtilizarSSLProtocol();
            ValidarSesion();
            try
            {
                UpdateProspectoBtn.Visible = true;
                EndButton.Visible = false;
                Id = -1;
                if (!string.IsNullOrEmpty(this.Request.QueryString["Idprosp"]))
                {
                    Id = Convert.ToInt32(this.Request.QueryString["Idprosp"]);
                    Session["Idprospecto"] = Id;
                }
                if (!this.IsPostBack)
                {
                    CargarProspecto(Id);
                }
                Session["resultadoProceso"] = "0";

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void CargarProspecto(int IdProspecto)
        {
            try
            {
                CatProspectoBehaivor ProspectoItem = new CatProspectoBehaivor();
                ProspectoItem.Connection = ConectionBD;
                int modo = 2;
                List<CatProspectoDatos> ProspectoLst = ProspectoItem.CN_fn_ProspectoxIdProspectoSel(IdProspecto, modo);
                if (ProspectoLst.Count > 0)
                {
                    prospectotxt.Text = ProspectoLst[0].prospecto;
                }
            }
            catch (Exception ex)
            {
                throw ex;
                //ShowMessageClient(ex.Message);
            }
        }

        protected void UpdateProspectoBtn_Click(object sender, EventArgs e)
        {
            lMessage.Text = "";
            int modo = 0;

            try
            {
                CatProspectoBehaivor ProspectoItem = new CatProspectoBehaivor();
                ProspectoItem.Connection = ConectionBD;
                List<CatProspectoDatos> ProspectoLst = null;
                UpdateProspectoBtn.Visible = true;
                EndButton.Visible = false;

                /***********************************************************************************
                 *  Verificar que el prospecto proyecto que se actualiza no exista ni esté vacío
                 * ********************************************************************************/
                if (prospectotxt.Text == "")
                {
                    lMessage.Visible = true;
                    lMessage2.Text = "El prospecto debe tener un valor, revise la información de favor.";
                    Session["resultadoProceso"] = "2";
                    return;
                } 
                modo = 6; // Modo para revisar registro
                ProspectoLst = ProspectoItem.CN_fn_ProspectoValidaActualizacion(Convert.ToInt16(Session["Idprospecto"]), prospectotxt.Text, modo);
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
                 *  Actualizar datos del Prospecto de proyecto
                 * ********************************************************************************/
                modo = 4; // Modo para actualizar prospecto de proyecto en el SP
                ProspectoLst = ProspectoItem.CN_fn_ProspectoUpdate(Convert.ToInt16(Session["Idprospecto"]), prospectotxt.Text, Convert.ToInt16(CmbActivo.SelectedValue), modo);

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
                UpdateProspectoBtn.Visible = false;

                Session["resultadoProceso"] = "1";
                lMessage.Visible = true;
                lMessage.Text = "Prospecto de Proyecto actualizado con éxito. ";

                /***** Ingresar acción en Bitácora ***/
                Bitacorear.Guardar(ID_USUARIO_SESSION, Convert.ToInt32(Session["idrol"]), "ActualizarCatalogoProspecto.aspx", "Actualizar", "Prospecto de Proyecto: [ " + prospectotxt.Text + "] ", ConectionBD);

                //Registrar en notificación el evento y obtener ID
                // Registro nueva Prospecto de Proyecto: 16
                int tipoNotificacion = 16;
                Inboxfn.RegistrarNotificacion("Actualizar Prospecto de Proyecto", "Actualizar registro Catálogo Prospecto de Proyecto: " + prospectotxt.Text, tipoNotificacion, ConectionBD);
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