/* Copyright 2017-2019
 * Author:  Damian Suess
 * Date:    2019-3-22
 * File:    MainView.xaml.cs
 * Description:
 *
 */

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tmpl.PrismApp.Client.Views
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class MainView : MasterDetailPage
  {
    public MainView()
    {
      InitializeComponent();
    }
  }
}