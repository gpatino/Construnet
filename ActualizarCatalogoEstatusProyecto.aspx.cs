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
    public partial class ActualizarCatalogoEstatusProyecto : BasePage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            //SecureHttps.UtilizarSSLProtocol();
            ValidarSesion();
            try
            {
                UpdateEstatusProyectoBtn.Visible = true;
                EndButton.Visible = false;
                Id = -1;
                if (!string.IsNullOrEmpty(this.Request.QueryString["Idestatusproy"]))
                {
                    Id = Convert.ToInt32(this.Request.QueryString["Idestatusproy"]);
                    Session["IdEstatusProyecto"] = Id;
                }
                if (!this.IsPostBack)
                {
                    CargarEstatusProyecto(Id);
                }
                Session["resultadoProceso"] = "0";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void CargarEstatusProyecto(int IdEstatusProyecto)
        {
            try
            {
                CatEstatusProyectoBehaivor EstatusProyItem = new CatEstatusProyectoBehaivor();
                EstatusProyItem.Connection = ConectionBD;
                int modo = 2;
                List<CatEstatusProyectoDatos> LstEstatusProy = EstatusProyItem.CN_fn_EstatusProyectoxIdEstatusSel(IdEstatusProyecto, modo);
                if (LstEstatusProy.Count > 0)
                {
                    estatusproyectotxt.Text = LstEstatusProy[0].estatusProyecto;
                }
            }
            catch (Exception ex)
            {
                throw ex;
                //ShowMessageClient(ex.Message);
            }
        }


        protected void UpdateEstatusProyectoBtn_Click(object sender, EventArgs e)
        {
            lMessage.Text = "";
            int modo = 0;

            try
            {
                CatEstatusProyectoBehaivor EstatusProyItem = new CatEstatusProyectoBehaivor();
                EstatusProyItem.Connection = ConectionBD;
                List<CatEstatusProyectoDatos> LstEstatusProy = null;
                UpdateEstatusProyectoBtn.Visible = true;
                EndButton.Visible = false;

                /**************************************************************************************************
                 *  Verificar que el estatus proyecto que se actualiza no exista en otro registro ni venga vacío
                 * ************************************************************************************************/
                if (estatusproyectotxt.Text == "")
                {
                    lMessage.Visible = true;
                    lMessage2.Text = "El Estatus de Proyecto debe tener un valor, revise la información de favor.";
                    Session["resultadoProceso"] = "2";
                    return;
                }
                modo = 6; // Modo para revisar registro
                LstEstatusProy = EstatusProyItem.CN_fn_EstatusProyectoValidaActualizacion(Convert.ToInt16(Session["IdEstatusProyecto"]), estatusproyectotxt.Text, modo);
                if (LstEstatusProy.Count > 0)
                {
                    lMessage.Visible = true;
                    lMessage2.Text = "Este Estatus de Proyecto ya está registrado, revise la información de favor.";
                    Session["resultadoProceso"] = "2";
                    return;
                }
                else
                {
                    lMessage.Text = "Adelante";
                    lMessage.Visible = false;
                }

                /***********************************************************************************
                 *  Actualizar datos del estatus proyecto
                 * ********************************************************************************/
                modo = 4; // Modo para actualizar estatus proyecto en el SP
                LstEstatusProy = EstatusProyItem.CN_fn_EstatusProyectoUpdate(Convert.ToInt16(Session["IdEstatusProyecto"]), estatusproyectotxt.Text, Convert.ToInt16(CmbActivo.SelectedValue), modo);

                if (LstEstatusProy.Count > 0)
                {
                    Id = LstEstatusProy[0].IdEstatusProyecto;
                }

                /***************************************************************************************************************
                 * Pantalla de registro
                 * ************************************************************************************************************/
                estatusproyectotxt.Enabled = false;
                CancelButton.Visible = false;
                EndButton.Visible = true;
                UpdateEstatusProyectoBtn.Visible = false;

                Session["resultadoProceso"] = "1";
                lMessage.Visible = true;
                lMessage.Text = "Estatus Proyecto actualizado con éxito. ";

                /***** Ingresar acción en Bitácora ***/
                Bitacorear.Guardar(ID_USUARIO_SESSION, Convert.ToInt32(Session["idrol"]), "ActualizarCatalogoEstatusProyecto.aspx", "Actualizar", "Estatus Proyecto: [ " + estatusproyectotxt.Text + "] ", ConectionBD);

                //Registrar en notificación el evento y obtener ID
                // Registro nueva Estatus Proyecto: 14
                int tipoNotificacion = 14;
                Inboxfn.RegistrarNotificacion("Actualizar Estatus Proyecto", "Actualizar registro Catálogo Estatus Proyecto: " + estatusproyectotxt.Text, tipoNotificacion, ConectionBD);
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