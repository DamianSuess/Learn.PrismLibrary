using Prism;
using Prism.Ioc;

namespace Ex7Prism.BarcodeScanner.Droid
{
  public class AndroidInitializer : IPlatformInitializer
  {
    public void RegisterTypes(IContainerRegistry containerRegistry)
    {
      // Register Any Platform Specific Implementations that you cannot
      // access from Shared Code
    }
  }
}
