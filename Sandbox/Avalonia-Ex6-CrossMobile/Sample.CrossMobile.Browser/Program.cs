using System.Threading.Tasks;
using Avalonia;
using Avalonia.Browser;
using Sample.CrossMobile;

internal sealed partial class Program
{
  public static AppBuilder BuildAvaloniaApp()
      => AppBuilder.Configure<App>();

  private static Task Main(string[] args) => BuildAvaloniaApp()
    .WithInterFont()
    .StartBrowserAppAsync("out");
}
