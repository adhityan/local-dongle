﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LocalDongle.DongleServer {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="DongleServer.DongleServiceContract")]
    public interface DongleServiceContract {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/DongleServiceContract/login", ReplyAction="http://tempuri.org/DongleServiceContract/loginResponse")]
        DongleService.Structs.LoginResponse login(string username, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/DongleServiceContract/getSMS", ReplyAction="http://tempuri.org/DongleServiceContract/getSMSResponse")]
        DongleService.Structs.SMSObject[] getSMS(long uid);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface DongleServiceContractChannel : LocalDongle.DongleServer.DongleServiceContract, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class DongleServiceContractClient : System.ServiceModel.ClientBase<LocalDongle.DongleServer.DongleServiceContract>, LocalDongle.DongleServer.DongleServiceContract {
        
        public DongleServiceContractClient() {
        }
        
        public DongleServiceContractClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public DongleServiceContractClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DongleServiceContractClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DongleServiceContractClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public DongleService.Structs.LoginResponse login(string username, string password) {
            return base.Channel.login(username, password);
        }
        
        public DongleService.Structs.SMSObject[] getSMS(long uid) {
            return base.Channel.getSMS(uid);
        }
    }
}
