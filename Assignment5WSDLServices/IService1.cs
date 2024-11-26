using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Assignment5WSDLServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        List<List<string>> Weather5day(string zipcode);

        // TODO: Add your service operations here

        [OperationContract]
        decimal WindIntensity(decimal latitude, decimal longitude);

        [OperationContract]
        decimal SolarIntensity(decimal latitude, decimal longitude);

        [OperationContract]
        string getLatLng(string zipcode);

    }


}
