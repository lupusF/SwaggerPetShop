using SwaggerPetShop.Services.Implementation;
using SwaggerPetShop.Services.Interface;
using SwaggerPetShop.View;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace SwaggerPetShop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            DependencyInjector.Register<IFindByStatusService, FindByStatusService>();
            DependencyInjector.Register<IAddPetService, AddPetService>();
            DependencyInjector.Register<IDeletePetService, DeletePetService>();
            DependencyInjector.Register<IGetByIdService, GetByIdService>();
            DependencyInjector.Register<IUpdatePetService, UpdatePetService>();
            MainWindow = DependencyInjector.Retrieve<MainWin>();
            MainWindow.Show();
        }
    }
}
