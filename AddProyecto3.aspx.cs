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
    public partial class AddProyecto3 : BasePage
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
                }
                else
                {
                }
                if (!this.IsPostBack)
                {
                    ValidarSesion();
                    CargarEmpresas();
                    CargarRolesEmpresas();
                }
            }
            catch (Exception ex)
            {
                mensajeErrorlbl.Visible = true;
                mensajeErrorlbl.ForeColor = System.Drawing.Color.Red;
                mensajeErrorlbl.Text = "!Error / Load: " + ex.Message + "!";
            }
        }

        protected void CargarEmpresas()
        {
            try
            {
                int modo = 11;
                ProyectosBehaivor EmpresasProyectosItem = new ProyectosBehaivor();
                EmpresasProyectosItem.Connection = ConectionBD;
                List<ProyectosDatos> empresasProyLst = EmpresasProyectosItem.CN_fn_EmpresasProyectosSel(Id, modo);

                if (empresasProyLst.Count > 0)
                {
                    cmbEmpresaContacto1.DataTextField = "nombreEmpresa";
                    cmbEmpresaContacto1.DataValueField = "IdEmpresa";
                    cmbEmpresaContacto1.DataSource = empresasProyLst;
                    cmbEmpresaContacto1.DataBind();
                    cmbEmpresaContacto1.Items.Insert(0, new ListItem("Seleccione una empresa", "0"));

                    cmbEmpresaContacto2.DataTextField = "nombreEmpresa";
                    cmbEmpresaContacto2.DataValueField = "IdEmpresa";
                    cmbEmpresaContacto2.DataSource = empresasProyLst;
                    cmbEmpresaContacto2.DataBind();
                    cmbEmpresaContacto2.Items.Insert(0, new ListItem("Seleccione una empresa", "0"));

                    cmbEmpresaContacto3.DataTextField = "nombreEmpresa";
                    cmbEmpresaContacto3.DataValueField = "IdEmpresa";
                    cmbEmpresaContacto3.DataSource = empresasProyLst;
                    cmbEmpresaContacto3.DataBind();
                    cmbEmpresaContacto3.Items.Insert(0, new ListItem("Seleccione una empresa", "0"));
                }
            }
            catch (Exception ex)
            {
                mensajeErrorlbl.Visible = true;
                mensajeErrorlbl.ForeColor = System.Drawing.Color.Red;
                mensajeErrorlbl.Text = "!Error / Cargar Empresa: " + ex.Message + "!";
            }
        }

        protected void CargarRolesEmpresas()
        {
            try
            {
                int modo = 7;
                EmpresasBehaivor empresasRolItem = new EmpresasBehaivor();
                empresasRolItem.Connection = ConectionBD;
                List<EmpresasDatos> empresaRolesList = empresasRolItem.CN_fn_EmpresasRolesContactoSel(modo);

                cmbRolContacto1.DataTextField = "rolContactoEmpresa";
                cmbRolContacto1.DataValueField = "IdRolContactoEmpresa";
                cmbRolContacto1.DataSource = empresaRolesList;
                cmbRolContacto1.DataBind();
                cmbRolContacto1.Items.Insert(0, new ListItem("Seleccione un rol", "0"));

                cmbRolContacto2.DataTextField = "rolContactoEmpresa";
                cmbRolContacto2.DataValueField = "IdRolContactoEmpresa";
                cmbRolContacto2.DataSource = empresaRolesList;
                cmbRolContacto2.DataBind();
                cmbRolContacto2.Items.Insert(0, new ListItem("Seleccione un rol", "0"));

                cmbRolContacto3.DataTextField = "rolContactoEmpresa";
                cmbRolContacto3.DataValueField = "IdRolContactoEmpresa";
                cmbRolContacto3.DataSource = empresaRolesList;
                cmbRolContacto3.DataBind();
                cmbRolContacto3.Items.Insert(0, new ListItem("Seleccione un rol", "0"));
            }
            catch (Exception ex)
            {
                mensajeErrorlbl.Visible = true;
                mensajeErrorlbl.ForeColor = System.Drawing.Color.Red;
                mensajeErrorlbl.Text = "!Error / Cargar Roles Empresa: " + ex.Message + "!";
            }
        }

        protected void AddProyectBtn_Click(object sender, EventArgs e)
        {
            lMessage.Text = "";
            int modo = 0;

            try
            {
                ProyectosBehaivor NewProyectItem = new ProyectosBehaivor();
                NewProyectItem.Connection = ConectionBD;
                List<ProyectosDatos> ProyLst = null;

                /***********************************************************************************
                 *  Continuar ingreso de datos Contactos Empresas con Proyecto
                 * ********************************************************************************/
                modo = 3; // Modo para registrar nuevo contacto de empresa en proyecto 
                ProyLst = NewProyectItem.CN_fn_ProyectoContactoInsert(
                                                                Id,
                                                                nombrecontacto1txt.Text,
                                                                telefonocontacto1txt.Text,
                                                                emailcontacto1txt.Text,
                                                                puestocontacto1txt.Text,
                                                                Convert.ToInt32(cmbRolContacto1.SelectedValue),
                                                                Convert.ToInt32(cmbEmpresaContacto1.SelectedValue),
                                                                modo);

                if (nombrecontacto2txt.Text != "")
                {
                    ProyLst = NewProyectItem.CN_fn_ProyectoContactoInsert(
                                                                    Id,
                                                                    nombrecontacto2txt.Text,
                                                                    telefonocontacto2txt.Text,
                                                                    emailcontacto2txt.Text,
                                                                    puestocontacto2txt.Text,
                                                                    Convert.ToInt32(cmbRolContacto2.SelectedValue),
                                                                    Convert.ToInt32(cmbEmpresaContacto2.SelectedValue),
                                                                    modo);

                }

                if (nombrecontacto3txt.Text != "")
                {
                    ProyLst = NewProyectItem.CN_fn_ProyectoContactoInsert(
                                                                    Id,
                                                                    nombrecontacto3txt.Text,
                                                                    telefonocontacto3txt.Text,
                                                                    emailcontacto3txt.Text,
                                                                    puestocontacto3txt.Text,
                                                                    Convert.ToInt32(cmbRolContacto3.SelectedValue),
                                                                    Convert.ToInt32(cmbEmpresaContacto3.SelectedValue),
                                                                    modo);

                }


                /***************************************************************************************************************
                 * Pantalla de Usuario Registrado
                 * ************************************************************************************************************/
                nombrecontacto1txt.Enabled = false;
                telefonocontacto1txt.Enabled = false;
                emailcontacto1txt.Enabled = false;
                puestocontacto1txt.Enabled = false;
                cmbRolContacto1.Enabled = false;
                cmbEmpresaContacto1.Enabled = false;
                nombrecontacto2txt.Enabled = false;
                telefonocontacto2txt.Enabled = false;
                emailcontacto2txt.Enabled = false;
                puestocontacto2txt.Enabled = false;
                cmbRolContacto2.Enabled = false;
                cmbEmpresaContacto2.Enabled = false;
                nombrecontacto3txt.Enabled = false;
                telefonocontacto3txt.Enabled = false;
                emailcontacto3txt.Enabled = false;
                puestocontacto3txt.Enabled = false;
                cmbRolContacto3.Enabled = false;
                cmbEmpresaContacto3.Enabled = false;
                AddProyectBtn.Enabled = false;

                Session["resultadoProceso"] = "1";
                lMessage.Visible = true;
                lMessage.Text = "Contactos de Proyecto registrados con éxito.";

                /***** Ingresar acción en Bitácora ***/
                Bitacorear.Guardar(ID_USUARIO_SESSION, Convert.ToInt32(Session["idrol"]), "AddProyecto3.aspx", "Registrar", "Proyecto Contactos Empresa: [ " + Id + "] ", ConectionBD);

            }
            catch (Exception ex)
            {
                mensajeErrorlbl.Visible = true;
                mensajeErrorlbl.ForeColor = System.Drawing.Color.Red;
                mensajeErrorlbl.Text = "!Error / Agregar Registro 3: " + ex.Message + "!";
            }

            Response.Redirect("AddProyecto4.aspx?idproy=" + Id);

        }
    }
}