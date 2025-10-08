<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Header.Master" AutoEventWireup="true" CodeBehind="AddJewelPage.aspx.cs" Inherits="PSD_Project.View.AddJewelPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Add Jewel Page</h1>

    <div>
        <asp:Label ID="Lbl_JewelName" runat="server" Text="Jewel Name"></asp:Label>
        <asp:TextBox ID="TBox_JewelName" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="Lbl_Category" runat="server" Text="Category"></asp:Label>
        <asp:DropDownList ID="DDList_Category" runat="server"></asp:DropDownList>
    </div>
    <div>
        <asp:Label ID="Lbl_Brand" runat="server" Text="Brand"></asp:Label>
        <asp:DropDownList ID="DDList_Brand" runat="server"></asp:DropDownList>
    </div>
    <div>
        <asp:Label ID="Lbl_Price" runat="server" Text="Price $"></asp:Label>
        <asp:TextBox ID="TBox_Price" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="Lbl_ReleaseYear" runat="server" Text="Release Year"></asp:Label>
        <asp:TextBox ID="TBox_ReleaseYear" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="Lbl_Status" runat="server" Text="" ForeColor="Red"></asp:Label>
    </div>
    <div>
        <asp:Button ID="Btn_Cancel" runat="server" Text="Cancel" OnClick="Btn_Cancel_Click" />
        <asp:Button ID="Btn_Add" runat="server" Text="Add" OnClick="Btn_Add_Click" Style="background-color: mediumspringgreen"/>
    </div>


</asp:Content>
