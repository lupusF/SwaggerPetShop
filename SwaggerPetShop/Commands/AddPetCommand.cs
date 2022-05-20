using SwaggerPetShop.Model;
using SwaggerPetShop.Services.Implementation;
using SwaggerPetShop.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SwaggerPetShop.Commands
{
    public class AddPetCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public MainViewModel _vm;

        public AddPetCommand(MainViewModel vm)
        {
            _vm = vm;
        }

        public bool CanExecute(object? parameter)
        {
            //TODO validation
            return true;
        }

        public void Execute(object? parameter)
        {
            _vm.AddPet(parameter as Pet); 
        }
    }
}
