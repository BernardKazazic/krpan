<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="DeleteKorisnik.aspx.vb" Inherits="YazakiWarehouseManagement.DeleteKorisnik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Delete Korisnik</h2>

    <div>
        <asp:Label ID="lblDeleteMessage" runat="server" Text="Are you sure you want to delete this user?"></asp:Label><br />
        <asp:Label ID="lblUserId" runat="server"></asp:Label><br />
        <asp:Label ID="lblIme" runat="server"></asp:Label><br />
        <asp:Label ID="lblPrezime" runat="server"></asp:Label><br />

        <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" />
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
    </div>
</asp:Content>
