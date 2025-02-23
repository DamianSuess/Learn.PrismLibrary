using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Prism.DryIoc;
using Prism.Ioc;
using Sample.CrossMobile.ViewModels;
using Sample.CrossMobile.Views;

namespace Sample.CrossMobile;

/// <summary>Prism Avalonia application entry point.</summary>
/// <remarks>
///   v8.1 - Desktop, Mobile, Web
///   v9.1 - Desktop, Mobile      - Web stops at splash screen.
/// </remarks>
public partial class App : PrismApplication
{
  public override void Initialize()
  {
    AvaloniaXamlLoader.Load(this);

    // Required Prism.Avalonia initialization
    base.Initialize();
  }

  protected override AvaloniaObject CreateShell()
  {
    if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
    {
      // Desktop applications
      return Container.Resolve<MainWindow>();
    }
    else
    {
      // Mobile and WebBrowser
      return Container.Resolve<MainView>();
    }
  }

  protected override void RegisterTypes(IContainerRegistry containerRegistry)
  {
    // Services

    // Navigation
    containerRegistry.Register<MainWindow>();
    containerRegistry.RegisterForNavigation<MainView, MainViewModel>();
  }

  /*
  public override void OnFrameworkInitializationCompleted()
  {
    if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
    {
      // Avoid duplicate validations from both Avalonia and the CommunityToolkit.
      // More info: https://docs.avaloniaui.net/docs/guides/development-guides/data-validation#manage-validationplugins
      DisableAvaloniaDataAnnotationValidation();
      desktop.MainWindow = new MainWindow
      {
        DataContext = new MainViewModel()
      };
    }
    else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
    {
      singleViewPlatform.MainView = new MainView
      {
        DataContext = new MainViewModel()
      };
    }

    base.OnFrameworkInitializationCompleted();
  }

  private void DisableAvaloniaDataAnnotationValidation()
  {
    // Get an array of plugins to remove
    var dataValidationPluginsToRemove = BindingPlugins.DataValidators.OfType<DataAnnotationsValidationPlugin>().ToArray();

    // remove each entry found
    foreach (var plugin in dataValidationPluginsToRemove)
    {
      BindingPlugins.DataValidators.Remove(plugin);
    }
  }
  */
}
