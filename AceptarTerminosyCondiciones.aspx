<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AceptarTerminosyCondiciones.aspx.cs" Inherits="ConstrunetUnlimited.AceptarTerminosyCondiciones" %>
<!DOCTYPE html>
<html lang="en-us">
	<head>
		<meta charset="utf-8">
		<title> ::Construnet Advance::</title>
		<meta name="description" content="">
		<meta name="author" content="">
			
		<meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no">
		
		<!-- #CSS Links -->
		<!-- Basic Styles -->
		<link rel="stylesheet" type="text/css" media="screen" href="css/bootstrap.min.css">
		<link rel="stylesheet" type="text/css" media="screen" href="css/font-awesome.min.css">

		<!-- SmartAdmin Styles : Please note (smartadmin-production.css) was created using LESS variables -->
		<link rel="stylesheet" type="text/css" media="screen" href="css/smartadmin-production.min.css">
		<link rel="stylesheet" type="text/css" media="screen" href="css/smartadmin-skins.min.css">

		<!-- SmartAdmin RTL Support is under construction
			 This RTL CSS will be released in version 1.5
		<link rel="stylesheet" type="text/css" media="screen" href="css/smartadmin-rtl.min.css"> -->

		<!-- We recommend you use "your_style.css" to override SmartAdmin
		     specific styles this will also ensure you retrain your customization with each SmartAdmin update.
		<link rel="stylesheet" type="text/css" media="screen" href="css/your_style.css"> -->

		<!-- Demo purpose only: goes with demo.js, you can delete this css when designing your own WebApp -->
		<link rel="stylesheet" type="text/css" media="screen" href="css/demo.min.css">

		<!-- #FAVICONS -->
		<link rel="shortcut icon" href="img/favicon/favicon.ico" type="image/x-icon">
		<link rel="icon" href="img/favicon/favicon.ico" type="image/x-icon">

		<!-- #GOOGLE FONT -->
		<link rel="stylesheet" href="http://fonts.googleapis.com/css?family=Open+Sans:400italic,700italic,300,400,700">

		<!-- #APP SCREEN / ICONS -->
		<!-- Specifying a Webpage Icon for Web Clip 
			 Ref: https://developer.apple.com/library/ios/documentation/AppleApplications/Reference/SafariWebContent/ConfiguringWebApplications/ConfiguringWebApplications.html -->
		<link rel="apple-touch-icon" href="img/splash/sptouch-icon-iphone.png">
		<link rel="apple-touch-icon" sizes="76x76" href="img/splash/touch-icon-ipad.png">
		<link rel="apple-touch-icon" sizes="120x120" href="img/splash/touch-icon-iphone-retina.png">
		<link rel="apple-touch-icon" sizes="152x152" href="img/splash/touch-icon-ipad-retina.png">
		
		<!-- iOS web-app metas : hides Safari UI Components and Changes Status Bar Appearance -->
		<meta name="apple-mobile-web-app-capable" content="yes">
		<meta name="apple-mobile-web-app-status-bar-style" content="black">
		
		<!-- Startup image for web apps -->
		<link rel="apple-touch-startup-image" href="img/splash/ipad-landscape.png" media="screen and (min-device-width: 481px) and (max-device-width: 1024px) and (orientation:landscape)">
		<link rel="apple-touch-startup-image" href="img/splash/ipad-portrait.png" media="screen and (min-device-width: 481px) and (max-device-width: 1024px) and (orientation:portrait)">
		<link rel="apple-touch-startup-image" href="img/splash/iphone.png" media="screen and (max-device-width: 320px)">

	</head>

	<!--

	TABLE OF CONTENTS.
	
	Use search to find needed section.
	
	===================================================================
	
	|  01. #CSS Links                |  all CSS links and file paths  |
	|  02. #FAVICONS                 |  Favicon links and file paths  |
	|  03. #GOOGLE FONT              |  Google font link              |
	|  04. #APP SCREEN / ICONS       |  app icons, screen backdrops   |
	|  05. #BODY                     |  body tag                      |
	|  06. #HEADER                   |  header tag                    |
	|  07. #PROJECTS                 |  project lists                 |
	|  08. #TOGGLE LAYOUT BUTTONS    |  layout buttons and actions    |
	|  09. #MOBILE                   |  mobile view dropdown          |
	|  10. #SEARCH                   |  search field                  |
	|  11. #NAVIGATION               |  left panel & navigation       |
	|  12. #MAIN PANEL               |  main panel                    |
	|  13. #MAIN CONTENT             |  content holder                |
	|  14. #PAGE FOOTER              |  page footer                   |
	|  15. #SHORTCUT AREA            |  dropdown shortcuts area       |
	|  16. #PLUGINS                  |  all scripts and plugins       |
	
	===================================================================
	
	-->
	
	<!-- #BODY -->
	<!-- Possible Classes

		* 'smart-skin-{SKIN#}'
		* 'smart-rtl'         - Switch theme mode to RTL (will be avilable from version SmartAdmin 1.5)
		* 'menu-on-top'       - Switch to top navigation (no DOM change required)
		* 'hidden-menu'       - Hides the main menu but still accessable by hovering over left edge
		* 'fixed-header'      - Fixes the header
		* 'fixed-navigation'  - Fixes the main menu
		* 'fixed-ribbon'      - Fixes breadcrumb
		* 'fixed-footer'      - Fixes footer
		* 'container'         - boxed layout mode (non-responsive: will not work with fixed-navigation & fixed-ribbon)
	-->
	<body class="">
    <form runat="server">


		<!-- #HEADER -->
		<header id="header">
			<div id="logo-group">

				<!-- PLACE YOUR LOGO HERE -->
				<img src="Images/logohenkel.png" width="100%" alt="BiPolar V2">
				<!-- END LOGO PLACEHOLDER -->

				<!-- AJAX-DROPDOWN : control this dropdown height, look and feel from the LESS variable file -->
				<div class="ajax-dropdown">

	
				</div>
				<!-- END AJAX-DROPDOWN -->
			</div>

			<!-- #TOGGLE LAYOUT BUTTONS -->
			<!-- pulled right: nav area -->
			<div class="pull-right">
				
				<!-- collapse menu button -->
				<div id="hide-menu" class="btn-header pull-right">
					<span> <a href="javascript:void(0);" data-action="toggleMenu" title="Collapse Menu"><i class="fa fa-reorder"></i></a> </span>
				</div>
				<!-- end collapse menu -->
				

				<!-- logout button -->
				<div id="logout" class="btn-header transparent pull-right">
					<span> <a href="login.aspx" title="Sign Out" data-action="userLogout" data-logout-msg="You can improve your security further after logging out by closing this opened browser"><i class="fa fa-sign-out"></i></a> </span>
				</div>
				<!-- end logout button -->

				<!-- end search mobile button -->
				

				<!-- multiple lang dropdown : find all flags in the flags page -->
				<ul class="header-dropdown-list hidden-xs">
					<li>
						<a href="#" class="dropdown-toggle" data-toggle="dropdown"> <img src="img/blank.gif" class="flag flag-mx" alt="México"> <span> Español (MX) </span> <i class="fa fa-angle-down"></i> </a>
						<ul class="dropdown-menu pull-right">
							<li class="active">
								<a href="javascript:void(0);"><img src="img/blank.gif" class="flag flag-us" alt="United States"> English (US)</a>
							</li>
							<li>
								<a href="javascript:void(0);"><img src="img/blank.gif" class="flag flag-es" alt="Spanish"> Español</a>
							</li>
							<li>
								<a href="javascript:void(0);"><img src="img/blank.gif" class="flag flag-de" alt="German"> Deutsch</a>
							</li>
							<li>
								<a href="javascript:void(0);"><img src="img/blank.gif" class="flag flag-br" alt="Brazil"> Portuguese</a>
							</li>							
						</ul>
					</li>
				</ul>
				<!-- end multiple lang -->

			</div>
			<!-- end pulled right: nav area -->

		</header>
		<!-- END HEADER -->

		<!-- MAIN PANEL -->
		<div id="main" role="main">

			<!-- RIBBON -->
			<div id="ribbon">

			</div>
			<!-- END RIBBON -->
			
			

			<!-- MAIN CONTENT -->
			<div id="content">

				<!-- row -->
				<div class="row">
					
					<!-- col -->
					<div class="col-xs-12 col-sm-7 col-md-7 col-lg-4">
						<h1 class="page-title txt-color-blueDark">
							
							<!-- PAGE HEADER -->
							<i class="fa-fw fa fa-home"></i> 
								Bienvenido a Construnet Advance
						</h1>
					</div>
					<!-- end col -->
					
				</div>
				<!-- end row -->
				
				<!-- widget grid -->
				<section id="widget-grid" class="">
				
					<!-- row -->
					<div class="row">
						
						<!-- NEW WIDGET START -->
						<article class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
							
							<!-- Widget ID (each widget will need unique ID)-->
							<div >
								<header>
									<h2>Aviso de Privacidad y Acuerdo de Términos & Condiciones de Uso - Construnet Advance </h2>				
									
								</header>
				
								<!-- widget div-->
								<div>
									
									<!-- widget edit box -->
									<div class="jarviswidget-editbox">
										<!-- This area used as dropdown edit box -->
										<input class="form-control" type="text">	
									</div>
									<!-- end widget edit box -->
									
									<!-- widget content -->
									<div class="widget-body">

                                                   <table border="0" style="width:100%">
                                                       <tr>
                                                           <td colspan="2" style="text-align:left;height:30px;width:30%"><asp:label id="nombreUserLbl" runat="server" class="label label-info" Text="Estimado Usuari@, para poder utilizar la plataforma debe aceptar el Aviso de Privacidad y el Acuerdo de Uso y Condiciones de la Plataforma que a continuación se muestra." ></asp:label></td>
                                                       </tr>
                                                       <tr>
                                                           <td style="text-align:center;height:30px;width:300px">
                                                               <asp:TextBox ID="TextAvisoPrivacidad" runat="server" ReadOnly="true" Columns="200" Width="600" Rows="15" TextMode="MultiLine">Aspectos Generales

