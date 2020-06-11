using Microsoft.Extensions.Configuration;
using ReactiveUI;
using Splat;
using WpfApp.Views;

namespace WpfApp.ViewModels
{
    public class AppBootstrapper : ReactiveObject, IScreen
    {
        private readonly IConfiguration Configuration;

        public string Version { get; internal set; }

        public AppBootstrapper(IConfiguration configuration)
        {
            Configuration = configuration;

            // ReactiveUI Router
            Router = new RoutingState();

            // ReactiveUI IoC container
            Locator.CurrentMutable.RegisterConstant(this, typeof(IScreen));
            //Locator.CurrentMutable.Register(() => new TodoView(), typeof(IViewFor<TodoViewModel>));

            // INIT
            Version = Configuration["Version"];

            //Router.Navigate.Execute(new TodoViewModel(this));
        }

        public RoutingState Router { get; private set; }
    }
}
