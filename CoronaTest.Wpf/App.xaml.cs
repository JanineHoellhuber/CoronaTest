using CoronaTest.Wpf.Common;
using CoronaTest.WPF;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace CoronaTest.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private async void Application_Startup(object sender, StartupEventArgs e)
        {
            WindowController controller = new WindowController();
            controller.ShowWindow(await MainViewModel.CreateAsync(controller));
        }
    }
}
