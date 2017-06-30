<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ActualizarPassword.aspx.cs" Inherits="ConstrunetUnlimited.ActualizarPassword" %>

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
					<li>Home</li><li>Administración</li><li><a href="Usuarios.aspx">Usuarios</a></li><li>Actualizar Password</li>
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
				            Actualizar Password
		                </h1>
	            </div>
	
            </div>

            <% if ((String)Session["resultadoProceso"] == "1")  {%>
            <div class="alert alert-block alert-success">
	            <a class="close" data-dismiss="alert" href="#">×</a>
	            <h4 class="alert-heading"><i class="fa fa-check-square-o"></i> Modificación exitosa!</h4>
	            <p>
                    <asp:Label ID="lMessage" runat="server" ></asp:Label>
	            </p>
            </div>
            <%} %>
            <% else if ((String)Session["resultadoProceso"] == "2")  {%>
            <div class="alert alert-block alert-warning">
	            <a class="close" data-dismiss="alert" href="#">×</a>
	            <h4 class="alert-heading"><i class="fa fa-check-square-o"></i> Modificación fallida!</h4>
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
					            <h2>Actualizar Password </h2>				
					
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
								            Password
							            </header>

							            <fieldset>
                                            <div class="row">
								            <section class="col col-4">
									            <label class="input"> <i class="icon-append fa fa-lock"></i>
										            <asp:TextBox ID="tpassword" runat="server" TextMode="Password" placeholder="Password"></asp:TextBox>
										            <b class="tooltip tooltip-bottom-right">Don't forget your password</b> </label>
                                                    <div class="note note-error"><asp:RequiredFieldValidator ID="passwordValidator" runat="server" ControlToValidate="tpassword" SetFocusOnError="true" InitialValue="" ErrorMessage="Ingresar un password es requerido" ForeColor="Red"></asp:RequiredFieldValidator></div>
								            </section>

								            <section class="col col-4">
									            <label class="input"> <i class="icon-append fa fa-lock"></i>
										            <asp:TextBox ID="tconfirmpassword" runat="server" TextMode="Password" placeholder="Confirm password"></asp:TextBox>
										            <b class="tooltip tooltip-bottom-right">Don't forget your password</b> </label>
                                                    <div class="note note-error">
                                                        <asp:RequiredFieldValidator ID="confirmpasswordValidator" runat="server" ControlToValidate="tconfirmpassword" SetFocusOnError="true" InitialValue="" ErrorMessage="Ingresar una confirmación de password es requerido" ForeColor="Red"></asp:RequiredFieldValidator>
                                                        <asp:CompareValidator ID="PasswordCompareValidator" runat="server" ControlToValidate="tconfirmpassword" CssClass="text-danger" ControlToCompare="tpassword" ErrorMessage="Confirmación no coincide" ToolTip="Password deben ser el mismo" SetFocusOnError="true"></asp:CompareValidator>
                                                    </div>
								            </section>
                                            </div>
							            </fieldset>


							            <footer>
                                            <asp:Button ID="UpdateButton" runat="server" Text="Actualizar password" OnClick="UpdateButton_Click" CssClass="btn btn-success" />
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
