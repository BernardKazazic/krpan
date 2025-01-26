<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="EditKorisnik.aspx.vb" Inherits="YazakiWarehouseManagement.EditKorisnik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Edit Korisnik</h2>

    <div>
        <asp:Label ID="lblId" runat="server" Text="ID: "></asp:Label>
        <asp:Label ID="lblUserId" runat="server"></asp:Label><br />

        <asp:Label ID="lblIme" runat="server" Text="Ime: "></asp:Label>
        <asp:TextBox ID="txtIme" runat="server"></asp:TextBox><br />

        <asp:Label ID="lblPrezime" runat="server" Text="Prezime: "></asp:Label>
        <asp:TextBox ID="txtPrezime" runat="server"></asp:TextBox><br />

        <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
    </div>
</asp:Content>
