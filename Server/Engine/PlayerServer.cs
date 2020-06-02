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
        [DataMember]
        private int _size;
        [DataMember]
        private int _score;

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

        public int Size
        {
            get { return _size; }
            set { _size = value; }
        }

        public int Score
        {
            get { return _score; }
            set { _score = value; }
        }
        public PlayerServer(string login, Guid id, Point lastPosition, OperationContext operationContext)
        {
            _login = login;
            _id = id;
            Position = lastPosition;
            OperationContext = operationContext;
            Size = 32;
        }
        public PlayerServer(string login, Guid id, Point lastPosition, int size, OperationContext operationContext)
        {
            _login = login;
            _id = id;
            Position = lastPosition;
            OperationContext = operationContext;
            Size = size;
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
