using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Windows;
using WcfService.Engine; 

namespace WcfService
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IService1" в коде и файле конфигурации.
    [ServiceContract(CallbackContract = typeof(IClientCallback))]
    public interface IAuthorization
    {

        [OperationContract]
        Guid Authorization(string login, string password);

        [OperationContract]
        void Disconnect(Guid id);

        [OperationContract]
        bool AvailabilityLogin(string login);

        [OperationContract]
        void ServerStatus();

        [OperationContract]
        Guid Registration(string login, string password);

        [OperationContract]
        void ChangePosition(Guid id, Point position);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        [OperationContract]
        List<PlayerServer> GetAllPlayers(Guid id);

        [OperationContract]
        List<FoodPoint> GetFoods();

        // TODO: Добавьте здесь операции служб
    }


    // Используйте контракт данных, как показано в примере ниже, чтобы добавить составные типы к операциям служб.
    [DataContract]
    public class CompositeType
    {
        private bool boolValue = true;
        private string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
