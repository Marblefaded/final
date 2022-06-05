using ReactiveUI;
using System.Reactive;
using Course.Models;

namespace Course.ViewModels
{
    public class FirstViewModel : ViewModelBase
    {
        public FirstViewModel(MainWindowViewModel? mainContext = null)
        {
            MainContext = mainContext;
            ButtonDeleteTab = ReactiveCommand.Create<MyTab, Unit>((tab) =>
            {
                if (tab is DynamicTab)
                {
                    MainContext.Queries.Remove((tab as DynamicTab).BindedQuery);
                }
                MainContext.Tabs.Remove(tab);
                return Unit.Default;
            });
        }
        public ReactiveCommand<MyTab, Unit> ButtonDeleteTab { get; }

        public MainWindowViewModel? MainContext { get; set; }
        bool buttonsEnabled = true;
        public bool ButtonsEnabled
        {
            get { return buttonsEnabled; }
            set { this.RaiseAndSetIfChanged(ref buttonsEnabled, value); }
        }
    }
}
