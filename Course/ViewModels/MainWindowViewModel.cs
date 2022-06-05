using System;
using System.Collections.ObjectModel;
using ReactiveUI;
using Course.Models;
using Course.Models.Database;
using Course.Models.StaticTabs;

namespace Course.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            CreateContext();
            CreateTabs();
            CreateQueries();
            Content = Fv = new FirstViewModel(this);
            Sv = new SecondViewModel(this);
        }
        ViewModelBase content;
        public ViewModelBase Content
        {
            get { return content; }
            set { this.RaiseAndSetIfChanged(ref content, value); }
        }
        public void Change()
        {
            if (Content == Fv)
                Content = Sv;
            else if (Content == Sv)
                Content = Fv;
            else throw new InvalidOperationException();
        }

        ObservableCollection<MyTab> tabs;
        public ObservableCollection<MyTab> Tabs
        {
            get { return tabs; }
            set { this.RaiseAndSetIfChanged(ref tabs, value); }
        }

        ObservableCollection<Query> queries;
        public ObservableCollection<Query> Queries
        {
            get { return queries; }
            set { this.RaiseAndSetIfChanged(ref queries, value); }
        }

        public FirstViewModel Fv { get; }
        public SecondViewModel Sv { get; }

        Models.Database.snookerContext data;

        public Models.Database.snookerContext Data
        {
            get { return data; }
            set { this.RaiseAndSetIfChanged(ref data, value); }
        }
        private void CreateContext()
        {
            Data = new Models.Database.snookerContext();
        }

        private void CreateTabs()
        {
            Tabs = new ObservableCollection<MyTab>();
            Tabs.Add(new MatchTab("match", Data.Matches));
            Tabs.Add(new TournamentTab("tournament", Data.Tournaments));
            Tabs.Add(new PlayerStatTab("player", Data.Players));
            Tabs.Add(new ResultTab("result", Data.Results));
        }
        private void CreateQueries()
        {
            Queries = new ObservableCollection<Query>();
        }
    }
}
