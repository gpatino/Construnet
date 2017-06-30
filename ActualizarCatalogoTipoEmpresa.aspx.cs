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
    public partial class ActualizarCatalogoTipoEmpresa : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //SecureHttps.UtilizarSSLProtocol();
            ValidarSesion();
            try
            {
                UpdateTipoEmpresaBtn.Visible = true;
                EndButton.Visible = false;
                Id = -1;
                if (!string.IsNullOrEmpty(this.Request.QueryString["Idtipemp"]))
                {
                    Id = Convert.ToInt32(this.Request.QueryString["Idtipemp"]);
                    Session["IdTipoEmpresa"] = Id;
                }
                if (!this.IsPostBack)
                {
                    CargarTipoEmpresa(Id);
                }
                Session["resultadoProceso"] = "0";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void CargarTipoEmpresa(int IdTipoEmpresa)
        {
            try
            {
                CatTipoEmpresaBehaivor TipoEmpItem = new CatTipoEmpresaBehaivor();
                TipoEmpItem.Connection = ConectionBD;
                int modo = 2;
                List<CatTipoEmpresaDatos> LstTipoEmp = TipoEmpItem.CN_fn_TipoEmpresaxIdempresaSel(IdTipoEmpresa, modo);
                if (LstTipoEmp.Count > 0)
                {
                    tipoempresatxt.Text = LstTipoEmp[0].tipoEmpresa;
                }
            }
            catch (Exception ex)
            {
                throw ex;
                //ShowMessageClient(ex.Message);
            }
        }

        protected void UpdateTipoEmpresaBtn_Click(object sender, EventArgs e)
        {
            lMessage.Text = "";
            int modo = 0;

            try
            {
                CatTipoEmpresaBehaivor TipoEmpItem = new CatTipoEmpresaBehaivor();
                TipoEmpItem.Connection = ConectionBD;
                List<CatTipoEmpresaDatos> LstTipoEmp = null;
                UpdateTipoEmpresaBtn.Visible = true;
                EndButton.Visible = false;

                /***********************************************************************************
                 *  Verificar que el tipo empresa que se registra no exista en otro o venga vacío
                 * ********************************************************************************/
                if (tipoempresatxt.Text == "")
                {
                    lMessage.Visible = true;
                    lMessage2.Text = "El tipo de empresa debe tener un valor, revise la información de favor.";
                    Session["resultadoProceso"] = "2";
                    return;
                } 
                modo = 6; // Modo para revisar registro
                LstTipoEmp = TipoEmpItem.CN_fn_TipoEmpresaValidaActualizacion(Convert.ToInt16(Session["IdTipoEmpresa"]), tipoempresatxt.Text, modo);
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
                 *  Actualizar datos del tipo empresa
                 * ********************************************************************************/
                modo = 4; // Modo para ingresar tipo empresa nuevo en el SP
                LstTipoEmp = TipoEmpItem.CN_fn_TipoEmpresaUpdate(Convert.ToInt16(Session["IdTipoEmpresa"]), tipoempresatxt.Text, Convert.ToInt16(CmbActivo.SelectedValue), modo);

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
                UpdateTipoEmpresaBtn.Visible = false;

                Session["resultadoProceso"] = "1";
                lMessage.Visible = true;
                lMessage.Text = "Tipo de empresa actualizada con éxito. ";

                /***** Ingresar acción en Bitácora ***/
                Bitacorear.Guardar(ID_USUARIO_SESSION, Convert.ToInt32(Session["idrol"]), "ActualizarCatalogoTipoEmpresa.aspx", "Actualizar", "Tipo Empresa: [ " + tipoempresatxt.Text + "] ", ConectionBD);

                //Registrar en notificación el evento y obtener ID
                // Registro nueva Tipo Empresa 11
                int tipoNotificacion = 11;
                Inboxfn.RegistrarNotificacion("Actualizar Tipo Empresa", "Actualización registro Catálogo Tipo Empresa: " + tipoempresatxt.Text, tipoNotificacion, ConectionBD);
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