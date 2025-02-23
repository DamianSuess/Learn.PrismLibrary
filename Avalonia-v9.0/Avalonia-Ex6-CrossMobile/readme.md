# Prism Avalonia - CrossMoble

Demonstration of _**desktop, mobile, and web application**_ using Prism.Avalonia!

> **Note:**
>
> _The Prism.Avalonia v9.x is still in the testing phases. The v8.1 example is feature-functional._

## Overview

One thing to note between each of these 3 flavors is the _Application Lifetime_ usage:

* Desktop - `IClassicDesktopStyleApplicationLifetime`
* Mobile/Web - `ISingleViewApplicationLifetime`

Desktop applications starts in the `MainWindow`, whereas, Mobile/Web uses `MainView`.

This MUST be propertly set in the `App.axaml.cs` override method, `CreateShell()`.

```cs
  protected override AvaloniaObject CreateShell()
  {
    if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
      // Desktop applications
      return Container.Resolve<MainWindow>();
    else
      // Mobile and WebBrowser
      return Container.Resolve<MainView>();
  }
```
