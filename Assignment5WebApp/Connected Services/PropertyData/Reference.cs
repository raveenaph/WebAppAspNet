﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Assignment5.PropertyData {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="PropertyData.IService1")]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/getAirQuality", ReplyAction="http://tempuri.org/IService1/getAirQualityResponse")]
        string getAirQuality(decimal latitude, decimal longitude);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/getAirQuality", ReplyAction="http://tempuri.org/IService1/getAirQualityResponse")]
        System.Threading.Tasks.Task<string> getAirQualityAsync(decimal latitude, decimal longitude);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetPropertyData", ReplyAction="http://tempuri.org/IService1/GetPropertyDataResponse")]
        string GetPropertyData(string address, string propertyType, int bedrooms, int bathrooms, int squareFootage, int compCount);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetPropertyData", ReplyAction="http://tempuri.org/IService1/GetPropertyDataResponse")]
        System.Threading.Tasks.Task<string> GetPropertyDataAsync(string address, string propertyType, int bedrooms, int bathrooms, int squareFootage, int compCount);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : Assignment5.PropertyData.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<Assignment5.PropertyData.IService1>, Assignment5.PropertyData.IService1 {
        
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
        
        public string getAirQuality(decimal latitude, decimal longitude) {
            return base.Channel.getAirQuality(latitude, longitude);
        }
        
        public System.Threading.Tasks.Task<string> getAirQualityAsync(decimal latitude, decimal longitude) {
            return base.Channel.getAirQualityAsync(latitude, longitude);
        }
        
        public string GetPropertyData(string address, string propertyType, int bedrooms, int bathrooms, int squareFootage, int compCount) {
            return base.Channel.GetPropertyData(address, propertyType, bedrooms, bathrooms, squareFootage, compCount);
        }
        
        public System.Threading.Tasks.Task<string> GetPropertyDataAsync(string address, string propertyType, int bedrooms, int bathrooms, int squareFootage, int compCount) {
            return base.Channel.GetPropertyDataAsync(address, propertyType, bedrooms, bathrooms, squareFootage, compCount);
        }
    }
}