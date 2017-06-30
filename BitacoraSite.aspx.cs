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
using System.IO;
using System.Data;

namespace ConstrunetUnlimited
{
    public partial class BitacoraSite : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //SecureHttps.UtilizarSSLProtocol();
            ValidarSesion();
            if (!this.IsPostBack)
            {
                DateTime fechaInicio = DateTime.Now;
                DateTime fechaFin = DateTime.Now;
                fechaInicio.AddDays(-2);
                CargarDatosFormulario();
                CargarBitacoraInicial(1);
            }
            Bitacorear.Guardar(ID_USUARIO_SESSION, Convert.ToInt32(Session["idrol"]), "BitacoraSite.aspx", "Revisar Bitácora", "Bitácora ", ConectionBD);

        }

        protected void CargarDatosFormulario()
        {
            CargarDatosUsuarios();
            CargarDatosAcciones();
        }

        protected void BitacoraButton_Click(object sender, EventArgs e)
        {
            DateTime fechaInicio = DateTime.Now;
            DateTime fechaFin = DateTime.Now;
            //bool result = DateTime.TryParse(TfechaInicio.Text, out fechaInicio);
            //bool result2 = DateTime.TryParse(TfechaFin.Text, out fechaFin);
            fechaInicio = Convert.ToDateTime(TfechaInicio.Text + " 12:00:00 AM");
            fechaFin = Convert.ToDateTime(TfechaFin.Text + " 11:59:59 PM");
            rsltlbl.Text = cmbUsers.SelectedItem.ToString();
            int modo = 3;

            try
            {
                BitacoraBehaivor BitacoraItem = new BitacoraBehaivor();
                BitacoraItem.Connection = ConectionBD;
                //1 - Administrador Global - Puede ver todos los usuarios
                if (Convert.ToString(Session["idrol"]) == "1")
                {
                    if ((Convert.ToInt32(cmbUsers.SelectedValue) == 0) && (cmbAcciones.SelectedValue == "0"))
                        modo = 3;
                    else if ((Convert.ToInt32(cmbUsers.SelectedValue) > 0) && (cmbAcciones.SelectedValue == "0"))
                        modo = 10;
                    else if ((Convert.ToInt32(cmbUsers.SelectedValue) == 0) && (cmbAcciones.SelectedValue != "0"))
                        modo = 11;
                    else if ((Convert.ToInt32(cmbUsers.SelectedValue) > 0) && (cmbAcciones.SelectedValue != "0"))
                        modo = 12;

                    List<BitacoraDatos> LstBitacora = BitacoraItem.CN_fn_BitacoraSel(fechaInicio, fechaFin, Convert.ToInt32(cmbUsers.SelectedValue), Convert.ToInt32(Session["idrol"]), Convert.ToString(cmbAcciones.SelectedValue), modo);
                    rptBitacora.DataSource = LstBitacora;
                    rptBitacora.DataBind();
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void CargarBitacoraInicial(int modo)
        {
            try
            {
                BitacoraBehaivor BitacoraItem = new BitacoraBehaivor();
                BitacoraItem.Connection = ConectionBD;
                //1 - Administrador Global - Puede ver todos los usuarios
                if (Convert.ToString(Session["idrol"]) == "1")
                {
                    List<BitacoraDatos> LstBitacora = BitacoraItem.CN_fn_BitacoraTotal(modo);
                    rptBitacora.DataSource = LstBitacora;
                    rptBitacora.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        protected void CargarBitacora(DateTime fechaInicio, DateTime fechaFin, int user, string accion, int modo)
        {
            try
            {
                BitacoraBehaivor BitacoraItem = new BitacoraBehaivor();
                BitacoraItem.Connection = ConectionBD;
                //1 - Administrador Global - Puede ver todos los usuarios
                if (Convert.ToString(Session["idrol"]) == "1")
                {
                    List<BitacoraDatos> LstBitacora = BitacoraItem.CN_fn_BitacoraSel(fechaInicio, fechaFin, user, Convert.ToInt32(Session["idrol"]), accion, modo);
                    rptBitacora.DataSource = LstBitacora;
                    rptBitacora.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void CargarDatosUsuarios()
        {
            try
            {
                UsuarioBehaivor UsuarioItem = new UsuarioBehaivor();
                UsuarioItem.Connection = ConectionBD;
                //1 - Administrador Global - Puede ver todos los usuarios
                if (Convert.ToString(Session["idrol"]) == "1")
                {
                    int modo = 3;
                    List<UsuarioDatos> LstUsuarios = UsuarioItem.CN_fn_ListaUsuarios(modo);
                    cmbUsers.DataTextField = "NombreCompleto";
                    cmbUsers.DataValueField = "UserId";
                    cmbUsers.DataSource = LstUsuarios;
                    cmbUsers.DataBind();
                    cmbUsers.Items.Insert(0, new ListItem("Seleccione un usuario", "0"));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void CargarDatosAcciones()
        {
            int modo = 2;
            try
            {
                BitacoraBehaivor BitacoraItem = new BitacoraBehaivor();
                BitacoraItem.Connection = ConectionBD;
                //1 - Administrador Global - Puede ver todos los usuarios
                if (Convert.ToString(Session["idrol"]) == "1")
                {
                    List<BitacoraDatos> LstBitacora = BitacoraItem.CN_fn_BitacoraAccionesDist(modo);
                    cmbAcciones.DataTextField = "Accion";
                    cmbAcciones.DataValueField = "Accion";
                    cmbAcciones.DataSource = LstBitacora;
                    cmbAcciones.DataBind();
                    cmbAcciones.Items.Insert(0, new ListItem("Seleccione una acción", "0"));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void ExporttoExcelBtn_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=BitacoraBiPolar.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            Response.ContentEncoding = System.Text.Encoding.Default;
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            rptBitacora.RenderControl(hw);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
    }
}