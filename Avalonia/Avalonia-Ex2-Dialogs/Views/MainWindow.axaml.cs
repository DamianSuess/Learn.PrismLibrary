using Avalonia;
using Avalonia.Controls;

namespace SampleDialogApp.Views
{
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();
#if DEBUG
      this.AttachDevTools();
#endif
    }

    // When referencing Avalonia package, XamlNameReferenceGenerator
    ////private void InitializeComponent()
    ////{
    ////    AvaloniaXamlLoader.Load(this);
    ////}
  }
}
