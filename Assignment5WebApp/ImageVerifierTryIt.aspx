<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImageVerifierTryIt.aspx.cs" Inherits="Assignment5.ImageVerifierTryIt" %>

<%@ Register src="ImageVerifier.ascx" tagname="ImageVerifier" tagprefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <uc1:ImageVerifier ID="ImageVerifier1" runat="server" />
        </div>

        <br />
        <asp:TextBox ID="txtInput" runat="server"></asp:TextBox>
        <br />
        <br />
        
        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
        <br />

        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>

    </form>

   
</body>
</html>
