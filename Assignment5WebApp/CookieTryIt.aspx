<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CookieTryIt.aspx.cs" Inherits="Assignment5.CookieTryIt" %>

<%@ Register src="Login.ascx" tagname="Login" tagprefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>

    <h3>This is the Cookie Try It page</h3>
    <p>
        Enter your username in the below box and press &quot;Submit&quot;. This will store your username in a cookie.
        <br />
        Then press "Test Cookie" and it will take you to another page which will show your username printed from the cookie
        <br />
        It will take you to another page where you will see your username from the cookie. <br />        
    </p>
    <form id="form1" runat="server">
        <uc1:Login ID="Login1" runat="server" />
        <br />
        <br />
        <asp:Button ID="btnTestCookie" runat="server" Text="Test Cookie" OnClick="btnTestCookie_Click" />
    </form>
    </body>
</html>