Henkel Capital, S.A. de C. V., en lo sucesivo Henkel, con domicilio en Boulevard Magnocentro 8 – 2 Centro Urbano Interlomas, Huixquilucan, Estado de México, C. P. 52,760, con correo electrónico aviso.privacidad@mx.henkel.com, manifiesta que respeta 
la privacidad de cada persona que visita los sitios web de Henkel y que es responsable de recabar sus datos personales, del uso que se le dé a los mismos y de su protección.
Henkel desea proporcionarle el máximo control posible sobre la información que le identifica a usted personalmente. También queremos informarle que usted puede ejercitar los derechos de acceso, rectificación, cancelación y oposición al 
tratamiento de sus datos personales, en los términos y condiciones previstos en la Ley Federal de Protección de Datos Personales en Posesión de los Particulares.

Henkel proporciona a los usuarios los recursos técnicos adecuados para que, con carácter previo, puedan acceder a esta Política de Privacidad y puedan prestar su consentimiento a fin de que Henkel proceda al tratamiento automatizado de sus datos personales.

Finalidades del Tratamiento de la Información
Henkel puede guardar y procesar sus datos personales para las siguientes finalidades:
1) Ayudar a establecer y verificar la identidad de los usuarios.
2)Aperturar, mantener, administrar y hacer el seguimiento de las cuentas o inscripciones de los usuarios.
3) Prestar servicio y asistencia a los usuarios.
4) Proporcionarle información acerca de oportunidades de empleo, administración del proceso de reclutamiento y considerarlo para un empleo si usted ha aplicado para alguna posición o enviarle vacantes que le podrían interesar, asimismo proporcionaremos sus datos a empresas del ramo que busquen vacantes de su perfil.
5) Para llevar a cabo rifas, sorteos, concursos, promociones y para proporcionar los resultados. Para proporcionar a los usuarios actualización de productos o servicios, avisos de promociones, ofertas y otro tipo de información de Henkel y de sus filiales.
6) Para mejorar el sitio web tomando en cuenta las preferencias de los usuarios.
7) Responder a sus preguntas, requerimientos, comentarios o sugerencias. Para mantener la seguridad y la integridad de nuestros sistemas.
8) Para entender mejor sus necesidades y el modo en el que podemos mejorar nuestros productos y servicios.
9) Para contactar con usted, incluso por medios electrónicos tales como correo electrónica, fax, mensajes a móviles u otros análogos, por ejemplo, para personalizar la información de los productos o servicios que le ofrezcamos, para poder enviarles materiales de marketing o promoción o para poder responder a sus comentarios o solicitudes de información.
10) En ocasiones Henkel podrá contactar a terceras personas para administrar o analizar la información que recabamos, incluyendo Información Personal, con la finalidad de ayudarnos a mejorar nuestros productos y nuestros sitios de Internet. Adicionalmente y en caso de que usted nos solicite algún producto o servicio, podríamos llegar a proporcionar su Información Personal a distribuidores o terceras personas con la finalidad de entregarle el producto o prestarle el servicio de que se trate o en su caso para que un tercero se ponga en contacto con usted con la finalidad de que éste lo ayude con su solicitud en caso de que nosotros no lo podamos hacer de manera directa. Estos terceros no tendrán autorización nuestra para utilizar su Información Personal de otra manera para la cual fue proporcionada.
                        
