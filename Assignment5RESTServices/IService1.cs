using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5RESTServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        [WebGet(UriTemplate = "/getAirQuality?latitude={latitude}&longitude={longitude}")]
        string getAirQuality(decimal latitude, decimal longitude);

        [OperationContract]
        [WebGet(UriTemplate = "/GetPropertyData?address={address}&propertyType={propertyType}&bedrooms={bedrooms}&bathrooms={bathrooms}&squareFootage={squareFootage}&compCount={compCount}",
               ResponseFormat = WebMessageFormat.Json)]
        Task<string> GetPropertyDataAsync(string address, string propertyType, int bedrooms, int bathrooms, int squareFootage, int compCount);
    }

}
