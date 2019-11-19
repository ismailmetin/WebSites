<%@ Page Title="" Language="C#" MasterPageFile="~/Temel.master" AutoEventWireup="true" CodeFile="AnaYemekTarifleri.aspx.cs" Inherits="AnaYemekTarifleri" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

     <p>
        <asp:DropDownList ID="DropDownList_anayemek" runat="server" Width="175px" AutoPostBack="True" OnSelectedIndexChanged="DropDownList_anayemek_SelectedIndexChanged"  >
        
        </asp:DropDownList>
    </p>
    <p>
        &nbsp;</p>
    <p>
        <asp:GridView ID="GridView_anayemek" runat="server" Visible="False" OnSelectedIndexChanged="GridView_anayemek_SelectedIndexChanged" >
            <Columns>
                <asp:ButtonField CommandName="Select" Text="Seç" />
            </Columns>
        </asp:GridView>
    </p>



</asp:Content>

