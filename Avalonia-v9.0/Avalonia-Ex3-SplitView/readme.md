# Prism.Avalonia SplitView App

This is a demo of the `SplitView` user control for navigation and has a property of `IsPaneOpen` to assist with collapsing.


## So what's different than Ex-1 "SampleMvvmApp"?

Though they look the exact same (_on purpose_) they are different.

In Ex-1, we used the `<Grid ColumnDefinitions="Auto,*" ...>` control, placing `SidebarView` as the navigation bar.  Here, we're using the `<SplitView>` control.

```xml
  <SplitView DisplayMode="CompactInline"
              IsPaneOpen="{Binding IsPaneOpened}"
              OpenPaneLength="200">
    <SplitView.Pane>
      <!-- Sidebar contents -->
    </SplitView>

    <!-- Main content area -->

  </SplitView>
```


## Features

This demonstrates the following Prism.Avalonia features:

* SplitView for navigation sidebar panel
* .NET 6, 7, 8 - Cross-platform
* MVVM Pattern - _Model View ViewModel_
* Prism Navigation with and without passing parameters.
* Prism Journling backwards
* Prism Regions for placing views
* Prism.DryIoc for Dependency Injection of Services
* Avalonia Glyphs
* Avalonia Styles (_Fluent Theme Light_)

## Glyphs

Get more styles and read the tutorial on the Avalonia docs.

* [https://avaloniaui.github.io/icons.html]
* [https://docs.avaloniaui.net/tutorials/music-store-app/add-and-layout-controls]

[SuessLabs.com](https://suesslabs.com/) - [Suess Labs (GitHub)](https://github.com/SuessLabs) - [Damian Suess (GitHub)](https://github.com/DamianSuess)
