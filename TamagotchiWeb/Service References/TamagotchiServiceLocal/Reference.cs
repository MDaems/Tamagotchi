﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TamagotchiWeb.TamagotchiServiceLocal {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Tamagotchi", Namespace="http://schemas.datacontract.org/2004/07/TamagotchiWebService")]
    [System.SerializableAttribute()]
    public partial class Tamagotchi : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int AgeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int BoredomField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int HealthField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int HungerField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime LastAccessField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int SleepField;
        
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
        public int Age {
            get {
                return this.AgeField;
            }
            set {
                if ((this.AgeField.Equals(value) != true)) {
                    this.AgeField = value;
                    this.RaisePropertyChanged("Age");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Boredom {
            get {
                return this.BoredomField;
            }
            set {
                if ((this.BoredomField.Equals(value) != true)) {
                    this.BoredomField = value;
                    this.RaisePropertyChanged("Boredom");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Health {
            get {
                return this.HealthField;
            }
            set {
                if ((this.HealthField.Equals(value) != true)) {
                    this.HealthField = value;
                    this.RaisePropertyChanged("Health");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Hunger {
            get {
                return this.HungerField;
            }
            set {
                if ((this.HungerField.Equals(value) != true)) {
                    this.HungerField = value;
                    this.RaisePropertyChanged("Hunger");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ID {
            get {
                return this.IDField;
            }
            set {
                if ((this.IDField.Equals(value) != true)) {
                    this.IDField = value;
                    this.RaisePropertyChanged("ID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime LastAccess {
            get {
                return this.LastAccessField;
            }
            set {
                if ((this.LastAccessField.Equals(value) != true)) {
                    this.LastAccessField = value;
                    this.RaisePropertyChanged("LastAccess");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Sleep {
            get {
                return this.SleepField;
            }
            set {
                if ((this.SleepField.Equals(value) != true)) {
                    this.SleepField = value;
                    this.RaisePropertyChanged("Sleep");
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
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CompositeType", Namespace="http://schemas.datacontract.org/2004/07/TamagotchiService")]
    [System.SerializableAttribute()]
    public partial class CompositeType : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool BoolValueField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string StringValueField;
        
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
        public bool BoolValue {
            get {
                return this.BoolValueField;
            }
            set {
                if ((this.BoolValueField.Equals(value) != true)) {
                    this.BoolValueField = value;
                    this.RaisePropertyChanged("BoolValue");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string StringValue {
            get {
                return this.StringValueField;
            }
            set {
                if ((object.ReferenceEquals(this.StringValueField, value) != true)) {
                    this.StringValueField = value;
                    this.RaisePropertyChanged("StringValue");
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
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="TamagotchiServiceLocal.ITamagotchiService")]
    public interface ITamagotchiService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITamagotchiService/GetAllTamagotchies", ReplyAction="http://tempuri.org/ITamagotchiService/GetAllTamagotchiesResponse")]
        TamagotchiWeb.TamagotchiServiceLocal.Tamagotchi[] GetAllTamagotchies();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITamagotchiService/GetAllTamagotchies", ReplyAction="http://tempuri.org/ITamagotchiService/GetAllTamagotchiesResponse")]
        System.Threading.Tasks.Task<TamagotchiWeb.TamagotchiServiceLocal.Tamagotchi[]> GetAllTamagotchiesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITamagotchiService/GetTamagotchi", ReplyAction="http://tempuri.org/ITamagotchiService/GetTamagotchiResponse")]
        TamagotchiWeb.TamagotchiServiceLocal.Tamagotchi GetTamagotchi(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITamagotchiService/GetTamagotchi", ReplyAction="http://tempuri.org/ITamagotchiService/GetTamagotchiResponse")]
        System.Threading.Tasks.Task<TamagotchiWeb.TamagotchiServiceLocal.Tamagotchi> GetTamagotchiAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITamagotchiService/AddTamagotchi", ReplyAction="http://tempuri.org/ITamagotchiService/AddTamagotchiResponse")]
        void AddTamagotchi(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITamagotchiService/AddTamagotchi", ReplyAction="http://tempuri.org/ITamagotchiService/AddTamagotchiResponse")]
        System.Threading.Tasks.Task AddTamagotchiAsync(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITamagotchiService/StartTimer", ReplyAction="http://tempuri.org/ITamagotchiService/StartTimerResponse")]
        void StartTimer();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITamagotchiService/StartTimer", ReplyAction="http://tempuri.org/ITamagotchiService/StartTimerResponse")]
        System.Threading.Tasks.Task StartTimerAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITamagotchiService/GetDataUsingDataContract", ReplyAction="http://tempuri.org/ITamagotchiService/GetDataUsingDataContractResponse")]
        TamagotchiWeb.TamagotchiServiceLocal.CompositeType GetDataUsingDataContract(TamagotchiWeb.TamagotchiServiceLocal.CompositeType composite);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITamagotchiService/GetDataUsingDataContract", ReplyAction="http://tempuri.org/ITamagotchiService/GetDataUsingDataContractResponse")]
        System.Threading.Tasks.Task<TamagotchiWeb.TamagotchiServiceLocal.CompositeType> GetDataUsingDataContractAsync(TamagotchiWeb.TamagotchiServiceLocal.CompositeType composite);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ITamagotchiServiceChannel : TamagotchiWeb.TamagotchiServiceLocal.ITamagotchiService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class TamagotchiServiceClient : System.ServiceModel.ClientBase<TamagotchiWeb.TamagotchiServiceLocal.ITamagotchiService>, TamagotchiWeb.TamagotchiServiceLocal.ITamagotchiService {
        
        public TamagotchiServiceClient() {
        }
        
        public TamagotchiServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public TamagotchiServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TamagotchiServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TamagotchiServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public TamagotchiWeb.TamagotchiServiceLocal.Tamagotchi[] GetAllTamagotchies() {
            return base.Channel.GetAllTamagotchies();
        }
        
        public System.Threading.Tasks.Task<TamagotchiWeb.TamagotchiServiceLocal.Tamagotchi[]> GetAllTamagotchiesAsync() {
            return base.Channel.GetAllTamagotchiesAsync();
        }
        
        public TamagotchiWeb.TamagotchiServiceLocal.Tamagotchi GetTamagotchi(int id) {
            return base.Channel.GetTamagotchi(id);
        }
        
        public System.Threading.Tasks.Task<TamagotchiWeb.TamagotchiServiceLocal.Tamagotchi> GetTamagotchiAsync(int id) {
            return base.Channel.GetTamagotchiAsync(id);
        }
        
        public void AddTamagotchi(string name) {
            base.Channel.AddTamagotchi(name);
        }
        
        public System.Threading.Tasks.Task AddTamagotchiAsync(string name) {
            return base.Channel.AddTamagotchiAsync(name);
        }
        
        public void StartTimer() {
            base.Channel.StartTimer();
        }
        
        public System.Threading.Tasks.Task StartTimerAsync() {
            return base.Channel.StartTimerAsync();
        }
        
        public TamagotchiWeb.TamagotchiServiceLocal.CompositeType GetDataUsingDataContract(TamagotchiWeb.TamagotchiServiceLocal.CompositeType composite) {
            return base.Channel.GetDataUsingDataContract(composite);
        }
        
        public System.Threading.Tasks.Task<TamagotchiWeb.TamagotchiServiceLocal.CompositeType> GetDataUsingDataContractAsync(TamagotchiWeb.TamagotchiServiceLocal.CompositeType composite) {
            return base.Channel.GetDataUsingDataContractAsync(composite);
        }
    }
}
