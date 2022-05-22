using SwaggerPetShop.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SwaggerPetShop.Commands
{
    public class AddNewItemClickedCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        private MainViewModel _vm;

        public AddNewItemClickedCommand(MainViewModel vm)
        {
            _vm = vm;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            _vm.AddNewItemClicked();
        }
    }
}
