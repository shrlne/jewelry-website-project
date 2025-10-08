<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Header.Master" AutoEventWireup="true" CodeBehind="JewelDetails.aspx.cs" Inherits="PSD_Project.View.DetailsPage" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Jewel Detail</h1>

    <div>
        <asp:Label ID="Lbl_JewelName" runat="server" Text="Jewel Name: "></asp:Label>
        <asp:Label ID="Lbl_JewelNameValue" runat="server" Text=""></asp:Label>
    </div>
    <div>
        <asp:Label ID="Lbl_JewelCategory" runat="server" Text="Jewel Category: "></asp:Label>
        <asp:Label ID="Lbl_JewelCategoryValue" runat="server" Text=""></asp:Label>
    </div>
    <div>
        <asp:Label ID="Lbl_JewelBrand" runat="server" Text="Jewel Brand: "></asp:Label>
        <asp:Label ID="Lbl_JewelBrandValue" runat="server" Text=""></asp:Label>
    </div>
    <div>
        <asp:Label ID="Lbl_JewelOrigin" runat="server" Text="Jewel Origin: "></asp:Label>
        <asp:Label ID="Lbl_JewelOriginValue" runat="server" Text=""></asp:Label>
    </div>
    <div>
        <asp:Label ID="Lbl_JewelClass" runat="server" Text="Jewel Class: "></asp:Label>
        <asp:Label ID="Lbl_JewelClassValue" runat="server" Text=""></asp:Label>
    </div>
    <div>
        <asp:Label ID="Lbl_JewelPrice" runat="server" Text="Jewel Price: "></asp:Label>
        <asp:Label ID="Lbl_JewelPriceValue" runat="server" Text=""></asp:Label>
    </div>
    <div>
        <asp:Label ID="Lbl_JewelYear" runat="server" Text="Jewel Release Year: "></asp:Label>
        <asp:Label ID="Lbl_JewelYearValue" runat="server" Text=""></asp:Label>
    </div>

    <div>
        <asp:Label ID="Lbl_Status" runat="server" Text=""></asp:Label>
    </div>
    <div>
        <asp:Button ID="Btn_AddToCart" runat="server" Text="Add To Cart" Visible="false" OnClick="Btn_AddToCart_Click" />
        <asp:Button ID="Btn_Delete" runat="server" Text="Delete" Visible="false" OnClick="Btn_Delete_Click" BackColor="Red" />
        <asp:Button ID="Btn_Edit" runat="server" Text="Edit" Visible="false" OnClick="Btn_Edit_Click" />
    </div>


</asp:Content>