Para las finalidades señaladas en el presente aviso de privacidad, podemos recabar sus datos personales de distintas formas: cuando usted nos los proporciona directamente; cuando visita nuestro sitio de Internet o utiliza nuestros servicios en línea, y cuando obtenemos información a través de otras fuentes tales como los directorios telefónicos o laborales que están permitidas por la ley.

Es importante que usted esté enterado que Henkel no comercializa Información Personal.

El usuario garantiza que los datos personales facilitados a Henkel son veraces y se hace responsable de comunicar a ésta cualquier modificación en los mismos.

En cuanto a los formularios electrónicos de obtención de datos del sitio web, salvo en los campos en que se indique lo contrario, las respuestas a las preguntas sobre datos personales son voluntarias, sin que la falta de
contestación implique una merma en la calidad o cantidad de los servicios correspondientes, a menos que se indique otra cosa.

Seguridad

Henkel se compromete a tratar su Información Personal con la máxima la privacidad, confidencialidad y seguridad conforme a la Ley Federal de Protección de Datos Personales en Posesión de los Particulares, y a proteger razonablemente sus datos 
personales de la pérdida, mal uso, acceso no autorizado, alteración y destrucción.

La transmisión de la información de nosotros hacia usted y viceversa se encuentra encriptada ya que usamos conexiones seguras estándar que ayudan a proteger dicha información de intercepciones. Sin embargo, por favor esté consiente 
que cualquier correo electrónico u otra transmisión que usted mande por Internet no puede ser complemente protegida en contra de intercepciones no autorizadas.

