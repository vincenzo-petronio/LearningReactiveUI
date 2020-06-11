﻿using ReactiveUI;
using System.Reactive.Disposables;
using WpfApp.ViewModels;

namespace WpfApp.Views
{
    /// <summary>
    /// Interaction logic for Todo.xaml
    /// </summary>
    public partial class TodoView : IViewFor<TodoViewModel>
    {
        public TodoView()
        {
            InitializeComponent();

            this.WhenActivated(disposable =>
            {
                this.OneWayBind(this.ViewModel, vm => vm.Text, v => v.ID_txt.Content).DisposeWith(disposable);
            });
        }
    }
}