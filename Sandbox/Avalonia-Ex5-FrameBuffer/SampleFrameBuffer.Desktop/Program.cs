using System;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading;
using Avalonia;
using Avalonia.Dialogs;
using Avalonia.ReactiveUI;

namespace SampleFrameBuffer.Desktop;

internal class Program
{
  // Initialization code. Don't use any Avalonia, third-party APIs or any
  // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
  // yet and stuff might break.
  [STAThread]
  public static int Main(string[] args)
  {
    if (args.Contains("--wait-for-attach"))
    {
      Console.WriteLine("Attach debugger and use 'Set next statement'");
      while (true)
      {
        Thread.Sleep(100);
        if (Debugger.IsAttached)
          break;
      }
    }

    var builder = BuildAvaloniaApp();

    if (args.Contains("--fbdev"))
    {
      Console.WriteLine("-- Starting: Framebuffer");
      return builder.StartLinuxFbDev(args, scaling: GetScaling(args));

    }
    else if (args.Contains("--drm"))
    {
      Console.WriteLine("-- Starting: Linux DRM");
      SilenceConsole();
      return builder.StartLinuxDrm(args, scaling: GetScaling(args));
    }
    else
    {
      Console.WriteLine("-- Starting: Classic Desktop");
      return builder.StartWithClassicDesktopLifetime(args);
    }
  }

  // Avalonia configuration, don't remove; also used by visual designer.
  public static AppBuilder BuildAvaloniaApp() =>
    AppBuilder.Configure<App>()
    .UsePlatformDetect()
    .WithInterFont()  // May not be needed
    .LogToTrace()
    .With(new Win32PlatformOptions())
    .UseSkia()
    .UseReactiveUI()
    .UseManagedSystemDialogs();

  private static double GetScaling(string[] args)
  {
    var idx = Array.IndexOf(args, "--scaling");

    if (idx != 0 &&
        args.Length > idx + 1 &&
        double.TryParse(args[idx + 1], NumberStyles.Any, CultureInfo.InvariantCulture, out var scaling))
    {
      return scaling;
    }
    else
    {
      return 1;
    }
  }

  private static void SilenceConsole()
  {
    new Thread(() =>
    {
      Console.CursorVisible = false;

      while (true)
        Console.ReadKey(true);
    })
    {
      IsBackground = true,
    }.Start();
  }
}