Empresas externas a Henkel que tengan acceso a sus datos personales en relación con los servicios prestados a Henkel estarán obligados a mantener la información confidencial y no tendrán permiso para utilizar esta información para cualquier 
otra finalidad que no sea desempeñar los servicios que están realizando para Henkel.

Aceptación

Utilizando nuestro sitio web, usted se compromete a aceptar los términos y condiciones de nuestra actual Política de Privacidad tal como se explica en esta sección del sitio web. Si usted no acepta los términos y condiciones de esta Política 
de Privacidad, le rogamos que no suministre ningún dato de carácter personal a Henkel a través de este sitio web.

Henkel se reserva el derecho a modificar la presente Política de Privacidad para adaptarla a novedades legislativas o jurisprudenciales. El hecho de continuar utilizando el sitio web de Henkel después de haberse consignado cualesquiera cambios de 
esta Política de Privacidad significará que usted ha aceptado tales cambios.

Cuando usted nos suministre voluntariamente datos de carácter personal, nos está autorizando para utilizar dicha Información Personal de acuerdo con los términos y condiciones de nuestra Política de Privacidad.

Usted puede dejar de recibir mensajes promocionales por teléfono fijo o celular, correo postal publicitario, correo postal, correos electrónicos con promocionales, mandando un correo electrónico a la dirección: aviso.privacidad@mx.henkel.com, en donde le 
solicitamos explique su solicitud e inmediatamente le enviaremos un correo para dar seguimiento y solución a la misma.

