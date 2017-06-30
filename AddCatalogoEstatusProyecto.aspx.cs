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
    public partial class AddCatalogoEstatusProyecto : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //SecureHttps.UtilizarSSLProtocol();
            ValidarSesion();
            try
            {
                AddEstatusProyectoBtn.Visible = true;
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

        protected void AddEstatusProyectoBtn_Click(object sender, EventArgs e)
        {
            lMessage.Text = "";
            int modo = 0;

            try
            {
                CatEstatusProyectoBehaivor EstatusProyItem = new CatEstatusProyectoBehaivor();
                EstatusProyItem.Connection = ConectionBD;
                List<CatEstatusProyectoDatos> LstEstatusProy = null;
                AddEstatusProyectoBtn.Visible = true;
                EndButton.Visible = false;

                /***********************************************************************************
                 *  Verificar que el estatus proyecto que se registra no exista
                 * ********************************************************************************/
                modo = 5; // Modo para revisar registro
                LstEstatusProy = EstatusProyItem.CN_fn_EstatusProyectoValidaExista(estatusproyectotxt.Text, modo);
                if (LstEstatusProy.Count > 0 && LstEstatusProy[0].IdEstatusProyecto > -1)
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
                 *  Ingresar datos del estatus proyecto
                 * ********************************************************************************/
                modo = 3; // Modo para ingresar estatus proyecto nuevo en el SP
                LstEstatusProy = EstatusProyItem.CN_fn_EstatusProyectoInsert(estatusproyectotxt.Text, modo);

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
                AddEstatusProyectoBtn.Visible = false;

                Session["resultadoProceso"] = "1";
                lMessage.Visible = true;
                lMessage.Text = "Estatus Proyecto registrado con éxito. ";

                /***** Ingresar acción en Bitácora ***/
                Bitacorear.Guardar(ID_USUARIO_SESSION, Convert.ToInt32(Session["idrol"]), "AddCatalogoEstatusProyecto.aspx", "Registrar", "Estatus Proyecto: [ " + estatusproyectotxt.Text + "] ", ConectionBD);

                //Registrar en notificación el evento y obtener ID
                // Registro nueva Estatus Proyecto: 14
                int tipoNotificacion = 14;
                Inboxfn.RegistrarNotificacion("Registrar Estatus Proyecto", "Nuevo registro Catálogo Estatus Proyecto: " + estatusproyectotxt.Text, tipoNotificacion, ConectionBD);
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