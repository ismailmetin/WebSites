<%@ Page Title="" Language="C#" MasterPageFile="~/Temel.master" AutoEventWireup="true" CodeFile="TatliTarifleri.aspx.cs" Inherits="TatliTarifleri" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <p>
        <asp:DropDownList ID="DropDownList_tatlilar" runat="server" Width="175px" AutoPostBack="True" OnSelectedIndexChanged="DropDownList_tatlilar_SelectedIndexChanged">
        
        </asp:DropDownList>
    </p>
    <p>
        &nbsp;</p>
    <p>
        <asp:GridView ID="GridView_tatlilar" runat="server"  Visible="False" OnSelectedIndexChanged="GridView_tatlilar_SelectedIndexChanged" >
            <Columns>
                <asp:ButtonField CommandName="Select" Text="Seç" />
            </Columns>
        </asp:GridView>
    </p>

</asp:Content>

