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
    public partial class ActualizarCatalogoEtapaProyecto : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //SecureHttps.UtilizarSSLProtocol();
            ValidarSesion();
            try
            {
                UpdateEtapaProyectoBtn.Visible = true;
                EndButton.Visible = false;
                Id = -1;
                if (!string.IsNullOrEmpty(this.Request.QueryString["Idetapaproy"]))
                {
                    Id = Convert.ToInt32(this.Request.QueryString["Idetapaproy"]);
                    Session["IdEtapaProyecto"] = Id;
                }
                if (!this.IsPostBack)
                {
                    CargarComboTipoObra();
                    CargarEtapaProyecto(Id);
                }
                Session["resultadoProceso"] = "0";

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void CargarEtapaProyecto(int IdEtapaProyecto)
        {
            try
            {
                CatEtapasProyectoBehaivor EtapaProyItem = new CatEtapasProyectoBehaivor();
                EtapaProyItem.Connection = ConectionBD;
                int modo = 2;
                List<CatEtapasProyectoDatos> LstEtapaProy = EtapaProyItem.CN_fn_EtapasProyectoxIdEtapaSel(IdEtapaProyecto, modo);
                if (LstEtapaProy.Count > 0)
                {
                    etapaproyectotxt.Text = LstEtapaProy[0].etapaProyecto;
                    cmbTipoObra.SelectedValue = LstEtapaProy[0].IdTipoObra.ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
                //ShowMessageClient(ex.Message);
            }
        }

        protected void UpdateEtapaProyectoBtn_Click(object sender, EventArgs e)
        {
            lMessage.Text = "";
            int modo = 0;

            try
            {
                CatEtapasProyectoBehaivor EtapaProyItem = new CatEtapasProyectoBehaivor();
                EtapaProyItem.Connection = ConectionBD;
                List<CatEtapasProyectoDatos> LstEtapaProy = null;
                UpdateEtapaProyectoBtn.Visible = true;
                EndButton.Visible = false;

                /*************************************************************************************************
                 *  Verificar que el estatus proyecto que se actualiza no exista en otro registro ni venga vacío
                 * ***********************************************************************************************/
                if (etapaproyectotxt.Text == "")
                {
                    lMessage.Visible = true;
                    lMessage2.Text = "La Etapa del Proyecto debe tener un valor, revise la información de favor.";
                    Session["resultadoProceso"] = "2";
                    return;
                } 
                modo = 7; // Modo para revisar registro
                LstEtapaProy = EtapaProyItem.CN_fn_EstatusProyectoValidaActualizacion(Convert.ToInt32(Session["IdEtapaProyecto"]), etapaproyectotxt.Text, modo);
                if (LstEtapaProy.Count > 0 && LstEtapaProy[0].IdEtapaProyecto > -1)
                {
                    lMessage.Visible = true;
                    lMessage2.Text = "La Etapa del Proyecto ya está registrado, revise la información de favor.";
                    Session["resultadoProceso"] = "2";
                    return;
                }
                else
                {
                    lMessage.Text = "Adelante";
                    lMessage.Visible = false;
                }

                /***********************************************************************************
                 *  Ingresar datos del etapa proyecto
                 * ********************************************************************************/
                modo = 4; // Modo para actualizar la etapa proyecto en el SP
                LstEtapaProy = EtapaProyItem.CN_fn_TiposObraUpdate(Convert.ToInt16(Session["IdEtapaProyecto"]), etapaproyectotxt.Text, Convert.ToInt32(cmbTipoObra.SelectedValue), Convert.ToInt16(CmbActivo.SelectedValue), modo);

                if (LstEtapaProy.Count > 0)
                {
                    Id = LstEtapaProy[0].IdEtapaProyecto;
                }

                /***************************************************************************************************************
                 * Pantalla de registro
                 * ************************************************************************************************************/
                etapaproyectotxt.Enabled = false;
                CancelButton.Visible = false;
                EndButton.Visible = true;
                UpdateEtapaProyectoBtn.Visible = false;

                Session["resultadoProceso"] = "1";
                lMessage.Visible = true;
                lMessage.Text = "Etapa Proyecto actualizada con éxito. ";

                /***** Ingresar acción en Bitácora ***/
                Bitacorear.Guardar(ID_USUARIO_SESSION, Convert.ToInt32(Session["idrol"]), "ActualizarCatalogoEtapaProyecto.aspx", "Actualizar", "Etapa Proyecto: [ " + etapaproyectotxt.Text + "] ", ConectionBD);

                //Registrar en notificación el evento y obtener ID
                // Registro nueva Etapa Proyecto: 15
                int tipoNotificacion = 15;
                Inboxfn.RegistrarNotificacion("Actualizar Etapa Proyecto", "Actualizar registro Catálogo Etapa Proyecto: " + etapaproyectotxt.Text, tipoNotificacion, ConectionBD);
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

        protected void CargarComboTipoObra()
        {
            try
            {
                CatTipoObraBehaivor TipoObraItem = new CatTipoObraBehaivor();
                TipoObraItem.Connection = ConectionBD;
                List<CatTipoObraDatos> TipoObraLst = TipoObraItem.CN_fn_TiposObraSel(1);
                cmbTipoObra.DataTextField = "tipoObra";
                cmbTipoObra.DataValueField = "IdTipoObra";
                cmbTipoObra.DataSource = TipoObraLst;
                cmbTipoObra.DataBind();
                cmbTipoObra.Items.Insert(0, "Seleccione un tipo de obra");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}