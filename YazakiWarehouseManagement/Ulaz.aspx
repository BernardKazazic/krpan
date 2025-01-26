<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Ulaz.aspx.vb" Inherits="YazakiWarehouseManagement.Ulaz" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Ulaz</h2>

    <!-- Table for displaying the existing Ulaz records -->
    <asp:Table ID="ulazTable" runat="server" border="1" cellpadding="5" cellspacing="0">
        <asp:TableHeaderRow>
            <asp:TableHeaderCell>ID</asp:TableHeaderCell>
            <asp:TableHeaderCell>Datum</asp:TableHeaderCell>
            <asp:TableHeaderCell>Artikl</asp:TableHeaderCell>
            <asp:TableHeaderCell>Kolicina</asp:TableHeaderCell>
            <asp:TableHeaderCell>Proizvodjac</asp:TableHeaderCell>
            <asp:TableHeaderCell>Actions</asp:TableHeaderCell>
        </asp:TableHeaderRow>
    </asp:Table>

    <br />
    <!-- Button to show the form to add new Ulaz record -->
    <asp:Button ID="btnAddNew" runat="server" Text="Add New Ulaz" OnClick="btnAddNew_Click" />

    <!-- Form for adding a new Ulaz -->
    <div id="newUlazForm" style="display:none;" runat="server">
        <h3>Add New Ulaz</h3>

        <!-- Input fields for the new Ulaz data -->
        <asp:TextBox ID="txtDatum" runat="server" placeholder="Datum" TextMode="Date"></asp:TextBox><br />
        <asp:DropDownList ID="ddlArtikl" runat="server"></asp:DropDownList><br />
        <asp:TextBox ID="txtKolicina" runat="server" placeholder="Kolicina" TextMode="Number"></asp:TextBox><br />
        <asp:DropDownList ID="ddlProizvodjac" runat="server"></asp:DropDownList><br />

        <!-- Buttons for submitting or canceling the form -->
        <asp:Button ID="btnSubmitNewUlaz" runat="server" Text="Submit" OnClick="btnSubmitNewUlaz_Click" />
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
    </div>
</asp:Content>