<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddEmpresa.aspx.cs" Inherits="ConstrunetUnlimited.AddEmpresa" %>

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
					<li>Home</li><li>Proyectos</li><li><a href="Empresas.aspx"> Empresas</a></li><li>Agregar Empresa</li>
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
				            Agregar Empresa
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
					            <h2>Ingresar información </h2>				
					
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
										                <asp:TextBox ID="empresatxt" runat="server" placeholder="Nombre de la Empresa" AutoPostBack="true" OnTextChanged="empresatxt_TextChanged" ></asp:TextBox></label>
                                                        <div class="note note-error"><asp:RequiredFieldValidator ID="empresaValidator" runat="server" ControlToValidate="empresatxt" SetFocusOnError="true" InitialValue="" ErrorMessage="Ingresar Empresa es requerido" ForeColor="Red"></asp:RequiredFieldValidator></div>
									            </section>
                                                <section class="col col-3">
                                                     <asp:Repeater ID="rptEmpresas" runat="server" Visible="false">
                                                            <HeaderTemplate>
										                        <br /><br />
                                                                <table id="dt_basic" class="table table-striped table-bordered table-hover" >
											                        <thead>			                
												                    <tr>
													                    <th style="text-align:center" data-hide="phone">Id</th>
													                    <th style="text-align:center"> Empresa</th>
												                    </tr>
											                    </thead>
											                    <tbody>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>  
												                <tr>
													                <td style="text-align:center"><%# Eval("IdEmpresa") %></td>
													                <td style="text-align:center"><%# Eval("nombreEmpresa") %></td>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
												                </tr>
											                    </tbody>
										                        </table>
                                                            </FooterTemplate>
                                                        </asp:Repeater>
                                                </section>
								            </div>
								            <div class="row">
									            <section class="col col-4">
										            <label class="select"> <i class="icon-append fa fa-wrench"></i>
											            <asp:DropDownList ID="cmbClasificacion" runat="server">
                                                            <asp:ListItem Value="0" Text="Clasificación de Empresa"></asp:ListItem>
											            </asp:DropDownList> <i></i> </label>
                                                        <div class="note note-error"><asp:RequiredFieldValidator ID="clasificacionValidator" runat="server" ControlToValidate="cmbClasificacion" SetFocusOnError="true" InitialValue="0" ErrorMessage="Selección de Clasificación es requerido" ForeColor="Red"></asp:RequiredFieldValidator></div>
									            </section>
								            </div>
								            <div class="row">
									            <section class="col col-4">
										            <label class="select"> <i class="icon-append fa fa-wrench"></i>
											            <asp:DropDownList ID="cmbTipoEmpresa" runat="server">
                                                            <asp:ListItem Value="0" Text="Tipo de Empresa"></asp:ListItem>
											            </asp:DropDownList> <i></i> </label>
                                                        <div class="note note-error"><asp:RequiredFieldValidator ID="tipoempresaValidator" runat="server" ControlToValidate="cmbTipoEmpresa" SetFocusOnError="true" InitialValue="0" ErrorMessage="Selección de Tipo Empresa es requerido" ForeColor="Red"></asp:RequiredFieldValidator></div>
									            </section>
								            </div>
								            <div class="row">
									            <section class="col col-4">
										            <label class="select"> <i class="icon-append fa fa-wrench"></i>
											            <asp:DropDownList ID="cmbZonaVentas" runat="server">
                                                            <asp:ListItem Value="0" Text="Zona de Ventas"></asp:ListItem>
											            </asp:DropDownList> <i></i> </label>
                                                        <div class="note note-error"><asp:RequiredFieldValidator ID="zonaValidator" runat="server" ControlToValidate="cmbZonaVentas" SetFocusOnError="true" InitialValue="0" ErrorMessage="Selección de Zona de Ventas es requerido" ForeColor="Red"></asp:RequiredFieldValidator></div>
									            </section>
								            </div>
							            </fieldset>

							            <fieldset>
								            <div class="row">
									            <section class="col col-3">
									                <label class="input"> <i class="icon-append fa fa-pencil"></i>
										                <asp:TextBox ID="domiciliotxt" runat="server" placeholder="Domicilio" ></asp:TextBox></label>
                                                        <div class="note note-error"><asp:RequiredFieldValidator ID="domicilioValidator" runat="server" ControlToValidate="domiciliotxt" SetFocusOnError="true" InitialValue="" ErrorMessage="Ingresar Domicilio es requerido" ForeColor="Red"></asp:RequiredFieldValidator></div>
									            </section>
								            </div>
								            <div class="row">
									            <section class="col col-3">
									                <label class="input"> <i class="icon-append fa fa-pencil"></i>
										                <asp:TextBox ID="coloniatxt" runat="server" placeholder="Colonia" ></asp:TextBox></label>
									            </section>
								            </div>
								            <div class="row">
									            <section class="col col-3">
									                <label class="input"> <i class="icon-append fa fa-pencil"></i>
										                <asp:TextBox ID="municipiotxt" runat="server" placeholder="Municipio" ></asp:TextBox></label>
									            </section>
								            </div>
								            <div class="row">
									            <section class="col col-3">
									                <label class="input"> <i class="icon-append fa fa-pencil"></i>
										                <asp:TextBox ID="cptxt" runat="server" placeholder="Código Postal" ></asp:TextBox></label>
									            </section>
								            </div>
								            <div class="row">
									            <section class="col col-4">
										            <label class="select"> <i class="icon-append fa fa-wrench"></i>
											            <asp:DropDownList ID="cmbEstado" runat="server">
                                                            <asp:ListItem Value="0" Text="Entidad Federativa"></asp:ListItem>
											            </asp:DropDownList> <i></i> </label>
                                                        <div class="note note-error"><asp:RequiredFieldValidator ID="estadoValidator" runat="server" ControlToValidate="cmbEstado" SetFocusOnError="true" InitialValue="0" ErrorMessage="Selección de Entidad Federativa es requerido" ForeColor="Red"></asp:RequiredFieldValidator></div>
									            </section>
								            </div>
							            </fieldset>

							            <footer>
                                            <asp:Button ID="AddEmpresaBtn" runat="server" Text="Registrar" OnClick="AddEmpresaBtn_Click" CssClass="btn btn-success" />
                                            <asp:HyperLink ID="EndButton" runat="server" Text="Finalizar" CssClass="btn btn-success" NavigateUrl="~/Empresas.aspx"/>
                                            <asp:HyperLink ID="CancelButton" runat="server" Text="Cancelar" CssClass="btn btn-danger" NavigateUrl="~/Empresas.aspx"/>
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
