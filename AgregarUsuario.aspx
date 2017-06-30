<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarUsuario.aspx.cs" Inherits="ConstrunetUnlimited.AgregarUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

		<!-- MAIN PANEL -->
		<div id="main" role="main">

			<!-- RIBBON -->
			<div id="ribbon">

				<span class="ribbon-button-alignment"> 
					<span id="refresh" class="btn btn-ribbon" data-action="resetWidgets" data-title="refresh"  rel="tooltip" data-placement="bottom" data-original-title="<i class='text-warning fa fa-warning'></i> Warning! This will reset all your widget settings." data-html="true">
						<i class="fa fa-refresh"></i>
					</span> 
				</span>

				<!-- breadcrumb -->
				<ol class="breadcrumb">
					<li>Home</li><li>Administración</li><li><a href="Usuarios.aspx">Usuarios</a></li><li><asp:Label ID="lbcAddEditUser" runat="server" Text="Agregar Usuario"></asp:Label> </li>
				</ol>
				<!-- end breadcrumb -->

			</div>
			<!-- END RIBBON -->

			<!-- MAIN CONTENT -->
			<div id="content">

                <div class="row">
                	<div class="col-xs-12 col-sm-9 col-md-9 col-lg-9">
                		<h1 class="page-title txt-color-blueDark">
			
			            <!-- PAGE HEADER -->
			                <i class="fa-fw fa fa-pencil-square-o"></i> 
				            Agregar Usuario
		                </h1>
	            </div>
	
            </div>

            <% if ((String)Session["resultadoProceso"] == "1")  {%>
            <div class="alert alert-block alert-success">
	            <a class="close" data-dismiss="alert" href="#">×</a>
	            <h4 class="alert-heading"><i class="fa fa-check-square-o"></i> Registro Exitoso!</h4>
	            <p>
                    <asp:Label ID="lMessage" runat="server" ></asp:Label>
	            </p>
            </div>
            <%} %>
            <% else if ((String)Session["resultadoProceso"] == "2")  {%>
            <div class="alert alert-block alert-warning">
	            <a class="close" data-dismiss="alert" href="#">×</a>
	            <h4 class="alert-heading"><i class="fa fa-check-square-o"></i> Registro fallido!</h4>
	            <p>
                    <asp:Label ID="lMessage2" runat="server" ></asp:Label>
	            </p>
            </div>
            <%} %>

            <!-- widget grid -->
            <section id="widget-grid" class="">


	            <!-- START ROW -->

                <div class="row">

		            <!-- NEW COL START -->
		            <article class="col-sm-12 col-md-12 col-lg-12">

			            <!-- Widget ID (each widget will need unique ID)-->
			            <div class="jarviswidget" id="wid-id-4" data-widget-editbutton="false" data-widget-custombutton="false">

				            <header>
					            <span class="widget-icon"> <i class="fa fa-edit"></i> </span>
					            <h2>Agregar Usuario </h2>				
					
				            </header>

				            <!-- widget div-->
				            <div>
					
					            <!-- widget edit box -->
					            <div class="jarviswidget-editbox">
						            <!-- This area used as dropdown edit box -->
						
					            </div>
					            <!-- end widget edit box -->
					
					            <!-- widget content -->
					            <div class="widget-body no-padding">
						
						            <div id="smart-form-register" class="smart-form">
							            <header>
								            Nuevo Usuario
							            </header>

							            <fieldset>
								            <div class="row">
									            <section class="col col-4">
										            <label class="select"> <i class="icon-append fa fa-wrench"></i>
											            <asp:DropDownList ID="cmbPerfil" runat="server" AutoPostBack="true" OnSelectedIndexChanged="cmbPerfil_SelectedIndexChanged">
                                                            <asp:ListItem Value="0" Text="Perfil"></asp:ListItem>
											            </asp:DropDownList> <i></i> </label>
                                                        <div class="note note-error"><asp:RequiredFieldValidator ID="perfilValidator" runat="server" ControlToValidate="cmbPerfil" SetFocusOnError="true" InitialValue="0" ErrorMessage="Selección de Perfil es requerido" ForeColor="Red"></asp:RequiredFieldValidator></div>
									            </section>
								            </div>
                                            <div class="row">
								            <section class="col col-6">
									            <label class="input"> <i class="icon-append fa fa-envelope-o"></i>
										            <asp:TextBox ID="temail" runat="server" placeholder="e-mail trabajo" ></asp:TextBox>
										            <b class="tooltip tooltip-bottom-right">Necesario para ingresar a tu cuenta y envío de notificaciones</b> </label>
                                                    <div class="note note-error"><asp:RequiredFieldValidator ID="emailValidator" runat="server" ControlToValidate="temail" SetFocusOnError="true" InitialValue="" ErrorMessage="Ingresar e-mail es requerido" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator Id="emailExpValidator" RunAt="server" ControlToValidate="temail" ErrorMessage="Ingrese un correo válido" ForeColor="Red" ValidationExpression="^([a-zA-Z0-9_\-\.]+)@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,3})$"></asp:RegularExpressionValidator></div>
								            </section>
                                            </div>

								            <div class="row">
									            <section class="col col-4">
										            <label class="select"> <i class="icon-append fa fa-power-off"></i>
											            <asp:DropDownList ID="cmbEstatus" runat="server">
                                                            <asp:ListItem Value="0" Text="Estatus"></asp:ListItem>
											            </asp:DropDownList> <i></i> </label>
                                                        <div class="note note-error"><asp:RequiredFieldValidator ID="EstatusValidator" runat="server" ControlToValidate="cmbEstatus" SetFocusOnError="true" InitialValue="0" ErrorMessage="Selección de Estatus es requerido" ForeColor="Red"></asp:RequiredFieldValidator></div>
									            </section>
								            </div>	
							            </fieldset>


							            <fieldset>
								            <div class="row">
									            <section class="col col-6">
										            <label class="input"><i class="icon-append fa fa-user"></i>
											            <asp:TextBox ID="tfirstname" runat="server" placeholder="Nombre" ></asp:TextBox>
                                                        <b class="tooltip tooltip-bottom-right">Nombre de usuario / Firstname</b>
										            </label>
                                                    <div class="note note-error"><asp:RequiredFieldValidator ID="firstnameValidator" runat="server" ControlToValidate="tfirstname" SetFocusOnError="true" InitialValue="" ErrorMessage="Ingresar un nombre de usuario es requerido" ForeColor="Red"></asp:RequiredFieldValidator></div>
									            </section>
									            <section class="col col-6">
										            <label class="input"><i class="icon-append fa fa-user"></i>
											            <asp:TextBox ID="tlastname" runat="server" placeholder="Apellidos" ></asp:TextBox>
                                                        <b class="tooltip tooltip-bottom-right">Apellidos / Lastname</b> 
										            </label>
                                                    <div class="note note-error"><asp:RequiredFieldValidator ID="lastnameValidator" runat="server" ControlToValidate="tlastname" SetFocusOnError="true" InitialValue="" ErrorMessage="Ingresar un apellido de usuario es requerido" ForeColor="Red"></asp:RequiredFieldValidator></div>
									            </section>
								            </div>
								            
								            <div class="row">
									            <section class="col col-4">
										            <label class="select"> <i class="icon-append fa fa-power-off"></i>
											            <asp:DropDownList ID="cmbZonaVentas" runat="server" Enabled="false">
                                                            <asp:ListItem Value="0" Text="Zona Ventas"></asp:ListItem>
											            </asp:DropDownList> <i></i> </label>
                                                </section>

									            <section class="col col-4">
										            <label class="select"> <i class="icon-append fa fa-power-off"></i>
											            <asp:DropDownList ID="cmbGerenteZona" runat="server" Enabled="false">
                                                            <asp:ListItem Value="0" Text="Gerente / Zona Ventas"></asp:ListItem>
											            </asp:DropDownList> <i></i> </label>
									            </section>
								            </div>	
                                            <br />
								            <section>
									            <label class="checkbox">
										            <asp:CheckBox ID="cbnotificar" runat="server" Checked="true" />
										            <i></i>Envíar correo de notificación</label>
								            </section>
							            </fieldset>
							            <footer>
                                            <asp:Button ID="AddUserButton" runat="server" Text="Registrar Usuario" OnClick="AddUserButton_Click" CssClass="btn btn-success" />
                                            <asp:HyperLink ID="EndButton" runat="server" Text="Finalizar" CssClass="btn btn-success" NavigateUrl="~/Usuarios.aspx"/>
                                            <asp:HyperLink ID="CancelButton" runat="server" Text="Cancelar" CssClass="btn btn-danger" NavigateUrl="~/Usuarios.aspx"/>
							            </footer>
						            </div>						
						
					            </div>
					            <!-- end widget content -->
					
				            </div>
				            <!-- end widget div -->
				
			            </div>
			            <!-- end widget -->
                
                        <asp:Label ID="mensajeErrolbl" runat="server" Visible="false"></asp:Label>

		            </article>
		            <!-- END COL -->		

                </div>
	            <!-- END ROW -->
			
            </section>
            <!-- end widget grid -->

			</div>
			<!-- END MAIN CONTENT -->

		</div>
		<!-- END MAIN PANEL -->


</asp:Content>
