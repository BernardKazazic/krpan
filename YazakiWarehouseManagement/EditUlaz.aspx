<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="EditUlaz.aspx.vb" Inherits="YazakiWarehouseManagement.EditUlaz" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Edit Ulaz</h2>

    <div>
        <asp:Label ID="lblId" runat="server" Text="ID: "></asp:Label>
        <asp:Label ID="lblUlazId" runat="server"></asp:Label><br />

        <asp:Label ID="lblDatum" runat="server" Text="Datum: "></asp:Label>
        <asp:TextBox ID="txtDatum" runat="server" TextMode="Date"></asp:TextBox><br />

        <asp:Label ID="lblArtikl" runat="server" Text="Artikl: "></asp:Label>
        <asp:DropDownList ID="ddlArtikl" runat="server"></asp:DropDownList><br />

        <asp:Label ID="lblKolicina" runat="server" Text="Kolicina: "></asp:Label>
        <asp:TextBox ID="txtKolicina" runat="server"></asp:TextBox><br />

        <asp:Label ID="lblProizvodjac" runat="server" Text="Proizvodjac: "></asp:Label>
        <asp:DropDownList ID="ddlProizvodjac" runat="server"></asp:DropDownList><br />

        <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
    </div>
</asp:Content>