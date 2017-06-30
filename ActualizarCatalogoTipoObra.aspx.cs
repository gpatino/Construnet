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
    public partial class ActualizarCatalogoTipoObra : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //SecureHttps.UtilizarSSLProtocol();
            ValidarSesion();
            try
            {
                UpdateTipoObraBtn.Visible = true;
                EndButton.Visible = false;
                Id = -1;
                if (!string.IsNullOrEmpty(this.Request.QueryString["IdtipObra"]))
                {
                    Id = Convert.ToInt32(this.Request.QueryString["IdtipObra"]);
                    Session["IdtipoObra"] = Id;
                }
                if (!this.IsPostBack)
                {
                    CargarTipoObra(Id);
                }
                Session["resultadoProceso"] = "0";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void CargarTipoObra(int IdTipoObra)
        {
            try
            {
                CatTipoObraBehaivor TipoObraItem = new CatTipoObraBehaivor();
                TipoObraItem.Connection = ConectionBD;
                int modo = 2;
                List<CatTipoObraDatos> LstTipoObra = TipoObraItem.CN_fn_TiposObraxIdTipoSel(IdTipoObra, modo);
                if (LstTipoObra.Count > 0)
                {
                    tipoobratxt.Text = LstTipoObra[0].tipoObra;
                }
            }
            catch (Exception ex)
            {
                throw ex;
                //ShowMessageClient(ex.Message);
            }
        }


        protected void UpdateTipoObraBtn_Click(object sender, EventArgs e)
        {
            lMessage.Text = "";
            int modo = 0;

            try
            {
                CatTipoObraBehaivor TipoObraItem = new CatTipoObraBehaivor();
                TipoObraItem.Connection = ConectionBD;
                List<CatTipoObraDatos> LstTipoObra = null;
                UpdateTipoObraBtn.Visible = true;
                EndButton.Visible = false;

                /**********************************************************************************************
                 *  Verificar que el tipo obra que se actualiza no exista en otro registro y no venga vacío
                 * ********************************************************************************************/
                if (tipoobratxt.Text == "")
                {
                    lMessage.Visible = true;
                    lMessage2.Text = "El tipo de obra debe tener un valor, revise la información de favor.";
                    Session["resultadoProceso"] = "2";
                    return;
                }
                modo = 6; // Modo para revisar registro
                LstTipoObra = TipoObraItem.CN_fn_TipoObraValidaActualizacion(Convert.ToInt16(Session["IdtipoObra"]), tipoobratxt.Text, modo);
                if (LstTipoObra.Count > 0 )
                {
                    lMessage.Visible = true;
                    lMessage2.Text = "Este Tipo de Obra ya está registrado, revise la información de favor.";
                    Session["resultadoProceso"] = "2";
                    return;
                }
                else
                {
                    lMessage.Text = "Adelante";
                    lMessage.Visible = false;
                }

                /***********************************************************************************
                 *  Actualizar datos del tipo obra
                 * ********************************************************************************/
                modo = 4; // Modo para actualizar tipo obra en el SP
                LstTipoObra = TipoObraItem.CN_fn_TiposObraUpdate(Convert.ToInt16(Session["IdtipoObra"]), tipoobratxt.Text, Convert.ToInt16(CmbActivo.SelectedValue), modo);

                if (LstTipoObra.Count > 0)
                {
                    Id = LstTipoObra[0].IdTipoObra;
                }

                /***************************************************************************************************************
                 * Pantalla de registro
                 * ************************************************************************************************************/
                tipoobratxt.Enabled = false;
                CancelButton.Visible = false;
                EndButton.Visible = true;
                UpdateTipoObraBtn.Visible = false;

                Session["resultadoProceso"] = "1";
                lMessage.Visible = true;
                lMessage.Text = "Tipo de obra actualizado con éxito. ";

                /***** Ingresar acción en Bitácora ***/
                Bitacorear.Guardar(ID_USUARIO_SESSION, Convert.ToInt32(Session["idrol"]), "UpdateCatalogoTipoObra.aspx", "Actualizar", "Tipo Obra: [ " + tipoobratxt.Text + "] ", ConectionBD);

                //Registrar en notificación el evento y obtener ID
                // Registro nueva Tipo Obra 13
                int tipoNotificacion = 13;
                Inboxfn.RegistrarNotificacion("Actualizar Tipo Obra", "Actualizar registro Catálogo Tipo Obra: " + tipoobratxt.Text, tipoNotificacion, ConectionBD);
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