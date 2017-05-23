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
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/DongleServiceContract/getIncomingSms", ReplyAction="http://tempuri.org/DongleServiceContract/getIncomingSmsResponse")]
        DongleService.Structs.SMSObject[] getIncomingSms(long uid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/DongleServiceContract/addNewUser", ReplyAction="http://tempuri.org/DongleServiceContract/addNewUserResponse")]
        DongleService.Structs.ExecuteResponse addNewUser(string username, string password, string phone, string name, string email);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/DongleServiceContract/updatePassword", ReplyAction="http://tempuri.org/DongleServiceContract/updatePasswordResponse")]
        DongleService.Structs.ExecuteResponse updatePassword(long uid, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/DongleServiceContract/sendSMS", ReplyAction="http://tempuri.org/DongleServiceContract/sendSMSResponse")]
        DongleService.Structs.ExecuteResponse sendSMS(long senderId, string to, string messsage);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/DongleServiceContract/setComId", ReplyAction="http://tempuri.org/DongleServiceContract/setComIdResponse")]
        bool setComId(ushort comId);
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
        
        public DongleService.Structs.SMSObject[] getIncomingSms(long uid) {
            return base.Channel.getIncomingSms(uid);
        }
        
        public DongleService.Structs.ExecuteResponse addNewUser(string username, string password, string phone, string name, string email) {
            return base.Channel.addNewUser(username, password, phone, name, email);
        }
        
        public DongleService.Structs.ExecuteResponse updatePassword(long uid, string password) {
            return base.Channel.updatePassword(uid, password);
        }
        
        public DongleService.Structs.ExecuteResponse sendSMS(long senderId, string to, string messsage) {
            return base.Channel.sendSMS(senderId, to, messsage);
        }
        
        public bool setComId(ushort comId) {
            return base.Channel.setComId(comId);
        }
    }
}
