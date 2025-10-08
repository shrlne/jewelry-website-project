<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterPage.aspx.cs" Inherits="PSD_Project.View.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Register Page</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>JAwels & Diamonds</h1>
        </div>
        <div>
            <h2>Register</h2>
            <h3>Please fill in the information below</h3>
        </div>
        <div>
            <asp:Label ID="Lbl_Email" runat="server" Text="Email"></asp:Label>
            <asp:TextBox ID="TBox_Email" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="Lbl_Username" runat="server" Text="Username"></asp:Label>
            <asp:TextBox ID="TBox_Username" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="Lbl_Password" runat="server" Text="Password"></asp:Label>
            <asp:TextBox ID="TBox_Password" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="Lbl_ConfirmPassword" runat="server" Text="Confirm Password"></asp:Label>
            <asp:TextBox ID="TBox_ConfirmPassword" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="Lbl_Gender" runat="server" Text="Gender"></asp:Label>
            <asp:RadioButton ID="Male" runat="server" Text="Male" GroupName="GenderGroup"/>
            <asp:RadioButton ID="Female" runat="server" Text="Female" GroupName="GenderGroup"/>
        </div>
        <div>
            <asp:Label ID="Lbl_DOB" runat="server" Text="Date of Birth"></asp:Label>
            <asp:TextBox ID="TBox_DOB" runat="server" TextMode="Date"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="Lbl_Status" runat="server" Text="" ForeColor="Red"></asp:Label>
        </div>
        <div>
            <asp:Button ID="Btn_Register" runat="server" Text="Register" OnClick="Btn_Register_Click" />
        </div>
        <div>
            <asp:Label ID="Lbl_Login" runat="server" Text="Already have an account? "></asp:Label>
            <asp:HyperLink ID="HLink_Login" runat="server" NavigateUrl="~/View/LoginPage.aspx">Login</asp:HyperLink>
        </div>
    </form>
</body>
</html>
