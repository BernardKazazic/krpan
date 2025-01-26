<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Artikl.aspx.vb" Inherits="YazakiWarehouseManagement.Artikl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Artikli</h2>

    <asp:Table ID="artikliTable" runat="server" border="1" cellpadding="5" cellspacing="0">
        <asp:TableHeaderRow>
            <asp:TableHeaderCell>ID</asp:TableHeaderCell>
            <asp:TableHeaderCell>Ime</asp:TableHeaderCell>
            <asp:TableHeaderCell>Proizvodjac</asp:TableHeaderCell>
            <asp:TableHeaderCell>Datum Dolaska</asp:TableHeaderCell>
            <asp:TableHeaderCell>Kolicina</asp:TableHeaderCell>
            <asp:TableHeaderCell>Actions</asp:TableHeaderCell>
        </asp:TableHeaderRow>
    </asp:Table>

    <br />
    <asp:Button ID="btnAddNew" runat="server" Text="Add New Artikl" OnClick="btnAddNew_Click" />

    <div id="newArtiklForm" style="display:none;" runat="server">
        <h3>Add New Artikl</h3>

        <asp:TextBox ID="txtIme" runat="server" placeholder="Ime"></asp:TextBox><br />
        <asp:DropDownList ID="ddlProizvodjac" runat="server"></asp:DropDownList><br />
        <asp:TextBox ID="txtDatumDolaska" runat="server" placeholder="Datum Dolaska" TextMode="Date"></asp:TextBox><br />
        <asp:TextBox ID="txtKolicina" runat="server" placeholder="Kolicina"></asp:TextBox><br />

        <asp:Button ID="btnSubmitNewArtikl" runat="server" Text="Submit" OnClick="btnSubmitNewArtikl_Click" />
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
    </div>
</asp:Content>
