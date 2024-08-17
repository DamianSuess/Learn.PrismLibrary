# Prism.Maui

## NuGet Gackages

The base NuGet packages required are:

* Prism.Maui
* Prism.DryIoc.Maui

### Optional

* Prism.Events
* Prism.Maui.Rx

## Reproduce Samples

1. Start with .NET MAUI base project
2. Remove Shell page
3. Create `Views` or `Pages` folder
4. Create `ViewModels` folder

## MauiProgram.cs

```cs
    var builder = MauiApp.CreateBuilder();
    builder
      .UseMauiApp<App>()
      // -------------- INSERT THE FOLLOWING BELOW ---------------
      .UsePrism(prism =>
        prism.ConfigureModuleCatalog(catalog =>
        {
          ;
        })
        .RegisterTypes(container =>
        {
          container.RegisterForNavigation<MainPage>();
        })
        // - -=[ REQUIRES: Prism.Maui.Rx ]=- -
        .AddGlobalNavigationObserver(context => context.Subscribe(x =>
        {
          if (x.Type == NavigationRequestType.Navigate)
            Console.WriteLine($"Navigation (URL): {x.Uri}");
          else
            Console.WriteLine($"Navigation (Type): {x.Type}");
        }))
        // - -=[ END Prism.Maui.Rx ]=- -
      .CreateWindow(nav => nav.CreateBuilder()
        .AddSegment<MainPageViewModel>()
        .NavigateAsync(OnNavigationError)
      ))
```
