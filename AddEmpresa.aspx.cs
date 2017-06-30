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
    public partial class AddEmpresa : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //SecureHttps.UtilizarSSLProtocol();
            ValidarSesion();
            try
            {
                AddEmpresaBtn.Visible = true;
                EndButton.Visible = false;
                Session["resultadoProceso"] = "0";

                if (!this.IsPostBack)
                {
                    ValidarSesion();
                    CargarComboClasificacionEmpresas();
                    CargarComboTipoEmpresas();
                    CargarComboZonasVenta();
                    CargarComboEstados();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void AddEmpresaBtn_Click(object sender, EventArgs e)
        {
            lMessage.Text = "";
            int modo = 0;

            try
            {
                EmpresasBehaivor EmpresasItem = new EmpresasBehaivor();
                EmpresasItem.Connection = ConectionBD;
                List<EmpresasDatos> empresasLst = null;
                AddEmpresaBtn.Visible = true;
                EndButton.Visible = false;

                /***********************************************************************************
                 *  Verificar que la empresa que se registra no exista
                 * ********************************************************************************/
                modo = 5; // Modo para revisar registro
                empresasLst = EmpresasItem.CN_fn_VerificarEmpresaExiste(empresatxt.Text, modo);
                if (empresasLst.Count > 0 && empresasLst[0].IdEmpresa > -1)
                {   
                    lMessage.Visible = true;
                    lMessage2.Text = "Esta Empresa ya está registrada, revise la información de favor.";
                    Session["resultadoProceso"] = "2";
                    return;
                }
                else
                {
                    lMessage.Text = "Adelante";
                    lMessage.Visible = false;
                }

                /***********************************************************************************
                 *  Ingresar datos de la empresa
                 * ********************************************************************************/
                modo = 3; // Modo para ingresar empresa nueva en el SP
                string razonsocial = "";
                string  rfc = "";
                int idsectoreconomico = 0;
                empresasLst = EmpresasItem.CN_fn_EmpresaInsert(empresatxt.Text, razonsocial, rfc, Convert.ToInt32(cmbClasificacion.SelectedValue), 
                                    Convert.ToInt32(cmbTipoEmpresa.SelectedValue), Convert.ToInt32(cmbZonaVentas.SelectedValue), 
                                    domiciliotxt.Text, coloniatxt.Text, municipiotxt.Text, cptxt.Text, Convert.ToInt32(cmbEstado.SelectedValue), idsectoreconomico, modo);

                if (empresasLst.Count > 0)
                {
                    Id = empresasLst[0].IdEmpresa;
                }

                /***************************************************************************************************************
                 * Pantalla de registro
                 * ************************************************************************************************************/
                empresatxt.Enabled = false;
                cmbClasificacion.Enabled = false;
                cmbTipoEmpresa.Enabled = false;
                cmbZonaVentas.Enabled = false;
                domiciliotxt.Enabled = false;
                coloniatxt.Enabled = false;
                cptxt.Enabled = false;
                municipiotxt.Enabled = false;
                cmbEstado.Enabled = false;
                CancelButton.Visible = false;
                EndButton.Visible = true;
                AddEmpresaBtn.Visible = false;

                Session["resultadoProceso"] = "1";
                lMessage.Visible = true;
                lMessage.Text = "Empresa registrada con éxito. ";

                /***** Ingresar acción en Bitácora ***/
                Bitacorear.Guardar(ID_USUARIO_SESSION, Convert.ToInt32(Session["idrol"]), "AddEmpresa.aspx", "Registrar", "Empresa: [ " + empresatxt.Text + "] ", ConectionBD);

                //Registrar en notificación el evento y obtener ID
                // Registro nueva Empresas: 17
                int tipoNotificacion = 16;
                Inboxfn.RegistrarNotificacion("Registrar Empresa", "Nuevo registro Empresa: " + empresatxt.Text, tipoNotificacion, ConectionBD);
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

        protected void CargarComboClasificacionEmpresas()
        {
            try
            {
                CatClasificacionEmpresaBehaivor ClasEmpresaItem = new CatClasificacionEmpresaBehaivor();
                ClasEmpresaItem.Connection = ConectionBD;
                List<CatClasificacionEmpresaDatos> ClasEmpresaLst = ClasEmpresaItem.CN_fn_ClasificacionEmpresaSel(1);
                cmbClasificacion.DataTextField = "clasificacionEmpresa";
                cmbClasificacion.DataValueField = "IdClasificacionEmpresa";
                cmbClasificacion.DataSource = ClasEmpresaLst;
                cmbClasificacion.DataBind();
                cmbClasificacion.Items.Insert(0, "Seleccione una clasificación de empresa");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void CargarComboTipoEmpresas()
        {
            try
            {
                CatTipoEmpresaBehaivor tipoEmpresaItem = new CatTipoEmpresaBehaivor();
                tipoEmpresaItem.Connection = ConectionBD;
                List<CatTipoEmpresaDatos> tipoEmpresaLst = tipoEmpresaItem.CN_fn_TipoEmpresaSel(1);
                cmbTipoEmpresa.DataTextField = "tipoEmpresa";
                cmbTipoEmpresa.DataValueField = "IdTipoEmpresa";
                cmbTipoEmpresa.DataSource = tipoEmpresaLst;
                cmbTipoEmpresa.DataBind();
                cmbTipoEmpresa.Items.Insert(0, "Seleccione un tipo de empresa");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void CargarComboZonasVenta()
        {
            try
            {
                CatZonasVentasBehaivor zonaVentasItem = new CatZonasVentasBehaivor();
                zonaVentasItem.Connection = ConectionBD;
                List<CatZonasVentaDatos> zonaVentasLst = zonaVentasItem.CN_fn_ZonasVentaSel(1);
                cmbZonaVentas.DataTextField = "zonaVenta";
                cmbZonaVentas.DataValueField = "IdZonaVenta";
                cmbZonaVentas.DataSource = zonaVentasLst;
                cmbZonaVentas.DataBind();
                cmbZonaVentas.Items.Insert(0, "Seleccione una zona de ventas");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void CargarComboEstados()
        {
            try
            {
                CatEstadosPaisBehaivor estadosItem = new CatEstadosPaisBehaivor();
                estadosItem.Connection = ConectionBD;
                List<CatEstadosPaisDatos> estadosLst = estadosItem.CN_fn_EstadosPaisSel(1);
                cmbEstado.DataTextField = "estadoPais";
                cmbEstado.DataValueField = "IdEstadoPais";
                cmbEstado.DataSource = estadosLst;
                cmbEstado.DataBind();
                cmbEstado.Items.Insert(0, "Seleccione un estado del país");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void empresatxt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                EmpresasBehaivor EmpresasItem = new EmpresasBehaivor();
                EmpresasItem.Connection = ConectionBD;
                int modo = 8;
                List<EmpresasDatos> lstEmpresasValidar = EmpresasItem.CN_fn_VerificarEmpresasParecidas(empresatxt.Text, modo);
                if (lstEmpresasValidar.Count > 0)
                {
                    rptEmpresas.DataSource = lstEmpresasValidar;
                    rptEmpresas.DataBind();
                    rptEmpresas.Visible = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}