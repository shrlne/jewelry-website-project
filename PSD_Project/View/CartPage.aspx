<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Header.Master" AutoEventWireup="true" CodeBehind="CartPage.aspx.cs" Inherits="PSD_Project.View.CartPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Cart Page</h1>

    <asp:GridView ID="GV_JewelList" runat="server" AutoGenerateColumns="False" OnRowCommand="GV_JewelList_RowCommand" >
        <Columns>
            <asp:BoundField DataField="JewelID" HeaderText="Jewel ID" />
            <asp:BoundField DataField="JewelName" HeaderText="Jewel Name" />
            <asp:BoundField DataField="JewelPrice" HeaderText="Price" DataFormatString="${0:N0}" />
            <asp:BoundField DataField="BrandName" HeaderText="Jewel Brand" />
            <asp:TemplateField HeaderText="Quantity">
                <ItemTemplate>
                    <asp:TextBox ID="TBox_Quantity" runat="server" Text='<%# Eval("Quantity") %>' Width="50px" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="SubTotal" HeaderText="Subtotal" />
            <asp:TemplateField HeaderText="Action">
                <ItemTemplate>
                    <asp:Button ID="Btn_Update" runat="server" Text="Update" CommandName="UpdateItem" CommandArgument='<%# Eval("JewelID") %>'/>
                    <asp:Button ID="Btn_Remove" runat="server" Text="Remove" CommandName="RemoveItem" CommandArgument='<%# Eval("JewelID") %>' />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <div>
        <asp:Label ID="Lbl_Total" runat="server" Text="Total: "></asp:Label>
        <asp:Label ID="Lbl_Error" runat="server" Text="" Style="margin-left: 400px;"></asp:Label>
    </div>
    <div>
        <asp:DropDownList ID="DDL_Payment" runat="server"></asp:DropDownList>
        <asp:Button ID="Btn_ClearCart" runat="server" Text="Clear Cart" Style="margin-left: 300px;" OnClick="Btn_ClearCart_Click" />
        <asp:Button ID="Btn_Checkout" runat="server" Text="Proceed to Checkout" Style="margin-left: 20px;" OnClick="Btn_Checkout_Click" />
    </div>

</asp:Content>
