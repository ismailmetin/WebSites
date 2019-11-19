<%@ Page Title="" Language="C#" MasterPageFile="~/Temel.master" AutoEventWireup="true" CodeFile="Tarif.aspx.cs" Inherits="Tarif" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style3 {
            width: 391px;
            text-align: right;
        }
      
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">




    <table class="nav-justified" style="border-collapse:separate;border-spacing:10px">
        <tr>
            <td class="auto-style3">MALZEMELER</td>
            <td>
                &nbsp;

                 <asp:TextBox ID="TextBox_malzemelerTarif" runat="server" ReadOnly="True" TextMode="MultiLine" Height="150px" Width="400px"  CssClass="auto-style4"></asp:TextBox>


   



            </td>
        </tr>
        <tr>
            <td class="auto-style3">TARİF</td>
            <td>
                &nbsp;


    <asp:TextBox ID="TextBox_tarifGoster" runat="server" ReadOnly="True" TextMode="MultiLine" Height="150px" Width="400px"  CssClass="auto-style4"></asp:TextBox>

            </td>
        </tr>
    </table>

</asp:Content>

