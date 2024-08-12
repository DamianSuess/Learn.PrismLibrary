using Prism.Mvvm;

namespace Modules.Admin.ViewModels
{
  public class AdminViewModel : BindableBase
  {
    private string _message;

    public AdminViewModel()
    {
      Message = "Admin Module";
    }

    public string Message
    {
      get => _message;
      set => SetProperty(ref _message, value);
    }
  }
}
