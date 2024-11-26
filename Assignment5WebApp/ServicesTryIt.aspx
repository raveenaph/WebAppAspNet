<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ServicesTryIt.aspx.cs" Inherits="Assignment5.ServicesTryIt" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h3>Services TryIt Page</h3>

    
    <div>
        <div><h5>Wind Energy Service: </h5>
            <p>Return the annual average wind index of a given position (latitude, longitude). </p>        
            <p>This service can be used for deciding if installing a windmill device is effective at the location </p>
        </div>

        <div>
            <asp:Label ID="LabelLatWind" runat="server" Text="Latitude"></asp:Label>
            <asp:TextBox ID="TextBoxLatWind" runat="server"></asp:TextBox>
            <asp:Label ID="LabelLongWind" runat="server" Text="Longitude"></asp:Label>
            <asp:TextBox ID="TextBoxLongWind" runat="server"></asp:TextBox>
        </div>

        <div>            
            <asp:Button ID="ButtonGetWindSpeed" runat="server" Text="Get Wind Speed" OnClick="ButtonWindService_Click" />
            <asp:Label ID="LabelWindSpeed" runat="server" Text="Wind Speed:"></asp:Label>
            <asp:Label ID="LabelWindOutput" runat="server" Text="Wind speed will be displayed here"></asp:Label>
        </div>
    </div>

    <div>
        <div><h5>Solar Energy Service: </h5>
            <p>Return the annual average sunshine index of a given position (latitude, longitude). </p>
            <p>This service can be used for deciding if installing a solar energy device is effective at the location</p>
        </div>
        
        <div>    
            <asp:Label ID="LabelLatSolar" runat="server" Text="Latitude"></asp:Label>
            <asp:TextBox ID="TextBoxLatSolar" runat="server"></asp:TextBox>
            <asp:Label ID="LabelLongSolar" runat="server" Text="Longitude"></asp:Label>
            <asp:TextBox ID="TextBoxLongSolar" runat="server"></asp:TextBox>  
        </div>

        <div>
            <asp:Button ID="ButtonGetSolarIntensity" runat="server" Text="Get Solar Intensity" OnClick="ButtonGetSolarService_Click" />
            <asp:Label ID="LabelSolarIntensity" runat="server" Text="Average solar intensity: "></asp:Label>
            <asp:Label ID="LabelSolarOutput" runat="server" Text="Average solar intensity"></asp:Label>
        </div>
     </div>


    <div>
        <div><h5>5 day weather forecast: </h5>
            A 5-day min and max temperature forecast for a given zipcode
        </div>
  
        <div>
            <asp:TextBox ID="txtZipcode" runat="server" Width="100px" placeholder="Zipcode:"></asp:TextBox>
            <asp:Button ID="ButtonGetForecast" runat="server" OnClick="ButtonGetForecast_Click" Text="Get Forecast" />
        </div>
 
         <div>
            <asp:Label ID ="labelWS" runat="server"></asp:Label>
        </div>    
    </div>


    <div>
        <div><h5>Air Quality RESTful service: </h5>
            Air Quality metric for a given location (latitude and longitude)
        </div>

        <div>
            <asp:Label ID="LabelLatAQ" runat="server" Text="Latitude"></asp:Label>
            <asp:TextBox ID="TextBoxLatAQ" runat="server"></asp:TextBox>
            <asp:Label ID="LabelLongAQ" runat="server" Text="Longitude"></asp:Label>
            <asp:TextBox ID="TextBoxLongAQ" runat="server"></asp:TextBox>
        </div>

        <div>
            <asp:Button ID="ButtonAQ" runat="server" OnClick="ButtonGetAQ_Click" Text="Get Air Quality" />
            <asp:Label ID ="labelAQOutput" runat="server"></asp:Label>
        </div>
    </div>

</asp:Content>
