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
    public partial class ActualizarCatalogoSector : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //SecureHttps.UtilizarSSLProtocol();
            ValidarSesion();
            try
            {
                UpdateSectorBtn.Visible = true;
                EndButton.Visible = false;
                Id = -1;
                if (!string.IsNullOrEmpty(this.Request.QueryString["Idsect"]))
                {
                    Id = Convert.ToInt32(this.Request.QueryString["Idsect"]);
                    Session["Idsector"] = Id;
                }
                if (!this.IsPostBack)
                {
                    CargarSector(Id);
                }
                Session["resultadoProceso"] = "0";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void CargarSector(int idsector)
        {
            try
            {
                CatSectoresEconomicosBehaivor SectorItem = new CatSectoresEconomicosBehaivor();
                SectorItem.Connection = ConectionBD;
                int modo = 2;
                List<CatSectoresEconomicosDatos> LstSector = SectorItem.BI_fn_SectorEconomicoxIdSector(idsector, modo);
                if (LstSector.Count > 0)
                {
                    sectortxt.Text = LstSector[0].sectorEconomico;
                }
            }
            catch (Exception ex)
            {
                throw ex;
                //ShowMessageClient(ex.Message);
            }
        }

        protected void UpdateSectorBtn_Click(object sender, EventArgs e)
        {
            lMessage.Text = "";
            int modo = 0;

            try
            {
                CatSectoresEconomicosBehaivor SectorItem = new CatSectoresEconomicosBehaivor();
                SectorItem.Connection = ConectionBD;
                List<CatSectoresEconomicosDatos> LstSector = null;
                UpdateSectorBtn.Visible = true;
                EndButton.Visible = false;

                /***********************************************************************************
                 *  Verificar que el sector que se registra no exista y no esté vacío
                 * ********************************************************************************/
                if (sectortxt.Text == "")
                {
                    lMessage.Visible = true;
                    lMessage2.Text = "Debe ingresar un valor en sector, revise la información de favor.";
                    Session["resultadoProceso"] = "2";
                }
                modo = 6; // Modo para revisar sector
                LstSector = SectorItem.CN_fn_SectorValidaActualizacion(Convert.ToInt16(Session["Idsector"]), sectortxt.Text, modo);
                if (LstSector.Count > 0)
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
                 *  Actualizar datos del Sector Económico 
                 * ********************************************************************************/
                int estatusSector = 0;
                if (CmbActivo.SelectedValue == "1")
                    estatusSector = 1;
                else if (CmbActivo.SelectedValue == "0")
                    estatusSector = 0;


                modo = 4; // Modo para actualizar sector nuevo en el SP
                LstSector = SectorItem.CN_fn_SectoresEconomicosUpdate(Convert.ToInt16(Session["Idsector"]), sectortxt.Text, estatusSector, ID_USUARIO_SESSION, modo);

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
                UpdateSectorBtn.Visible = false;

                Session["resultadoProceso"] = "1";
                lMessage.Visible = true;
                lMessage.Text = "Sector económico actualizado con éxito. ";

                /***** Ingresar acción en Bitácora ***/
                Bitacorear.Guardar(ID_USUARIO_SESSION, Convert.ToInt32(Session["idrol"]), "ActualizarCatalogoSector.aspx", "Actualizar", "Sector económico: [ " + sectortxt.Text + "] ", ConectionBD);

                //Registrar en notificación el evento y obtener ID
                // Registro nueva Zona Ventas 10
                int tipoNotificacion = 10;
                Inboxfn.RegistrarNotificacion("Actualizar Sector Económico", "Actualizar registro Catálogo Sector Económico: " + sectortxt.Text, tipoNotificacion, ConectionBD);
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