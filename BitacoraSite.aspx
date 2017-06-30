<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BitacoraSite.aspx.cs" Inherits="ConstrunetUnlimited.BitacoraSite" %>

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
					<li>Home</li><li>Administración</li><li>Bitácora</li>
				</ol>
				<!-- end breadcrumb -->

			</div>
			<!-- END RIBBON -->

			<!-- MAIN CONTENT -->
			<div id="content">

				<div class="row">
					<div class="col-xs-12 col-sm-7 col-md-7 col-lg-4">
						<h1 class="page-title txt-color-blueDark">
							<i class="fa fa-table fa-fw "></i> 
								Bitácora
						</h1>
					</div>
				</div>
				
				<!-- widget grid -->
				<section id="widget-grid" class="">
				
					<!-- row -->
					<div class="row">
				
						<!-- NEW WIDGET START -->
						<article class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
				
							<!-- Widget ID (each widget will need unique ID)-->
							<div class="jarviswidget jarviswidget-color-darken" id="wid-id-0" data-widget-editbutton="false">

								<header>
									<span class="widget-icon"> <i class="fa fa-table"></i> </span>
									<h2>Bitácora</h2>
				
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
							            <fieldset>
								            <div class="row">
									            <section class="col col-4">
										            <label class="input"> <i class="icon-append fa fa-calendar"></i>
                                                        <asp:TextBox ID="TfechaInicio" runat="server" placeholder="Fecha Inicio" class="datepicker" data-dateformat='mm/dd/yy'></asp:TextBox>
										            </label>
                                                    <div class="note note-error"><asp:RequiredFieldValidator ID="fechaInicioValidator" runat="server" ControlToValidate="TfechaInicio" SetFocusOnError="true" InitialValue="" ErrorMessage="Ingrese una fecha de Inicio" ForeColor="Red"></asp:RequiredFieldValidator></div>
									            </section>

									            <section class="col col-4">
										            <label class="input"> <i class="icon-append fa fa-calendar"></i>
                                                        <asp:TextBox ID="TfechaFin" runat="server" placeholder="Fecha Fin" class="datepicker" data-dateformat='mm/dd/yy'></asp:TextBox>
										            </label>
                                                    <div class="note note-error"><asp:RequiredFieldValidator ID="fechaFinValidator" runat="server" ControlToValidate="TfechaFin" SetFocusOnError="true" InitialValue="" ErrorMessage="Ingrese una fecha de fin" ForeColor="Red"></asp:RequiredFieldValidator></div>
									            </section>
                                            </div>
                                            <div class="row">
									            <section class="col col-4">
										            <label class="select">
											            <asp:DropDownList ID="cmbUsers" runat="server">
                                                            <asp:ListItem Selected="True" Text="Seleccione una opción" Value="0" Enabled="true"></asp:ListItem>
											            </asp:DropDownList> <i></i> </label><asp:Label ID="rsltlbl" runat="server" Visible="false"></asp:Label>
									            </section>
									            <section class="col col-4">
										            <label class="select">
											            <asp:DropDownList ID="cmbAcciones" runat="server">
                                                            <asp:ListItem Value="0" Text="Acciones"></asp:ListItem>
											            </asp:DropDownList> <i></i> </label>
									            </section>
								            </div>
							            </fieldset>
							            <footer>
                                            <asp:Button ID="BitacoraButton" runat="server" class="btn btn-success" Text="Buscar" OnClick="BitacoraButton_Click" ></asp:Button>
							            </footer>
                                    </div>

                                    <div class="DocumentScroll">

                                        <asp:Repeater ID="rptBitacora" runat="server">
                                            <HeaderTemplate>
										        <table id="dt_basic" class="table table-striped table-bordered table-hover" width="100%">
											        <thead>			                
												    <tr>
													    <th style="text-align:center" data-hide="phone">Id</th>
													    <th style="text-align:center"> Fecha</th>
													    <th style="text-align:center"> Usuario</th>
													    <th style="text-align:center"> Perfil</th>
													    <th style="text-align:center"> Page</th>
													    <th style="text-align:center"> Acción</th>
													    <th style="text-align:center"> Detalle</th>
												    </tr>
											    </thead>
											    <tbody>
                                            </HeaderTemplate>
                                            <ItemTemplate>  
												<tr>
													<td style="text-align:center"><%# Eval("IdBitacora")  %></td>
													<td style="text-align:center"><%# Eval("fecha", "{0:G}") %></td>
													<td style="text-align:center"><%# Eval("nombreCompleto") %></td>
													<td style="text-align:center"><%# Eval("nombreRol") %></td>
													<td style="text-align:center"><%# Eval("webpage") %></td>
													<td style="text-align:center"><%# Eval("accion") %></td>
													<td style="text-align:center"><%# Eval("descripcion") %></td>
                                            </ItemTemplate>
                                            <FooterTemplate>
												</tr>
											    </tbody>
										        </table>
                                            </FooterTemplate>
                                        </asp:Repeater>

                                    </div>    
                                        <br /><br /><br />

                                    </div>
                                    <p style="text-align:center"> <br />
                                        <asp:LinkButton ID="ExporttoExcelBtn" runat="server" OnClick="ExporttoExcelBtn_Click" Class="btn btn-info"><i class="fa fa-file-excel-o"></i>&nbsp;Exportar a Excel</asp:LinkButton>
                                    </p>
                                    <br /><br />

									<!-- end widget content -->
                                    <br /><br />
								</div>
								<!-- end widget div -->
							</div>
							<!-- end widget -->
								
						</article>
						<!-- WIDGET END -->


				
					</div>
				
					<!-- end row -->
				
				</section>
				<!-- end widget grid -->

			</div>
			<!-- END MAIN CONTENT -->

		</div>
		<!-- END MAIN PANEL -->

		<!--================================================== -->

		<!-- PACE LOADER - turn this on if you want ajax loading to show (caution: uses lots of memory on iDevices)-->
		<script data-pace-options='{ "restartOnRequestAfter": true }' src="js/plugin/pace/pace.min.js"></script>

		<!-- Link to Google CDN's jQuery + jQueryUI; fall back to local -->
		<script src="http://ajax.googleapis.com/ajax/libs/jquery/2.0.2/jquery.min.js"></script>
		<script>
		    if (!window.jQuery) {
		        document.write('<script src="js/libs/jquery-2.0.2.min.js"><\/script>');
		    }
		</script>

		<script src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.10.3/jquery-ui.min.js"></script>
		<script>
		    if (!window.jQuery.ui) {
		        document.write('<script src="js/libs/jquery-ui-1.10.3.min.js"><\/script>');
		    }
		</script>

		<!-- IMPORTANT: APP CONFIG -->
		<script src="js/app.config.js"></script>


		<!-- PAGE RELATED PLUGIN(S) -->
		<script src="js/plugin/datatables/jquery.dataTables.min.js"></script>
		<script src="js/plugin/datatables/dataTables.colVis.min.js"></script>
		<script src="js/plugin/datatables/dataTables.tableTools.min.js"></script>
		<script src="js/plugin/datatables/dataTables.bootstrap.min.js"></script>
		<script src="js/plugin/datatable-responsive/datatables.responsive.min.js"></script>


		<script type="text/javascript">

		    // DO NOT REMOVE : GLOBAL FUNCTIONS!

		    $(document).ready(function () {

		        pageSetUp();

		        /* // DOM Position key index //
            
                l - Length changing (dropdown)
                f - Filtering input (search)
                t - The Table! (datatable)
                i - Information (records)
                p - Pagination (paging)
                r - pRocessing 
                < and > - div elements
                <"#id" and > - div with an id
                <"class" and > - div with a class
                <"#id.class" and > - div with an id and class
                
                Also see: http://legacy.datatables.net/usage/features
                */

		        /* BASIC ;*/
		        var responsiveHelper_dt_basic = undefined;

		        var breakpointDefinition = {
		            tablet: 1024,
		            phone: 480
		        };

		        $('#dt_basic').dataTable({
		            "sDom": "<'dt-toolbar'<'col-xs-12 col-sm-6'f><'col-sm-6 col-xs-12 hidden-xs'>r>" +
						"t" +
						"<'dt-toolbar-footer'<'col-sm-6 col-xs-12 hidden-xs'l i><'col-xs-12 col-sm-6'p>>",
		            "autoWidth": true,
		            "preDrawCallback": function () {
		                // Initialize the responsive datatables helper once.
		                if (!responsiveHelper_dt_basic) {
		                    responsiveHelper_dt_basic = new ResponsiveDatatablesHelper($('#dt_basic'), breakpointDefinition);
		                }
		            },
		            "rowCallback": function (nRow) {
		                responsiveHelper_dt_basic.createExpandIcon(nRow);
		            },
		            "drawCallback": function (oSettings) {
		                responsiveHelper_dt_basic.respond();
		            }
		        });

		        /* END BASIC */

		    })

		</script>

</asp:Content>
