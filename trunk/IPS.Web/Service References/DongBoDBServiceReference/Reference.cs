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
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ChangeResultSettings", Namespace="http://schemas.datacontract.org/2004/07/UnitSettingLibrary")]
    [System.SerializableAttribute()]
    public partial class ChangeResultSettings : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private IPS.Web.DongBoDBServiceReference.ChangeResult ChangeResultField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MessageField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public IPS.Web.DongBoDBServiceReference.ChangeResult ChangeResult {
            get {
                return this.ChangeResultField;
            }
            set {
                if ((this.ChangeResultField.Equals(value) != true)) {
                    this.ChangeResultField = value;
                    this.RaisePropertyChanged("ChangeResult");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Message {
            get {
                return this.MessageField;
            }
            set {
                if ((object.ReferenceEquals(this.MessageField, value) != true)) {
                    this.MessageField = value;
                    this.RaisePropertyChanged("Message");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ChangeResult", Namespace="http://schemas.datacontract.org/2004/07/UnitSettingLibrary")]
    public enum ChangeResult : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        ThatBai = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        ThanhCong = 1,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="DongBoDBServiceReference.IDongBoDBServices")]
    public interface IDongBoDBServices {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDongBoDBServices/DongBoDBDauTu", ReplyAction="http://tempuri.org/IDongBoDBServices/DongBoDBDauTuResponse")]
        IPS.Web.DongBoDBServiceReference.ChangeResultSettings DongBoDBDauTu();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDongBoDBServices/DongBoDBDauTu", ReplyAction="http://tempuri.org/IDongBoDBServices/DongBoDBDauTuResponse")]
        System.Threading.Tasks.Task<IPS.Web.DongBoDBServiceReference.ChangeResultSettings> DongBoDBDauTuAsync();
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
        
        public IPS.Web.DongBoDBServiceReference.ChangeResultSettings DongBoDBDauTu() {
            return base.Channel.DongBoDBDauTu();
        }
        
        public System.Threading.Tasks.Task<IPS.Web.DongBoDBServiceReference.ChangeResultSettings> DongBoDBDauTuAsync() {
            return base.Channel.DongBoDBDauTuAsync();
        }
    }
}
