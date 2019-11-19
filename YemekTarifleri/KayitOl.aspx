<%@ Page Title="" Language="C#" MasterPageFile="~/Temel.master" AutoEventWireup="true" CodeFile="KayitOl.aspx.cs" Inherits="KayitOl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

   



    <style type="text/css">
        .auto-style1 {
            width: 445px;
        }
        .auto-style2 {
            width: 445px;
            text-align: right;
        }
        .auto-style3 {
            width: 445px;
            text-align: right;
            height: 20px;
        }
        .auto-style4 {
            height: 20px;
        }
    </style>

   



</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">





    
    


    <table class="nav-justified" style="border-collapse:separate;border-spacing:5px">
       
        <tr>
            <td class="auto-style3"></td>
            <td class="auto-style4" style="font-size: 15px; font-weight: bold">
                &nbsp;&nbsp;KULLANICI KAYIT SAYFASI</td>
        </tr>
       
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
       
        <tr>
            <td class="auto-style2">Adınızı girin</td>
            <td>
                 &nbsp;&nbsp;<asp:TextBox ID="TextBox_ad" runat="server" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Soyadınızı girin</td>
            <td>
                &nbsp;&nbsp;<asp:TextBox ID="TextBox_soyad" runat="server" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Emailinizi girin</td>
            <td>
                &nbsp;&nbsp;<asp:TextBox ID="TextBox_email" runat="server" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Kullanıcı adınızı girin</td>
            <td>
                &nbsp;&nbsp;<asp:TextBox ID="TextBox_kullaniciad" runat="server" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Parolanızı girin</td>
            <td>
                &nbsp;&nbsp;<asp:TextBox ID="TextBox_parola" runat="server" Width="200px" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Parolanızı tekrar girin</td>
            <td>
                &nbsp;&nbsp;<asp:TextBox ID="TextBox_parolaTekrar" runat="server" Width="200px" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr >
            <td class="auto-style1">
                &nbsp;&nbsp;</td>
            <td>&nbsp;&nbsp;<asp:Button ID="Button_kayit" runat="server" Text="Kayıt Ol" OnClick="Button_kayit_Click" />
            </td>
        </tr>
    </table>





    



</asp:Content>

