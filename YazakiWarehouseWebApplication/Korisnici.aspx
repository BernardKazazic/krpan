<%@ Page Title="Korisnici" Language="VB" AutoEventWireup="true" CodeBehind="Korisnici.aspx.vb" Inherits="YazakiWarehouseWebApplication.Korisnici" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Korisnici</h2>

    <!-- Add the runat="server" to the table so it can be referenced in code-behind -->
    <table id="korisniciTable" border="1" cellpadding="5" cellspacing="0" runat="server">
        <thead>
            <tr>
                <th>ID</th>
                <th>Ime</th>
                <th>Prezime</th>
                <th>Actions</th>
            </tr>
        </thead>
        <tbody>
            <!-- Data rows will be dynamically added here -->
        </tbody>
    </table>

    <br />
    <button id="btnAddNew" runat="server" onclick="btnAddNew_Click">Add New</button>
</asp:Content>