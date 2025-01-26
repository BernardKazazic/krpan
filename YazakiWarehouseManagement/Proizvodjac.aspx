<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Proizvodjac.aspx.vb" Inherits="YazakiWarehouseManagement.Proizvodjac" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Proizvodjaci</h2>

    <asp:Table ID="proizvodjacTable" runat="server" border="1" cellpadding="5" cellspacing="0">
        <asp:TableHeaderRow>
            <asp:TableHeaderCell> ID </asp:TableHeaderCell>
            <asp:TableHeaderCell> Ime </asp:TableHeaderCell>
            <asp:TableHeaderCell> Actions </asp:TableHeaderCell>
        </asp:TableHeaderRow>
    </asp:Table>

    <br />
    <asp:Button ID="btnAddNew" runat="server" Text="Add New Proizvodjac" OnClick="btnAddNew_Click" />

    <div id="newProizvodjacForm" style="display:none;" runat="server">
        <h3>Add New Proizvodjac</h3>

        <asp:TextBox ID="txtIme" runat="server" placeholder="Ime"></asp:TextBox><br />
        <asp:Button ID="btnSubmitNewProizvodjac" runat="server" Text="Submit" OnClick="btnSubmitNewProizvodjac_Click" />
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
    </div>
</asp:Content>
