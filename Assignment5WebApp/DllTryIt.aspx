<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DllTryIt.aspx.cs" Inherits="Assignment5.DllTryIt" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h3>DLL TryIt Page</h3>
    <div>
        <asp:TextBox ID="txtHash" runat="server" placeholder="Enter string to hash"></asp:TextBox>
        <asp:Button ID="btnHashIt" runat="server" Text="HashIt" OnClick="btnHashIt_Click" />
        <br />
        <br />
        <asp:Label ID="lblHashInfo" runat="server" Text="Hashed String: "></asp:Label>
        <asp:Label ID="lblHashed" runat="server"></asp:Label>
    </div>



</asp:Content>
