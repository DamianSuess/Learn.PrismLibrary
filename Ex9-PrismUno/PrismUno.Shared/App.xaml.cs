﻿using Microsoft.Extensions.Logging;
using Prism.Ioc;
using PrismUno.Shared.Views;
using Windows.ApplicationModel;
using Windows.UI.Xaml;

namespace PrismUno
{
  /// <summary>
  /// Provides application-specific behavior to supplement the default Application class.
  /// </summary>
  sealed partial class App
  {
    /// <summary>
    /// Initializes the singleton application object.  This is the first line of authored code
    /// executed, and as such is the logical equivalent of main() or WinMain().
    /// </summary>
    public App()
    {
      ConfigureFilters(global::Uno.Extensions.LogExtensionPoint.AmbientLoggerFactory);

      this.InitializeComponent();
    }

    protected override UIElement CreateShell()
    {
      return Container.Resolve<Shell>();
    }

    protected override void RegisterTypes(IContainerRegistry containerRegistry)
    {

    }

    /// <summary>
    /// Invoked when application execution is being suspended.  Application state is saved
    /// without knowing whether the application will be terminated or resumed with the contents
    /// of memory still intact.
    /// </summary>
    /// <param name="sender">The source of the suspend request.</param>
    /// <param name="e">Details about the suspend request.</param>
    protected override void OnSuspending(SuspendingEventArgs e)
    {
      var deferral = e.SuspendingOperation.GetDeferral();
      //TODO: Save application state and stop any background activity
      deferral.Complete();
    }

    /// <summary>
    /// Configures global logging
    /// </summary>
    /// <param name="factory"></param>
    static void ConfigureFilters(ILoggerFactory factory)
    {
      factory
          .WithFilter(new FilterLoggerSettings
              {
                        { "Uno", LogLevel.Warning },
                        { "Windows", LogLevel.Warning },

            // Debug JS interop
            // { "Uno.Foundation.WebAssemblyRuntime", LogLevel.Debug },

            // Generic Xaml events
            // { "Windows.UI.Xaml", LogLevel.Debug },
            // { "Windows.UI.Xaml.VisualStateGroup", LogLevel.Debug },
            // { "Windows.UI.Xaml.StateTriggerBase", LogLevel.Debug },
            // { "Windows.UI.Xaml.UIElement", LogLevel.Debug },

            // Layouter specific messages
            // { "Windows.UI.Xaml.Controls", LogLevel.Debug },
            // { "Windows.UI.Xaml.Controls.Layouter", LogLevel.Debug },
            // { "Windows.UI.Xaml.Controls.Panel", LogLevel.Debug },
            // { "Windows.Storage", LogLevel.Debug },

            // Binding related messages
            // { "Windows.UI.Xaml.Data", LogLevel.Debug },

            // DependencyObject memory references tracking
            // { "ReferenceHolder", LogLevel.Debug },

            // ListView-related messages
            // { "Windows.UI.Xaml.Controls.ListViewBase", LogLevel.Debug },
            // { "Windows.UI.Xaml.Controls.ListView", LogLevel.Debug },
            // { "Windows.UI.Xaml.Controls.GridView", LogLevel.Debug },
            // { "Windows.UI.Xaml.Controls.VirtualizingPanelLayout", LogLevel.Debug },
            // { "Windows.UI.Xaml.Controls.NativeListViewBase", LogLevel.Debug },
            // { "Windows.UI.Xaml.Controls.ListViewBaseSource", LogLevel.Debug }, //iOS
            // { "Windows.UI.Xaml.Controls.ListViewBaseInternalContainer", LogLevel.Debug }, //iOS
            // { "Windows.UI.Xaml.Controls.NativeListViewBaseAdapter", LogLevel.Debug }, //Android
            // { "Windows.UI.Xaml.Controls.BufferViewCache", LogLevel.Debug }, //Android
            // { "Windows.UI.Xaml.Controls.VirtualizingPanelGenerator", LogLevel.Debug }, //WASM
          }
          )
          .AddConsole(LogLevel.Information);
    }
  }
}
