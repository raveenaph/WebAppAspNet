<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MemberRegistration.aspx.cs" Inherits="Assignment5.Member.MemberRegistration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

    <head runat="server">
        <title>Member Registration</title>
    </head>
    
    <body>
        <h3>Member Registration Form</h3>
        <div>
            <form runat="server">
                <asp:Label ID="lblUserName" runat="server" Text="UserName: "></asp:Label>
                <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
                <br />
                <br />
                <asp:Label ID="lblUserNameError" runat="server" Text=""></asp:Label>
                <br />
                <br />
                <asp:Label ID="lblPassword" runat="server" Text="Password:"></asp:Label>
                <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
                <br />
                <br />
                <asp:Label ID="lblPasswordError" runat="server" Text=""></asp:Label>
                <br />
                <br />
                <asp:Label ID="lblHashed" runat="server" Text=""></asp:Label>
                <br />
                <br />
                <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" />
            </form>

        </div>
    </body>

</html>
