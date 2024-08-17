using Microsoft.Extensions.Logging;
using Sample.DialogPopups.Dialogs;
using Sample.DialogPopups.ViewModels;
using Sample.DialogPopups.ViewModels.Dialogs;
using Sample.DialogPopups.Views;

namespace Sample.DialogPopups;

public static class MauiProgram
{
  public static MauiApp CreateMauiApp()
  {
    var builder = MauiApp.CreateBuilder();
    builder
      .UseMauiApp<App>()
      .UsePrism(prism =>
        prism.ConfigureModuleCatalog(catalog =>
        {
          ;
        })
        .RegisterTypes(container =>
        {
          // Navigation Pages
          container.RegisterForNavigation<MainPage>();
          container.RegisterForNavigation<DialogTesterPage, DialogTesterPageViewModel>();

          // Dialogs
          container.RegisterDialog<OptionsDialog, OptionsDialogViewMode>();
        })
        // Prism.Maui.Rx:
        .AddGlobalNavigationObserver(context => context.Subscribe(x =>
        {
          if (x.Type == NavigationRequestType.Navigate)
            Console.WriteLine($"Navigation (URL): {x.Uri}");
          else
            Console.WriteLine($"Navigation (Type): {x.Type}");
        }))
      .CreateWindow(nav => nav.CreateBuilder()
        .AddSegment<MainPageViewModel>()
        .NavigateAsync(OnNavigationError)
      ))
      .ConfigureFonts(fonts =>
      {
        fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
        fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
      });

#if DEBUG
    builder.Logging.AddDebug();
#endif

    return builder.Build();
  }

  private static void OnNavigationError(Exception exception)
  {
    Console.WriteLine(exception);
    System.Diagnostics.Debugger.Break();
  }
}
