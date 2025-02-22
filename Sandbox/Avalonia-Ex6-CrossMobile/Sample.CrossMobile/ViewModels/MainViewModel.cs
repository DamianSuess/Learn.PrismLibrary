using CommunityToolkit.Mvvm.ComponentModel;

namespace Sample.CrossMobile.ViewModels;

public partial class MainViewModel : ViewModelBase
{
  [ObservableProperty]
  private string _greeting = "Welcome to Avalonia!";
}
