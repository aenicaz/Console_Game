﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClientWPF.ServiceReference1 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IAuthorization", CallbackContract=typeof(ClientWPF.ServiceReference1.IAuthorizationCallback))]
    public interface IAuthorization {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthorization/Authorization", ReplyAction="http://tempuri.org/IAuthorization/AuthorizationResponse")]
        System.Guid Authorization(string login, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthorization/Authorization", ReplyAction="http://tempuri.org/IAuthorization/AuthorizationResponse")]
        System.Threading.Tasks.Task<System.Guid> AuthorizationAsync(string login, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthorization/Disconnect", ReplyAction="http://tempuri.org/IAuthorization/DisconnectResponse")]
        void Disconnect(System.Guid id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthorization/Disconnect", ReplyAction="http://tempuri.org/IAuthorization/DisconnectResponse")]
        System.Threading.Tasks.Task DisconnectAsync(System.Guid id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthorization/AvailabilityLogin", ReplyAction="http://tempuri.org/IAuthorization/AvailabilityLoginResponse")]
        bool AvailabilityLogin(string login);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthorization/AvailabilityLogin", ReplyAction="http://tempuri.org/IAuthorization/AvailabilityLoginResponse")]
        System.Threading.Tasks.Task<bool> AvailabilityLoginAsync(string login);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthorization/ServerStatus", ReplyAction="http://tempuri.org/IAuthorization/ServerStatusResponse")]
        void ServerStatus();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthorization/ServerStatus", ReplyAction="http://tempuri.org/IAuthorization/ServerStatusResponse")]
        System.Threading.Tasks.Task ServerStatusAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthorization/Registration", ReplyAction="http://tempuri.org/IAuthorization/RegistrationResponse")]
        System.Guid Registration(string login, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthorization/Registration", ReplyAction="http://tempuri.org/IAuthorization/RegistrationResponse")]
        System.Threading.Tasks.Task<System.Guid> RegistrationAsync(string login, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthorization/ChangePosition", ReplyAction="http://tempuri.org/IAuthorization/ChangePositionResponse")]
        void ChangePosition(System.Guid id, System.Windows.Point position);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthorization/ChangePosition", ReplyAction="http://tempuri.org/IAuthorization/ChangePositionResponse")]
        System.Threading.Tasks.Task ChangePositionAsync(System.Guid id, System.Windows.Point position);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthorization/GetDataUsingDataContract", ReplyAction="http://tempuri.org/IAuthorization/GetDataUsingDataContractResponse")]
        WcfService.CompositeType GetDataUsingDataContract(WcfService.CompositeType composite);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthorization/GetDataUsingDataContract", ReplyAction="http://tempuri.org/IAuthorization/GetDataUsingDataContractResponse")]
        System.Threading.Tasks.Task<WcfService.CompositeType> GetDataUsingDataContractAsync(WcfService.CompositeType composite);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthorization/GetAllPlayers", ReplyAction="http://tempuri.org/IAuthorization/GetAllPlayersResponse")]
        WcfService.Engine.PlayerServer[] GetAllPlayers(System.Guid id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthorization/GetAllPlayers", ReplyAction="http://tempuri.org/IAuthorization/GetAllPlayersResponse")]
        System.Threading.Tasks.Task<WcfService.Engine.PlayerServer[]> GetAllPlayersAsync(System.Guid id);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IAuthorizationCallback {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthorization/ConnectEnemy", ReplyAction="http://tempuri.org/IAuthorization/ConnectEnemyResponse")]
        void ConnectEnemy(WcfService.Engine.PlayerServer player);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthorization/DisconectEnemy", ReplyAction="http://tempuri.org/IAuthorization/DisconectEnemyResponse")]
        void DisconectEnemy(System.Guid id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthorization/ChangeEnemyPosition", ReplyAction="http://tempuri.org/IAuthorization/ChangeEnemyPositionResponse")]
        void ChangeEnemyPosition(System.Guid id, System.Windows.Point position);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IAuthorizationChannel : ClientWPF.ServiceReference1.IAuthorization, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class AuthorizationClient : System.ServiceModel.DuplexClientBase<ClientWPF.ServiceReference1.IAuthorization>, ClientWPF.ServiceReference1.IAuthorization {
        
        public AuthorizationClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public AuthorizationClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public AuthorizationClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public AuthorizationClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public AuthorizationClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public System.Guid Authorization(string login, string password) {
            return base.Channel.Authorization(login, password);
        }
        
        public System.Threading.Tasks.Task<System.Guid> AuthorizationAsync(string login, string password) {
            return base.Channel.AuthorizationAsync(login, password);
        }
        
        public void Disconnect(System.Guid id) {
            base.Channel.Disconnect(id);
        }
        
        public System.Threading.Tasks.Task DisconnectAsync(System.Guid id) {
            return base.Channel.DisconnectAsync(id);
        }
        
        public bool AvailabilityLogin(string login) {
            return base.Channel.AvailabilityLogin(login);
        }
        
        public System.Threading.Tasks.Task<bool> AvailabilityLoginAsync(string login) {
            return base.Channel.AvailabilityLoginAsync(login);
        }
        
        public void ServerStatus() {
            base.Channel.ServerStatus();
        }
        
        public System.Threading.Tasks.Task ServerStatusAsync() {
            return base.Channel.ServerStatusAsync();
        }
        
        public System.Guid Registration(string login, string password) {
            return base.Channel.Registration(login, password);
        }
        
        public System.Threading.Tasks.Task<System.Guid> RegistrationAsync(string login, string password) {
            return base.Channel.RegistrationAsync(login, password);
        }
        
        public void ChangePosition(System.Guid id, System.Windows.Point position) {
            base.Channel.ChangePosition(id, position);
        }
        
        public System.Threading.Tasks.Task ChangePositionAsync(System.Guid id, System.Windows.Point position) {
            return base.Channel.ChangePositionAsync(id, position);
        }
        
        public WcfService.CompositeType GetDataUsingDataContract(WcfService.CompositeType composite) {
            return base.Channel.GetDataUsingDataContract(composite);
        }
        
        public System.Threading.Tasks.Task<WcfService.CompositeType> GetDataUsingDataContractAsync(WcfService.CompositeType composite) {
            return base.Channel.GetDataUsingDataContractAsync(composite);
        }
        
        public WcfService.Engine.PlayerServer[] GetAllPlayers(System.Guid id) {
            return base.Channel.GetAllPlayers(id);
        }
        
        public System.Threading.Tasks.Task<WcfService.Engine.PlayerServer[]> GetAllPlayersAsync(System.Guid id) {
            return base.Channel.GetAllPlayersAsync(id);
        }
    }
}
