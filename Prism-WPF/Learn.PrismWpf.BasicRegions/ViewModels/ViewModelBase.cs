using Prism.Mvvm;
using Prism.Navigation;
using Prism.Regions;

namespace Learn.PrismWpf.BasicRegions.ViewModels
{
  public abstract class ViewModelBase :  BindableBase, IDestructible
  {
    protected ViewModelBase()
    {
    }

    public virtual void Destroy()
    {
    }
  }
}