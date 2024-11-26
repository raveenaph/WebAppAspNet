<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Assignment5._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h3>Location based Web Application</h3>

    <div>
        <p>
            This is a Web application that provides various location based services, <br />
            such as getting the air quality, average wind speed, and solar intensity of a given area. <br />
            Currently, you can click on the member and staff login to go to the respective pages <br />
            The login and registration functionality is not coded and will be done in Assignment 6<br />
            However, just typing any username and any password and pressing submit on either of the pages will take you to the respective parts<br />
            In the member pages, you can try out the provided functionality of the services<br />
            Cookie is used to store username and will be displayed on all pages<br />
            Session state is used to save page load counts and will be shown at the bottom of every page<br />
            Global asax will keep track of number of sessions using an event handler<br />
            To test this functionality open the application using browser from another provider, such as Microsoft Edge<br />
        </p>
    </div>

    <div>

        <asp:Button ID="btnMember" runat="server" Text="Member Page" OnClick="btnMember_Click" />
        <br />
        <br />
        <asp:Button ID="btnMemberReg" runat="server" Text="Member Self Subscribe" OnClick="btnMemberReg_Click" />
        <br />
        <br />
        <asp:Button ID="btnStaff" runat="server" Text="Staff Page" OnClick="btnStaff_Click" />

    </div>
    <br />
    <div>
        <p>The below session will increment if the application opened from another browser type</p>
        <asp:Label ID="lblSessionCountTxt" runat="server" Text="Session Count: " style="color:Red;"></asp:Label>
        <asp:Label ID="lblSessionCount" runat="server" Text=""></asp:Label>
    </div>

</asp:Content>
