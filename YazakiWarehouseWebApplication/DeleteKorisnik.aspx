<%@ Page Title="Delete Korisnik" Language="VB" AutoEventWireup="true" CodeBehind="DeleteKorisnik.aspx.vb" Inherits="YazakiWarehouseWebApplication.DeleteKorisnik" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Are you sure you want to delete this Korisnik?</h2>

    <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>

    <!-- Display confirmation details -->
    <div>
        <asp:Label ID="lblImePrezime" runat="server"></asp:Label>
    </div>
    <br />
    <asp:Button ID="btnDelete" runat="server" Text="Yes, Delete" OnClick="btnDelete_Click" />
    <asp:Button ID="btnCancel" runat="server" Text="No, Cancel" OnClick="btnCancel_Click" />
</asp:Content>