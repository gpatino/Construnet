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
    public partial class AddCatalogoTipoObra : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //SecureHttps.UtilizarSSLProtocol();
            ValidarSesion();
            try
            {
                AddTipoObraBtn.Visible = true;
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

        protected void AddTipoObraBtn_Click(object sender, EventArgs e)
        {
            lMessage.Text = "";
            int modo = 0;

            try
            {
                CatTipoObraBehaivor TipoObraItem = new CatTipoObraBehaivor();
                TipoObraItem.Connection = ConectionBD;
                List<CatTipoObraDatos> LstTipoObra = null;
                AddTipoObraBtn.Visible = true;
                EndButton.Visible = false;

                /***********************************************************************************
                 *  Verificar que el tipo obra que se registra no exista
                 * ********************************************************************************/
                modo = 5; // Modo para revisar registro
                LstTipoObra = TipoObraItem.CN_fn_TipoObraValidaExista(tipoobratxt.Text, modo);
                if (LstTipoObra.Count > 0 && LstTipoObra[0].IdTipoObra > -1)
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
                 *  Ingresar datos del tipo obra
                 * ********************************************************************************/
                modo = 3; // Modo para ingresar tipo obra nuevo en el SP
                LstTipoObra = TipoObraItem.CN_fn_TiposObraInsert(tipoobratxt.Text, modo);

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
                AddTipoObraBtn.Visible = false;

                Session["resultadoProceso"] = "1";
                lMessage.Visible = true;
                lMessage.Text = "Tipo de obra registrada con éxito. ";

                /***** Ingresar acción en Bitácora ***/
                Bitacorear.Guardar(ID_USUARIO_SESSION, Convert.ToInt32(Session["idrol"]), "AddCatalogoTipoObra.aspx", "Registrar", "Tipo Obra: [ " + tipoobratxt.Text + "] ", ConectionBD);

                //Registrar en notificación el evento y obtener ID
                // Registro nueva Tipo Obra 13
                int tipoNotificacion = 13;
                Inboxfn.RegistrarNotificacion("Registrar Tipo Obra", "Nuevo registro Catálogo Tipo Obra: " + tipoobratxt.Text, tipoNotificacion, ConectionBD);
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