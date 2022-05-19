using SwaggerPetShop.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SwaggerPetShop.Commands
{
    public class GetPetByStatusCommand : ICommand
    {
        private MainViewModel _vm;
        public event EventHandler? CanExecuteChanged;

        public GetPetByStatusCommand(MainViewModel vm)
        {
            _vm = vm;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            _vm.GetPetByStatus();
        }
    }
}
