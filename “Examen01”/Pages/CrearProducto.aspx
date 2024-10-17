<%@ Page Title="Crear producto" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CrearProducto.aspx.cs" Inherits="_Examen01_.CrearProducto" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title" class="text-center">

        <h2 class="mt-4">Crear producto</h2>
        
        <%-- Formulario para crear un nuevo producto --%>
        <div class="form-group mt-3">

            <%-- Nombre del producto --%>
            <label for="txtNombreProducto">Nombre del producto</label>
            <asp:TextBox ID="txtNombreProducto" runat="server" CssClass="form-control w-50 mx-auto" />
        </div>
        
        <div class="form-group mt-3">
            <%-- Cantidad --%>
            <label for="txtCantidad">Cantidad</label>
            <asp:TextBox ID="txtCantidad" runat="server" CssClass="form-control w-50 mx-auto" />
        </div>
        
        <div class="form-group mt-3">
            <%-- Precio Unitario --%>
            <label for="txtPrecioUnitario">Precio unitario</label>
            <asp:TextBox ID="txtPrecioUnitario" runat="server" CssClass="form-control w-50 mx-auto" />
        </div>

        <%-- Botones de Guardar y Cancelar --%>
        <div class="mt-4">
            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-primary me-2" OnClick="BtnGuardar_Click" />
            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-secondary" OnClick="BtnCancelar_Click" CausesValidation="false" />
        </div>
    </main>
</asp:Content>
