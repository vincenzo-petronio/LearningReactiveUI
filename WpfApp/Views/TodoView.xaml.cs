using ReactiveUI;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using WpfApp.ViewModels;

namespace WpfApp.Views
{

    public class TodoBaseView : ReactiveUserControl<TodoViewModel> { }

    /// <summary>
    /// Interaction logic for Todo.xaml
    /// </summary>
    public partial class TodoView : TodoBaseView
    {
        public TodoView()
        {
            InitializeComponent();

            this.WhenActivated(disposable =>
            {
                this.OneWayBind(this.ViewModel, vm => vm.Title, v => v.ID_title.Content).DisposeWith(disposable);
                this.OneWayBind(this.ViewModel, vm => vm.TodoItems, v => v.ID_lvItems.ItemsSource).DisposeWith(disposable);
            });
        }
    }
}
