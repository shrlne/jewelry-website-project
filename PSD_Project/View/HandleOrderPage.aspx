<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Header.Master" AutoEventWireup="true" CodeBehind="HandleOrderPage.aspx.cs" Inherits="PSD_Project.View.HandleOrderPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Handle Orders</h1>

    <asp:GridView ID="GV_HandleOrder" runat="server" DataKeyNames="TransactionID" AutoGenerateColumns="false" OnRowCommand="GV_HandleOrder_RowCommand" OnRowDataBound="GV_HandleOrder_RowDataBound" >
    <Columns>
        <asp:BoundField DataField="TransactionID" HeaderText="Transaction ID" />
        <asp:BoundField DataField="UserID" HeaderText="User ID" />
        <asp:BoundField DataField="TransactionStatus" HeaderText="Status" />
        <asp:TemplateField HeaderText="Action">
            <ItemTemplate>
                <asp:Button ID="Btn_Ship" runat="server" Text="Ship Package" CommandName="ShipPackage" Visible="false" CommandArgument='<%# Container.DataItemIndex %>' />
                <asp:Button ID="Btn_ConfirmPayment" runat="server" Text="Confirm Payment" CommandName="ConfirmPayment" Visible="false" CommandArgument='<%# Container.DataItemIndex %>' />
                <asp:Label ID="Lbl_WaitUserConfirmation" runat="server" Text="Waiting for user confirmation..." Visible="false"></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>

</asp:GridView>
</asp:Content>
