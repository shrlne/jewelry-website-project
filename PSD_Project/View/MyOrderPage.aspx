<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Header.Master" AutoEventWireup="true" CodeBehind="MyOrderPage.aspx.cs" Inherits="PSD_Project.View.MyOrderPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>My Orders Page</h1>

    <asp:GridView ID="GV_MyOrder" runat="server" AutoGenerateColumns="false" OnRowCommand="GV_MyOrder_RowCommand" OnRowDataBound="GV_MyOrder_RowDataBound" >
        <Columns>
            <asp:BoundField DataField="TransactionID" HeaderText="Transaction ID" />
            <asp:BoundField DataField="TransactionDate" HeaderText="Date" DataFormatString="{0:dd/MM/yyyy HH:mm:ss tt}" HtmlEncode="false" />
            <asp:BoundField DataField="PaymentMethod" HeaderText="Payment" />
            <asp:BoundField DataField="TransactionStatus" HeaderText="Status" />
            <asp:TemplateField HeaderText="Action">
                <ItemTemplate>
                    <asp:Button ID="Btn_ViewDetails" runat="server" Text="View Details" CommandName="ViewDetails" CommandArgument='<%# Container.DataItemIndex %>' />
                    <asp:Button ID="Btn_Confirm" runat="server" Text="Confirm Package" Visible="false" CommandName="ConfirmPackage" CommandArgument='<%# Container.DataItemIndex %>' />
                    <asp:Button ID="Btn_Reject" runat="server" Text="Reject Package" Visible="false" CommandName="RejectPackage" CommandArgument='<%# Container.DataItemIndex %>' />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>

    </asp:GridView>
</asp:Content>