Transferencia

Henkel podrá transmitir sus datos personales al resto de compañías de Henkel, con las mismas finalidades que se han indicado para la obtención de los datos personales por parte de Henkel en relación con sus respectivos productos y servicios.

En ciertos casos, se transmiten datos personales a terceras empresas dentro y fuera de México, para que proporcionen servicios en nuestro nombre. A estas compañías sólo se les proporcionará la información que necesiten para proporcionar el servicio, 
y se les prohibirá utilizar dicha información con cualquier otro propósito.

Las trasferencias las realizaremos de conformidad con la Ley Federal de Protección de Datos Personales en Posesión de los Particulares, publicada en el Diario Oficial de la Federación el 5 de julio del 2010 y nos comprometemos a no transferir su 
información personal a terceros sin su consentimiento, salvo las excepciones previstas en dicha Ley, que son.

* Cuando la transferencia esté prevista en una Ley o Tratado en los que México sea parte;
* Cuando la transferencia sea necesaria para la prevención o el diagnóstico médico, la prestación de asistencia sanitaria, tratamiento médico o la gestión de servicios sanitarios;
* Cuando la transferencia sea efectuada a sociedades controladoras, subsidiarias o afiliadas bajo el control común del responsable, o a una sociedad matriz o a cualquier sociedad del mismo grupo del responsable que opere bajo los mismos procesos y políticas internas;
* Cuando la transferencia sea necesaria por virtud de un contrato celebrado o por celebrar en interés del titular, por el responsable y un tercero;
* Cuando la transferencia sea necesaria o legalmente exigida para la salvaguarda de un interés público, o para la procuración o administración de justicia;
* Cuando la transferencia sea precisa para el reconocimiento, ejercicio o defensa de un derecho en un proceso judicial, y
* Cuando la transferencia sea precisa para el mantenimiento o cumplimiento de una relación jurídica entre el responsable y el titular.

Si usted no manifiesta su oposición para que sus datos personales sean transferidos, se entenderá que ha otorgado su consentimiento para ello.

Menores

Henkel pide a los padres o tutores que informen a los menores de edad acerca del uso responsable y seguro de sus datos de carácter personal cuando participen en actividades on-line.

Henkel no tiene intención de recoger Información Personal de menores de 18 años. Cuando sea preciso, Henkel dará instrucciones específicas a los menores para que no proporcionen datos de carácter personal en nuestros anuncios o sitios web.

Henkel podría recoger información personal de menores de 18 años. Cuando un menor de edad se identifica como tal, siempre incorporamos información con instrucciones al niño para que obtenga el consentimiento de sus padres o tutores antes de proporcionarnos cualquier dato de carácter personal.

Si el menor nos ha proporcionado datos de carácter personal, el padre o tutor del menor deberá ponerse en contacto con nosotros a través de nuestra dirección postal o de correo electrónico detallados en esta Política de Privacidad si desea que 
cancelemos dicha información de nuestros registros dedicaremos todos los esfuerzos razonables a nuestro alcance a fin de cancelar la información del menor de nuestras bases de datos.

Información no personal recogida automáticamente

Nuestro servicio web recoge automáticamente determinada información no personal sobre el uso de nuestro sitio web que se almacena en nuestros servidores para fines exclusivamente internos, como pueden ser facilitar su visita a nuestro sitio web, 
mejorar su experiencia on-line o para finalidades estadísticas de acceso.

Ejemplos de este tipo de información no personal incluyen el nombre de su proveedor de servicios de Internet, el tipo de navegador de Internet o el sistema operativo utilizado por usted y el nombre de dominio del sitio web desde el cual ha llegado a nuestro 
sitio o anuncio.

Cuando usted ve una de nuestras páginas web, podemos almacenar cierta información en su ordenador en forma de "cookie" o similar que nos ayudará en diversas formas, como por ejemplo, permitirnos adecuar una página web o anuncio a sus intereses y preferencia. 
En la mayoría de navegadores de Internet usted puede eliminar las "cookies" del disco duro de su ordenador, bloquear todas los "cookies" o recibir un aviso antes de que se instale una "cookie". Por favor, consulte las instrucciones de su navegador o la pantalla de ayuda para saber más sobre el 
funcionamiento de estas funciones.

