# MAUI - Add Prism to Default MAUI App

## Overview

In this example we started with the default MAUI application from Visual Studio 2022, and added Prism which is also in preview.

## Ways To Register Navigation

There are a few different methods for initializing and configuring your applications. The architecture style is up to you depending on the size and complexity of your app.

For instance, if it is a small test-bench project, Sample-1 may be best, where-as Sample-2 could be fore larger enterprise applications.

Sample 2 may be more familiar for legacy Prism users.

### Sample 1 - MauiApp.CreateBuilder Lambdas

**File:** `MauiProgram.cs`

```cs
public static class MauiProgram
{
  public static MauiApp CreateMauiApp()
  {
    return MauiApp.CreateBuilder()
      .UsePrismApp<App>(prism =>
        prism.ConfigureModuleCatalog(moduleCatalog =>
        {
          moduleCatalog.AddModule<MauiAppModule>();
          moduleCatalog.AddModule<MauiTestRegionsModule>();
        })
        .RegisterTypes(containerRegistry =>
        {
          containerRegistry.RegisterGlobalNavigationObserver();
          containerRegistry.RegisterForNavigation<MainPage>();
          containerRegistry.RegisterForNavigation<RootPage>();
          containerRegistry.RegisterForNavigation<SamplePage>();
          containerRegistry.RegisterForNavigation<SplashPage>();
        })
      )
      .ConfigureFonts(fonts =>
      {
        fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
        fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
      })
      .Build();
  }
}
```

### Sample 2 - Prism Startup Class

**File:** `MauiProgram.cs`

```cs
public static class MauiProgram
{
  public static MauiApp CreateMauiApp()
  {
    var builder = MauiApp.CreateBuilder()
      .UsePrismApp<App>(PrismStartup.Configure)
      .ConfigureFonts(fonts =>
      {
        fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
        fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
      });

    return builder.Build();
  }
}
```

**File:** `PrismStartup.cs`

```cs
  internal static class PrismStartup
  {
    public static void Configure(PrismAppBuilder builder)
    {
      // You may also do this in-line via lambdas without the need of static methods.
      builder
        .ConfigureModuleCatalog(OnConfigureModuleCatalog)
        .RegisterTypes(OnRegisterTypes)
        .OnAppStart($"{nameof(NavigationPage)}/{nameof(MainPage)}");
    }

    private static void OnConfigureModuleCatalog(IModuleCatalog moduleCatalog)
    {
      // Add custom Module to catalog
      //  moduleCatalog.AddModule<MauiAppModule>();
      //  moduleCatalog.AddModule<MauiTestRegionsModule>();
    }

    private static void OnRegisterTypes(IContainerRegistry containerRegistry)
    {
      containerRegistry
        .RegisterForNavigation<MainPage>()                   // Auto-assign ViewModel
        .RegisterForNavigation<Page2View, Page2ViewModel>()  // Manually assign ViewModel
        .RegisterInstance(SemanticScreenReader.Default);
    }
  }
```

## References

* [Prism.Maui](https://github.com/dansiegel/Prism.Maui)
* [Prism Library](https://github.com/PrismLibrary/Prism)
* [.NET MAUI](https://dotnet.microsoft.com/en-us/apps/maui)

[SuessLabs.com](https://suesslabs.com/) - [Suess Labs (GitHub)](https://github.com/SuessLabs) - [Damian Suess (GitHub)](https://github.com/DamianSuess)
