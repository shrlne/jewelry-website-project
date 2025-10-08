<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="PSD_Project.View.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login Page</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>JAwels & Diamonds</h1>
        </div>
        <div>
            <h2>Login</h2>
            <h3>Enter your email and password to login</h3>
        </div>
        <div>
            <asp:Label ID="Lbl_Email" runat="server" Text="Email"></asp:Label>
            <asp:TextBox ID="TBox_Email" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="Lbl_Password" runat="server" Text="Password"></asp:Label>
            <asp:TextBox ID="TBox_Password" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:CheckBox ID="CBox_RememberMe" runat="server" Text="Remember Me" />
        </div>
        <div>
            <asp:Label ID="Lbl_Status" runat="server" Text="" ForeColor="Red"></asp:Label>
        </div>
        <div>
            <asp:Button ID="Btn_Login" runat="server" Text="Login" OnClick="Btn_Login_Click" />
        </div>
        <div>
            <asp:Label ID="Lbl_Register" runat="server" Text="Don't have an account? "></asp:Label>
            <asp:HyperLink ID="HLink_Register" runat="server" NavigateUrl="~/View/RegisterPage.aspx">Register</asp:HyperLink>
        </div>
    </form>
</body>
</html>