Las cookies son archivos de texto que son descargados automáticamente y almacenados en el disco duro del equipo de cómputo del usuario al navegar en una página de Internet específica, que permiten recordar al servidor de Internet algunos datos sobre 
este usuario, entre ellos, sus preferencias para la visualización de las páginas en ese servidor, nombre y contraseña.

Por su parte, las web beacons son imágenes insertadas en una página de Internet o correo electrónico, que puede ser utilizado para monitorear el comportamiento de un visitante, como almacenar información sobre la dirección IP del usuario, duración 
del tiempo de interacción en dicha página y el tipo de navegador utilizado, entre otros.

Le informamos que utilizamos cookies y web beacons para obtener información personal de usted, como la siguiente: su tipo de navegador y sistema operativo, las páginas de Internet que visita, los vínculos que sigue, la dirección IP, el sitio que visitó antes de entrar al nuestro. En caso de transmisión de datos a un proveedor de servicios externo, se aplicarán las medidas técnicas adecuadas para garantizar una transmisión conforme a las disposiciones en materia de protección de datos.

A través de usted podemos obtener Información Personal de una tercera persona (por ejemplo, un sitio de Internet puede permitirle mandar una "tarjeta electrónica" a un amigo, en cuyo caso requeriremos el nombre de esa persona y su dirección de correo 
electrónico). Esa información se utilizará únicamente para los fines que se especifiquen en cada caso y no contactaremos a la tercera persona otra vez, a menos que dicha tercera persona nos contacte de vuelta.

Eventualmente podríamos llegar a complementar la información que usted nos haya proporcionado con información que nos haya sido proporcionada por terceras partes. Hacemos esto con fines de mercadotecnia con la finalidad de poder atender mejor 
sus requerimientos y ofrecerle productos y servicios que cumplan con sus necesidades.

Sin embargo esa información también puede ser usada, en caso de ser necesario para ayudar a identificar a cualquier persona que intente ingresar o dañar el sitio web de Henkel. Podríamos en ese caso compartir su información con la autoridad y con 
empresas profesionales que ayuden a encontrar el problema si creemos que tenemos la evidencia necesaria de violación.

 
Links a otros Sitios Web

Nuestros sitios pueden contener links hacia otros sitios web. Henkel no es responsable por las políticas de privacidad o el contenido de esos sitios web. Favor de tomar nota que las políticas de privacidad de esos sitios web pueden ser en forma 
significativa diferentes de nuestra política, por lo que le aconsejamos que las lea cuidadosamente antes de usar esos sitios. Henkel no se hace responsable de ninguna acción o contenido de esos sitios web.

Derechos de Acceso, Rectificación, Cancelación y Oposición.

Usted tiene derecho de acceder a sus datos personales que poseemos y a los detalles del tratamiento de los mismos, así como a rectificarlos en caso de ser inexactos o incompletos; cancelarlos cuando considere que no se requieren para alguna de las 
finalidades señalados en el presente aviso de privacidad, estén siendo utilizados para finalidades no consentidas o haya finalizado la relación contractual o de servicio, o bien, oponerse al tratamiento de los mismos para fines específicos.

Los mecanismos que se han implementado para el ejercicio de dichos derechos son a través de la presentación de la solicitud respectiva a través del correo electrónico avisoprivacidad@henkel.com

Su solicitud de conformidad con la Ley Federal de Protección de Datos Personales publicada en el Diario Oficial de la Federación el 5 de julio del 2010, deberá contener:
1) El nombre del titular y domicilio u otro medio para comunicarle la respuesta a su solicitud;
2) Los documentos que acrediten la identidad o, en su caso, la representación legal del titular;
3) La descripción clara y precisa de los datos personales respecto de los que se busca ejercer alguno de los derechos antes mencionados, y
4) Cualquier otro elemento o documento que facilite la localización de los datos personales.
5) En el caso de solicitudes de rectificación de datos personales, el titular deberá indicar, además de lo anterior, las modificaciones a realizarse y aportar la documentación que sustente su petición.

