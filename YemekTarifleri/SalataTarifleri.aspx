<%@ Page Title="" Language="C#" MasterPageFile="~/Temel.master" AutoEventWireup="true" CodeFile="SalataTarifleri.aspx.cs" Inherits="SalataTarifleri" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

     <p>
        <asp:DropDownList ID="DropDownList_salata" runat="server" Width="175px" AutoPostBack="True" OnSelectedIndexChanged="DropDownList_salata_SelectedIndexChanged">
        
        </asp:DropDownList>
    </p>
    <p>
        &nbsp;</p>
    <p>
        <asp:GridView ID="GridView_salata" runat="server"  Visible="False" OnSelectedIndexChanged="GridView_salata_SelectedIndexChanged" >
            <Columns>
                <asp:ButtonField CommandName="Select" Text="Seç" />
            </Columns>
        </asp:GridView>
    </p>

</asp:Content>

