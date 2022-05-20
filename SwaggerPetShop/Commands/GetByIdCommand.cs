﻿using SwaggerPetShop.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SwaggerPetShop.Commands
{
    public class GetByIdCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;
        public MainViewModel _mainViewModel;

        public GetByIdCommand(MainViewModel vm)
        {
            _mainViewModel = vm;
        }

        public bool CanExecute(object? parameter)
        {
           return true;
        }

        public void Execute(object? parameter)
        {
            _mainViewModel.GetById();
        }
    }
}