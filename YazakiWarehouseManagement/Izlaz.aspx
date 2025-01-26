<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Izlaz.aspx.vb" Inherits="YazakiWarehouseManagement.Izlaz" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Izlaz</h2>

    <asp:Table ID="izlazTable" runat="server" border="1" cellpadding="5" cellspacing="0">
        <asp:TableHeaderRow>
            <asp:TableHeaderCell>ID</asp:TableHeaderCell>
            <asp:TableHeaderCell>Datum</asp:TableHeaderCell>
            <asp:TableHeaderCell>Kolicina</asp:TableHeaderCell>
            <asp:TableHeaderCell>Artikl</asp:TableHeaderCell>
            <asp:TableHeaderCell>Actions</asp:TableHeaderCell>
        </asp:TableHeaderRow>
    </asp:Table>

    <br />
    <asp:Button ID="btnAddNew" runat="server" Text="Add New Izlaz" OnClick="btnAddNew_Click" />

    <div id="newIzlazForm" style="display:none;" runat="server">
        <h3>Add New Izlaz</h3>

        <asp:TextBox ID="txtDatum" runat="server" placeholder="Datum" TextMode="Date"></asp:TextBox><br />
        <asp:TextBox ID="txtKolicina" runat="server" placeholder="Kolicina"></asp:TextBox><br />
        <asp:DropDownList ID="ddlArtikl" runat="server"></asp:DropDownList><br />

        <asp:Button ID="btnSubmitNewIzlaz" runat="server" Text="Submit" OnClick="btnSubmitNewIzlaz_Click" />
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
    </div>
</asp:Content>