<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Header.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="PSD_Project.View.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Home Page</h1>
    <asp:Label ID="Lbl_Hello" runat="server" Text=""></asp:Label>

    <asp:GridView ID="GV_JewelList" runat="server" AutoGenerateColumns="False" OnRowCommand="GV_JewelList_RowCommand">
        <Columns>
            <asp:BoundField DataField="JewelID" HeaderText="Jewel ID" />
            <asp:BoundField DataField="JewelName" HeaderText="Jewel Name" />
            <asp:BoundField DataField="JewelPrice" HeaderText="Price" DataFormatString="${0:N0}" />
            <asp:TemplateField HeaderText="Action">
                <ItemTemplate>
                    <asp:Button ID="BtnDetail" runat="server" Text="Detail" CommandName="ViewDetail" CommandArgument='<%# Container.DataItemIndex %>' />
                </ItemTemplate>
            </asp:TemplateField>

        </Columns>
    </asp:GridView>


</asp:Content>
