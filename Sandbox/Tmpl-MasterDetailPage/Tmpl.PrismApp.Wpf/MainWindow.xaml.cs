/* Copyright Xeno Innovations, Inc. 2017-2019
 * Author:  Damian Suess
 * Date:    2019-1-8
 * File:    MainWindow.xaml.cs
 * Description:
 *
 */


using Xamarin.Forms;
using Xamarin.Forms.Platform.WPF;

namespace Tmpl.PrismApp.WPF
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : FormsApplicationPage
  {
    public MainWindow()
    {
      InitializeComponent();

      Forms.Init();
      LoadApplication(new Tmpl.PrismApp.Client.App());
    }
  }
}
