using Xamarin.Forms;

namespace Test.PrismXF.Views
{
  public partial class CustomMDPage : MasterDetailPage, IMasterDetailPageController
  {
    public CustomMDPage()
    {
      InitializeComponent();
    }

    /// <summary>
    /// Property to set if the Menu will be present after the navigation.
    /// When True, the moenu won't close. False by default.
    /// </summary>
    public bool IsPresentedAfterNavigation => true;
  }
}