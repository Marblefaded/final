using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Course.Models;
using Course.Models.StaticTabs;
using Microsoft.EntityFrameworkCore;
using System;

namespace Course.Views
{
    public partial class FirstView : UserControl
    {
        public FirstView()
        {
            InitializeComponent();
            /*this.FindControl<MenuItem>("Exit").Click += delegate
            {
                //this.Close();
            };*/
            this.FindControl<MenuItem>("Save").Click += delegate
            {
                //this.Save();
            };

            this.FindControl<MenuItem>("About").Click += delegate
            {
                var window = new Info();
                window.ShowDialog((Window)this.VisualRoot);
            };
            this.Find<DataGrid>("DataTable").AutoGeneratingColumn += dataGrid_AutoGeneratingColumn;
            this.FindControl<TabControl>("DataTabs").SelectionChanged += tabControl_SelectionChanged;
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
        private void tabControl_SelectionChanged(object? sender,
           SelectionChangedEventArgs e)
        {
            object? selectedTab;
            selectedTab = this.FindControl<TabControl>("DataTabs").SelectedItem;
            if (selectedTab != null)
            {
                if (selectedTab is DynamicTab)
                {
                    var selectedItems = (selectedTab as DynamicTab).ObjectList;
                    if (selectedItems != null)
                        this.Find<DataGrid>("DataTable").Items = selectedItems;
                }
                else
                {
                    if (selectedTab is MatchTab)
                    {
                        var selectedItems = (selectedTab as MatchTab).DBS;
                        if (selectedItems != null)
                            this.Find<DataGrid>("DataTable").Items = selectedItems;
                    }
                    else if (selectedTab is PlayerStatTab)
                    {
                        var selectedItems = (selectedTab as PlayerStatTab).DBS;
                        if (selectedItems != null)
                            this.Find<DataGrid>("DataTable").Items = selectedItems;
                    }
                    else if (selectedTab is TournamentTab)
                    {
                        var selectedItems = (selectedTab as TournamentTab).DBS;
                        if (selectedItems != null)
                            this.Find<DataGrid>("DataTable").Items = selectedItems;
                    }
                    else if (selectedTab is ResultTab)
                    {
                        var selectedItems = (selectedTab as ResultTab).DBS;
                        if (selectedItems != null)
                            this.Find<DataGrid>("DataTable").Items = selectedItems;
                    }
                    else throw new System.ArgumentException();
                }
            }
        }
        private void dataGrid_AutoGeneratingColumn(object? sender,
        DataGridAutoGeneratingColumnEventArgs e)
        {
            var tab = (this.FindControl<TabControl>("DataTabs").SelectedItem as MyTab);
            if (!tab.DataColumns.Contains(e.Column.Header.ToString()))
                e.Column.IsVisible = false;
        }
    }
}
