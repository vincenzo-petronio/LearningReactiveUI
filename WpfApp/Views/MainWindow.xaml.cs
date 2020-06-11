using Microsoft.Extensions.Configuration;
using ReactiveUI;
using System.Reactive.Disposables;
using WpfApp.ViewModels;

namespace WpfApp.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ReactiveWindow<AppBootstrapper>
    {
        /// <summary>
        /// Corrisponde al ViewModel della View iniziale, cioè MainWindow
        /// </summary>
        public AppBootstrapper AppBootstrapper { get; protected set; }

        public MainWindow(IConfiguration configuration)
        {
            InitializeComponent();

            AppBootstrapper = ViewModel = new AppBootstrapper(configuration);

            // Data Binding tra View e ViewModel
            this.WhenActivated(disposable =>
            {
                this.OneWayBind(this.ViewModel, vm => vm.Version, v => v.Title, this.ConvertVersionToTitle).DisposeWith(disposable);
                this.OneWayBind(this.ViewModel, vm => vm.Router, v => v.rvh.Router).DisposeWith(disposable);
            });
        }

        // Inline Binding Converters
        private string ConvertVersionToTitle(string version)
        {
            return $"Learning WPF - v{version}";
        }
    }
}
