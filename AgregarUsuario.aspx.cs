using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Library.BaseDatos;
using Library.Entidades;
using Library.Common;
using ConstrunetUnlimited.Common;
using ConstrunetUnlimited.Common.Helper;

namespace ConstrunetUnlimited
{
    public partial class AgregarUsuario : BasePage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            //SecureHttps.UtilizarSSLProtocol();
            ValidarSesion();
            try
            {
                AddUserButton.Visible = true;
                EndButton.Visible = false;
                lbcAddEditUser.Text = "Agregar Usuario";
                Session["resultadoProceso"] = "0";
                Session["camposextras"] = "0";
                Session["campogte"] = "0";
                Session["campoeje"] = "0";

                if (!this.IsPostBack)
                {
                    ValidarSesion();
                    CargarDatosNuevoUsuario();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void AddUserButton_Click(object sender, EventArgs e)
        {
            string passwordmd5;
            lMessage.Text = "";
            int modo = 0;
            int idzonaventa = 0;
            int idusergerente = 0;
            int iduserejecutivo = 0;

            try
            {
                UsuarioBehaivor NuevoUsuarioItem = new UsuarioBehaivor();
                NuevoUsuarioItem.Connection = ConectionBD;
                List<UsuarioDatos> LstUser = null;
                AddUserButton.Visible = true;
                EndButton.Visible = false;

                /***********************************************************************************
                 *  Verificar que el correo con que se registra el usuario no exista
                 * ********************************************************************************/
                modo = 2; // Modo para revisar correo
                LstUser = NuevoUsuarioItem.CN_fn_UsuarioValidaCorreoSel(temail.Text, "-", 2);
                if (LstUser.Count > 0 && LstUser[0].UserId > -1)
                {
                    lMessage.Visible = true;
                    lMessage2.Text = "Esta direccion de correo electronico ya esta en uso, registre otra por favor";
                    Session["resultadoProceso"] = "2";
                    return;
                }
                else
                {
                    lMessage.Text = "Adelante";
                    lMessage.Visible = false;
                }

                /**********************************************************************************************************************
                 * Verificar información del perfil de usuario para IdZonaVentas de usuario y relación gerente - ejecutivo en su caso
                 * *******************************************************************************************************************/
                 if (Convert.ToInt32(cmbPerfil.SelectedValue) == 3)         // Perfil Gerente
                 {
                     idzonaventa = Convert.ToInt32(cmbZonaVentas.SelectedValue);
                 }
                 else if (Convert.ToInt32(cmbPerfil.SelectedValue) == 4)    // Perfil Ejecutivo
                 {
                    modo = 5;
                    LstUser = NuevoUsuarioItem.CN_fn_ObtenerInformacionGte(Convert.ToInt32(cmbGerenteZona.SelectedValue), modo);                         
                    if (LstUser.Count > 0)
                    {
                        idzonaventa = LstUser[0].IdZonaVenta;
                        idusergerente = LstUser[0].UserId;
                    }
                 }
                
                /***********************************************************************************
                 *  Ingresar datos del usuario nuevo
                 * ********************************************************************************/
                DateTime bday = DateTime.Now;
                string phone = "";
                string numempleado = "";
                int idkam = 0;
                modo = 1; // Modo para ingresar usuario nuevo en el SP
                LstUser = NuevoUsuarioItem.CN_fn_UsuariosInsert(-1, numempleado, temail.Text, tfirstname.Text, tlastname.Text, bday, Convert.ToInt32(cmbPerfil.SelectedValue), Convert.ToInt32(cmbEstatus.SelectedValue), idkam, idzonaventa, phone, 1);

                if (LstUser.Count > 0)
                {
                    Id = LstUser[0].UserId;
                }

                // si insertó, generar password                    
                Random pass = new Random(100000);
                int p = pass.Next(100, 100000);
                string pwd;
                pwd = CreateRandomPassword(6);
                /*Convierte el password en MD5 */
                using (MD5 md5Hash = MD5.Create())
                    passwordmd5 = GetMd5Hash(md5Hash, pwd);


                modo = 6; // Actualizar email and password en bd
                NuevoUsuarioItem.CN_fn_UsuariosLoginSIUD(Id, temail.Text, passwordmd5, modo);


                /***************************************************************************************************************
                 * Si el usuario registrado fue ejecutivo, ingresar relación con gerente
                 * ************************************************************************************************************/
                 if (Convert.ToInt32(cmbPerfil.SelectedValue) == 4)    // Perfil Ejecutivo
                 {
                    modo = 1;
                    iduserejecutivo = Id;
                   
                    UsuarioBehaivor GerenteEjecutivoItem = new UsuarioBehaivor();
                    GerenteEjecutivoItem.Connection = ConectionBD;

                    GerenteEjecutivoItem.CN_fn_GenerarRelacionGteEjecutivo(idusergerente, iduserejecutivo, idzonaventa, modo);                         
                 }


                /***************************************************************************************************************
                 * Pantalla de Usuario Registrado
                 * ************************************************************************************************************/
                cmbPerfil.Enabled = false;
                temail.Enabled = false;
                tfirstname.Enabled = false;
                tlastname.Enabled = false;
                cmbEstatus.Enabled = false;
                CancelButton.Visible = false;
                EndButton.Visible = true;
                AddUserButton.Visible = false;

                Session["resultadoProceso"] = "1";
                lMessage.Visible = true;
                lMessage.Text = "Usuario registrado con éxito. Un correo fue enviado al usuario para informarle del registro.";

                /***** Ingresar acción en Bitácora ***/
                Bitacorear.Guardar(ID_USUARIO_SESSION, Convert.ToInt32(Session["idrol"]), "AgregarUsuario.aspx", "Registrar", "Usuario: [ " + temail.Text + "] ", ConectionBD);

                //Registrar en notificación el evento y obtener ID
                // Registro nuevo usuario: 2
                int tipoNotificacion = 2;
                Inboxfn.RegistrarNotificacion("Registro Nuevo Usuario", "Bienvenido a Construnet Advance: " + tfirstname.Text + " " + tlastname.Text, tipoNotificacion, ConectionBD);
                // Obtener último ID Notificación registrado
                int IDLastNotification = 0;
                IDLastNotification = Inboxfn.ObtenerIDNotificacion(ConectionBD);
                //Envio a inbox x Usuario
                Inboxfn.RegistrarNotificacionxUsuario(ID_USUARIO_SESSION, IDLastNotification, 1, ConectionBD);

                /***** Texto correo ***/
                string textomail = "";
                if (Convert.ToInt32(cmbPerfil.SelectedValue) == 6)
                    textomail = TextoCorreos.RegistroNuevoUsuarioSCExterno(tfirstname.Text, temail.Text, pwd);
                else
                    textomail = TextoCorreos.RegistroNuevoUsuario(tfirstname.Text, temail.Text, pwd);

                if (cbnotificar.Checked)
                {
                    /***** Enviar correo a Participantes ***/
                    EnviarCorreo enviarCorreo;
                    enviarCorreo = new EnviarCorreo();
                    enviarCorreo.SendEmail(temail.Text, "Bienvenido a Construnet Advance", textomail);
                }

            }
            catch (Exception ex)
            {
                mensajeErrolbl.Visible = true;
                mensajeErrolbl.ForeColor = System.Drawing.Color.Red;
                mensajeErrolbl.Text = "!Error / Ingresar usuario: " + ex.Message + "!";
            }
        }

        protected void CargarDatosNuevoUsuario()
        {
            try
            {
                CargarComboPerfiles();
                CargarComboEstatus();
            }
            catch (Exception ex)
            {
                mensajeErrolbl.Visible = true;
                mensajeErrolbl.ForeColor = System.Drawing.Color.Red;
                mensajeErrolbl.Text = "!Error / Cargar datos combos: " + ex.Message + "!";
            }
        }

        /*******************************************************************************************************
         * Funciones para cargar datos de combos
         * *****************************************************************************************************/
        protected void CargarComboPerfiles()
        {
            try
            {
                PerfilesBehaivor PerfilesItem = new PerfilesBehaivor();
                PerfilesItem.Connection = ConectionBD;
                //1 - Administrador Global - Puede ver todos los usuarios
                if (Convert.ToString(Session["idrol"]) == "1")
                {
                    List<PerfilesDatos> LstPerfiles = PerfilesItem.CN_fn_PerfilesSel();
                    cmbPerfil.DataTextField = "NombrePerfil";
                    cmbPerfil.DataValueField = "IdPerfil";
                    cmbPerfil.DataSource = LstPerfiles;
                    cmbPerfil.DataBind();
                    cmbPerfil.Items.Insert(0, "Seleccione un perfil");
                }
            }
            catch (Exception ex)
            {
                mensajeErrolbl.Visible = true;
                mensajeErrolbl.ForeColor = System.Drawing.Color.Red;
                mensajeErrolbl.Text = "!Error / Cargar Combo Perfiles: " + ex.Message + "!";
            }
        }

        protected void CargarComboEstatus()
        {
            try
            {
                EstatusBehaivor EstatusItem = new EstatusBehaivor();
                EstatusItem.Connection = ConectionBD;
                //1 - Administrador Global - Puede ver todos los usuarios
                if (Convert.ToString(Session["idrol"]) == "1")
                {
                    List<EstatusDatos> LstEstatus = EstatusItem.CN_fn_estatus();
                    cmbEstatus.DataTextField = "NombreEstatus";
                    cmbEstatus.DataValueField = "IdEstatus";
                    cmbEstatus.DataSource = LstEstatus;
                    cmbEstatus.DataBind();
                    cmbEstatus.Items.Insert(0, "Seleccione un estatus");
                }
            }
            catch (Exception ex)
            {
                mensajeErrolbl.Visible = true;
                mensajeErrolbl.ForeColor = System.Drawing.Color.Red;
                mensajeErrolbl.Text = "!Error / Cargar Combo Estatus: " + ex.Message + "!";
            }
        }

        protected void cmbPerfil_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(cmbPerfil.SelectedValue) == 3)
                {
                    Session["camposextras"] = "1";
                    Session["campogte"] = "1";
                    cmbZonaVentas.Visible = true;
                    cmbZonaVentas.Enabled = true;
                    CargarComboZonasVenta();
                }
                if (Convert.ToInt32(cmbPerfil.SelectedValue) == 4)
                {
                    Session["camposextras"] = "1";
                    Session["campoeje"] = "1";
                    cmbGerenteZona.Visible = true;
                    cmbGerenteZona.Enabled = true;
                    CargarComboGerentesZonaVenta();
                }
            }
            catch (Exception ex)
            {
                mensajeErrolbl.Visible = true;
                mensajeErrolbl.ForeColor = System.Drawing.Color.Red;
                mensajeErrolbl.Text = "!Error / Actualizar CmbPerfil: " + ex.Message + "!";
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
                mensajeErrolbl.Visible = true;
                mensajeErrolbl.ForeColor = System.Drawing.Color.Red;
                mensajeErrolbl.Text = "!Error / Cargar Zonas Venta: " + ex.Message + "!";
            }
        }


        protected void CargarComboGerentesZonaVenta()
        {
            try
            {
                int modo = 4;
                UsuarioBehaivor GteEjeItem = new UsuarioBehaivor();
                GteEjeItem.Connection = ConectionBD;
                List<UsuarioDatos> GteEjeLst = GteEjeItem.CN_fn_ListGerentes(modo);
                cmbGerenteZona.DataTextField = "nombreCompletoGerenteyZona";
                cmbGerenteZona.DataValueField = "UserId";
                cmbGerenteZona.DataSource = GteEjeLst;
                cmbGerenteZona.DataBind();
                cmbGerenteZona.Items.Insert(0, "Seleccione un gerente / zona");
            }
            catch (Exception ex)
            {
                mensajeErrolbl.Visible = true;
                mensajeErrolbl.ForeColor = System.Drawing.Color.Red;
                mensajeErrolbl.Text = "!Error / Cargar Combo Gerente / Zona: " + ex.Message + "!";
            }
        }


        /*******************************************************************************************************
         * Funciones para generación de passord y encriptación a MD5
         * *****************************************************************************************************/
        public static string CreateRandomPassword(int PasswordLength)
        {
            string _allowedChars = "abcdefghijkmnpqrstuvwxyzABCDEFGHJKLMNPQRSTUVWXYZ23456789!@$?";
            Byte[] randomBytes = new Byte[PasswordLength];
            char[] chars = new char[PasswordLength];
            int allowedCharCount = _allowedChars.Length;

            for (int i = 0; i < PasswordLength; i++)
            {
                Random randomObj = new Random();
                randomObj.NextBytes(randomBytes);
                chars[i] = _allowedChars[(int)randomBytes[i] % allowedCharCount];
            }

            return new string(chars);
        }

        public string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

    }
}