<%@ Page Title="" Language="C#" MasterPageFile="~/Temel.master" AutoEventWireup="true" CodeFile="TarifEkle.aspx.cs" Inherits="TarifEkle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 417px;
        }
        .auto-style2 {
            width: 417px;
            text-align: right;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">








    <table  class="nav-justified" style="border-collapse:separate;border-spacing:10px">
        <tr>
            <td class="auto-style2">
                <asp:Label ID="Label_yemekKate" runat="server" Text="YEMEK KATEGORİSİNİ SEÇİNİZ"></asp:Label>
            </td>
            <td>&nbsp;
                <asp:DropDownList ID="DropDownList_kategori" runat="server" Width="150px" AutoPostBack="True" OnSelectedIndexChanged="DropDownList_kategori_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:Label ID="Label_yemekTur" runat="server" Text="YEMEK TÜRÜNÜ SEÇİNİZ"></asp:Label>
            </td>
            <td>
                &nbsp;
                <asp:DropDownList ID="DropDownList_yemekSinif" runat="server" Width="150px" AutoPostBack="True">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:Label ID="Label_malzeme" runat="server" Text="MALZEMELER"></asp:Label>
            </td>
            <td>
                &nbsp;
                <asp:TextBox ID="TextBox_malzeme" runat="server" Height="100px" Width="350px" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:Label ID="Label_tarif" runat="server" Text="TARİFİNİZİ GİRİNİZ"></asp:Label>
            </td>
            <td>
                &nbsp;
                <asp:TextBox ID="TextBox_tarifGir" runat="server" Height="100px" TextMode="MultiLine" Width="350px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">
                &nbsp;</td>
            <td>
                &nbsp;
                <asp:Button ID="Button_tarifEkle" runat="server" Text="TARİF EKLE" OnClick="Button_tarifEkle_Click" />
            </td>
        </tr>
    </table>








</asp:Content>

