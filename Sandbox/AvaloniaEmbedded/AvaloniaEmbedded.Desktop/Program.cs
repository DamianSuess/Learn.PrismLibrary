﻿using System;
using System.Linq;
using System.Threading;
using Avalonia;
using Avalonia.ReactiveUI;

namespace AvaloniaEmbedded.Desktop;

internal class Program
{
  // Initialization code. Don't use any Avalonia, third-party APIs or any
  // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
  // yet and stuff might break.
  [STAThread]
  public static int Main(string[] args)
  {
    var builder = BuildAvaloniaApp();
    if (args.Contains("--drm"))
    {
      try
      {
        SilenceConsole();

        // If Card0, Card1 and Card2 all don't work. You can also try:
        // return builder.StartLinuxFbDev(args);
        // return builder.StartLinuxDrm(args, "/dev/dri/card1");
        return builder.StartLinuxDrm(args, "/dev/dri/card1", 1D);
      }
      catch(Exception ex)
      {
        Console.CursorVisible = true;
        Console.WriteLine($"Failed to launch console.{Environment.NewLine}{ex}");
      }
    }

    return builder.StartWithClassicDesktopLifetime(args);
  }

  // Avalonia configuration, don't remove; also used by visual designer.
  public static AppBuilder BuildAvaloniaApp()
    => AppBuilder.Configure<App>()
        .UsePlatformDetect()
        .WithInterFont()
        .LogToTrace()
        .UseReactiveUI();

  private static void SilenceConsole()
  {
    new Thread(() =>
    {
      Console.CursorVisible = false;
      while (true)
        Console.ReadKey(true);
    })
    { IsBackground = true }.Start();
  }
}
