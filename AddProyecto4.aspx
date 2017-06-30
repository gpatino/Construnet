<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddProyecto4.aspx.cs" Inherits="ConstrunetUnlimited.AddProyecto4" %>
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
												<li data-target="#step3">
													<span class="badge">3</span>Info Contactos<span class="chevron"></span>
												</li>
												<li data-target="#step4" class="active">
													<span class="badge">4</span>Info Participantes<span class="chevron"></span>
												</li>
												<li data-target="#step5">
													<span class="badge">5</span>Finalizado<span class="chevron"></span>
												</li>
											</ul>
											<div class="actions">
												<asp:LinkButton ID="AddProyectBtn" runat="server" class="btn btn-sm btn-success btn-next" OnClick="AddProyectBtn_Click">Siguiente <i class="fa fa-arrow-right"></i></asp:LinkButton>
											</div>
										</div>
										<div class="step-content">
											<div class="form-horizontal" id="fuelux-wizard" >
				
				

												<div class="step-pane active" id="step4">
													<h3><strong>Paso 4 </strong> - Información Responsables...</h3>
													<br>
													<br>
						                            <div id="smart-form-register" class="smart-form">

							                            <fieldset>
								                            <div class="row">
									                            <section class="col col-4">
										                            <label class="select"> <i class="icon-append fa fa-user"></i>
											                            <asp:DropDownList ID="cmbGerente" runat="server" OnSelectedIndexChanged="cmbGerente_SelectedIndexChanged" AutoPostBack="true">
											                            </asp:DropDownList> <i></i> </label>
                                                                        <div class="note note-error"><asp:RequiredFieldValidator ID="gerenteValidator" runat="server" ControlToValidate="cmbGerente" SetFocusOnError="true" InitialValue="0" ErrorMessage="Selección de gerente es requerido" ForeColor="Red"></asp:RequiredFieldValidator></div>
									                            </section>
								                            </div>
								                            <div class="row">
									                            <section class="col col-4">
										                            <label class="select"> <i class="icon-append fa fa-user"></i>
											                            <asp:DropDownList ID="cmbEjecutivo" runat="server">
											                            </asp:DropDownList> <i></i> </label>
                                                                        <div class="note note-error"><asp:RequiredFieldValidator ID="ejecutivoValidator" runat="server" ControlToValidate="cmbEjecutivo" SetFocusOnError="true" InitialValue="0" ErrorMessage="Selección de ejecutivo es requerido" ForeColor="Red"></asp:RequiredFieldValidator></div>
									                            </section>
								                            </div>
								                            <div class="row">
									                            <section class="col col-4">
										                            <label class="select"> <i class="icon-append fa fa-building"></i>
											                            <asp:DropDownList ID="cmbCliente" runat="server">
											                            </asp:DropDownList> <i></i> </label>
                                                                        <div class="note note-error"><asp:RequiredFieldValidator ID="clienteValidator" runat="server" ControlToValidate="cmbCliente" SetFocusOnError="true" InitialValue="0" ErrorMessage="Selección de cliente es requerido" ForeColor="Red"></asp:RequiredFieldValidator></div>
									                            </section>
								                            </div>
								                            <div class="row">
									                            <section class="col col-4">
										                            <label class="select"> <i class="icon-append fa fa-star"></i>
											                            <asp:DropDownList ID="cmbProspecto" runat="server">
											                            </asp:DropDownList> <i></i> </label>
                                                                        <div class="note note-error"><asp:RequiredFieldValidator ID="prospectoValidator" runat="server" ControlToValidate="cmbProspecto" SetFocusOnError="true" InitialValue="0" ErrorMessage="Selección de quién prospectó es requerido" ForeColor="Red"></asp:RequiredFieldValidator></div>
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
