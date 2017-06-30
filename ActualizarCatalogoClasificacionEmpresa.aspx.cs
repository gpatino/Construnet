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
    public partial class ActualizarCatalogoClasificacionEmpresa : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //SecureHttps.UtilizarSSLProtocol();
            ValidarSesion();
            try
            {
                UpdateClasificacionEmpresaBtn.Visible = true;
                EndButton.Visible = false;
                Id = -1;
                if (!string.IsNullOrEmpty(this.Request.QueryString["Idclasemp"]))
                {
                    Id = Convert.ToInt32(this.Request.QueryString["Idclasemp"]);
                    Session["IdClasEmp"] = Id;
                }
                if (!this.IsPostBack)
                {
                    CargarClasificacionEmpresa(Id);
                }
                Session["resultadoProceso"] = "0";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void CargarClasificacionEmpresa(int IdClasificacionEmpresa)
        {
            try
            {
                CatClasificacionEmpresaBehaivor ClasEmpItem = new CatClasificacionEmpresaBehaivor();
                ClasEmpItem.Connection = ConectionBD;
                int modo = 2;
                List<CatClasificacionEmpresaDatos> LstClasifEmp = ClasEmpItem.CN_fn_ClasificacionEmpresaxIdClasificacionSel(IdClasificacionEmpresa, modo);
                if (LstClasifEmp.Count > 0)
                {
                    clasificacionempresatxt.Text = LstClasifEmp[0].clasificacionEmpresa;
                }
            }
            catch (Exception ex)
            {
                throw ex;
                //ShowMessageClient(ex.Message);
            }
        }


        protected void UpdateClasificacionEmpresaBtn_Click(object sender, EventArgs e)
        {
            lMessage.Text = "";
            int modo = 0;

            try
            {
                CatClasificacionEmpresaBehaivor ClasEmpItem = new CatClasificacionEmpresaBehaivor();
                ClasEmpItem.Connection = ConectionBD;
                List<CatClasificacionEmpresaDatos> LstClasifEmp = null;
                UpdateClasificacionEmpresaBtn.Visible = true;
                EndButton.Visible = false;

                /******************************************************************************************************
                 *  Verificar que la clasificación empresa que se actualiza no exista en otro registro y no esté vacío
                 * ****************************************************************************************************/
                if (clasificacionempresatxt.Text == "")
                {
                    lMessage.Visible = true;
                    lMessage2.Text = "La clasificación de empresa debe tener un valor, revise la información de favor.";
                    Session["resultadoProceso"] = "2";
                    return;
                } 
                modo = 6; // Modo para revisar registro
                LstClasifEmp = ClasEmpItem.CN_fn_ClasificacionEmpresaValidaActualizacion(Convert.ToInt16(Session["IdClasEmp"]), clasificacionempresatxt.Text, modo);
                if (LstClasifEmp.Count > 0)
                {
                    lMessage.Visible = true;
                    lMessage2.Text = "Esta Clasificación de Empresa ya está registrada, revise la información de favor.";
                    Session["resultadoProceso"] = "2";
                    return;
                }
                else
                {
                    lMessage.Text = "Adelante";
                    lMessage.Visible = false;
                }

                /***********************************************************************************
                 *  Actualizar datos del clasificación empresa
                 * ********************************************************************************/
                modo = 4; // Modo para actualizar clasificación empresa en el SP
                LstClasifEmp = ClasEmpItem.CN_fn_ClasificacionEmpresaUpdate(Convert.ToInt16(Session["IdClasEmp"]), clasificacionempresatxt.Text, Convert.ToInt16(CmbActivo.SelectedValue), modo);

                if (LstClasifEmp.Count > 0)
                {
                    Id = LstClasifEmp[0].IdClasificacionEmpresa;
                }

                /***************************************************************************************************************
                 * Pantalla de registro
                 * ************************************************************************************************************/
                clasificacionempresatxt.Enabled = false;
                CancelButton.Visible = false;
                EndButton.Visible = true;
                UpdateClasificacionEmpresaBtn.Visible = false;

                Session["resultadoProceso"] = "1";
                lMessage.Visible = true;
                lMessage.Text = "Clasificación de empresa actualizada con éxito. ";

                /***** Ingresar acción en Bitácora ***/
                Bitacorear.Guardar(ID_USUARIO_SESSION, Convert.ToInt32(Session["idrol"]), "ActyalizarCatalogoClasificacionEmpresa.aspx", "Actualizar", "Clasificación Empresa: [ " + clasificacionempresatxt.Text + "] ", ConectionBD);

                //Registrar en notificación el evento y obtener ID
                // Registro nueva Tipo Empresa 12
                int tipoNotificacion = 12;
                Inboxfn.RegistrarNotificacion("Actualizar Clasificación Empresa", "Actualización registro Catálogo Clasificación Empresa: " + clasificacionempresatxt.Text, tipoNotificacion, ConectionBD);
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