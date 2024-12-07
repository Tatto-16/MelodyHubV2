<%@ Page Language="C#" MasterPageFile="~/Site.Master"AutoEventWireup="true" CodeBehind="inicio.aspx.cs" Inherits="MelodyHub.inicio" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="resources/css/styles.css"/>
    <title>Inicio</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>El usuario <%=Session["nombre"] %> ingresó</h1>
            <asp:Button ID ="btnSalir" runat="server" Text="Salir" OnClick="BtnSalir_Click1" />
        </div>
        <div>
            <a href="Site.Master">Gestión de Instrumentos</a>
        </div>
    </form>
</body>
</html>
