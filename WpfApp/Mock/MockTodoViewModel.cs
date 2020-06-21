using DynamicData;
using ReactiveUI;
using Splat;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using WpfApp.Services;

namespace WpfApp.ViewModels
{
    /// <summary>
    /// ViewModel usato in Design Time
    /// </summary>
    public class MockTodoViewModel : TodoViewModel
    {
        private readonly ReadOnlyObservableCollection<string> todoItems;
        public new ReadOnlyObservableCollection<string> TodoItems => todoItems;


        public MockTodoViewModel() : base(Locator.Current.GetService<IScreen>(), new JsonPlaceholderService())
        {
            todoItems.Add(new List<string>()
            {
                "AAA",
                "BBB",
                "cccc",
                "ddd",
                "eeeeeeeeeeeeeeeee",
                "f",
                "ggggg",
                "HHHHHHhhhHHHHHHH",
                "iii",
                "lllll",
                "jansdasnoemfs,dmf",
            });
        }

    }
}
