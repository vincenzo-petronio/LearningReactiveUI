using ReactiveUI;

namespace WpfApp.ViewModels
{
    public class TodoViewModel : ReactiveObject, IRoutableViewModel
    {
        public IScreen HostScreen { get; protected set; }

        public string Text { get; internal set; }

        public TodoViewModel(IScreen screen = null)
        {
            HostScreen = screen;

            Text = "provatest tesx satetaetaet";
        }

        #region Impl Interface
        public string UrlPathSegment => "todo";
        #endregion
    }
}
