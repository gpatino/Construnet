<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ActualizarCatalogoSector.aspx.cs" Inherits="ConstrunetUnlimited.ActualizarCatalogoSector" %>
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
					<li>Home</li><li>Administración</li><li>Catálogos</li><li>Aplicación</li><li><a href="CatalogoSectoresEconomicos.aspx"> Sectores Económicos</a></li>
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
				            Actualizar Sector Económico
		                </h1>
	            </div>
	
            </div>

            <% if ((String)Session["resultadoProceso"] == "1")  {%>
            <div class="alert alert-block alert-success">
	            <a class="close" data-dismiss="alert" href="#">×</a>
	            <h4 class="alert-heading"><i class="fa fa-check-square-o"></i> Actualización Exitosa!</h4>
	            <p>
                    <asp:Label ID="lMessage" runat="server" ></asp:Label>
	            </p>
            </div>
            <%} %>
            <% else if ((String)Session["resultadoProceso"] == "2")  {%>
            <div class="alert alert-block alert-warning">
	            <a class="close" data-dismiss="alert" href="#">×</a>
	            <h4 class="alert-heading"><i class="fa fa-check-square-o"></i> Actualización fallida!</h4>
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
					            <h2>Actualizar información </h2>				
					
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
								            
							            </header>

							            <fieldset>
								            <div class="row">
									            <section class="col col-3">
									                <label class="input"> <i class="icon-append fa fa-pencil"></i>
										                <asp:TextBox ID="sectortxt" runat="server" placeholder="Nombre del Sector Económico" ></asp:TextBox></label>
                                                        <div class="note note-error"><asp:RequiredFieldValidator ID="sectorValidator" runat="server" ControlToValidate="sectortxt" SetFocusOnError="true" InitialValue="" ErrorMessage="Ingresar Sector Económico es requerido" ForeColor="Red"></asp:RequiredFieldValidator></div>
									            </section>
								            </div>
								            <div class="row">
									            <section class="col col-3">
									                <label class="input"> <i class="icon-append fa fa-pencil"></i>
                                                        <asp:DropDownList ID="CmbActivo" runat="server" placeholder="Estatus del Sector Económico" >
                                                            <asp:ListItem Value="1" Text="Habilitado"></asp:ListItem>
                                                            <asp:ListItem Value="0" Text="Deshabilitado"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </label>
									            </section>
								            </div>
							            </fieldset>

							            <footer>
                                            <asp:Button ID="UpdateSectorBtn" runat="server" Text="Registrar" OnClick="UpdateSectorBtn_Click" CssClass="btn btn-success" />
                                            <asp:HyperLink ID="EndButton" runat="server" Text="Finalizar" CssClass="btn btn-success" NavigateUrl="~/CatalogoSectoresEconomicos.aspx"/>
                                            <asp:HyperLink ID="CancelButton" runat="server" Text="Cancelar" CssClass="btn btn-danger" NavigateUrl="~/CatalogoSectoresEconomicos.aspx"/>
							            </footer>
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


</asp:Content>
