using DynamicData;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace WpfApp.ViewModels
{
    /// <summary>
    /// ViewModel usato in Design Time
    /// </summary>
    public class MockTodoViewModel : TodoViewModel
    {
        public MockTodoViewModel() : base(null, null)
        {
            //TodoItems =new ReadOnlyObservableCollection<string>(new List<string>()
            //{
            //    "AAA",
            //    "BBB",
            //    "cccc",
            //    "ddd",
            //    "eeeeeeeeeeeeeeeee",
            //    "f",
            //    "ggggg",
            //    "HHHHHHhhhHHHHHHH",
            //    "iii",
            //    "lllll",
            //    "jansdasnoemfs,dmf",
            //});
        }

    }
}
