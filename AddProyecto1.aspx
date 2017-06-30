<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddProyecto1.aspx.cs" Inherits="ConstrunetUnlimited.AddProyecto1" %>

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
												<asp:LinkButton ID="AddProyectBtn" runat="server" class="btn btn-sm btn-success btn-next" OnClick="AddProyectBtn_Click" >Siguiente <i class="fa fa-arrow-right"></i></asp:LinkButton>
											</div>
										</div>
										<div class="step-content">
											<div class="form-horizontal" id="fuelux-wizard" >
				
												<div class="step-pane active" id="step1">
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
										                            <asp:TextBox ID="fecharegistrotxt" runat="server" placeholder="Fecha Registro" class="datepicker" data-dateformat='dd/mm/yy'></asp:TextBox></label>
                                                                    <div class="note note-error"><asp:RequiredFieldValidator ID="fechaValidator" runat="server" ControlToValidate="fecharegistrotxt" SetFocusOnError="true" InitialValue="" ErrorMessage="Ingresar fecha es requerido" ForeColor="Red"></asp:RequiredFieldValidator></div>
								                                </section>
                                                            </div>
							                            </fieldset>

							                            <fieldset>
								                            <div class="row">
									                            <section class="col col-4">
										                            <label class="select"> <i class="icon-append fa fa-wrench"></i>
											                            <asp:DropDownList ID="cmbTipoObra" runat="server" AutoPostBack="true" OnSelectedIndexChanged="cmbTipoObra_SelectedIndexChanged">
											                            </asp:DropDownList> <i></i> </label>
                                                                        <div class="note note-error"><asp:RequiredFieldValidator ID="tipoObraValidator" runat="server" ControlToValidate="cmbTipoObra" SetFocusOnError="true" InitialValue="0" ErrorMessage="Selección de Tipo de Obra es requerido" ForeColor="Red"></asp:RequiredFieldValidator></div>
									                            </section>
									                            <section class="col col-4">
										                            <label class="select"> <i class="icon-append fa fa-wrench"></i>
											                            <asp:DropDownList ID="cmbEtapaProyecto" runat="server" >
											                            </asp:DropDownList> <i></i> </label>
                                                                        <div class="note note-error"><asp:RequiredFieldValidator ID="etapaobraValidator" runat="server" ControlToValidate="cmbEtapaProyecto" SetFocusOnError="true" InitialValue="0" ErrorMessage="Selección de Etapa de Proyecto es requerido" ForeColor="Red"></asp:RequiredFieldValidator></div>
									                            </section>
								                            </div>
								                            <div class="row">
									                            <section class="col col-4">
										                            <label class="select"> <i class="icon-append fa fa-wrench"></i>
											                            <asp:DropDownList ID="cmbEstatus" runat="server" >
											                            </asp:DropDownList> <i></i> </label>
                                                                        <div class="note note-error"><asp:RequiredFieldValidator ID="estatusValidator" runat="server" ControlToValidate="cmbEstatus" SetFocusOnError="true" InitialValue="0" ErrorMessage="Selección de Estatus de Proyecto es requerido" ForeColor="Red"></asp:RequiredFieldValidator></div>
									                            </section>
								                                <section class="col col-4">
										                            <label class="select"> <i class="icon-append fa fa-wrench"></i>
											                            <asp:DropDownList ID="cmbSector" runat="server" >
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
											                            </asp:DropDownList> <i></i> </label>
                                                                        <div class="note note-error"><asp:RequiredFieldValidator ID="empresaValidator" runat="server" ControlToValidate="cmbEmpresaRaiz" SetFocusOnError="true" InitialValue="0" ErrorMessage="Selección de Empresa es requerido" ForeColor="Red"></asp:RequiredFieldValidator></div>
									                            </section>
								                                <section class="col col-6">
										                            <label class="select"> <i class="icon-append fa fa-wrench"></i>
											                            <asp:DropDownList ID="cmbEmpresasContratista" runat="server" >
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
    									                            <label class="select"> <i class="icon-append fa fa-usd"></i>
                                                                    <asp:ListBox ID="CmbInversion" runat="server" placeholder="Inversión estimada" SelectionMode="Single" Rows="1">
                                                                    </asp:ListBox><i></i></label>
                                                                    <div class="note note-error"><asp:RequiredFieldValidator ID="InversionValidator" runat="server" ControlToValidate="CmbInversion" SetFocusOnError="true" InitialValue="0" ErrorMessage="Selección de rando de inversión es requerido" ForeColor="Red"></asp:RequiredFieldValidator></div>
								                                </section>
                                                            </div>
							                            </fieldset>
				                                    </div>
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

		<!-- PAGE RELATED PLUGIN(S) -->
		<script src="js/plugin/jquery-form/jquery-form.min.js"></script>
		
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
		                title: "¡Felicidades! Proyecto ingresado",
		                content: "<i class='fa fa-clock-o'></i> <i>1 seconds ago...</i>",
		                color: "#5F895F",
		                iconSmall: "fa fa-check bounce animated",
		                timeout: 4000
		            });

		        });
		    })

		</script>

</asp:Content>
