<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Member.aspx.cs" Inherits="Assignment5.Member.Member" %>

<%@ Register src="../username.ascx" tagname="username" tagprefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Member Page</title>
</head>
<body>
    
    <form id ="WindServices" runat="server">

        <p>The below Welcome message is a user control and is getting the username from the Session["name"] variable</p>

        <uc1:username ID="username1" runat="server" />

        <h1>Location Services Application</h1>
        <p>This is an application that provides several location based services based on your zipcode</p>

        <div>
            <div>
                <h4>Wind Energy Service: </h4>
                <p>Return the annual average wind index of a given position (latitude, longitude). </p>        
                <p>This service can be used for deciding if installing a windmill device is effective at the location </p>
            </div>

            <div>
                <asp:Label ID="LabelLatWind" runat="server" Text="Latitude"></asp:Label>
                <asp:TextBox ID="TextBoxLatWind" runat="server"></asp:TextBox>
                <asp:Label ID="LabelLongWind" runat="server" Text="Longitude"></asp:Label>
                <asp:TextBox ID="TextBoxLongWind" runat="server"></asp:TextBox>
            </div>

            <br />
            <div>            
                <asp:Button ID="ButtonGetWindSpeed" runat="server" Text="Get Wind Speed" OnClick="ButtonGetWindSpeed_Click"/>
                <asp:Label ID="LabelWindSpeed" runat="server" Text="Wind Speed:"></asp:Label>
                <asp:Label ID="LabelWindOutput" runat="server" Text="Wind speed will be displayed here"></asp:Label>
            </div>
        </div>
     

        <div>
            <div><h4>Solar Energy Service: </h4>
                <p>Return the annual average sunshine index of a given position (latitude, longitude). </p>
                <p>This service can be used for deciding if installing a solar energy device is effective at the location</p>
            </div>
        
            <div>    
                <asp:Label ID="LabelLatSolar" runat="server" Text="Latitude"></asp:Label>
                <asp:TextBox ID="TextBoxLatSolar" runat="server"></asp:TextBox>
                <asp:Label ID="LabelLongSolar" runat="server" Text="Longitude"></asp:Label>
                <asp:TextBox ID="TextBoxLongSolar" runat="server"></asp:TextBox>  
            </div>
            <br />
            <div>
                <asp:Button ID="ButtonGetSolarIntensity" runat="server" Text="Get Solar Intensity" OnClick="ButtonGetSolarIntensity_Click"/>
                <asp:Label ID="LabelSolarIntensity" runat="server" Text="Average solar intensity: "></asp:Label>
                <asp:Label ID="LabelSolarOutput" runat="server" Text="Average solar intensity"></asp:Label>
            </div>
     </div>


         <div>
             <div><h5>5 day weather forecast: </h5>
                 A 5-day min and max temperature forecast for a given zipcode
             </div>
  
             <br />
             <div>
                 <asp:TextBox ID="txtZipcode" runat="server" Width="100px" placeholder="Zipcode:"></asp:TextBox>
                 <asp:Button ID="ButtonGetForecast" runat="server" Text="Get Forecast" OnClick="ButtonGetForecast_Click" />
             </div>
                
              <div>
                 <asp:Label ID ="labelWS" runat="server"></asp:Label>
             </div>    
         </div>

    </form>


</body>
</html>
