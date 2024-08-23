# Prism.Maui

These projects help provide samples for basic Prism.Maui features. As must as I try to keep them up-to-date with the latest, some of the versions provided are for earlier versions as well.

Implicit Using:<br/>
Some of the projects disable [Implicit Using](https://devblogs.microsoft.com/dotnet/welcome-to-csharp-10/) so that you know which classes to include. _You're welcome!_

## NuGet Packages

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

## Recommendations

### Use Compiled Bindings

Use [compiled bindings](https://learn.microsoft.com/en-us/dotnet/maui/fundamentals/data-binding/compiled-bindings?view=net-maui-8.0) to catch errors early!

1. Add `xmlns:vm="..."
2. Add `x:DataType="vm:MyViewModel"

```xml
<?xml version="1.0" encoding="utf-8" ?>
<ContentPage ...
             xmlns:vm="clr-namespace:Sample.DialogPopups.ViewModels"
             x:Class="Sample.DialogPopups.Views.MainPage"
             x:DataType="vm:MainPageViewModel">

```

### MAUI Popups

* https://github.com/thomasgalliker/MauiPopups
