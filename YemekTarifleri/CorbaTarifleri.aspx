<%@ Page Title="" Language="C#" MasterPageFile="~/Temel.master" AutoEventWireup="true" CodeFile="CorbaTarifleri.aspx.cs" Inherits="CorbaTarifleri" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">








    <p>
        <asp:DropDownList ID="DropDownList1" runat="server" Width="175px" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" >
        
        </asp:DropDownList>
    </p>
    <p>
        &nbsp;</p>
    <p>
        <asp:GridView ID="GridView_corba" runat="server" OnSelectedIndexChanged="GridView_corba_SelectedIndexChanged" Visible="False" >
            <Columns>
                <asp:ButtonField CommandName="Select" Text="Seç" />
            </Columns>
        </asp:GridView>
    </p>







</asp:Content>

