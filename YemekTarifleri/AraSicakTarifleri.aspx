<%@ Page Title="" Language="C#" MasterPageFile="~/Temel.master" AutoEventWireup="true" CodeFile="AraSicakTarifleri.aspx.cs" Inherits="AraSicakTarifleri" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

      <p>
        <asp:DropDownList ID="DropDownList_arasicak" runat="server" Width="175px" AutoPostBack="True" OnSelectedIndexChanged="DropDownList_arasicak_SelectedIndexChanged"  >
        
        </asp:DropDownList>
    </p>
    <p>
        &nbsp;</p>
    <p>
        <asp:GridView ID="GridView_arasicak" runat="server" Visible="False" OnSelectedIndexChanged="GridView_arasicak_SelectedIndexChanged" >
            <Columns>
                <asp:ButtonField CommandName="Select" Text="Seç" />
            </Columns>
        </asp:GridView>
    </p>


</asp:Content>

