using System;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Windows;


namespace WcfService.Engine
{
    [DataContract]
    public class PlayerServer
    {
        [DataMember]
        private string _login;
        [DataMember]
        private Guid _id;
        [DataMember]
        private Point _position;

        public OperationContext OperationContext {get;set;}

        public Point Position 
        {
            get
            {
                return _position;
            }
            set
            {
                _position = value;
            }
        }

        public Guid ID
        {
            get { return _id; }
        }

        public string Login
        {
            get { return _login; }
        }

        public PlayerServer(string login, Guid id, OperationContext operationContext)
        {
            _login = login;
            _id = id;
            Position = new Point(0, 0);
            OperationContext = operationContext;

        }
    }
}
