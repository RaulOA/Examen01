<%@ Page Title="Lista de productos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListaProductos.aspx.cs" Inherits="_Examen01_.ListaProductos" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">

        <h2 class="text-center mt-4">Lista de productos</h2>

        <%-- Botón de nuevo producto --%>
        <div class="text-center mt-3">
            <asp:Button ID="btnNuevoProducto" runat="server" Text="Nuevo producto" CssClass="btn btn-primary" OnClick="BtnNuevoProducto_Click" />
        </div>

        <%-- GridView de productos --%>
        <div class="mt-4">
            <asp:GridView ID="gvProductos" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-hover">
                <Columns>
                    <%-- Columna de ID del producto (alineación a la izquierda) --%>
                    <asp:BoundField DataField="idProducto" HeaderText="ID" ItemStyle-HorizontalAlign="Left" />

                    <%-- Columna del nombre del producto (centrada) --%>
                    <asp:BoundField DataField="nombre" HeaderText="Producto" />

                    <%-- Columna de la fecha de registro (centrada) --%>
                    <asp:BoundField DataField="fechaRegistro" HeaderText="Fecha registro" DataFormatString="{0:yyyy-MM-dd}" />

                    <%-- Columna de cantidad (alineación a la izquierda) --%>
                    <asp:BoundField DataField="cantidad" HeaderText="Cantidad" ItemStyle-HorizontalAlign="Left" />

                    <%-- Columna de precio unitario (alineación a la izquierda) --%>
                    <asp:BoundField DataField="precioUnitario" HeaderText="Precio unitario" DataFormatString="{0:N2}" ItemStyle-HorizontalAlign="Left" />

                    <%-- Columna del costo total (alineación a la izquierda) --%>
                    <asp:BoundField DataField="costoTotal" HeaderText="Costo total" DataFormatString="{0:N2}" ItemStyle-HorizontalAlign="Left" />

                    <%-- Columna del estado del producto (centrada) --%>
                    <asp:BoundField DataField="estado" HeaderText="Estado" />
                </Columns>
            </asp:GridView>
        </div>
    </main>
</asp:Content>
