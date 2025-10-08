<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Header.Master" AutoEventWireup="true" CodeBehind="ProfilePage.aspx.cs" Inherits="PSD_Project.View.ProfilePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Profile Page</h1>

    <div>
        <asp:Label ID="Lbl_Username" runat="server" Text="Username: "></asp:Label>
        <asp:Label ID="Lbl_UsernameValue" runat="server" Text=""></asp:Label>
    </div>
    <div>
        <asp:Label ID="Lbl_Email" runat="server" Text="Email: "></asp:Label>
        <asp:Label ID="Lbl_EmailValue" runat="server" Text=""></asp:Label>
    </div>
    <div>
        <asp:Label ID="Lbl_DOB" runat="server" Text="Date of Birth: "></asp:Label>
        <asp:Label ID="Lbl_DOBValue" runat="server" Text=""></asp:Label>
    </div>
    <div>
        <asp:Label ID="Lbl_Gender" runat="server" Text="Gender: "></asp:Label>
        <asp:Label ID="Lbl_GenderValue" runat="server" Text=""></asp:Label>
    </div>
    <div>
        <asp:Label ID="Lbl_Role" runat="server" Text="Role: "></asp:Label>
        <asp:Label ID="Lbl_RoleValue" runat="server" Text=""></asp:Label>
    </div>

    <h4>Change Password</h4>
    <div>
        <asp:Label ID="Lbl_OldPassword" runat="server" Text="Old Password: "></asp:Label>
        <asp:TextBox ID="TBox_OldPassword" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="Lbl_NewPassword" runat="server" Text="New Password: "></asp:Label>
        <asp:TextBox ID="TBox_NewPassword" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="Lbl_ConfirmPassword" runat="server" Text="Confirm Password: "></asp:Label>
        <asp:TextBox ID="TBox_ConfirmPassword" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="Lbl_Status" runat="server" Text=""></asp:Label>
    </div>
    <div>
        <asp:Button ID="Btn_ChangePassword" runat="server" Text="Change Password" OnClick="Btn_ChangePassword_Click" />
    </div>


</asp:Content>
