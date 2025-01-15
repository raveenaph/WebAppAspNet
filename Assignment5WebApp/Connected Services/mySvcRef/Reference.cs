﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Assignment5.mySvcRef {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="mySvcRef.IService1")]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Weather5day", ReplyAction="http://tempuri.org/IService1/Weather5dayResponse")]
        string[][] Weather5day(string zipcode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Weather5day", ReplyAction="http://tempuri.org/IService1/Weather5dayResponse")]
        System.Threading.Tasks.Task<string[][]> Weather5dayAsync(string zipcode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/WindIntensity", ReplyAction="http://tempuri.org/IService1/WindIntensityResponse")]
        decimal WindIntensity(decimal latitude, decimal longitude);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/WindIntensity", ReplyAction="http://tempuri.org/IService1/WindIntensityResponse")]
        System.Threading.Tasks.Task<decimal> WindIntensityAsync(decimal latitude, decimal longitude);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/SolarIntensity", ReplyAction="http://tempuri.org/IService1/SolarIntensityResponse")]
        decimal SolarIntensity(decimal latitude, decimal longitude);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/SolarIntensity", ReplyAction="http://tempuri.org/IService1/SolarIntensityResponse")]
        System.Threading.Tasks.Task<decimal> SolarIntensityAsync(decimal latitude, decimal longitude);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/getLatLng", ReplyAction="http://tempuri.org/IService1/getLatLngResponse")]
        string getLatLng(string zipcode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/getLatLng", ReplyAction="http://tempuri.org/IService1/getLatLngResponse")]
        System.Threading.Tasks.Task<string> getLatLngAsync(string zipcode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/NaturalHazardData", ReplyAction="http://tempuri.org/IService1/NaturalHazardDataResponse")]
        string[] NaturalHazardData(string type, string latitude, string longitude);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/NaturalHazardData", ReplyAction="http://tempuri.org/IService1/NaturalHazardDataResponse")]
        System.Threading.Tasks.Task<string[]> NaturalHazardDataAsync(string type, string latitude, string longitude);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : Assignment5.mySvcRef.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<Assignment5.mySvcRef.IService1>, Assignment5.mySvcRef.IService1 {
        
        public Service1Client() {
        }
        
        public Service1Client(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Service1Client(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string[][] Weather5day(string zipcode) {
            return base.Channel.Weather5day(zipcode);
        }
        
        public System.Threading.Tasks.Task<string[][]> Weather5dayAsync(string zipcode) {
            return base.Channel.Weather5dayAsync(zipcode);
        }
        
        public decimal WindIntensity(decimal latitude, decimal longitude) {
            return base.Channel.WindIntensity(latitude, longitude);
        }
        
        public System.Threading.Tasks.Task<decimal> WindIntensityAsync(decimal latitude, decimal longitude) {
            return base.Channel.WindIntensityAsync(latitude, longitude);
        }
        
        public decimal SolarIntensity(decimal latitude, decimal longitude) {
            return base.Channel.SolarIntensity(latitude, longitude);
        }
        
        public System.Threading.Tasks.Task<decimal> SolarIntensityAsync(decimal latitude, decimal longitude) {
            return base.Channel.SolarIntensityAsync(latitude, longitude);
        }
        
        public string getLatLng(string zipcode) {
            return base.Channel.getLatLng(zipcode);
        }
        
        public System.Threading.Tasks.Task<string> getLatLngAsync(string zipcode) {
            return base.Channel.getLatLngAsync(zipcode);
        }
        
        public string[] NaturalHazardData(string type, string latitude, string longitude) {
            return base.Channel.NaturalHazardData(type, latitude, longitude);
        }
        
        public System.Threading.Tasks.Task<string[]> NaturalHazardDataAsync(string type, string latitude, string longitude) {
            return base.Channel.NaturalHazardDataAsync(type, latitude, longitude);
        }
    }
}
