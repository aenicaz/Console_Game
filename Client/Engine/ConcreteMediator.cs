using ClientWPF.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientWPF.Engine
{
    class ConcreteMediator: Mediator
    {
        public ControlVM ControlVM { get; set; }
        public AppViewModel AppViewModel { get; set; }
        public StatisticsVM StatisticsVM { get; set; }

        private static ConcreteMediator _mediator;
        public static ConcreteMediator getInstance()
        {
            if(_mediator != null)
            {
                return _mediator;
            }
            else
            {
                _mediator = new ConcreteMediator();
                return _mediator;
            }
        }

        public override void Send(object data, BaseViewModel viewModel)
        {
            if(viewModel is ControlVM)
            {

            }

            if (viewModel is AppViewModel)
            {
                ControlVM.Notify(data);
            }

            if (viewModel is StatisticsVM)
            {

            }

        }
    }
}
