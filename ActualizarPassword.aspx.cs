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
    public partial class ActualizarPassword : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //SecureHttps.UtilizarSSLProtocol();
            ValidarSesion();
            try
            {
                UpdateButton.Visible = true;
                EndButton.Visible = false;
                Id = -1;
                if (!string.IsNullOrEmpty(this.Request.QueryString["Id"]))
                {
                    Id = Convert.ToInt32(this.Request.QueryString["Id"]);
                }
                Session["resultadoProceso"] = "0";

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void UpdateButton_Click(object sender, EventArgs e)
        {
            string passwordmd5;
            lMessage.Text = "";
            int modo = 0;
            string nombreusuario = "";
            string emailusuario = "";

            try
            {
                UsuarioBehaivor NuevoUsuarioItem = new UsuarioBehaivor();
                NuevoUsuarioItem.Connection = ConectionBD;

                EndButton.Visible = true;
                UpdateButton.Visible = false;

                // Modificar password
                /*Convierte el password en MD5 */
                using (MD5 md5Hash = MD5.Create())
                    passwordmd5 = GetMd5Hash(md5Hash, tpassword.Text);


                List<UsuarioDatos> ListUsuario = NuevoUsuarioItem.CN_fn_UsuariosSel(Id);
                if (ListUsuario.Count > 0)
                {
                    nombreusuario = ListUsuario[0].NombreCompleto;
                    emailusuario = ListUsuario[0].email;
                }

                modo = 4; // Actualizar el password en bd
                NuevoUsuarioItem.CN_fn_UsuariosLoginSIUD(Id, "a", passwordmd5, modo);

                /***************************************************************************************************************
                 * Pantalla de Password Registrado
                 * ************************************************************************************************************/
                tpassword.Text = "";
                tconfirmpassword.Text = "";
                CancelButton.Visible = false;
                EndButton.Visible = true;
                UpdateButton.Visible = false;

                Session["resultadoProceso"] = "1";
                lMessage.Visible = true;
                lMessage.Text = "Password actualizado con éxito. Un correo fue enviado al usuario para informarle del cambio.";

                /***** Ingresar acción en Bitácora ***/
                Bitacorear.Guardar(ID_USUARIO_SESSION, Convert.ToInt32(Session["idrol"]), "ActualizarPassword.aspx", "Actualizar", "Password:  [ " + emailusuario + " ] ", ConectionBD);

                /***** Texto correo Edición Usuario ***/
                string textomail = "";
                textomail = TextoCorreos.ActualizarPassword(nombreusuario);

                //Registrar en notificación el evento y obtener ID
                // TipoNotificacion Passord: 4
                int tipoNotificacion = 4;
                Inboxfn.RegistrarNotificacion("Actualización de la contraseña", "Actualización de password de la cuenta: " + emailusuario, tipoNotificacion, ConectionBD);
                // Obtener último ID Notificación registrado
                int IDLastNotification = 0;
                IDLastNotification = Inboxfn.ObtenerIDNotificacion(ConectionBD);
                //Envio a inbox x Usuario
                Inboxfn.RegistrarNotificacionxUsuario(ID_USUARIO_SESSION, IDLastNotification, 1, ConectionBD);


                /***** Enviar correo a Participantes ***/
                EnviarCorreo enviarCorreo;
                enviarCorreo = new EnviarCorreo();
                enviarCorreo.SendEmail(emailusuario, "Construnet Advance: Actualización de contraseña", textomail);

            }
            catch (Exception ex)
            {
                throw ex;
                //ShowMessageClient(ex.Message);
            }
        }

        /*******************************************************************************************************
         * Funciones para generación de passord y encriptación a MD5
         * *****************************************************************************************************/
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