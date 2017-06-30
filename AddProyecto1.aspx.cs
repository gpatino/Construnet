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
    public partial class AddProyecto1 : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //SecureHttps.UtilizarSSLProtocol();
            ValidarSesion();
            try
            {
                Session["resultadoProceso"] = "0";
                if (!this.IsPostBack)
                {
                    ValidarSesion();
                    CargarTipoObra();
                    CargarEstatusProyecto();
                    CargarSectorEconomico();
                    CargarEmpresaRaizyContratisa();
                    CargarRangoInversionProyecto();
                }
            }
            catch (Exception ex)
            {
                mensajeErrorlbl.Visible = true;
                mensajeErrorlbl.ForeColor = System.Drawing.Color.Red;
                mensajeErrorlbl.Text = "!Error / Load: " + ex.Message + "!";
            }
        }

        protected void CargarTipoObra()
        {
            try
            {
                CatTipoObraBehaivor tipoobraItem = new CatTipoObraBehaivor();
                tipoobraItem.Connection = ConectionBD;
                List<CatTipoObraDatos> tipoobraLst = tipoobraItem.CN_fn_TiposObraSel(1);

                cmbTipoObra.DataTextField = "tipoObra";
                cmbTipoObra.DataValueField = "IdTipoObra";
                cmbTipoObra.DataSource = tipoobraLst;
                cmbTipoObra.DataBind();
                cmbTipoObra.Items.Insert(0, new ListItem("Seleccione un tipo de obra","0"));
            }
            catch (Exception ex)
            {
                mensajeErrorlbl.Visible = true;
                mensajeErrorlbl.ForeColor = System.Drawing.Color.Red;
                mensajeErrorlbl.Text = "!Error / Cargar Tipo de Obra: " + ex.Message + "!";
            }
        }

        protected void CargarEtapaProyecto(int iditpoobra)
        {
            try
            {
                CatEtapasProyectoBehaivor etataProyItem = new CatEtapasProyectoBehaivor();
                etataProyItem.Connection = ConectionBD;
                List<CatEtapasProyectoDatos> etapaProyLst = etataProyItem.CN_fn_EtapasProyectoxTipoObraSel(iditpoobra, 6);

                cmbEtapaProyecto.DataTextField = "etapaProyecto";
                cmbEtapaProyecto.DataValueField = "IdEtapaProyecto";
                cmbEtapaProyecto.DataSource = etapaProyLst;
                cmbEtapaProyecto.DataBind();
                cmbEtapaProyecto.Items.Insert(0, new ListItem("Seleccione una Etapa de Proyecto", "0"));
            }
            catch (Exception ex)
            {
                mensajeErrorlbl.Visible = true;
                mensajeErrorlbl.ForeColor = System.Drawing.Color.Red;
                mensajeErrorlbl.Text = "!Error / Cargar Etapa Proyecto: " + ex.Message + "!";
            }
        }

        protected void CargarEstatusProyecto()
        {
            try
            {
                CatEstatusProyectoBehaivor estatusProyItem = new CatEstatusProyectoBehaivor();
                estatusProyItem.Connection = ConectionBD;
                List<CatEstatusProyectoDatos> estatusProyLst = estatusProyItem.CN_fn_EstatusProyectoSel(1);

                cmbEstatus.DataTextField = "estatusProyecto";
                cmbEstatus.DataValueField = "IdEstatusProyecto";
                cmbEstatus.DataSource = estatusProyLst;
                cmbEstatus.DataBind();
                cmbEstatus.Items.Insert(0, new ListItem("Seleccione un Estatus de Proyecto", "0"));
            }
            catch (Exception ex)
            {
                mensajeErrorlbl.Visible = true;
                mensajeErrorlbl.ForeColor = System.Drawing.Color.Red;
                mensajeErrorlbl.Text = "!Error / Cargar Estatus Proyecto: " + ex.Message + "!";
            }
        }

        protected void CargarSectorEconomico()
        {
            try
            {
                CatSectoresEconomicosBehaivor sectorItem = new CatSectoresEconomicosBehaivor();
                sectorItem.Connection = ConectionBD;
                List<CatSectoresEconomicosDatos> sectorLst = sectorItem.CN_fn_SectoresEconomicosSel(1);

                cmbSector.DataTextField = "sectorEconomico";
                cmbSector.DataValueField = "IdSectorEconomico";
                cmbSector.DataSource = sectorLst;
                cmbSector.DataBind();
                cmbSector.Items.Insert(0, new ListItem("Seleccione un Sector económico", "0"));
            }
            catch (Exception ex)
            {
                mensajeErrorlbl.Visible = true;
                mensajeErrorlbl.ForeColor = System.Drawing.Color.Red;
                mensajeErrorlbl.Text = "!Error / Cargar Sector: " + ex.Message + "!";
            }
        }

        protected void CargarEmpresaRaizyContratisa()
        {
            try
            {
                EmpresasBehaivor EmpresaItem = new EmpresasBehaivor();
                EmpresaItem.Connection = ConectionBD;
                List<EmpresasDatos> empresaLst = EmpresaItem.CN_fn_EmpresasSel(10);

                cmbEmpresaRaiz.DataTextField = "nombreEmpresa";
                cmbEmpresaRaiz.DataValueField = "IdEmpresa";
                cmbEmpresaRaiz.DataSource = empresaLst;
                cmbEmpresaRaiz.DataBind();
                cmbEmpresaRaiz.Items.Insert(0, new ListItem("Seleccione una empresa", "0"));

                cmbEmpresasContratista.DataTextField = "nombreEmpresa";
                cmbEmpresasContratista.DataValueField = "IdEmpresa";
                cmbEmpresasContratista.DataSource = empresaLst;
                cmbEmpresasContratista.DataBind();
                cmbEmpresasContratista.Items.Insert(0, new ListItem("Seleccione una empresa contratista", "0"));
            }
            catch (Exception ex)
            {
                mensajeErrorlbl.Visible = true;
                mensajeErrorlbl.ForeColor = System.Drawing.Color.Red;
                mensajeErrorlbl.Text = "!Error / Cargar Empresas: " + ex.Message + "!";
            }
        }

        protected void CargarRangoInversionProyecto()
        {
            try
            {
                InversionesBehaivor inversionItem = new InversionesBehaivor();
                inversionItem.Connection = ConectionBD;
                List<InversionesDatos> tipoobraLst = inversionItem.CN_fn_InversionesProyectoSel(1);

                CmbInversion.DataTextField = "rango_inversion";
                CmbInversion.DataValueField = "IdInversionproyecto";
                CmbInversion.DataSource = tipoobraLst;
                CmbInversion.DataBind();
                CmbInversion.Items.Insert(0, new ListItem("Seleccione un rango de inversión estimada", "0"));
            }
            catch (Exception ex)
            {
                mensajeErrorlbl.Visible = true;
                mensajeErrorlbl.ForeColor = System.Drawing.Color.Red;
                mensajeErrorlbl.Text = "!Error / Cargar Rango Inversión: " + ex.Message + "!";
            }
        }

        protected void cmbTipoObra_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarEtapaProyecto(Convert.ToInt32(cmbTipoObra.SelectedValue));
        }


        protected void AddProyectBtn_Click(object sender, EventArgs e)
        {
            int idproyecto = 0;
            lMessage.Text = "";
            int modo = 0;
            int activo = 0;
            int ventas = 0;
            string comentario = "";
            int idempresacontratista = 0;
            string descripcion, convenio, claveconvenio;
            descripcion = "";
            convenio = "";
            claveconvenio = "";

            /*********************************************************************************************************************************
             * Verificar que campos obligatorios estén ingresados
             * *******************************************************************************************************************************/
            if (nombreproyectotxt.Text == "" || fecharegistrotxt.Text == "" || Convert.ToString(cmbTipoObra.SelectedItem) == "" 
                || Convert.ToString(cmbEtapaProyecto.SelectedItem) == "" || Convert.ToString(cmbEstatus.SelectedItem) == "" 
                || Convert.ToString(cmbSector.SelectedItem) == "" || Convert.ToString(cmbEmpresaRaiz.SelectedItem) == "")
            {
                lMessage.Visible = true;
                lMessage2.Text = "Debe ingresar el nombre del proyecto, fecha registro, tipo de obra, Etapa de Proyecto, Estatus, Sector y Empresa Raíz.";
                Session["resultadoProceso"] = "2";
                return;
            }

            /*********************************************************************************************************************************
             * Campos opcionales inicializarlos para no generar error de input 
             * *******************************************************************************************************************************/
            if (Convert.ToString(cmbEmpresasContratista.SelectedItem) != "")
                idempresacontratista = Convert.ToInt32(cmbEmpresasContratista.SelectedValue);
            if (descripciontxt.Text != "")
                descripcion = descripciontxt.Text;

            try
            {
                ProyectosBehaivor NewProyectItem = new ProyectosBehaivor();
                NewProyectItem.Connection = ConectionBD;
                List<ProyectosDatos> ProyLst = null;

                /***********************************************************************************
                 *  Verificar que el nombre del proyecto que se registra no exista
                 * ********************************************************************************/
                modo = 7; // Modo para revisar proyecto existente
                ProyLst = NewProyectItem.CN_fn_ProyectoValidarNuevo(nombreproyectotxt.Text, modo);
                if (ProyLst.Count > 0 && ProyLst[0].IdProyecto > -1)
                {
                    lMessage.Visible = true;
                    lMessage2.Text = "Este nombre de Proyecto ya está registrado, ingrese con otro nombre.";
                    Session["resultadoProceso"] = "2";
                    return;
                }
                else
                {
                    lMessage.Text = "Adelante";
                    lMessage.Visible = false;
                }

                /***********************************************************************************
                 *  Ingresar datos del proyecto
                 * ********************************************************************************/
                modo = 1; // Modo para registrar nuevpo proyecto 
                ProyLst = NewProyectItem.CN_fn_ProyectoInsert(nombreproyectotxt.Text,
                                                                Convert.ToInt32(cmbEmpresaRaiz.SelectedValue),
                                                                idempresacontratista,
                                                                Convert.ToInt32(cmbTipoObra.SelectedValue),
                                                                Convert.ToInt32(cmbEtapaProyecto.SelectedValue),
                                                                Convert.ToInt32(cmbEstatus.SelectedValue),
                                                                Convert.ToInt32(cmbSector.SelectedValue),
                                                                convenio,
                                                                claveconvenio,
                                                                Convert.ToInt32(ID_USUARIO_SESSION),
                                                                Convert.ToInt32(CmbInversion.SelectedValue),
                                                                descripcion,
                                                                activo,
                                                                comentario,
                                                                ventas,
                                                                Convert.ToInt32(CmbInversion.SelectedValue),
                                                                modo);
                if (ProyLst.Count > 0)
                {
                    idproyecto = ProyLst[0].IdProyecto;
                }

                /***************************************************************************************************************
                 * Pantalla de Usuario Registrado
                 * ************************************************************************************************************/
                nombreproyectotxt.Enabled = false;
                cmbEmpresaRaiz.Enabled = false;
                cmbEmpresasContratista.Enabled = false;
                cmbTipoObra.Enabled = false;
                cmbEtapaProyecto.Enabled = false;
                cmbEstatus.Enabled = false;
                cmbSector.Enabled = false;
                CmbInversion.Enabled = false;
                descripciontxt.Enabled = false;
                AddProyectBtn.Enabled = false;

                Session["resultadoProceso"] = "1";
                lMessage.Visible = true;
                lMessage.Text = "Proyecto registrado con éxito.";

                /***** Ingresar acción en Bitácora ***/
                Bitacorear.Guardar(ID_USUARIO_SESSION, Convert.ToInt32(Session["idrol"]), "AddProyecto1.aspx", "Registrar", "Proyecto: [ " + idproyecto + " - " +nombreproyectotxt.Text + "] ", ConectionBD);

                //Registrar en notificación el evento y obtener ID
                // Registro nuevo proyecto: 
                int tipoNotificacion = 19;
                Inboxfn.RegistrarNotificacion("Registro Nuevo Proyecto", "Nuevo Proyecto: ID:" + idproyecto + " Proyecto: " + nombreproyectotxt.Text, tipoNotificacion, ConectionBD);
                // Obtener último ID Notificación registrado
                int IDLastNotification = 0;
                IDLastNotification = Inboxfn.ObtenerIDNotificacion(ConectionBD);
                //Envio a inbox x Usuario
                Inboxfn.RegistrarNotificacionxUsuario(ID_USUARIO_SESSION, IDLastNotification, 1, ConectionBD);
                Response.Redirect("AddProyecto2.aspx?idproy=" + idproyecto);

            }
            catch (Exception ex)
            {
                mensajeErrorlbl.Visible = true;
                mensajeErrorlbl.ForeColor = System.Drawing.Color.Red;
                mensajeErrorlbl.Text = "!Error / Agregar registro: " + ex.Message + "!";
            }

        }
    }
}