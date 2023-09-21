﻿using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using SampleFrameBuffer.ViewModels;
using SampleFrameBuffer.Views;

namespace SampleFrameBuffer;

public partial class App : Application
{
  public override void Initialize()
  {
    AvaloniaXamlLoader.Load(this);
  }

  public override void OnFrameworkInitializationCompleted()
  {
    if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
    {
      singleViewPlatform.MainView = new MainView
      {
        DataContext = new MainViewModel()
      };
    }
    else if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
    {
      desktop.MainWindow = new MainWindow
      {
        DataContext = new MainViewModel()
      };
    }

    base.OnFrameworkInitializationCompleted();
  }
}
