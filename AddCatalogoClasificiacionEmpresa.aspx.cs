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
    public partial class AddCatalogoClasificiacionEmpresa : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //SecureHttps.UtilizarSSLProtocol();
            ValidarSesion();
            try
            {
                AddClasificacionEmpresaBtn.Visible = true;
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

        protected void AddClasificacionEmpresaBtn_Click(object sender, EventArgs e)
        {
            lMessage.Text = "";
            int modo = 0;

            try
            {
                CatClasificacionEmpresaBehaivor ClasEmpItem = new CatClasificacionEmpresaBehaivor();
                ClasEmpItem.Connection = ConectionBD;
                List<CatClasificacionEmpresaDatos> LstClasifEmp = null;
                AddClasificacionEmpresaBtn.Visible = true;
                EndButton.Visible = false;

                /***********************************************************************************
                 *  Verificar que la clasificación empresa que se registra no exista
                 * ********************************************************************************/
                modo = 5; // Modo para revisar registro
                LstClasifEmp = ClasEmpItem.CN_fn_ClasificacionEmpresaValidaExista(clasificacionempresatxt.Text, modo);
                if (LstClasifEmp.Count > 0 && LstClasifEmp[0].IdClasificacionEmpresa > -1)
                {
                    lMessage.Visible = true;
                    lMessage2.Text = "Esta Clasificación de Empresa ya está registrado, revise la información de favor.";
                    Session["resultadoProceso"] = "2";
                    return;
                }
                else
                {
                    lMessage.Text = "Adelante";
                    lMessage.Visible = false;
                }

                /***********************************************************************************
                 *  Ingresar datos del clasificación empresa
                 * ********************************************************************************/
                modo = 3; // Modo para ingresar clasificación empresa nuevo en el SP
                LstClasifEmp = ClasEmpItem.CN_fn_ClasificacionEmpresaInsert(clasificacionempresatxt.Text, modo);

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
                AddClasificacionEmpresaBtn.Visible = false;

                Session["resultadoProceso"] = "1";
                lMessage.Visible = true;
                lMessage.Text = "Clasificación de empresa registrada con éxito. ";

                /***** Ingresar acción en Bitácora ***/
                Bitacorear.Guardar(ID_USUARIO_SESSION, Convert.ToInt32(Session["idrol"]), "AddCatalogoClasificacionEmpresa.aspx", "Registrar", "Clasificación Empresa: [ " + clasificacionempresatxt.Text + "] ", ConectionBD);

                //Registrar en notificación el evento y obtener ID
                // Registro nueva Tipo Empresa 12
                int tipoNotificacion = 12;
                Inboxfn.RegistrarNotificacion("Registrar Clasificación Empresa", "Nuevo registro Catálogo Clasificación Empresa: " + clasificacionempresatxt.Text, tipoNotificacion, ConectionBD);
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