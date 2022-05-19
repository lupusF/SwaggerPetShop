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
            MainWindow = DependencyInjector.Retrieve<MainWin>();
            MainWindow.Show();
        }
    }
}
