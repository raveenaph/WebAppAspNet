<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MemberRegistrationConfirmation.aspx.cs" Inherits="Assignment5.Account.MemberRegistrationConfirmation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <p>You are now registered. Please press next to go to the login page</p>
            <p>
                <asp:Button ID="btnNext" runat="server" Text="Next" OnClick="btnNext_Click" />
            </p>
        </div>
    </form>
</body>
</html>
