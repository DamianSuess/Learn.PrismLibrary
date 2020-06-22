# Introduction

This is a sample project for Prism with Xamarin.Forms using DryIoC.

Prism is a framework for building loosely coupled, maintainable, and testable XAML applications in WPF, Windows 10 UWP, and Xamarin Forms. Separate releases are available for each platform and those will be developed on independent timelines. Prism provides an implementation of a collection of design patterns that are helpful in writing well-structured and maintainable XAML applications, including MVVM, dependency injection, commands, EventAggregator, and others. Prism's core functionality is a shared code base in a Portable Class Library targeting these platforms.

Author: [Damian Suess](https://www.linkedin.com/in/damiansuess/)

## Examples

* [X] Navigation
* [X] MasterDetailPage
* [X] Tabbed Navigation Pages
* [X] Barcode Scanner
* [ ] DialogService (v7.2)
* [ ] Automatic View Registration (v7.2)
* [ ] ShellUI

## Semi-Requirements
The project works best if you include the [Prism Template Pack](https://marketplace.visualstudio.com/items?itemName=BrianLagunas.PrismTemplatePack). This allows the system to quickly type in code for you and _even creates a ViewModel class when you create a new page_!

## Dialog Service
Dialog Service was updated in v7.2. Here's how to use it according to the official release documentation.

### Custom Dialog View
```xml
<UserControl x:Class="HelloWorld.Dialogs.NotificationDialog"
             xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
             xmlns:prism="http://prismlibrary.com/"
             prism:ViewModelLocator.AutoWireViewModel="True"
             Width="300" Height="150">
  <Grid x:Name="LayoutRoot" Margin="5">
    <Grid.RowDefinitions>
      <RowDefinition />
      <RowDefinition Height="Auto" />
    </Grid.RowDefinitions>

    <TextBlock Text="{Binding Message}" HorizontalAlignment="Stretch" VerticalAlignment="Stretch" Grid.Row="0" TextWrapping="Wrap" />
    <Button Command="{Binding CloseDialogCommand}" CommandPrameter="true" Content="OK" Width="75" Height="25" HorizontalAlignment="Right" Margin="0,10,0,0" Grid.Row="1" IsDefault="True" />
  </Grid>
</UserControl>
```

### ViewModel

```cs
public class NotificationDialogViewModel : BindableBase, IDialogAware
{
  private DelegateCommand<string> _closeDialogCommand;
  private string _message;
  private string _title = "Notification";

  public DelegateCommand<string> CloseDialogCommand =>
    _closeDialogCommand ?? (_closeDialogCommand = new DelegateCommand<string>(CloseDialog));

  public string Message
  {
    get =>  _message;
    set => SetProperty(ref _message, value);
  }

  public string Title
  {
    get => _title;
    set => SetProperty(ref _title, value);
  }

  public event Action<IDialogResult> RequestClose;

  protected virtual void CloseDialog(string parameter)
  {
    ButtonResult result = ButtonResult.None;

    if (parameter?.ToLower() == "true")
      result = ButtonResult.OK;
    else if (parameter?.ToLower() == "false")
      result = ButtonResult.Cancel;

    RaiseRequestClose(new DialogResult(result));
  }

  public virtual void RaiseRequestClose(IDialogResult dialogResult)
  {
    RequestClose?.Invoke(dialogResult);
  }

  public virtual bool CanCloseDialog()
  {
    return true;
  }

  public virtual void OnDialogClosed()
  {
  }

  public virtual void OnDialogOpened(IDialogParameters parameters)
  {
    Message = parameters.GetValue<string>("message");
  }
}
```

What's inside of the ``IDialogAware`` interface
```cs
public interface IDialogAware
{
  string Title { get; set; }

  event Action<IDialogResult> RequestClose;

  bool CanCloseDialog();
  void OnDialogClosed();
  void OnDialogOpened(IDialogParameters parameters);
}
```

### Register Your Dialog
```cs
protected override void RegisterTypes(IContainerRegistry containerRegistry)
{
  containerRegistry.RegisterDialog<NotificationDialog, NotificationDialogViewModel>();
}
```

### Calling Your Dialog
```cs
public MainWindowViewModel(IDialogService dialogService)
{
  _dialogService = dialogService;
}

private void OnShowDialog()
{
  var message = "This is a message that should be shown in the dialog.";

  //using the dialog service as-is
  _dialogService.ShowDialog("NotificationDialog", new DialogParameters($"message={message}"), r =>
  {
    if (r.Result == ButtonResult.None)
      Title = "Result is None";
    else if (r.Result == ButtonResult.OK)
      Title = "Result is OK";
    else if (r.Result == ButtonResult.Cancel)
      Title = "Result is Cancel";
    else
      Title = "I Don't know what you did!?";
  });
}
```

### Styling the DialogWindow
You can control the properties of the DialogWindow by using a style via an attached property on the Dialog UserControl

```xml
<prism:Dialog.WindowStyle>
  <Style TargetType="Window">
    <Setter Property="prism:Dialog.WindowStartupLocation" Value="CenterScreen" />
    <Setter Property="ResizeMode" Value="NoResize"/>
    <Setter Property="ShowInTaskbar" Value="False"/>
    <Setter Property="SizeToContent" Value="WidthAndHeight"/>
  </Style>
</prism:Dialog.WindowStyle>
```


# Resources
* [Prism Library](https://prismlibrary.github.io/)
* [Prism on GitHub](https://github.com/PrismLibrary/Prism)
* [Prism Template Pack](https://marketplace.visualstudio.com/items?itemName=BrianLagunas.PrismTemplatePack)
* [Prism official samples](https://github.com/PrismLibrary/Prism-Samples-Forms)
* [Plugin Popups](https://github.com/dansiegel/Prism.Plugin.Popups)


### Learn
* [Prism for Xamarin.Forms - Create your first application](https://www.youtube.com/watch?v=81Q2fxFWIqA) - Created 2018-12-04
* [The Xamarin Show | Episode 10: Prism for Xamarin.Forms with Brian Lagunas](https://www.youtube.com/watch?v=mb3_vhYw1mA) - Created 2018-01-04 _Prism v6_
* [Xamarin Forms with Prism — Getting Started — Part 1](https://medium.com/tutorialsxl/xamarin-forms-with-prism-getting-started-part-1-14832d7cf5fa) - Created 2018-03-23
