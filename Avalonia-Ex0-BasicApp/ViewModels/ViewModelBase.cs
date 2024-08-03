using Prism.Mvvm;
using Prism.Regions;

namespace Avalonia_Ex4_Test1101.ViewModels
{
  public class ViewModelBase : BindableBase
  {
    private string _title = string.Empty;

    public string Title { get => _title; set => SetProperty(ref _title, value); }
  }
}
