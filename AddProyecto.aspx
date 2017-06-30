<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddProyecto.aspx.cs" Inherits="ConstrunetUnlimited.AddProyecto" %>

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
					<li>Home</li><li>Proyectos</li><li><a href="Proyectos.aspx">Proyectos</a></li><li>Nuevo Proyecto</li>
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
				            Nuevo Proyecto
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
					            <h2>Proceso de registro </h2>				
					
				            </header>

				            <!-- widget div-->
				            <div>
					
					            <!-- widget edit box -->
					            <div class="jarviswidget-editbox">
						            <!-- This area used as dropdown edit box -->
						
					            </div>
					            <!-- end widget edit box -->
					
									<!-- widget content -->
									<div class="widget-body fuelux">
				
										<div class="wizard">
											<ul class="steps">
												<li data-target="#step1" class="active">
													<span class="badge badge-info">1</span>Info Proyecto<span class="chevron"></span>
												</li>
												<li data-target="#step2" >
													<span class="badge">2</span>Info Ubicación<span class="chevron"></span>
												</li>
												<li data-target="#step3" >
													<span class="badge">3</span>Info Contactos<span class="chevron"></span>
												</li>
												<li data-target="#step4" >
													<span class="badge">4</span>Info Participantes<span class="chevron"></span>
												</li>
												<li data-target="#step5" >
													<span class="badge">5</span>Finalizado<span class="chevron"></span>
												</li>
											</ul>
											<div class="actions">
												<button type="button" class="btn btn-sm btn-primary btn-prev">
													<i class="fa fa-arrow-left"></i>Prev
												</button>
												<button type="button" class="btn btn-sm btn-success btn-next" data-last="Finish">
													Next<i class="fa fa-arrow-right"></i>
												</button>
											</div>
										</div>
										<div class="step-content">  
											<div class="form-horizontal" id="fuelux-wizard" >
				
												<div class="<%= Convert.ToString(Session["active_panel1"]) %>" id="step1">
													<h3><strong>Paso 1 </strong> - Información Proyecto</h3>
								
						                            <div id="smart-form-register" class="smart-form">

                                                        <fieldset>
								                            <div class="row">
									                            <section class="col col-4">
									                                <label class="input"> <i class="icon-append fa fa-key"></i>
										                                <asp:TextBox ID="nombreproyectotxt" runat="server" placeholder="Nombre Proyecto" ></asp:TextBox></label>
                                                                        <div class="note note-error"><asp:RequiredFieldValidator ID="nombreproyectoValidator" runat="server" ControlToValidate="nombreproyectotxt" SetFocusOnError="true" InitialValue="" ErrorMessage="Ingresar el Nombre de Proyecto es requerido" ForeColor="Red"></asp:RequiredFieldValidator></div>
									                            </section>
								                            </div>
                                                            <div class="row">
								                                <section class="col col-4">
									                            <label class="input"> <i class="icon-append fa fa-calendar"></i>
										                            <asp:TextBox ID="fecharegistrotxt" runat="server" placeholder="Fecha Registro" TextMode="Date"></asp:TextBox></label>
                                                                    <div class="note note-error"><asp:RequiredFieldValidator ID="fechaValidator" runat="server" ControlToValidate="fecharegistrotxt" SetFocusOnError="true" InitialValue="" ErrorMessage="Ingresar fecha es requerido" ForeColor="Red"></asp:RequiredFieldValidator></div>
								                                </section>
                                                            </div>
							                            </fieldset>

							                            <fieldset>
								                            <div class="row">
									                            <section class="col col-4">
										                            <label class="select"> <i class="icon-append fa fa-wrench"></i>
											                            <asp:DropDownList ID="cmbTipoObra" runat="server" AutoPostBack="true" OnSelectedIndexChanged="cmbTipoObra_SelectedIndexChanged">
                                                                            <asp:ListItem Value="0" Text="Tipo Obra"></asp:ListItem>
											                            </asp:DropDownList> <i></i> </label>
                                                                        <div class="note note-error"><asp:RequiredFieldValidator ID="tipoObraValidator" runat="server" ControlToValidate="cmbTipoObra" SetFocusOnError="true" InitialValue="0" ErrorMessage="Selección de Tipo de Obra es requerido" ForeColor="Red"></asp:RequiredFieldValidator></div>
									                            </section>
									                            <section class="col col-4">
										                            <label class="select"> <i class="icon-append fa fa-wrench"></i>
											                            <asp:DropDownList ID="cmbEtapaProyecto" runat="server" >
                                                                            <asp:ListItem Value="0" Text="Etapa Proyecto"></asp:ListItem>
											                            </asp:DropDownList> <i></i> </label>
                                                                        <div class="note note-error"><asp:RequiredFieldValidator ID="etapaobraValidator" runat="server" ControlToValidate="cmbEtapaProyecto" SetFocusOnError="true" InitialValue="0" ErrorMessage="Selección de Etapa de Proyecto es requerido" ForeColor="Red"></asp:RequiredFieldValidator></div>
									                            </section>
								                            </div>
								                            <div class="row">
									                            <section class="col col-4">
										                            <label class="select"> <i class="icon-append fa fa-wrench"></i>
											                            <asp:DropDownList ID="cmbEstatus" runat="server" >
                                                                            <asp:ListItem Value="0" Text="Estatus Proyecto"></asp:ListItem>
											                            </asp:DropDownList> <i></i> </label>
                                                                        <div class="note note-error"><asp:RequiredFieldValidator ID="estatusProyecto" runat="server" ControlToValidate="cmbEstatus" SetFocusOnError="true" InitialValue="0" ErrorMessage="Selección de Estatus de Proyecto es requerido" ForeColor="Red"></asp:RequiredFieldValidator></div>
									                            </section>
								                                <section class="col col-4">
										                            <label class="select"> <i class="icon-append fa fa-wrench"></i>
											                            <asp:DropDownList ID="cmbSector" runat="server" >
                                                                            <asp:ListItem Value="0" Text="Sector Económico"></asp:ListItem>
											                            </asp:DropDownList> <i></i> </label>
                                                                        <div class="note note-error"><asp:RequiredFieldValidator ID="sectorValidator" runat="server" ControlToValidate="cmbSector" SetFocusOnError="true" InitialValue="0" ErrorMessage="Selección de Sector económico es requerido" ForeColor="Red"></asp:RequiredFieldValidator></div>
								                                </section>
                                                            </div>
                                                        </fieldset>

                                                        <fieldset>
								                            <div class="row">
									                            <section class="col col-6">
										                            <label class="select"> <i class="icon-append fa fa-wrench"></i>
											                            <asp:DropDownList ID="cmbEmpresaRaiz" runat="server" >
                                                                            <asp:ListItem Value="0" Text="Empresa Raíz"></asp:ListItem>
											                            </asp:DropDownList> <i></i> </label>
                                                                        <div class="note note-error"><asp:RequiredFieldValidator ID="empresaValidator" runat="server" ControlToValidate="cmbEmpresaRaiz" SetFocusOnError="true" InitialValue="0" ErrorMessage="Selección de Empresa es requerido" ForeColor="Red"></asp:RequiredFieldValidator></div>
									                            </section>
								                                <section class="col col-6">
										                            <label class="select"> <i class="icon-append fa fa-wrench"></i>
											                            <asp:DropDownList ID="cmbEmpresasContratista" runat="server" >
                                                                            <asp:ListItem Value="0" Text="Empresa Contratista"></asp:ListItem>
											                            </asp:DropDownList> <i></i> </label>
								                                </section>
                                                            </div>
                                                        </fieldset>

                                                        <fieldset>
								                            <div class="row">
									                            <section class="col col-8">
    									                            <label class="input"> 
										                            <asp:TextBox ID="descripciontxt" runat="server" placeholder="Descripción" TextMode="MultiLine" Columns="80" Rows="5"></asp:TextBox></label>
									                            </section>
								                            </div>
							                            </fieldset>

                                                        <fieldset>
                                                            <div class="row">
								                                <section class="col col-4">
    									                            <label class="input"> <i class="icon-append fa fa-usd"></i>
										                            <asp:TextBox ID="invesiontxt" runat="server" placeholder="Invesión estimada" TextMode="SingleLine" MaxLength="50"></asp:TextBox></label>
								                                </section>
									                            <section class="col col-4">
    									                            <label class="input"> <i class="icon-append fa fa-folder"></i>
										                            <asp:TextBox ID="conveniotxt" runat="server" placeholder="Convenio" TextMode="SingleLine" MaxLength="100" ></asp:TextBox></label>
									                            </section>
								                                <section class="col col-4">
    									                            <label class="input"> <i class="icon-append fa fa-certificate"></i>
										                            <asp:TextBox ID="claveconveniotxt" runat="server" placeholder="Clave" TextMode="SingleLine" MaxLength="50"></asp:TextBox></label>
								                                </section>
                                                            </div>
							                            </fieldset>
				                                    </div>
												</div>
				
												<div class="<%= Convert.ToString(Session["active_panel2"]) %>" id="step2">
													<h3><strong>Paso 2 </strong> - Información Ubicación</h3>
													<br>
													<br>
						                            <div id="smart-form-register" class="smart-form">
							                            <fieldset>
								                            <div class="row">
									                            <section class="col col-3">
										                            <label class="select"> <i class="icon-append fa fa-map-marker"></i>
											                            <asp:DropDownList ID="cmbEstadoPais" runat="server" AutoPostBack="true" OnSelectedIndexChanged="cmbEstadoPais_SelectedIndexChanged">
                                                                            <asp:ListItem Value="0" Text="Estado"></asp:ListItem>
											                            </asp:DropDownList> <i></i> </label>
                                                                        <div class="note note-error"><asp:RequiredFieldValidator ID="estadoValidator" runat="server" ControlToValidate="cmbEstadoPais" SetFocusOnError="true" InitialValue="0" ErrorMessage="Selección de Entidad es requerido" ForeColor="Red"></asp:RequiredFieldValidator></div>
									                            </section>
								                            </div>
								                            <div class="row">
									                            <section class="col col-4">
										                            <label class="select"> <i class="icon-append fa fa-map-marker"></i>
											                            <asp:DropDownList ID="cmbMunicipio" runat="server">
                                                                            <asp:ListItem Value="0" Text="Municipio"></asp:ListItem>
											                            </asp:DropDownList> <i></i> </label>
                                                                        <div class="note note-error"><asp:RequiredFieldValidator ID="municipioValidator" runat="server" ControlToValidate="cmbMunicipio" SetFocusOnError="true" InitialValue="0" ErrorMessage="Selección de Municipio es requerido" ForeColor="Red"></asp:RequiredFieldValidator></div>
									                            </section>
								                            </div>
                                                        </fieldset>
                                                        <fieldset>
								                            <div class="row">
									                            <section class="col col-4">
    									                            <label class="input"> <i class="icon-append fa fa-home"></i>
										                            <asp:TextBox ID="domiciliotxt" runat="server" placeholder="Domicilio" TextMode="SingleLine" MaxLength="250" ></asp:TextBox></label>
                                                                    <div class="note note-error"><asp:RequiredFieldValidator ID="domicilioValidator" runat="server" ControlToValidate="domiciliotxt" SetFocusOnError="true" InitialValue="" ErrorMessage="Ingresar fecha es requerido" ForeColor="Red"></asp:RequiredFieldValidator></div>
									                            </section>
								                            </div>
								                            <div class="row">
									                            <section class="col col-4">
    									                            <label class="input"> <i class="icon-append fa fa-home"></i>
										                            <asp:TextBox ID="coloniatxt" runat="server" placeholder="Colonia" TextMode="SingleLine" MaxLength="150" ></asp:TextBox></label>
									                            </section>
								                            </div>
                                                            <div class="row">
								                                <section class="col col-4">
    									                            <label class="input"> <i class="icon-append fa fa-map-marker"></i>
										                            <asp:TextBox ID="cptxt" runat="server" placeholder="C.P." TextMode="SingleLine" MaxLength="5"></asp:TextBox></label>
								                                </section>
                                                            </div>
							                            </fieldset>
							                            <fieldset>
								                            <div class="row">
									                            <section class="col col-4">
										                            <label class="select"> <i class="icon-append fa fa-map-marker"></i>
											                            <asp:DropDownList ID="cmbZonaVenta" runat="server">
                                                                            <asp:ListItem Value="0" Text="Zona Venta"></asp:ListItem>
											                            </asp:DropDownList> <i></i> </label>
                                                                        <div class="note note-error"><asp:RequiredFieldValidator ID="zonaValidator" runat="server" ControlToValidate="cmbZonaVenta" SetFocusOnError="true" InitialValue="0" ErrorMessage="Selección de Zona de Venta es requerido" ForeColor="Red"></asp:RequiredFieldValidator></div>
									                            </section>
								                            </div>
                                                        </fieldset>
                                                    </div>
													<br>
													<br>
												</div>
				
												<div class="<%= Convert.ToString(Session["active_panel3"]) %>" id="step3">
													<h3><strong>Paso 3 </strong> - Información Contacto...</h3>
													<br>
													<br>
						                            <div id="smart-form-register" class="smart-form">
                                                        <!-- Contacto 1 -->
                                                        <fieldset>
								                            <div class="row">
									                            <section class="col col-4">
    									                            <label class="input"> <i class="icon-append fa fa-user"></i>
										                            <asp:TextBox ID="nombrecontacto1txt" runat="server" placeholder="Contacto 1" TextMode="SingleLine" MaxLength="250" ></asp:TextBox></label>
                                                                    <div class="note note-error"><asp:RequiredFieldValidator ID="contactoValidator" runat="server" ControlToValidate="nombrecontacto1txt" SetFocusOnError="true" InitialValue="" ErrorMessage="Ingresar un contacto es requerido" ForeColor="Red"></asp:RequiredFieldValidator></div>
									                            </section>
									                            <section class="col col-4">
    									                            <label class="input"> <i class="icon-append fa fa-envelope-o"></i>
										                            <asp:TextBox ID="TextBox1" runat="server" placeholder="e-mail contacto 1" TextMode="SingleLine" MaxLength="80" ></asp:TextBox></label>
                                                                    <div class="note note-error"><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="nombrecontacto1txt" SetFocusOnError="true" InitialValue="" ErrorMessage="Ingresar un contacto es requerido" ForeColor="Red"></asp:RequiredFieldValidator></div>
									                            </section>
								                            </div>
                                                            <div class="row">
								                                <section class="col col-4">
    									                            <label class="input"> <i class="icon-append fa fa-phone"></i>
										                            <asp:TextBox ID="telefonocontactotxt" runat="server" placeholder="Teléfono / Móvil contacto 1" TextMode="SingleLine" MaxLength="50"></asp:TextBox></label>
								                                </section>
								                                <section class="col col-4">
    									                            <label class="input"> <i class="icon-append fa fa-briefcase"></i>
										                            <asp:TextBox ID="puestocontactotxt" runat="server" placeholder="Puesto contacto 1" TextMode="SingleLine" MaxLength="80"></asp:TextBox></label>
								                                </section>
                                                            </div>
								                            <div class="row">
									                            <section class="col col-4">
										                            <label class="select"> <i class="icon-append fa fa-briefcase"></i>
											                            <asp:DropDownList ID="cmbRolContacto1" runat="server">
                                                                            <asp:ListItem Value="0" Text="Rol"></asp:ListItem>
											                            </asp:DropDownList> <i></i> </label>
									                            </section>
									                            <section class="col col-4">
										                            <label class="select"> <i class="icon-append fa fa-building"></i>
											                            <asp:DropDownList ID="cmbEmpresaContacto1" runat="server">
                                                                            <asp:ListItem Value="0" Text="Empresa"></asp:ListItem>
											                            </asp:DropDownList> <i></i> </label>
									                            </section>
								                            </div>
                                                        </fieldset>
                                                        <!-- Contacto 2 -->
                                                        <fieldset>
								                            <div class="row">
									                            <section class="col col-4">
    									                            <label class="input"> <i class="icon-append fa fa-user"></i>
										                            <asp:TextBox ID="nombrecontacto2txt" runat="server" placeholder="Contacto 2" TextMode="SingleLine" MaxLength="250" ></asp:TextBox></label>
									                            </section>
									                            <section class="col col-4">
    									                            <label class="input"> <i class="icon-append fa fa-envelope-o"></i>
										                            <asp:TextBox ID="emailcontacto2txt" runat="server" placeholder="e-mail contacto 2" TextMode="SingleLine" MaxLength="80" ></asp:TextBox></label>
									                            </section>
								                            </div>
                                                            <div class="row">
								                                <section class="col col-4">
    									                            <label class="input"> <i class="icon-append fa fa-phone"></i>
										                            <asp:TextBox ID="telefonocontacto2txt" runat="server" placeholder="Teléfono / Móvil contacto 2" TextMode="SingleLine" MaxLength="50"></asp:TextBox></label>
								                                </section>
								                                <section class="col col-4">
    									                            <label class="input"> <i class="icon-append fa fa-briefcase"></i>
										                            <asp:TextBox ID="puestocontacto2" runat="server" placeholder="Puesto contacto 2" TextMode="SingleLine" MaxLength="80"></asp:TextBox></label>
								                                </section>
                                                            </div>
								                            <div class="row">
									                            <section class="col col-4">
										                            <label class="select"> <i class="icon-append fa fa-briefcase"></i>
											                            <asp:DropDownList ID="cmbRolContacto2" runat="server">
                                                                            <asp:ListItem Value="0" Text="Rol"></asp:ListItem>
											                            </asp:DropDownList> <i></i> </label>
									                            </section>
									                            <section class="col col-4">
										                            <label class="select"> <i class="icon-append fa fa-building"></i>
											                            <asp:DropDownList ID="cmbEmpresaContacto2" runat="server">
                                                                            <asp:ListItem Value="0" Text="Empresa"></asp:ListItem>
											                            </asp:DropDownList> <i></i> </label>
									                            </section>
								                            </div>
                                                        </fieldset>
                                                        <!-- Contacto 3 -->
                                                        <fieldset>
								                            <div class="row">
									                            <section class="col col-4">
    									                            <label class="input"> <i class="icon-append fa fa-user"></i>
										                            <asp:TextBox ID="nombrecontacto3txt" runat="server" placeholder="Contacto 3" TextMode="SingleLine" MaxLength="250" ></asp:TextBox></label>
									                            </section>
									                            <section class="col col-4">
    									                            <label class="input"> <i class="icon-append fa fa-envelope-o"></i>
										                            <asp:TextBox ID="emailcontacto3txt" runat="server" placeholder="e-mail contacto 3" TextMode="SingleLine" MaxLength="80" ></asp:TextBox></label>
									                            </section>
								                            </div>
                                                            <div class="row">
								                                <section class="col col-4">
    									                            <label class="input"> <i class="icon-append fa fa-phone"></i>
										                            <asp:TextBox ID="telefonocontacto3txt" runat="server" placeholder="Teléfono / Móvil contacto 3" TextMode="SingleLine" MaxLength="50"></asp:TextBox></label>
								                                </section>
								                                <section class="col col-4">
    									                            <label class="input"> <i class="icon-append fa fa-briefcase"></i>
										                            <asp:TextBox ID="puestocontacto3txt" runat="server" placeholder="Puesto contacto 3" TextMode="SingleLine" MaxLength="80"></asp:TextBox></label>
								                                </section>
                                                            </div>
								                            <div class="row">
									                            <section class="col col-4">
										                            <label class="select"> <i class="icon-append fa fa-briefcase"></i>
											                            <asp:DropDownList ID="cmbRolContacto3" runat="server">
                                                                            <asp:ListItem Value="0" Text="Rol"></asp:ListItem>
											                            </asp:DropDownList> <i></i> </label>
									                            </section>
									                            <section class="col col-4">
										                            <label class="select"> <i class="icon-append fa fa-building"></i>
											                            <asp:DropDownList ID="cmbEmpresaContacto3" runat="server">
                                                                            <asp:ListItem Value="0" Text="Empresa"></asp:ListItem>
											                            </asp:DropDownList> <i></i> </label>
									                            </section>
								                            </div>
                                                        </fieldset>
                                                    </div>
													<br>
													<br>
												</div>

												<div class="<%= Convert.ToString(Session["active_panel4"]) %>" id="step4">
													<h3><strong>Paso 4 </strong> - Información Responsables...</h3>
													<br>
													<br>
						                            <div id="smart-form-register" class="smart-form">

							                            <fieldset>
								                            <div class="row">
									                            <section class="col col-4">
										                            <label class="select"> <i class="icon-append fa fa-user"></i>
											                            <asp:DropDownList ID="cmbDirector" runat="server">
											                            </asp:DropDownList> <i></i> </label>
									                            </section>
								                            </div>
								                            <div class="row">
									                            <section class="col col-4">
										                            <label class="select"> <i class="icon-append fa fa-user"></i>
											                            <asp:DropDownList ID="cmbGerente" runat="server" OnSelectedIndexChanged="cmbGerente_SelectedIndexChanged" AutoPostBack="true">
                                                                            <asp:ListItem Value="0" Text="Gerente"></asp:ListItem>
											                            </asp:DropDownList> <i></i> </label>
									                            </section>
								                            </div>
								                            <div class="row">
									                            <section class="col col-4">
										                            <label class="select"> <i class="icon-append fa fa-user"></i>
											                            <asp:DropDownList ID="cmbEjecutivo" runat="server">
                                                                            <asp:ListItem Value="0" Text="Ejecutivo"></asp:ListItem>
											                            </asp:DropDownList> <i></i> </label>
									                            </section>
								                            </div>
								                            <div class="row">
									                            <section class="col col-4">
										                            <label class="select"> <i class="icon-append fa fa-building"></i>
											                            <asp:DropDownList ID="cmbCliente" runat="server">
                                                                            <asp:ListItem Value="0" Text="Cliente"></asp:ListItem>
											                            </asp:DropDownList> <i></i> </label>
									                            </section>
								                            </div>
								                            <div class="row">
									                            <section class="col col-4">
										                            <label class="select"> <i class="icon-append fa fa-user"></i>
											                            <asp:DropDownList ID="cmbGerenteTecnico" runat="server">
                                                                            <asp:ListItem Value="0" Text="Gerente Técnico"></asp:ListItem>
											                            </asp:DropDownList> <i></i> </label>
									                            </section>
								                            </div>
								                            <div class="row">
									                            <section class="col col-4">
										                            <label class="select"> <i class="icon-append fa fa-user"></i>
											                            <asp:DropDownList ID="cmbEjecutivoTecnico" runat="server">
                                                                            <asp:ListItem Value="0" Text="Ejecutivo Técnico"></asp:ListItem>
											                            </asp:DropDownList> <i></i> </label>
									                            </section>
								                            </div>
								                            <div class="row">
									                            <section class="col col-4">
										                            <label class="select"> <i class="icon-append fa fa-star"></i>
											                            <asp:DropDownList ID="cmbProspecto" runat="server">
                                                                            <asp:ListItem Value="0" Text="Prospectó Proyecto"></asp:ListItem>
											                            </asp:DropDownList> <i></i> </label>
									                            </section>
								                            </div>
                                                        </fieldset>
                                                    </div>
													<br>
													<br>
												</div>
				
												<div class="<%= Convert.ToString(Session["active_panel5"]) %>" id="step5">
													<h3><strong>Paso 5 </strong> - Finalizado!</h3>
													<br>
													<br>
						                            <div id="smart-form-register" class="smart-form">

													    <h1 class="text-center text-success"><i class="fa fa-check"></i> Felicidades!
													    <br>
													    <small>Ha finalizado el registro del proyecto</small></h1>
                                                    </div>
													<br>
													<br>
													<br>
													<br>
												</div>
				
											</div>
										</div>
				
									</div>
									<!-- end widget content -->
					
				            </div>
				            <!-- end widget div -->
				
			            </div>
			            <!-- end widget -->

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



		
		<script type="text/javascript">

		    // DO NOT REMOVE : GLOBAL FUNCTIONS!

		    $(document).ready(function () {

		        pageSetUp();

		        // fuelux wizard
		        var wizard = $('.wizard').wizard();

		        wizard.on('finished', function (e, data) {
		            //$("#fuelux-wizard").submit();
		            //console.log("submitted!");
		            $.smallBox({
		                title: "Congratulations! Your form was submitted",
		                content: "<i class='fa fa-clock-o'></i> <i>1 seconds ago...</i>",
		                color: "#5F895F",
		                iconSmall: "fa fa-check bounce animated",
		                timeout: 4000
		            });

		        });


		    })

		</script>


</asp:Content>
