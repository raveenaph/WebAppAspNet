<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UsernameCookie.aspx.cs" Inherits="Assignment5.UsernameCookie" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <p>The below username is taken from the cookie which got created when you pressed submit in the previous page</p>
        <asp:Label ID="lblUsername" runat="server" Text="UserName: "></asp:Label>
        <asp:Label ID="lblCookieUsername" runat="server" Text=""></asp:Label>
    </form>
</body>
</html>
