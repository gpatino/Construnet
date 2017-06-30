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
    public partial class AddCatalogoTipoEmpresa : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //SecureHttps.UtilizarSSLProtocol();
            ValidarSesion();
            try
            {
                AddTipoEmpresaBtn.Visible = true;
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

        protected void AddTipoEmpresaBtn_Click(object sender, EventArgs e)
        {
            lMessage.Text = "";
            int modo = 0;

            try
            {
                CatTipoEmpresaBehaivor TipoEmpItem = new CatTipoEmpresaBehaivor();
                TipoEmpItem.Connection = ConectionBD;
                List<CatTipoEmpresaDatos> LstTipoEmp = null;
                AddTipoEmpresaBtn.Visible = true;
                EndButton.Visible = false;

                /***********************************************************************************
                 *  Verificar que el tipo empresa que se registra no exista
                 * ********************************************************************************/
                modo = 5; // Modo para revisar registro
                LstTipoEmp = TipoEmpItem.CN_fn_TipoEmpresaValidaExista(tipoempresatxt.Text, modo);
                if (LstTipoEmp.Count > 0 && LstTipoEmp[0].IdTipoEmpresa > -1)
                {
                    lMessage.Visible = true;
                    lMessage2.Text = "Este Tipo de Empresa ya está registrado, revise la información de favor.";
                    Session["resultadoProceso"] = "2";
                    return;
                }
                else
                {
                    lMessage.Text = "Adelante";
                    lMessage.Visible = false;
                }

                /***********************************************************************************
                 *  Ingresar datos del tipo empresa
                 * ********************************************************************************/
                modo = 3; // Modo para ingresar tipo empresa nuevo en el SP
                LstTipoEmp = TipoEmpItem.CN_fn_TipoEmpresaInsert(tipoempresatxt.Text, modo);

                if (LstTipoEmp.Count > 0)
                {
                    Id = LstTipoEmp[0].IdTipoEmpresa;
                }

                /***************************************************************************************************************
                 * Pantalla de registro
                 * ************************************************************************************************************/
                tipoempresatxt.Enabled = false;
                CancelButton.Visible = false;
                EndButton.Visible = true;
                AddTipoEmpresaBtn.Visible = false;

                Session["resultadoProceso"] = "1";
                lMessage.Visible = true;
                lMessage.Text = "Tipo de empresa registrada con éxito. ";

                /***** Ingresar acción en Bitácora ***/
                Bitacorear.Guardar(ID_USUARIO_SESSION, Convert.ToInt32(Session["idrol"]), "AddCatalogoTipoEmpresa.aspx", "Registrar", "Tipo Empresa: [ " + tipoempresatxt.Text + "] ", ConectionBD);

                //Registrar en notificación el evento y obtener ID
                // Registro nueva Tipo Empresa 11
                int tipoNotificacion = 11;
                Inboxfn.RegistrarNotificacion("Registrar Tipo Empresa", "Nuevo registro Catálogo Tipo Empresa: " + tipoempresatxt.Text, tipoNotificacion, ConectionBD);
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