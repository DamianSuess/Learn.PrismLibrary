using System;
using System.Diagnostics.CodeAnalysis;
using Avalonia;

namespace SampleApp;

public class Program
{
    // Initialization code. Don't use any Avalonia, third-party APIs or any
    // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
    // yet and stuff might break.
    [STAThread]
    [ExcludeFromCodeCoverage]
    public static void Main(string[] args) => BuildAvaloniaApp()
        .StartWithClassicDesktopLifetime(args);

    // Avalonia configuration, don't remove; also used by visual designer.
    public static AppBuilder BuildAvaloniaApp()
    {
        var builder = AppBuilder
            .Configure<App>()
            .UsePlatformDetect()
            .With(new X11PlatformOptions { EnableMultiTouch = true, UseDBusMenu = true, })
            .WithInterFont()
            .UseSkia();

#if DEBUG
        builder.LogToTrace();
#endif

        return builder;
    }
}
