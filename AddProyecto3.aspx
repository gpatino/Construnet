<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddProyecto3.aspx.cs" Inherits="ConstrunetUnlimited.AddProyecto3" %>
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
												<li data-target="#step1">
													<span class="badge badge-info">1</span>Info Proyecto<span class="chevron"></span>
												</li>
												<li data-target="#step2">
													<span class="badge">2</span>Info Ubicación<span class="chevron"></span>
												</li>
												<li data-target="#step3" class="active">
													<span class="badge">3</span>Info Contactos<span class="chevron"></span>
												</li>
												<li data-target="#step4">
													<span class="badge">4</span>Info Participantes<span class="chevron"></span>
												</li>
												<li data-target="#step5">
													<span class="badge">5</span>Finalizado<span class="chevron"></span>
												</li>
											</ul>
											<div class="actions">
												<asp:LinkButton ID="AddProyectBtn" runat="server" class="btn btn-sm btn-success btn-next" OnClick="AddProyectBtn_Click" >Siguiente <i class="fa fa-arrow-right"></i></asp:LinkButton>
											</div>
										</div>
										<div class="step-content">
											<div class="form-horizontal" id="fuelux-wizard" >
								
												<div class="step-pane active" id="step3">
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
                                                                    <div class="note note-error"><asp:RequiredFieldValidator ID="contactoValidator" runat="server" ControlToValidate="nombrecontacto1txt" SetFocusOnError="true" InitialValue="" ErrorMessage="Ingresar un nombre contacto es requerido" ForeColor="Red"></asp:RequiredFieldValidator></div>
									                            </section>
									                            <section class="col col-4">
    									                            <label class="input"> <i class="icon-append fa fa-envelope-o"></i>
										                            <asp:TextBox ID="emailcontacto1txt" runat="server" placeholder="e-mail contacto 1" TextMode="SingleLine" MaxLength="80" ></asp:TextBox></label>
                                                                    <div class="note note-error"><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="nombrecontacto1txt" SetFocusOnError="true" InitialValue="" ErrorMessage="Ingresar un email de contacto es requerido" ForeColor="Red"></asp:RequiredFieldValidator></div>
									                            </section>
								                            </div>
                                                            <div class="row">
								                                <section class="col col-4">
    									                            <label class="input"> <i class="icon-append fa fa-phone"></i>
										                            <asp:TextBox ID="telefonocontacto1txt" runat="server" placeholder="Teléfono / Móvil contacto 1" TextMode="SingleLine" MaxLength="50"></asp:TextBox></label>
								                                </section>
								                                <section class="col col-4">
    									                            <label class="input"> <i class="icon-append fa fa-briefcase"></i>
										                            <asp:TextBox ID="puestocontacto1txt" runat="server" placeholder="Puesto contacto 1" TextMode="SingleLine" MaxLength="80"></asp:TextBox></label>
								                                </section>
                                                            </div>
								                            <div class="row">
									                            <section class="col col-4">
										                            <label class="select"> <i class="icon-append fa fa-briefcase"></i>
											                            <asp:DropDownList ID="cmbRolContacto1" runat="server">
											                            </asp:DropDownList> <i></i> </label>
                                                                    <div class="note note-error"><asp:RequiredFieldValidator ID="rolValidator" runat="server" ControlToValidate="cmbRolContacto1" SetFocusOnError="true" InitialValue="0" ErrorMessage="Ingresar un rol de contacto es requerido" ForeColor="Red"></asp:RequiredFieldValidator></div>
									                            </section>
									                            <section class="col col-4">
										                            <label class="select"> <i class="icon-append fa fa-building"></i>
											                            <asp:DropDownList ID="cmbEmpresaContacto1" runat="server">
											                            </asp:DropDownList> <i></i> </label>
                                                                    <div class="note note-error"><asp:RequiredFieldValidator ID="empresaValidator" runat="server" ControlToValidate="cmbEmpresaContacto1" SetFocusOnError="true" InitialValue="0" ErrorMessage="Ingresar una empresa de contacto es requerido" ForeColor="Red"></asp:RequiredFieldValidator></div>
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
										                            <asp:TextBox ID="puestocontacto2txt" runat="server" placeholder="Puesto contacto 2" TextMode="SingleLine" MaxLength="80"></asp:TextBox></label>
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
				
											</div>
										</div>
                                        <br /><br /><br />
                                        <asp:Label ID="mensajeErrorlbl" runat="server" Visible="false"></asp:Label>
                                        <br />								
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
