<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Instrumentos.aspx.cs" Inherits="MelodyHub.instrumentos.Instrumentos" %>
<asp:Content ID="head" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="title" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="gvInstrumento" ContentPlaceHolderID="main" runat="server">
    <h2>Gestión de Instrumentos</h2>
    <asp:GridView ID="gvInstrumentos" runat="server" AutoGenerateColumns="False" DataKeyNames="id_instrumento" OnRowEditing="gvInstrumentos_RowEditing" OnRowDeleting="gvInstrumentos_RowDeleting" OnRowUpdating="gvInstrumentos_RowUpdating" OnRowCancelingEdit="gvInstrumentos_RowCancelingEdit">
        <Columns>
            <asp:BoundField DataField="id_instrumento" HeaderText="ID" ReadOnly="True" />
            <asp:BoundField DataField="tipo_instrumento" HeaderText="Tipo" />
            <asp:BoundField DataField="marca" HeaderText="Marca" />
            <asp:BoundField DataField="modelo" HeaderText="Modelo" />
            <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
        </Columns>
    </asp:GridView>
    <asp:Button ID="btnAgregar" runat="server" Text="Agregar Nuevo Instrumento" OnClick="btnAgregar_Click" />
</asp:Content>