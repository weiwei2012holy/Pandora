using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using DynamicData;
using Pandora.Services;
using ReactiveUI;

namespace Pandora.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
#pragma warning disable CA1822 // Mark members as static
    public string Greeting => "Welcome to Avalonia!";

    private string? _searchText = "";
    private bool _searching;

    private readonly AppService _appService = new AppService();


    public MainWindowViewModel()
    {
        // var app = AppIt
        var items = _appService.SearchApp(null);
        System.Console.WriteLine("MainWindowViewModel init...");
        System.Console.WriteLine(items);
        AppList = new ObservableCollection<AppItem>(items);
    }


    public string? SearchText
    {
        get => _searchText;
        set
        {
            this.RaiseAndSetIfChanged(ref _searchText, value);
            Searching = true;
            AppList = new ObservableCollection<AppItem>(_appService.SearchApp(value));

            System.Console.WriteLine(value);
            Searching = false;
        }
    }

    public bool Searching
    {
        get => _searching;
        set => this.RaiseAndSetIfChanged(ref _searching, value);
    }

    public ObservableCollection<AppItem> AppList
    {
        get; 
        set;
    }


#pragma warning restore CA1822 // Mark members as static
}