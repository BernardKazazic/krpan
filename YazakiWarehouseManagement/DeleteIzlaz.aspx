<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="DeleteIzlaz.aspx.vb" Inherits="YazakiWarehouseManagement.DeleteIzlaz" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Delete Izlaz</h2>

    <div>
        <asp:Label ID="lblDeleteMessage" runat="server" Text="Are you sure you want to delete this Izlaz?"></asp:Label><br />
        <asp:Label ID="lblIzlazId" runat="server"></asp:Label><br />
        <asp:Label ID="lblDatum" runat="server"></asp:Label><br />
        <asp:Label ID="lblKolicina" runat="server"></asp:Label><br />
        <asp:Label ID="lblArtikl" runat="server"></asp:Label><br />

        <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" />
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
    </div>
</asp:Content>