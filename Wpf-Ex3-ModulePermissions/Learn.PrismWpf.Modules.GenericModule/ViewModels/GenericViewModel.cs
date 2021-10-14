using Prism.Mvvm;

namespace Modules.Generic.ViewModels
{
  public class GenericViewModel : BindableBase
  {
    private string _message;

    public GenericViewModel()
    {
      Message = "Generic Module";
    }

    public string Message
    {
      get => _message;
      set => SetProperty(ref _message, value);
    }
  }
}
