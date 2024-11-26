<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GlobalTryIt.aspx.cs" Inherits="Assignment5.GlobalTryIt" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
 
        <div>
            <p>The below session will increment if the application opened from another browser type<br />
               This session counter is created in global.asax when the application starts<br />
               And is incremented in the global.asax anytime there is a new sesion<br />
               It is decremented when session is closed<br />
            </p>

            <asp:Label ID="lblSessionCountTxt" runat="server" Text="Session Count: " style="color:Red;"></asp:Label>
            <asp:Label ID="lblSessionCount" runat="server" Text=""></asp:Label>
            <br />
            <p>To increment the session counter, you can either open another session in a browser of a different type, <br />
                or login from another computer <br />
                or press the "Test" button to see the increment in action<br />
            </p>
        </div>

        <asp:Button ID="btnTest" runat="server" Text="Test" OnClick="btnTest_Click" />

    </form>
</body>
</html>
