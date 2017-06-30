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
    public partial class AddProyecto4 : BasePage
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
                    CargarGerentes();
                    CargarClientesHenkel();
                    CargarProspecto();
                }
            }
            catch (Exception ex)
            {
                mensajeErrorlbl.Visible = true;
                mensajeErrorlbl.ForeColor = System.Drawing.Color.Red;
                mensajeErrorlbl.Text = "!Error / Load: " + ex.Message + "!";
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
                cmbGerente.Items.Insert(0, new ListItem("Seleccione un gerente", "0"));
            }
            catch (Exception ex)
            {
                mensajeErrorlbl.Visible = true;
                mensajeErrorlbl.ForeColor = System.Drawing.Color.Red;
                mensajeErrorlbl.Text = "!Error / Cargar Gerentes: " + ex.Message + "!";
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
                cmbCliente.Items.Insert(0, new ListItem("Seleccione un cliente", "0"));
            }
            catch (Exception ex)
            {
                mensajeErrorlbl.Visible = true;
                mensajeErrorlbl.ForeColor = System.Drawing.Color.Red;
                mensajeErrorlbl.Text = "!Error / Cargar Clientes Henkel: " + ex.Message + "!";
            }
        }

        protected void CargarEjecutivos(int useridgerente)
        {
            try
            {
                int modo = 4;
                UsuariosPerfilBehaivor ejecutivosItem = new UsuariosPerfilBehaivor();
                ejecutivosItem.Connection = ConectionBD;
                List<UsuariosPerfilDatos> ejeLst = ejecutivosItem.CN_fn_ListEjecutivosxIdGerente(useridgerente, modo);

                cmbEjecutivo.DataTextField = "NombreCompletoEjecutivo";
                cmbEjecutivo.DataValueField = "UserId";
                cmbEjecutivo.DataSource = ejeLst;
                cmbEjecutivo.DataBind();
                cmbEjecutivo.Items.Insert(0, new ListItem("Seleccione un ejecutivo", "0"));
            }
            catch (Exception ex)
            {
                mensajeErrorlbl.Visible = true;
                mensajeErrorlbl.ForeColor = System.Drawing.Color.Red;
                mensajeErrorlbl.Text = "!Error / Cargar ATC: " + ex.Message + "!";
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
                cmbProspecto.Items.Insert(0, new ListItem("Seleccione quien prospectó", "0"));
            }
            catch (Exception ex)
            {
                mensajeErrorlbl.Visible = true;
                mensajeErrorlbl.ForeColor = System.Drawing.Color.Red;
                mensajeErrorlbl.Text = "!Error / Cargar Prospectó: " + ex.Message + "!";
            }
        }

        protected void cmbGerente_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarEjecutivos(Convert.ToInt32(cmbGerente.SelectedValue));
        }

        protected void AddProyectBtn_Click(object sender, EventArgs e)
        {
            lMessage.Text = "";

            try
            {
                int modo = 0;
                string nombreCompleto = "";
                string nombreProyecto = "";
                string emailUsuario = "";
                string textomail = "";

                ProyectosBehaivor NewProyectItem = new ProyectosBehaivor();
                NewProyectItem.Connection = ConectionBD;
                List<ProyectosDatos> ProyLst = null;

                /***********************************************************************************
                 *  Continuar ingreso de Responsables del Proyecto
                 * ********************************************************************************/
                modo = 4; // Modo para registrar responsables en proyecto 
                int iduserAdmin = 650;      //UserId de Lilia - Administradora
                int iduserDirVentas = 411;  //UserId de Vicente Madrid - Director Ventas
                ProyLst = NewProyectItem.CN_fn_ProyectoParticipantesInsert(Id, iduserAdmin, 1, modo);
                ProyLst = NewProyectItem.CN_fn_ProyectoParticipantesInsert(Id, iduserDirVentas, 2, modo);
                ProyLst = NewProyectItem.CN_fn_ProyectoParticipantesInsert(Id, Convert.ToInt32(cmbGerente.SelectedValue), 3, modo);
                ProyLst = NewProyectItem.CN_fn_ProyectoParticipantesInsert(Id, Convert.ToInt32(cmbEjecutivo.SelectedValue), 4, modo);

                /***********************************************************************************
                 *  Continuar ingreso de IDH Cliente
                * ********************************************************************************/
                modo = 5; // Modo para registrar responsables en proyecto 
                ProyLst = NewProyectItem.CN_fn_ProyectoIdhClienteInsertUpdate(Id, Convert.ToInt32(cmbCliente.SelectedValue), modo);

                /***********************************************************************************
                 *  Continuar ingreso de Prospectó Proyecto
                * ********************************************************************************/
                modo = 6; // Modo para registrar responsables en proyecto 
                ProyLst = NewProyectItem.CN_fn_ProyectoProspectoInsertUpdate(Id, Convert.ToInt32(cmbProspecto.SelectedValue), modo);

                /***********************************************************************************
                 *  Continuar ingreso de Evento Proyecto - 1. Nuevo Proyecto
                * ********************************************************************************/
                modo = 1; // Modo para registrar responsables en proyecto 
                int idevento = 1;   //Evento 1. Nuevo Proyecto
                NewProyectItem.CN_fn_ProyectoEventoInsertUpdate(Id, idevento, ID_USUARIO_SESSION, modo);


                /***************************************************************************************************************
                 * Pantalla de Usuario Registrado
                 * ************************************************************************************************************/
                cmbGerente.Enabled = false;
                cmbEjecutivo.Enabled = false;
                cmbCliente.Enabled = false;
                cmbProspecto.Enabled = false;
                AddProyectBtn.Enabled = false;

                Session["resultadoProceso"] = "1";
                lMessage.Visible = true;
                lMessage.Text = "Responsables del Proyecto registrados con éxito.";

                /***** Ingresar acción en Bitácora ***/
                Bitacorear.Guardar(ID_USUARIO_SESSION, Convert.ToInt32(Session["idrol"]), "AddProyecto4.aspx", "Registrar", "Proyecto Responsables: [ " + Id + "] ", ConectionBD);

                /***************************************************************************
                 * Obtener información del nombre del Proyecto y quien registró
                 * *************************************************************************/
                if (ProyLst.Count > 0)
                {
                    nombreProyecto = ProyLst[0].nombreProyecto;
                    nombreCompleto = ProyLst[0].NombreCompletoRegistro;
                    emailUsuario = ProyLst[0].email;
                }

               //Enviar correo de Nuevo Proyecto
               EnviarCorreo enviarCorreo;
                enviarCorreo = new EnviarCorreo();
                textomail = Convert.ToString(TextoCorreos.TextoNuevoProyecto(nombreCompleto, nombreProyecto));
                //Envio de correo a persona Aceptó términos y aviso de privacidad
                enviarCorreo.SendEmail(emailUsuario, "Construnet Advance: Nuevo Proyecto", textomail);

            }
            catch (Exception ex)
            {
                mensajeErrorlbl.Visible = true;
                mensajeErrorlbl.ForeColor = System.Drawing.Color.Red;
                mensajeErrorlbl.Text = "!Error / Agregar Registro 4: " + ex.Message + "!";
            }

            Response.Redirect("AddProyecto5.aspx?idproy=" + Id);
        }
    }
}