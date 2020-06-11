using ReactiveUI;

namespace WpfApp.ViewModels
{
    public class TodoViewModel : ReactiveObject, IRoutableViewModel
    {
        public IScreen HostScreen { get; protected set; }

        public TodoViewModel(IScreen screen = null)
        {
            HostScreen = screen;
        }

        #region Impl Interface
        public string UrlPathSegment => "todo";
        #endregion
    }
}
