using DynamicData;
using ReactiveUI;
using System;
using System.Collections.ObjectModel;
using System.Reactive.Linq;
using System.Threading.Tasks;
using WpfApp.Models;
using WpfApp.Services;

namespace WpfApp.ViewModels
{
    public class TodoViewModel : ReactiveObject, IRoutableViewModel
    {
        private string api => "jsonplaceholder.typicode.com/todos";

        private IDataService DataService { get; set; }

        private readonly ObservableAsPropertyHelper<string> title;
        public string Title => title.Value;

        /// <summary>
        /// ReadOnlyObservable con la collection in binding sulla ListBox
        /// </summary>
        public ReadOnlyObservableCollection<string> TodoItems;


        private bool isProgressRunning = false;
        public bool IsProgressRunning
        {
            get => isProgressRunning;
            set => this.RaiseAndSetIfChanged(ref isProgressRunning, value);
        }


        private SourceList<Todo> DataSource { get; } = new SourceList<Todo>();

        public TodoViewModel(IScreen screen, IDataService dataService)
        {
            HostScreen = screen;

            this.DataService = dataService;

            this.WhenAnyValue(vm => vm.api)
                .Where(x => !string.IsNullOrEmpty(x))
                .ToProperty(this, vm => vm.Title, out title)
                ;

            DataSource
                .Connect()
                .Filter(todo => !todo.Id.Equals(10))
                .Transform(todo => todo.Id + " - " + todo.Title)
                .ObserveOnDispatcher()
                .Bind(out TodoItems)
                .DisposeMany()
                .Subscribe()
                ;

            Init();
        }

        private async Task Init()
        {
            IsProgressRunning = true;

            var enumerableItems = await DataService.GetTodoItems();
            await Task.Run(async () =>
            {
                await Task.Delay(3000);

                foreach (var item in enumerableItems)
                {
                    DataSource.Add(item);
                }
            });

            IsProgressRunning = false;
        }

        #region Impl Interface
        public IScreen HostScreen { get; set; }

        public string UrlPathSegment => "todo";
        #endregion
    }
}
