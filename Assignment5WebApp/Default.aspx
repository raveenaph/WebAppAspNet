<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Assignment5._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h3>Location based Web Application</h3>

    <div>
        <p>
            This is a Web application that provides various location based services, <br />
            such as getting the air quality, average wind speed, and solar intensity of a given area. <br />
            <br />
            To register as a menber, please click on "Member Self Subscribe" <br />
            If you have already registered, you can click on Member Page which will take you to the login page <br />
            <br />
            If you are staff, you can click on the "Staff Login" button to enter your staff username and password <br />
            If you have already logged in as staff, pressing the "Staff Page" will take you to the staff page <br />

            </p>
    </div>

    <div>

        <asp:Button ID="btnMember" runat="server" Text="Member Page" OnClick="btnMember_Click" />
        <br />
        <br />
        <asp:Button ID="btnMemberReg" runat="server" Text="Member Self Subscribe" OnClick="btnMemberReg_Click" />
        <br />
        <br />
        <asp:Button ID="btnStaffLogin" runat="server" Text="Staff Login" OnClick="btnStaffLogin_Click" />
        <br />
        <br />
        <asp:Button ID="btnStaff" runat="server" Text="Staff Page" OnClick="btnStaff_Click"/>

    </div>
    <br />
    <div>
        <p>The below session count will increment if the application is opened from another browser type</p>
        <asp:Label ID="lblSessionCountTxt" runat="server" Text="Session Count: " style="color:Red;"></asp:Label>
        <asp:Label ID="lblSessionCount" runat="server" Text=""></asp:Label>
    </div>

</asp:Content>
