using System;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;

namespace BinaryCalculator.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            Services = ConfigureServices();
        }

        public new static App Current => (Application.Current as App)!;

        public IServiceProvider Services { get; }

        private static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            services.AddTransient<MainViewModel>();

            return services.BuildServiceProvider();
        }
    }
}
