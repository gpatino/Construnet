﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BusquedaDistribuidor.aspx.cs" Inherits="ConstrunetUnlimited.BusquedaDistribuidor" %>
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
					<li>Home</li><li>Búsquedas</li><li>Búsqueda por Distribuidor</li>
				</ol>
				<!-- end breadcrumb -->

			</div>
			<!-- END RIBBON -->

			<!-- MAIN CONTENT -->
			<div id="content">

				<div class="row">
					<div class="col-xs-12 col-sm-7 col-md-7 col-lg-4">
						<h1 class="page-title txt-color-blueDark">
							<i class="fa fa-file fa-fw "></i> 
								Resumen Distribuidores
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
									<h2></h2>
				
								</header>
				
								<!-- widget div-->
								<div>
				
									<!-- widget edit box -->
									<div class="jarviswidget-editbox">
										<!-- This area used as dropdown edit box -->
				
									</div>
									<!-- end widget edit box -->
				
									<!-- widget content -->
									<div class="DocumentScroll">
									    <div class="widget-body no-padding">
                                            <asp:Repeater ID="ClientesRpt" runat="server">
                                                <HeaderTemplate>
                                                    <br />
										            <table id="dt_basic" class="table table-striped table-bordered table-hover" >
											            <thead>			                
												        <tr>
													        <th style="text-align:center" data-hide="phone">IdhCliente</th>
													        <th style="text-align:center"> Cliente</th>
													        <th style="text-align:center"> Estado</th>
													        <th style="text-align:center"> Zona</th>
													        <th style="text-align:center"> KAM</th>
													        <th style="text-align:center"> Número de Proyecto</th>
													        <th style="text-align:center"> Número de Cotizaciones</th>
													        <th style="text-align:center"> Total $ Cotizado Solicitado</th>
													        <th style="text-align:center"> Total $ Cotizado Determinado</th>
													        <th style="text-align:center"> Total $ Cotizado Facturado</th>
													        <th style="text-align:center"> Ver Cotizaciones </th>
												        </tr>
											        </thead>
											        <tbody>
                                                </HeaderTemplate>
                                                <ItemTemplate>  
												    <tr>
													    <td style="text-align:center"><%# Eval("idhcliente") %></td>
													    <td style="text-align:center"><%# Eval("cliente") %></td>
													    <td style="text-align:center"><%# Eval("estado") %></td>
													    <td style="text-align:center"><%# Eval("zona") %></td>
													    <td style="text-align:center"><%# Eval("nombreKam") %></td>
													    <td style="text-align:center"><%# Eval("numero_proyectos") %></td>
													    <td style="text-align:center"><%# Eval("numero_cotizaciones") %></td>
													    <td style="text-align:center"><%# Eval("monto_total_cotizado_solicitado", "{0:c}") %></td>
													    <td style="text-align:center"><%# Eval("monto_total_cotizado_determinado", "{0:c}") %></td>
													    <td style="text-align:center"><%# Eval("monto_total_cotizado_facturado", "{0:c}") %></td>
													    <td style="text-align:center"><a href="DetalleProyectosCliente.aspx?Id=<%# Eval("idhcliente") %>" class="btn btn-circle bg-color-blue txt-color-white"><i class="fa fa-search"></i></a></td>
                                                </ItemTemplate>
                                                <FooterTemplate>
												    </tr>
											        </tbody>
										            </table>
                                                </FooterTemplate>
                                            </asp:Repeater>
                                        
                                            <br /><br /><br />

                                        </div>
                                    </div>
									<!-- end widget content -->
                                    <p style="text-align:center"> 
                                        <asp:HyperLink ID="AddProyectoLnk" runat="server" class="btn btn-primary" NavigateUrl="~/AddProyecto1.aspx"><i class="fa fa-plus-circle"></i> Agregar Proyecto</asp:HyperLink>
                                        <asp:Label ID="lmensaje" runat="server"></asp:Label>
                                    </p>
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
		            "sDom": "<'dt-toolbar'<'col-xs-12 col-sm-6'f><'col-sm-6 col-xs-12 hidden-xs'l>r>" +
						"t" +
						"<'dt-toolbar-footer'<'col-sm-6 col-xs-12 hidden-xs'i><'col-xs-12 col-sm-6'p>>",
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
