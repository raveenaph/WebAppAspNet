<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="staffLoginPage.aspx.cs" Inherits="Assignment5.staffLoginPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
     <div>

        <h4>Welcome to the staff login page</h4><br />

         <asp:Label ID="lblUserName" runat="server" Text="Staff User Name"></asp:Label>

        <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox><br /><br />
         <asp:Label ID="lblPassword" runat="server" Text="Staff Password"></asp:Label>
        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox><br/>
         <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
         <br />
        <br />
        
        <asp:Button ID="btnSubmit" runat="server" Text="submit" OnClick="btnSubmit_Click" />
         <br />
         <br />
         The page doesn&#39;t redirect to staff page after submit for some reason. <a href="Protected/Staff.aspx">Please click here to go to the staff page after submitting credentials.</a> <br />
        <asp:Label ID="Output" runat="server"></asp:Label>
        <a href="Account/MemberLogin.aspx">Click here to login as member</a>
     </div>
</asp:Content>


