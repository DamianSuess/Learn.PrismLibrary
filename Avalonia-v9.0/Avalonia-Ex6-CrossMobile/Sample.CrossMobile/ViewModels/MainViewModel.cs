using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Sample.CrossMobile.ViewModels;

public partial class MainViewModel : ViewModelBase
{
  [ObservableProperty]
  private string _greeting = "Welcome to Prism.Avalonia!";

  public MainViewModel()
  {
    Debug.WriteLine("MainViewModel - Constructed");
  }
}
