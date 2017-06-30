<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddProyecto2.aspx.cs" Inherits="ConstrunetUnlimited.AddProyecto2" %>

<asp:Content ID="headerMaps" ContentPlaceHolderID="cphHeader" runat="server">
    <style type="text/css">
      #map { height: 500px;
             width: 500px;
      }
       #pac-input {
          background-color: #fff;
          font-family: Roboto;
          font-size: 15px;
          font-weight: 300;
          margin-left: 12px;
          padding: 0 11px 0 13px;
          text-overflow: ellipsis;
          width: 300px;
        }

        #pac-input:focus {
          border-color: #4d90fe;
        }

        .pac-container {
          font-family: Roboto;
        }
    </style>
    <script src="//code.jquery.com/jquery-1.10.2.js"></script>
    <script type="text/javascript">
        var tipo = 1;
    </script>
    <script src="Scripts/GMapJS.js"></script>
</asp:Content>
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
													<span class="badge">1</span>Info Proyecto<span class="chevron"></span>
												</li>
												<li data-target="#step2" class="active">
													<span class="badge badge-info">2</span>Info Ubicación<span class="chevron"></span>
												</li>
												<li data-target="#step3">
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
								
												<div class="step-pane active" id="step2">
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
										                            <asp:TextBox ID="domiciliotxt" runat="server" placeholder="Domicilio" TextMode="SingleLine" MaxLength="80" ></asp:TextBox></label>
                                                                    <div class="note note-error"><asp:RequiredFieldValidator ID="domicilioValidator" runat="server" ControlToValidate="domiciliotxt" SetFocusOnError="true" InitialValue="" ErrorMessage="Ingresar domicilio es requerido" ForeColor="Red"></asp:RequiredFieldValidator></div>
									                            </section>
								                            </div>
								                            <div class="row">
									                            <section class="col col-4">
    									                            <label class="input"> <i class="icon-append fa fa-home"></i>
										                            <asp:TextBox ID="coloniatxt" runat="server" placeholder="Colonia" TextMode="SingleLine" MaxLength="30" ></asp:TextBox></label>
                                                                    <div class="note note-error"><asp:RequiredFieldValidator ID="ValidatorColonia" runat="server" ControlToValidate="coloniatxt" SetFocusOnError="true" InitialValue="" ErrorMessage="Ingresar colonia es requerido" ForeColor="Red"></asp:RequiredFieldValidator></div>
									                            </section>
								                            </div>
                                                            <div class="row">
								                                <section class="col col-4">
    									                            <label class="input"> <i class="icon-append fa fa-map-marker"></i>
										                            <asp:TextBox ID="cptxt" runat="server" placeholder="C.P." TextMode="SingleLine" MaxLength="5"></asp:TextBox></label>
                                                                    <div class="note note-error"><asp:RequiredFieldValidator ID="CPValidator" runat="server" ControlToValidate="cptxt" SetFocusOnError="true" InitialValue="" ErrorMessage="Ingresar código postal es requerido" ForeColor="Red"></asp:RequiredFieldValidator></div>
								                                </section>
                                                            </div>
							                            </fieldset>
							                            <fieldset>
								                            <div class="row">
									                            <section class="col col-4">
										                            <label class="select"> <i class="icon-append fa fa-map-marker"></i>
											                            <asp:DropDownList ID="cmbZonaVenta" runat="server">
											                            </asp:DropDownList> <i></i> </label>
                                                                        <div class="note note-error"><asp:RequiredFieldValidator ID="zonaValidator" runat="server" ControlToValidate="cmbZonaVenta" SetFocusOnError="true" InitialValue="0" ErrorMessage="Selección de Zona de Venta es requerido" ForeColor="Red"></asp:RequiredFieldValidator></div>
									                            </section>
								                            </div>
                                                        </fieldset>
							                            <fieldset>
								                            <div class="row">
									                            <section class="col col-4">
                                                                    <!-- Lugar de despliegue del mapa -->                                            
                                                                   <div id="map"></div>
                                                                    <input id="pac-input" class="controls" type="text" placeholder="Search Box">
                                                                    <input id="latlong" type="hidden" >
                                                                    <input id="idproyectomapa" value="<%= Convert.ToString(Session["idproyectomapa"]) %>" type="hidden">
                                                                    <br />
                                                                    <input type="button" value="Guardar GPS" class="btn btn-ribbon" onclick="irCoor();" />
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
        <script async defer
            src="https://maps.googleapis.com/maps/api/js?key=AIzaSyD5Waq2ngNt8trJJ8bBq1V6wxqnSsWuWTA&libraries=places&callback=AutoinitMap">
        </script>
</asp:Content>
