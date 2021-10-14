using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Mvvm;

namespace Learn.PrismWpf.Modules.GenericModule.ViewModels
{
  public class ViewAViewModel : BindableBase
  {
    private string _message;
    public string Message
    {
      get { return _message; }
      set { SetProperty(ref _message, value); }
    }

    public ViewAViewModel()
    {
      Message = "View A from your Prism Module";
    }
  }
}
