<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Principal.aspx.cs" Inherits="TMD.ACP.Site.Principal" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    

    <link rel="stylesheet" type="text/css" href="css/layout-default-latest.css" />
	<link rel="stylesheet" type="text/css" href="css/themes/jquery.ui.all.css" />

    <link rel="stylesheet" type="text/css" href="js/facebox/facebox.css" />
	
	<style type="text/css">

	/* remove padding and scrolling from elements that contain an Accordion OR a content-div */
	.ui-layout-center ,	/* has content-div */
	.ui-layout-west ,	/* has Accordion */
	.ui-layout-east ,	/* has content-div ... */
	.ui-layout-east .ui-layout-content { /* content-div has Accordion */
		padding: 0;
		overflow: hidden;
	}
	.ui-layout-center P.ui-layout-content {
		line-height:	1.4em;
		margin:			0; /* remove top/bottom margins from <P> used as content-div */
	}
	h3, h4 { /* Headers & Footer in Center & East panes */
		font-size:		1.1em;
		background:		#EEF;
		border:			1px solid #BBB;
		border-width:	0 0 1px;
		padding:		7px 10px;
		margin:			0;
	}
	.ui-layout-east h4 { /* Footer in East-pane */
		font-size:		0.9em;
		font-weight:	normal;
		border-width:	1px 0 0;
	}
	</style>
	
	<SCRIPT type="text/javascript" src="js/jquery.js"></SCRIPT>
    <SCRIPT type="text/javascript" src="js/jquery.layout.js"></SCRIPT>
    
    <script type="text/javascript" src="js/jquery-latest.js"></script>
	<script type="text/javascript" src="js/jquery-ui-latest.js"></script>
	<script type="text/javascript" src="js/jquery.layout-latest.js"></script>
	<script type="text/javascript" src="js/jquery.layout.resizePaneAccordions-1.0.js"></script>
	
	<script type="text/javascript" src="js/themeswitchertool.js"></script> 
	<script type="text/javascript" src="js/debug.js"></script>

    <script type="text/javascript" src="js/facebox/facebox.js"></script>
    <script type="text/javascript" src="js/utils.js"></script>
    
   <script type="text/javascript">

       var arrRefFunctions = new Array();

       $(document).ready(function () {

           myLayout = $('body').layout({
               west__size: 300
               // RESIZE Accordion widget when panes resize
		     , west__onresize: $.layout.callbacks.resizePaneAccordions
           });

           // ACCORDION - in the West pane
           $("#accordion1").accordion({ fillSpace: true });




       });
	</script>
    
</head>
<body>


<form id="form1" runat="server">

<iframe id="mainFrame" name="mainFrame" class="ui-layout-center"
	width="100%" height="600" frameborder="0" scrolling="auto"
	src="Dashboard.aspx"></iframe>
	   
<div class="ui-layout-center" style="display: none;"> 
	<h3 class="ui-widget-header">Auditoría de Procesos</h3>
	<div class="ui-layout-content ui-widget-content">
		<h2>Dashboard</h2>
	</div>
	
	
</div>

<div class="ui-layout-west" style="display: none;">
	<div id="accordion1" class="basic">

			<h3><a href="#">Planeamiento</a></h3>
			<div>
				<ul>
				<li><a href="#">Auditorías Anteriores</a></li>				
                <li><a href="#">Procedimientos de Procesos</a></li>	
                <li><a href="#">Consultar Procesos / Proyectos</a></li>	                
				</ul>
			</div>

			<h3><a href="#">Realización</a></h3>
			<div>
			    <ul>
                <li><a target="mainFrame" href="ListaPlanAuditoria.aspx">Plan de Auditoría</a></li>
				<li><a href="">Lista de Verificación</a></li>
				<li><a target="mainFrame" href="ConsultaAuditoria.aspx">Hallazgos</a></li>
				</ul>
			</div>

			<h3><a href="#">Seguimiento</a></h3>
			<div>				
			</div>			

	</div>
</div>


   
    </form>
</body>
</html>
