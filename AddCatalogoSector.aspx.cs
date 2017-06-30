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
    public partial class AddCatalogoSector : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //SecureHttps.UtilizarSSLProtocol();
            ValidarSesion();
            try
            {
                AddSectorBtn.Visible = true;
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

        protected void AddSectorBtn_Click(object sender, EventArgs e)
        {
            lMessage.Text = "";
            int modo = 0;

            try
            {
                CatSectoresEconomicosBehaivor SectorItem = new CatSectoresEconomicosBehaivor();
                SectorItem.Connection = ConectionBD;
                List<CatSectoresEconomicosDatos> LstSector = null;
                AddSectorBtn.Visible = true;
                EndButton.Visible = false;

                /***********************************************************************************
                 *  Verificar que el sector que se registra no exista
                 * ********************************************************************************/
                modo = 5; // Modo para revisar sector
                LstSector = SectorItem.CN_fn_SectorValidaExista(sectortxt.Text, modo);
                if (LstSector.Count > 0 && LstSector[0].IdSectorEconomico > -1)
                {
                    lMessage.Visible = true;
                    lMessage2.Text = "Este Sector Económico ya está registrado, revise la información de favor.";
                    Session["resultadoProceso"] = "2";
                    return;
                }
                else
                {
                    lMessage.Text = "Adelante";
                    lMessage.Visible = false;
                }

                /***********************************************************************************
                 *  Ingresar datos del Sector Económico 
                 * ********************************************************************************/
                modo = 3; // Modo para ingresar sector nuevo en el SP
                LstSector = SectorItem.CN_fn_SectoresEconomicosInsert(sectortxt.Text, modo);

                if (LstSector.Count > 0)
                {
                    Id = LstSector[0].IdSectorEconomico;
                }

                /***************************************************************************************************************
                 * Pantalla de Usuario Registrado
                 * ************************************************************************************************************/
                sectortxt.Enabled = false;
                CancelButton.Visible = false;
                EndButton.Visible = true;
                AddSectorBtn.Visible = false;

                Session["resultadoProceso"] = "1";
                lMessage.Visible = true;
                lMessage.Text = "Sector económico registrado con éxito. ";

                /***** Ingresar acción en Bitácora ***/
                Bitacorear.Guardar(ID_USUARIO_SESSION, Convert.ToInt32(Session["idrol"]), "AddCatalogoSector.aspx", "Registrar", "Sector económico: [ " + sectortxt.Text + "] ", ConectionBD);

                //Registrar en notificación el evento y obtener ID
                // Registro nueva Zona Ventas 10
                int tipoNotificacion = 10;
                Inboxfn.RegistrarNotificacion("Registrar Sector Económico", "Nuevo registro Catálogo Sector Económico: " + sectortxt.Text, tipoNotificacion, ConectionBD);
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