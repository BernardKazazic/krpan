<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="DeleteProizvodjac.aspx.vb" Inherits="YazakiWarehouseManagement.DeleteProizvodjac" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Delete Proizvodjac</h2>

    <div>
        <asp:Label ID="lblDeleteMessage" runat="server" Text="Are you sure you want to delete this Proizvodjac?"></asp:Label><br />
        <asp:Label ID="lblProizvodjacId" runat="server"></asp:Label><br />
        <asp:Label ID="lblIme" runat="server"></asp:Label><br />

        <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" />
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
    </div>
</asp:Content>
