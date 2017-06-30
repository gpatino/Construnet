using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Library.BaseDatos;
using Library.Entidades;
using Library.Common;
using ConstrunetUnlimited.Common;
using ConstrunetUnlimited.Common.Helper;

namespace ConstrunetUnlimited
{
    public partial class AceptarTerminosyCondiciones : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //SecureHttps.UtilizarSSLProtocol();                
            ValidarSesion();
            CargarUsuarioLogeado();
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            string nombreCompleto = "";
            string emailUsuario = "";
            string textomail = "";
            int paisusuario = 0;
            int idrolusuario = 0;
            EnviarCorreo enviarCorreo;

            try
            {
                UsuarioBehaivor usuario = new UsuarioBehaivor();
                usuario.Connection = ConectionBD;
                usuario.CN_fn_ModificaAceptacionTYC(ID_USUARIO_SESSION, 2);

                List<UsuarioDatos> lstUsuario = usuario.CN_fn_UsuariosSel(ID_USUARIO_SESSION);

                if (lstUsuario.Count > 0)
                {
                    nombreCompleto = lstUsuario[0].NombreCompleto;
                    emailUsuario = lstUsuario[0].email;
                    paisusuario = lstUsuario[0].idpais;
                    idrolusuario = lstUsuario[0].idrol;
                }

                //Enviar correo de Aceptación de Términos y Condiciones
                enviarCorreo = new EnviarCorreo();
                textomail = Convert.ToString(TextoCorreos.TextoAceptacionTYC(nombreCompleto));
                //Envio de correo a persona Aceptó términos y aviso de privacidad
                //enviarCorreo.SendEmail(emailUsuario, "Construnet Advance: Aceptación Aviso Privacidad", textomail);

                //Registrar en notificación el evento y obtener ID
                // Aceptación de Términos y Condiciones: 1
                int tipoNotificacion = 1;
                //Registrar en notificación el evento y obtener ID 
                Inboxfn.RegistrarNotificacion("Cuenta Activada", "Se ha activado la cuenta de : " + nombreCompleto, tipoNotificacion, ConectionBD);
                // Obtener último ID Notificación registrado
                int IDLastNotification = 0;
                IDLastNotification = Inboxfn.ObtenerIDNotificacion(ConectionBD);
                //Envio a inbox x Usuario
                Inboxfn.RegistrarNotificacionxUsuario(ID_USUARIO_SESSION, IDLastNotification, 1, ConectionBD);

                Bitacorear.Guardar(ID_USUARIO_SESSION, ID_ROL_SESSION, "AceptarTerminisoyCondiciones.aspx", "Insertar", "Aceptó Aviso Privacidad: [" + emailUsuario + " ]", ConectionBD);

                if (idrolusuario <= 6)
                    this.Context.Response.Redirect(PagesList.DefaultMX);
                else if (idrolusuario > 7)
                    this.Context.Response.Redirect(PagesList.DefaultDistribuidor);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}