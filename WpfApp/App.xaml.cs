using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IServiceProvider ServiceProvider { get; private set; }
        public IConfiguration Configuration { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            // Invece di usare StartupUri nello XAML, si può
            // fare l'override e poi lanciare via codice la prima View.

            Configuration = new ConfigurationBuilder()
                //.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            ServiceProvider = new ServiceCollection()
                .AddTransient(typeof(MainWindow))
                // more dependencies here ...
                .BuildServiceProvider();

            // StartupUri
            MainWindow home = new MainWindow(Configuration);
            home.Show();

            base.OnStartup(e);
        }
    }
}
