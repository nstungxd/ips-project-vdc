﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17929
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IPS.Web.DongBoDBServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="DongBoDBServiceReference.IDongBoDBServices")]
    public interface IDongBoDBServices {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDongBoDBServices/DongBoDBDauTu", ReplyAction="http://tempuri.org/IDongBoDBServices/DongBoDBDauTuResponse")]
        UnitSettingLibrary.ChangeResultSettings DongBoDBDauTu();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDongBoDBServices/DongBoDBDauTu", ReplyAction="http://tempuri.org/IDongBoDBServices/DongBoDBDauTuResponse")]
        System.Threading.Tasks.Task<UnitSettingLibrary.ChangeResultSettings> DongBoDBDauTuAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IDongBoDBServicesChannel : IPS.Web.DongBoDBServiceReference.IDongBoDBServices, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class DongBoDBServicesClient : System.ServiceModel.ClientBase<IPS.Web.DongBoDBServiceReference.IDongBoDBServices>, IPS.Web.DongBoDBServiceReference.IDongBoDBServices {
        
        public DongBoDBServicesClient() {
        }
        
        public DongBoDBServicesClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public DongBoDBServicesClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DongBoDBServicesClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DongBoDBServicesClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public UnitSettingLibrary.ChangeResultSettings DongBoDBDauTu() {
            return base.Channel.DongBoDBDauTu();
        }
        
        public System.Threading.Tasks.Task<UnitSettingLibrary.ChangeResultSettings> DongBoDBDauTuAsync() {
            return base.Channel.DongBoDBDauTuAsync();
        }
    }
}
