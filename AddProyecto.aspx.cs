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
    public partial class AddProyecto : BasePage
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
                    Session["active_tab1"] = "active";
                    Session["active_tab2"] = " ";
                    Session["active_tab3"] = " ";
                    Session["active_tab4"] = " ";
                    Session["active_tab5"] = " ";

                    Session["active_panel1"] = "step-pane active";
                    Session["active_panel2"] = "step-pane";
                    Session["active_panel3"] = "step-pane";
                    Session["active_panel4"] = "step-pane";
                    Session["active_panel5"] = "step-pane";
                    
                    ValidarSesion();
                    CargarEmpresaRaizyContratisa();
                    CargarTipoObra();
                    CargarEstatusProyecto();
                    CargarSectorEconomico();
                    CargarEstadosPais();
                    CargarZonaVentas();
                    CargarDirector();
                    CargarGerentes();
                    CargarGerentesTecnicos();
                    CargarClientesHenkel();
                    CargarEjecutivosTecnicos();
                    CargarProspecto();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void CargarEmpresaRaizyContratisa()
        {
            try
            {
                EmpresasBehaivor EmpresaItem = new EmpresasBehaivor();
                EmpresaItem.Connection = ConectionBD;
                List<EmpresasDatos> empresaLst = EmpresaItem.CN_fn_EmpresasSel(1);
                
                cmbEmpresaRaiz.DataTextField = "nombreEmpresa";
                cmbEmpresaRaiz.DataValueField = "IdEmpresa";
                cmbEmpresaRaiz.DataSource = empresaLst;
                cmbEmpresaRaiz.DataBind();
                cmbEmpresaRaiz.Items.Insert(0, "Seleccione una empresa raíz");

                cmbEmpresasContratista.DataTextField = "nombreEmpresa";
                cmbEmpresasContratista.DataValueField = "IdEmpresa";
                cmbEmpresasContratista.DataSource = empresaLst;
                cmbEmpresasContratista.DataBind();
                cmbEmpresasContratista.Items.Insert(0, "Seleccione una empresa contratista");

            }
            catch (Exception ex)
            {
                throw ex;
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
                cmbTipoObra.Items.Insert(0, new ListItem("0", "Seleccione un tipo de obra"));
            }
            catch (Exception ex)
            {
                throw ex;
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
                cmbEtapaProyecto.Items.Insert(0, "Seleccione una Etapa Proyecto");
            }
            catch (Exception ex)
            {
                throw ex;
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
                cmbEstatus.Items.Insert(0, "Seleccione un estatus de Proyecto");
            }
            catch (Exception ex)
            {
                throw ex;
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
                cmbSector.Items.Insert(0, "Seleccione un sector económico");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void CargarEstadosPais()
        {
            try
            {
                CatEstadosPaisBehaivor estadospaisItem = new CatEstadosPaisBehaivor();
                estadospaisItem.Connection = ConectionBD;
                List<CatEstadosPaisDatos> sectorLst = estadospaisItem.CN_fn_EstadosPaisSel(1);

                cmbEstadoPais.DataTextField = "estadoPais";
                cmbEstadoPais.DataValueField = "IdEstadoPais";
                cmbEstadoPais.DataSource = sectorLst;
                cmbEstadoPais.DataBind();
                cmbEstadoPais.Items.Insert(0, "Seleccione un estado");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void CargarMunicipiosPais(int idestadopais)
        {
            try
            {
                CatEstadosPaisBehaivor municipiosItem = new CatEstadosPaisBehaivor();
                municipiosItem.Connection = ConectionBD;
                List<CatEstadosPaisDatos> municipiosLst = municipiosItem.CN_fn_MunicipiosxIdEstadoPais(idestadopais, 3);

                cmbMunicipio.DataTextField = "municipio";
                cmbMunicipio.DataValueField = "IdMunicipio";
                cmbMunicipio.DataSource = municipiosLst;
                cmbMunicipio.DataBind();
                cmbMunicipio.Items.Insert(0, "Seleccione un Municipio");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void CargarZonaVentas()
        {
            try
            {
                CatZonasVentasBehaivor zonaItem = new CatZonasVentasBehaivor();
                zonaItem.Connection = ConectionBD;
                List<CatZonasVentaDatos> zonaLst = zonaItem.CN_fn_ZonasVentaSel(1);

                cmbZonaVenta.DataTextField = "zonaVenta";
                cmbZonaVenta.DataValueField = "IdZonaVenta";
                cmbZonaVenta.DataSource = zonaLst;
                cmbZonaVenta.DataBind();
                cmbZonaVenta.Items.Insert(0, "Seleccione una zona de ventas");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void CargarDirector()
        {
            try
            {
                int idperfil = 2;
                int modo = 1;
                UsuariosPerfilBehaivor directorItem = new UsuariosPerfilBehaivor();
                directorItem.Connection = ConectionBD;
                List<UsuariosPerfilDatos> directoLst = directorItem.CN_fn_ListUsuarioxPerfil(idperfil, modo);

                cmbDirector.DataTextField = "NombreCompleto";
                cmbDirector.DataValueField = "UserId";
                cmbDirector.DataSource = directoLst;
                cmbDirector.DataBind();
                cmbDirector.Items.Insert(0, "Seleccione un director");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        protected void CargarGerentes()
        {
            try
            {
                int idperfil = 3;
                int modo = 1;
                UsuariosPerfilBehaivor gerentesItem = new UsuariosPerfilBehaivor();
                gerentesItem.Connection = ConectionBD;
                List<UsuariosPerfilDatos> gerentesLst = gerentesItem.CN_fn_ListUsuarioxPerfil(idperfil, modo);

                cmbGerente.DataTextField = "NombreCompleto";
                cmbGerente.DataValueField = "UserId";
                cmbGerente.DataSource = gerentesLst;
                cmbGerente.DataBind();
                cmbGerente.Items.Insert(0, "Seleccione un gerente");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void CargarGerentesTecnicos()
        {
            try
            {
                int idperfil = 5;
                int modo = 1;
                UsuariosPerfilBehaivor gerentesItem = new UsuariosPerfilBehaivor();
                gerentesItem.Connection = ConectionBD;
                List<UsuariosPerfilDatos> gerentesLst = gerentesItem.CN_fn_ListUsuarioxPerfil(idperfil, modo);

                cmbGerenteTecnico.DataTextField = "NombreCompleto";
                cmbGerenteTecnico.DataValueField = "UserId";
                cmbGerenteTecnico.DataSource = gerentesLst;
                cmbGerenteTecnico.DataBind();
                cmbGerenteTecnico.Items.Insert(0, "Seleccione un gerente técnico");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void CargarEjecutivosTecnicos()
        {
            try
            {
                int idperfil = 5;
                int modo = 1;
                UsuariosPerfilBehaivor ejecutivosTecItem = new UsuariosPerfilBehaivor();
                ejecutivosTecItem.Connection = ConectionBD;
                List<UsuariosPerfilDatos> ejeTecLst = ejecutivosTecItem.CN_fn_ListUsuarioxPerfil(idperfil, modo);

                cmbEjecutivoTecnico.DataTextField = "NombreCompleto";
                cmbEjecutivoTecnico.DataValueField = "UserId";
                cmbEjecutivoTecnico.DataSource = ejeTecLst;
                cmbEjecutivoTecnico.DataBind();
                cmbEjecutivoTecnico.Items.Insert(0, "Seleccione un ejecutivo técnico");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void CargarClientesHenkel()
        {
            try
            {
                ClientesBehaivor clientehItem = new ClientesBehaivor();
                clientehItem.Connection = ConectionBD;
                List<ClientesDatos> clientesLst = clientehItem.CN_fn_ClientesDatos(1);

                cmbCliente.DataTextField = "cliente";
                cmbCliente.DataValueField = "idhcliente";
                cmbCliente.DataSource = clientesLst;
                cmbCliente.DataBind();
                cmbCliente.Items.Insert(0, "Seleccione un cliente");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void CargarEjecutivos(int idgerente)
        {
            try
            {
                int modo = 4;
                UsuariosPerfilBehaivor ejecutivosItem = new UsuariosPerfilBehaivor();
                ejecutivosItem.Connection = ConectionBD;
                List<UsuariosPerfilDatos> ejeLst = ejecutivosItem.CN_fn_ListEjecutivosxIdGerente(idgerente, modo);

                cmbEjecutivo.DataTextField = "NombreCompletoEjecutivo";
                cmbEjecutivo.DataValueField = "UserId";
                cmbEjecutivo.DataSource = ejeLst;
                cmbEjecutivo.DataBind();
                cmbEjecutivo.Items.Insert(0, "Seleccione un ejecutivo");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void CargarProspecto()
        {
            try
            {
                CatProspectoBehaivor prospectoItem = new CatProspectoBehaivor();
                prospectoItem.Connection = ConectionBD;
                List<CatProspectoDatos> prospectoLst = prospectoItem.CN_fn_ProspectoSel(1);

                cmbProspecto.DataTextField = "prospecto";
                cmbProspecto.DataValueField = "IdProspecto";
                cmbProspecto.DataSource = prospectoLst;
                cmbProspecto.DataBind();
                cmbProspecto.Items.Insert(0, "Seleccione Prospectó");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        protected void cmbTipoObra_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["active_tab1"] = "active";
            Session["active_tab2"] = " ";
            Session["active_tab3"] = " ";
            Session["active_tab4"] = " ";
            Session["active_tab5"] = " ";
            Session["active_panel1"] = "step-pane active";
            Session["active_panel2"] = "step-pane";
            Session["active_panel3"] = "step-pane";
            Session["active_panel4"] = "step-pane";
            Session["active_panel5"] = "step-pane";

            CargarEtapaProyecto(Convert.ToInt32(cmbTipoObra.SelectedValue));
        }

        protected void cmbEstadoPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["active_tab1"] = " ";
            Session["active_tab2"] = "active";
            Session["active_tab3"] = " ";
            Session["active_tab4"] = " ";
            Session["active_tab5"] = " ";
            Session["active_panel1"] = "step-pane";
            Session["active_panel2"] = "step-pane active";
            Session["active_panel3"] = "step-pane";
            Session["active_panel4"] = "step-pane";
            Session["active_panel5"] = "step-pane";
            CargarMunicipiosPais(Convert.ToInt32(cmbEstadoPais.SelectedValue));
        }

        protected void cmbGerente_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["active_tab1"] = " ";
            Session["active_tab2"] = " ";
            Session["active_tab3"] = " ";
            Session["active_tab4"] = "active";
            Session["active_tab5"] = " ";
            Session["active_panel1"] = "step-pane";
            Session["active_panel2"] = "step-pane";
            Session["active_panel3"] = "step-pane";
            Session["active_panel4"] = "step-pane active";
            Session["active_panel5"] = "step-pane";
            CargarEjecutivos(Convert.ToInt32(cmbGerente.SelectedValue));
        }

        protected void AddProyectBtn_Click(object sender, EventArgs e)
        {

        }
    }
}