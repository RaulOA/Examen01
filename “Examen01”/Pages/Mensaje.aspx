<%@ Page Title="Proceso finalizado" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Mensaje.aspx.cs" Inherits="_Examen01_.Mensaje" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title" class="text-center">
        <!-- Título de la página -->
        <h2 class="mt-4">Proceso finalizado</h2>

        <%-- Contenedor del mensaje de éxito --%>
        <div class="alert alert-success w-50 mx-auto mt-3" role="alert">
            Se ha completado correctamente el registro de un nuevo producto en la base de datos.
        </div>

        <%-- Link para regresar --%>
        <div class="mt-4">
            <a href="ListaProductos.aspx" class="btn btn-secondary">Regresar</a>
        </div>
    </main>
</asp:Content>
