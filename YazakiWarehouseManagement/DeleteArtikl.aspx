<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="DeleteArtikl.aspx.vb" Inherits="YazakiWarehouseManagement.DeleteArtikl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Delete Artikl</h2>

    <div>
        <asp:Label ID="lblDeleteMessage" runat="server" Text="Are you sure you want to delete this Artikl?"></asp:Label><br />
        <asp:Label ID="lblArtiklId" runat="server"></asp:Label><br />
        <asp:Label ID="lblIme" runat="server"></asp:Label><br />
        <asp:Label ID="lblProizvodjac" runat="server"></asp:Label><br />
        <asp:Label ID="lblDatumDolaska" runat="server"></asp:Label><br />
        <asp:Label ID="lblKolicina" runat="server"></asp:Label><br />

        <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" />
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
    </div>
</asp:Content>
