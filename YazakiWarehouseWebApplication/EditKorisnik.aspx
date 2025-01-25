<%@ Page Title="Edit Korisnik" Language="VB" AutoEventWireup="true" CodeBehind="EditKorisnik.aspx.vb" Inherits="YazakiWarehouseWebApplication.EditKorisnik" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Edit Korisnik</h2>

    <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>

    <!-- Form for editing Korisnik -->
    <form id="editForm" runat="server">
        <div>
            <label for="Ime">Ime:</label>
            <asp:TextBox ID="txtIme" runat="server"></asp:TextBox>
        </div>
        <div>
            <label for="Prezime">Prezime:</label>
            <asp:TextBox ID="txtPrezime" runat="server"></asp:TextBox>
        </div>
        <br />
        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
    </form>
</asp:Content>