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
    public partial class AddProyecto2 : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //SecureHttps.UtilizarSSLProtocol();
            ValidarSesion();
            try
            {
                Session["resultadoProceso"] = "0";
                if (!string.IsNullOrEmpty(this.Request.QueryString["idproy"]))
                {
                    Id = Convert.ToInt32(this.Request.QueryString["idproy"]);
                    Session["idproyectomapa"] = Id;
                }
                else
                {
                }
                if (!this.IsPostBack)
                {
                    CargarEstadosPais();
                    CargarZonaVentas();
                }
            }
            catch (Exception ex)
            {
                mensajeErrorlbl.Visible = true;
                mensajeErrorlbl.ForeColor = System.Drawing.Color.Red;
                mensajeErrorlbl.Text = "!Error / Load: " + ex.Message + "!";
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
                cmbEstadoPais.Items.Insert(0, new ListItem("Seleccione un estado", "0"));
            }
            catch (Exception ex)
            {
                mensajeErrorlbl.Visible = true;
                mensajeErrorlbl.ForeColor = System.Drawing.Color.Red;
                mensajeErrorlbl.Text = "!Error / Cargar Estados: " + ex.Message + "!";
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
                cmbMunicipio.DataValueField = "municipio";
                cmbMunicipio.DataSource = municipiosLst;
                cmbMunicipio.DataBind();
                cmbMunicipio.Items.Insert(0, "Seleccione un Municipio");
            }
            catch (Exception ex)
            {
                mensajeErrorlbl.Visible = true;
                mensajeErrorlbl.ForeColor = System.Drawing.Color.Red;
                mensajeErrorlbl.Text = "!Error / Cargar Municipios: " + ex.Message + "!";
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
                cmbZonaVenta.Items.Insert(0, new ListItem("Seleccione una zona de ventas", "0"));
            }
            catch (Exception ex)
            {
                mensajeErrorlbl.Visible = true;
                mensajeErrorlbl.ForeColor = System.Drawing.Color.Red;
                mensajeErrorlbl.Text = "!Error / Cargar Zonas Venta: " + ex.Message + "!";
            }
        }


        protected void cmbEstadoPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarMunicipiosPais(Convert.ToInt32(cmbEstadoPais.SelectedValue));
        }

        protected void AddProyectBtn_Click(object sender, EventArgs e)
        {
            lMessage.Text = "";
            int modo = 0;
            string colonia, cp;
            colonia = "";
            cp = "";


            /*********************************************************************************************************************************
             * Verificar que campos obligatorios estén ingresados
             * *******************************************************************************************************************************/
            if (domiciliotxt.Text == "" || Convert.ToString(cmbZonaVenta.SelectedItem) == "0"
                || Convert.ToString(cmbEstadoPais.SelectedItem) == "0" || Convert.ToString(cmbMunicipio.SelectedItem) == "0")
            {
                lMessage.Visible = true;
                lMessage2.Text = "Debe seleccionar Estado, Municipio y Zona Ventas, e ingresar domicilio.";
                Session["resultadoProceso"] = "2";
                return;
            }


            /*********************************************************************************************************************************
             * Verificar que haya registrado un ubicación en GPS
             * *******************************************************************************************************************************/
            MapasBehaivor MapaItem = new MapasBehaivor();
            MapaItem.Connection = ConectionBD;
            modo = 1;
            List<MapasDatos> MapaLst = MapaItem.CN_fn_MapasxProyectoSel(Id, modo);
            if (MapaLst.Count > 0)
            {

            }
            else
            {
                lMessage.Visible = true;
                lMessage2.Text = "Debe seleccionar y guardar coordenadas de ubicación en el mapa de GPS Maps.";
                Session["resultadoProceso"] = "2";
                return;
            }

            /*********************************************************************************************************************************
             * Campos opcionales inicializarlos para no generar error de input 
             * *******************************************************************************************************************************/
            if (coloniatxt.Text != "")
                colonia = coloniatxt.Text;
            if (cptxt.Text != "")
                cp = cptxt.Text;

            try
            {
                ProyectosBehaivor NewProyectItem = new ProyectosBehaivor();
                NewProyectItem.Connection = ConectionBD;
                List<ProyectosDatos> ProyLst = null;

                /***********************************************************************************
                 *  Continuar ingreso de datos del proyecto
                 * ********************************************************************************/
                modo = 2; // Modo para registrar nuevpo proyecto 
                ProyLst = NewProyectItem.CN_fn_ProyectoUbicacionInsertUpdate(Id,
                                                                domiciliotxt.Text,
                                                                colonia,
                                                                Convert.ToString(cmbMunicipio.SelectedValue),
                                                                cp, 
                                                                Convert.ToInt32(cmbEstadoPais.SelectedValue),
                                                                Convert.ToInt32(cmbZonaVenta.SelectedValue),
                                                                modo);

                /***************************************************************************************************************
                 * Pantalla de Usuario Registrado
                 * ************************************************************************************************************/
                domiciliotxt.Enabled = false;
                coloniatxt.Enabled = false;
                cmbMunicipio.Enabled = false;
                cptxt.Enabled = false;
                cmbEstadoPais.Enabled = false;
                cmbZonaVenta.Enabled = false;
                AddProyectBtn.Enabled = false;

                Session["resultadoProceso"] = "1";
                lMessage.Visible = true;
                lMessage.Text = "Proyecto Ubicación registrado con éxito.";

                /***** Ingresar acción en Bitácora ***/
                Bitacorear.Guardar(ID_USUARIO_SESSION, Convert.ToInt32(Session["idrol"]), "AddProyecto2.aspx", "Registrar", "Proyecto Ubicación: [ " + Id + "] ", ConectionBD);

            }
            catch (Exception ex)
            {
                mensajeErrorlbl.Visible = true;
                mensajeErrorlbl.ForeColor = System.Drawing.Color.Red;
                mensajeErrorlbl.Text = "!Error / Agregar registro 2: " + ex.Message + "!";
            }

            Response.Redirect("AddProyecto3.aspx?idproy=" + Id);
        }

        [System.Web.Services.WebMethod()]
        public static string guardarCoordenadas(string coordenadas, string idproyecto)
        {
            try
            {
                string Long = null;
                string Lat = null;
                int idproyectomapa = 0;
                int zoom = 5;
                int modo = 3;

                string[] datos = coordenadas.Split(',');
                Lat = datos[0].Replace("(", "").Trim();
                Long = datos[1].Replace(")", "").Trim();

                idproyectomapa = Convert.ToInt32(idproyecto);

                string resultado = string.Empty;
                string CadenaConexion = System.Configuration.ConfigurationManager.ConnectionStrings["ConstrunetConnection"].ConnectionString;
                SqlConnection con = new SqlConnection(CadenaConexion);
                con.Open();

                //Ingresar datos de Mapa
                MapasBehaivor MapaItem = new MapasBehaivor();
                MapaItem.Connection = con;
                List<MapasDatos> ProyLst = MapaItem.CN_fn_MapasInsert(idproyectomapa, Lat, Long, zoom, modo);

                //Retorna la cadena para pasarla a la pagina en la que se mostrara
                return "Mapa agregado con: lat=" + Lat + "&long=" + Long;

                //return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

    }
}