Los plazos para atender su solicitud son los siguientes:

* Henkel le comunicará a usted, en un plazo máximo de veinte días hábiles, contados desde la fecha en que se recibió la solicitud de acceso, rectificación, cancelación u oposición, la determinación adoptada, a efecto de que, si resulta procedente, se 
haga efectiva la misma dentro de los quince días hábiles siguientes a la fecha en que se comunica la respuesta.
* Tratándose de solicitudes de acceso a datos personales, procederá la entrega previa acreditación de la identidad del solicitante o representante legal, según corresponda.

Los plazos antes referidos podrán ser ampliados una sola vez por un periodo igual, siempre y cuando así lo justifiquen las circunstancias del caso.

Es importante que usted tenga conocimiento que si ha creado un currículum utilizando nuestro link, usted tendrá acceso a revisarlo, corregirlo, actualizarlo o borrarlo en cualquier tiempo, simplemente accese a su cuenta y haga los cambios necesarios.

Nos reservamos el derecho de efectuar en cualquier momento modificaciones o actualizaciones al presente aviso de privacidad, para la atención de novedades legislativas, políticas internas o nuevos requerimientos para la prestación u ofrecimiento de 
nuestros servicios o productos. Estas modificaciones estarán disponibles al público a través de los siguientes medios: (i) anuncios visibles en nuestros establecimientos o centros de atención a clientes; (ii) trípticos o folletos disponibles en nuestros establecimientos o centros de atención 
a clientes; (iii) en nuestra página de Internet [sección aviso de privacidad]; (iv) o se las haremos llegar al último correo electrónico que nos haya proporcionado.

Si usted considera que su derecho de protección de datos personales ha sido lesionado por alguna conducta de nuestros empleados o de nuestras actuaciones o respuestas, presume que en el tratamiento de sus datos personales existe alguna violación a las 
disposiciones previstas en la Ley Federal de Protección de Datos Personales en Posesión de los Particulares, podrá interponer la queja o denuncia correspondiente ante el IFAI, para mayor información visite www.ifai.org.mx

