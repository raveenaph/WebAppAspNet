<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Staff.aspx.cs" Inherits="Assignment5.Staff.Staff" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Staff Page</title>
</head>
<body>

    <a href="../Default.aspx">Go back to Home</a>
    <br />
    <br />
    <form id="form1" runat="server">
        <div>
            This is the Staff Page <br />
            This is a protected page and only staff can see this page <br />
            Members will not be able to see this page <br />
        </div>
    </form>
</body>
</html>
