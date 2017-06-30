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
    public partial class AddCatalogoEtapaProyecto : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //SecureHttps.UtilizarSSLProtocol();
            ValidarSesion();
            try
            {
                AddEtapaProyectoBtn.Visible = true;
                EndButton.Visible = false;
                Session["resultadoProceso"] = "0";
                
                if (!this.IsPostBack)
                {
                    ValidarSesion();
                    CargarComboTipoObra();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void AddEtapaProyectoBtn_Click(object sender, EventArgs e)
        {
            lMessage.Text = "";
            int modo = 0;

            try
            {
                CatEtapasProyectoBehaivor EtapaProyItem = new CatEtapasProyectoBehaivor();
                EtapaProyItem.Connection = ConectionBD;
                List<CatEtapasProyectoDatos> LstEtapaProy = null;
                AddEtapaProyectoBtn.Visible = true;
                EndButton.Visible = false;

                /***********************************************************************************
                 *  Verificar que el estatus proyecto que se registra no exista
                 * ********************************************************************************/
                modo = 5; // Modo para revisar registro
                LstEtapaProy = EtapaProyItem.CN_fn_EstatusProyectoValidaExista(Convert.ToInt32(cmbTipoObra.SelectedValue), etapaproyectotxt.Text, modo);
                if (LstEtapaProy.Count > 0 && LstEtapaProy[0].IdEtapaProyecto > -1)
                {
                    lMessage.Visible = true;
                    lMessage2.Text = "Este Estatus Proyecto ya está registrado, revise la información de favor.";
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
                modo = 3; // Modo para ingresar etapa proyecto nuevo en el SP
                LstEtapaProy = EtapaProyItem.CN_fn_EtapaProyectoInsert(Convert.ToInt32(cmbTipoObra.SelectedValue), etapaproyectotxt.Text, modo);

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
                AddEtapaProyectoBtn.Visible = false;

                Session["resultadoProceso"] = "1";
                lMessage.Visible = true;
                lMessage.Text = "Etapa Proyecto registrado con éxito. ";

                /***** Ingresar acción en Bitácora ***/
                Bitacorear.Guardar(ID_USUARIO_SESSION, Convert.ToInt32(Session["idrol"]), "AddCatalogoEtapaProyecto.aspx", "Registrar", "Etapa Proyecto: [ " + etapaproyectotxt.Text + "] ", ConectionBD);

                //Registrar en notificación el evento y obtener ID
                // Registro nueva Etapa Proyecto: 15
                int tipoNotificacion = 15;
                Inboxfn.RegistrarNotificacion("Registrar Etapa Proyecto", "Nuevo registro Catálogo Etapa Proyecto: " + etapaproyectotxt.Text, tipoNotificacion, ConectionBD);
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