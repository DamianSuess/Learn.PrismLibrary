# Prism.Forms - Flyout Menu Sample

## Overview

This is a sample of a basic navigation system using the Flyout menu, the successor to `MasterDetailPage`.

For referencing purposes, this project sticks to basic MVVM principals and folder structures. Also, this sample uses a more dynamic approach for assigning menu items using a List. Feel free to adopt or use your own methodology.

To add this to your own project, you start with the MasterDetailPage from the Prism Template, renaming some key items, or just copy & paste out chucks.

## Compare the Two

### FlyoutPage

```xml
<?xml version="1.0" encoding="utf-8" ?>
<FlyoutPage x:Class="Sample.PrismMobile.Views.FlyoutView"
            xmlns="http://xamarin.com/schemas/2014/forms"
            xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
            xmlns:prism="http://prismlibrary.com"
            xmlns:views="clr-namespace:Sample.PrismMobile.Views"
            prism:ViewModelLocator.AutowireViewModel="True">
  <FlyoutPage.Flyout>
    <views:FlyoutMenuView x:Name="flyoutPage" />
  </FlyoutPage.Flyout>

  <FlyoutPage.Detail>
    <ContentPage Title="Menu">
      <StackLayout Padding="20">
        <!--  TODO: // Update the Layout and add some real menu items  -->
        <Button Command="{Binding NavigateCommand}"
                CommandParameter="ViewA"
                Text="ViewA" />
      </StackLayout>
    </ContentPage>
  </FlyoutPage.Detail>
</FlyoutPage>
```

### MasterDetailPage

```xml
<?xml version="1.0" encoding="utf-8" ?>
<MasterDetailPage xmlns="http://xamarin.com/schemas/2014/forms"
                  xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
                  xmlns:prism="http://prismlibrary.com"
                  prism:ViewModelLocator.AutowireViewModel="True"
                  x:Class="Sample.PrismMobile.Views.FlyoutView">

  <MasterDetailPage.Master>
    <ContentPage Title="Menu">
      <StackLayout Padding="20">
        <!-- TODO: // Update the Layout and add some real menu items  -->
        <Button Text="ViewA" Command="{Binding NavigateCommand}" CommandParameter="ViewA" />
      </StackLayout>
    </ContentPage>
  </MasterDetailPage.Master>
</MasterDetailPage>
```

## References

* [Prism Library](https://github.com/PrismLibrary/Prism)
* [Xamarin.Forms](https://github.com/xamarin/Xamarin.Forms)
* [FlyoutPage](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/app-fundamentals/navigation/flyoutpage)