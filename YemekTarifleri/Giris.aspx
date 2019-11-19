<%@ Page Title="" Language="C#" MasterPageFile="~/Temel.master" AutoEventWireup="true" CodeFile="Giris.aspx.cs" Inherits="Giris" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 445px;
        }
        .auto-style2 {
            text-align: right;
            width: 445px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">




    <table class="nav-justified" style="border-collapse:separate;border-spacing:5px">
        <tr>
            <td class="auto-style1">&nbsp;</td>
            <td style="font-weight: bold">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; SİSTEME GİRİŞ</td>
        </tr>
        <tr>
            <td class="auto-style1">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">Email adresinizi girin</td>
            <td>
                 &nbsp;&nbsp;<asp:TextBox ID="TextBox_girEmail" runat="server" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Parolanızı girin</td>
            <td>
                &nbsp;&nbsp;<asp:TextBox ID="TextBox_girParola" runat="server" Width="200px" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">&nbsp;</td>
            <td>
                &nbsp;&nbsp;<asp:Button ID="Button_gir" runat="server" Text="GİRİŞ YAP" Width="200px" OnClick="Button_gir_Click" />
            </td>
        </tr>
    </table>




</asp:Content>

