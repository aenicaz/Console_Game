using ClientWPF.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientWPF.ViewModel
{
    abstract class BaseViewModel
    {
        protected Mediator mediator;

        public virtual void Send(object data)
        {
            mediator.Send(data, this);
        }

        public BaseViewModel(Mediator mediator)
        {
            this.mediator = mediator;
        }

        public abstract void Notify(object data);
    }
}
