using DynamicData;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive.Linq;
using System.Threading.Tasks;
using System.Windows.Documents;
using WpfApp.Models;
using WpfApp.Services;

namespace WpfApp.ViewModels
{
    public class TodoViewModel : ReactiveObject, IRoutableViewModel
    {
        private string api => "jsonplaceholder.typicode.com/todos";

        private IDataService dataService { get; set; }

        private readonly ObservableAsPropertyHelper<string> title;
        public string Title => title.Value;

        private readonly ReadOnlyObservableCollection<string> todoItems;
        public ReadOnlyObservableCollection<string> TodoItems => todoItems;

        private SourceList<Todo> dataSource { get; } = new SourceList<Todo>();

        public TodoViewModel(IScreen screen, IDataService dataService)
        {
            HostScreen = screen;

            this.dataService = dataService;

            this.WhenAnyValue(vm => vm.api)
                .Where(x => !string.IsNullOrEmpty(x))
                .ToProperty(this, vm => vm.Title, out title)
                ;

            dataSource
                .Connect()
                .Transform(todo => todo.Title)
                .ObserveOnDispatcher()
                .Bind(out todoItems)
                .DisposeMany()
                .Subscribe()
                ;

            Task.Factory.StartNew(() => Init());
        }

        private async void Init()
        {
            var enumerableItems = await dataService.GetTodoItems();
            foreach(var item in enumerableItems)
            {
                dataSource.Add(item);
            }
        }

        #region Impl Interface
        public IScreen HostScreen { get; set; }

        public string UrlPathSegment => "todo";
        #endregion
    }
}
