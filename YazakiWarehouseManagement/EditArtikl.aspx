<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="EditArtikl.aspx.vb" Inherits="YazakiWarehouseManagement.EditArtikl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Edit Artikl</h2>

    <div>
        <asp:Label ID="lblId" runat="server" Text="ID: "></asp:Label>
        <asp:Label ID="lblArtiklId" runat="server"></asp:Label><br />

        <asp:Label ID="lblIme" runat="server" Text="Ime: "></asp:Label>
        <asp:TextBox ID="txtIme" runat="server"></asp:TextBox><br />

        <asp:Label ID="lblProizvodjac" runat="server" Text="Proizvodjac: "></asp:Label>
        <asp:DropDownList ID="ddlProizvodjac" runat="server"></asp:DropDownList><br />

        <asp:Label ID="lblDatumDolaska" runat="server" Text="Datum Dolaska: "></asp:Label>
        <asp:TextBox ID="txtDatumDolaska" runat="server" TextMode="Date"></asp:TextBox><br />

        <asp:Label ID="lblKolicina" runat="server" Text="Kolicina: "></asp:Label>
        <asp:TextBox ID="txtKolicina" runat="server"></asp:TextBox><br />

        <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
    </div>
</asp:Content>