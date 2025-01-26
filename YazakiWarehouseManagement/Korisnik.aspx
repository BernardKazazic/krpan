<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Korisnik.aspx.vb" Inherits="YazakiWarehouseManagement.Korisnik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Korisnici</h2>

    <asp:Table ID="korisniciTable" runat="server" border="1" cellpadding="5" cellspacing="0">
        <asp:TableHeaderRow>
            <asp:TableHeaderCell> ID </asp:TableHeaderCell>
            <asp:TableHeaderCell> Ime </asp:TableHeaderCell>
            <asp:TableHeaderCell> Prezime </asp:TableHeaderCell>
            <asp:TableHeaderCell> Actions </asp:TableHeaderCell>
        </asp:TableHeaderRow>
    </asp:Table>

    <br />
    <asp:Button ID="btnAddNew" runat="server" Text="Add New" OnClick="btnAddNew_Click" />

    <div id="newUserForm" style="display:none;" runat="server">
        <h3>Add New User</h3>

        <asp:TextBox ID="txtIme" runat="server" placeholder="Ime"></asp:TextBox><br />
        <asp:TextBox ID="txtPrezime" runat="server" placeholder="Prezime"></asp:TextBox><br />

        <asp:Button ID="btnSubmitNewUser" runat="server" Text="Submit" OnClick="btnSubmitNewUser_Click" />
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
    </div>
</asp:Content>