Fecha de última actualización 4 julio 2011

                                                                </asp:TextBox>
                                                            </td>
                                                       </tr>
                                                     </table>
                                                    </div>
                                                    <table border="0" style="text-align:right">
                                                       <tr>
                                                           <td colspan="2" style="vertical-align:central;text-align:right">
                                                               <asp:Button runat="server" ID="btnAceptar" OnClick=" btnAceptar_Click" Text="Acepto" class="btn btn-success" />&nbsp;
                                                                <asp:Button runat="server" id="Cancel" Text="Salir" class="btn btn-danger" PostBackUrl="Login.aspx" />
                                                           </td>
                                                       </tr>
                                                   </table>
                                    <br /><br /><br />
										
									</div>
									<!-- end widget content -->
									
								</div>
								<!-- end widget div -->
												
						</article>
						<!-- WIDGET END -->
						
					</div>
				
					<!-- end row -->
				
					<!-- row -->
				
					<div class="row">
				
						<!-- a blank row to get started -->
						<div class="col-sm-12">
							<!-- your contents here -->
						</div>
							
					</div>
				
					<!-- end row -->
				
				</section>
				<!-- end widget grid -->

			</div>
			<!-- END MAIN CONTENT -->

		</div>
		<!-- END MAIN PANEL -->

		<!-- PAGE FOOTER -->
		<div class="page-footer">
			<div class="row">
				<div class="col-xs-12 col-sm-6">
					<span class="txt-color-white">&copy; 2009 - 2017 Henkel Capital S.A. de C.V. Huixquilucan, Estado de M&eacute;xico&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;Aviso de Privacidad&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;Developed by EnterpriseOpen!</span>
				</div>

			</div>
		</div>
		<!-- END PAGE FOOTER -->


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

		<!-- JS TOUCH : include this plugin for mobile drag / drop touch events-->
		<script src="js/plugin/jquery-touch/jquery.ui.touch-punch.min.js"></script> 

		<!-- BOOTSTRAP JS -->
		<script src="js/bootstrap/bootstrap.min.js"></script>

		<!-- CUSTOM NOTIFICATION -->
		<script src="js/notification/SmartNotification.min.js"></script>

		<!-- JARVIS WIDGETS -->
		<script src="js/smartwidgets/jarvis.widget.min.js"></script>

		<!-- EASY PIE CHARTS -->
		<script src="js/plugin/easy-pie-chart/jquery.easy-pie-chart.min.js"></script>

		<!-- SPARKLINES -->
		<script src="js/plugin/sparkline/jquery.sparkline.min.js"></script>

		<!-- JQUERY VALIDATE -->
		<script src="js/plugin/jquery-validate/jquery.validate.min.js"></script>

		<!-- JQUERY MASKED INPUT -->
		<script src="js/plugin/masked-input/jquery.maskedinput.min.js"></script>

		<!-- JQUERY SELECT2 INPUT -->
		<script src="js/plugin/select2/select2.min.js"></script>

		<!-- JQUERY UI + Bootstrap Slider -->
		<script src="js/plugin/bootstrap-slider/bootstrap-slider.min.js"></script>

		<!-- browser msie issue fix -->
		<script src="js/plugin/msie-fix/jquery.mb.browser.min.js"></script>

		<!-- FastClick: For mobile devices -->
		<script src="js/plugin/fastclick/fastclick.min.js"></script>

		<!--[if IE 8]>

		<h1>Your browser is out of date, please update your browser by going to www.microsoft.com/download</h1>

		<![endif]-->

		<!-- Demo purpose only -->
		<script src="js/demo.min.js"></script>

		<!-- MAIN APP JS FILE -->
		<script src="js/app.min.js"></script>

		<!-- ENHANCEMENT PLUGINS : NOT A REQUIREMENT -->
		<!-- Voice command : plugin -->
		<script src="js/speech/voicecommand.min.js"></script>

		<!-- PAGE RELATED PLUGIN(S) 
		<script src="..."></script>-->

		<script type="text/javascript">

		    $(document).ready(function () {

		        /* DO NOT REMOVE : GLOBAL FUNCTIONS!
				 *
				 * pageSetUp(); WILL CALL THE FOLLOWING FUNCTIONS
				 *
				 * // activate tooltips
				 * $("[rel=tooltip]").tooltip();
				 *
				 * // activate popovers
				 * $("[rel=popover]").popover();
				 *
				 * // activate popovers with hover states
				 * $("[rel=popover-hover]").popover({ trigger: "hover" });
				 *
				 * // activate inline charts
				 * runAllCharts();
				 *
				 * // setup widgets
				 * setup_widgets_desktop();
				 *
				 * // run form elements
				 * runAllForms();
				 *
				 ********************************
				 *
				 * pageSetUp() is needed whenever you load a page.
				 * It initializes and checks for all basic elements of the page
				 * and makes rendering easier.
				 *
				 */

		        pageSetUp();

		        /*
				 * ALL PAGE RELATED SCRIPTS CAN GO BELOW HERE
				 * eg alert("my home function");
				 * 
				 * var pagefunction = function() {
				 *   ...
				 * }
				 * loadScript("js/plugin/_PLUGIN_NAME_.js", pagefunction);
				 * 
				 * TO LOAD A SCRIPT:
				 * var pagefunction = function (){ 
				 *  loadScript(".../plugin.js", run_after_loaded);	
				 * }
				 * 
				 * OR
				 * 
				 * loadScript(".../plugin.js", run_after_loaded);
				 */

		    })

		</script>

		<!-- Your GOOGLE ANALYTICS CODE Below -->
		<script type="text/javascript">
		    var _gaq = _gaq || [];
		    _gaq.push(['_setAccount', 'UA-XXXXXXXX-X']);
		    _gaq.push(['_trackPageview']);

		    (function () {
		        var ga = document.createElement('script');
		        ga.type = 'text/javascript';
		        ga.async = true;
		        ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';
		        var s = document.getElementsByTagName('script')[0];
		        s.parentNode.insertBefore(ga, s);
		    })();

		</script>
    </form>
	</body>

</html>