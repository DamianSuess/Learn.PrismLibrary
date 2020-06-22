using System.Threading.Tasks;
using Ex7Prism.BarcodeScanner.Views;
using Prism.Navigation;
using Prism.Services;
using Xamarin.Forms;

namespace Ex7Prism.BarcodeScanner.ViewModels
{
  public class SplashScreenPageViewModel : ViewModelBase
  {
    public SplashScreenPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService, IDeviceService deviceService)
      : base(navigationService, pageDialogService, deviceService)
    {
    }

    public override void OnAppearing()
    {
      ; // Gets called after, OnNavigatedTo, but still gets called before page is rendered
    }

    public override async void OnNavigatedTo(NavigationParameters parameters)
    {
      // TODO: Implement any initialization logic you need here. Example would be to handle automatic user login

      // Simulated long running task.
      await Task.Delay(2000);

      // After performing the long running task we perform an absolute Navigation to remove the SplashScreen from
      // the Navigation Stack.
      await _navigationService.NavigateAsync($"/{nameof(NavigationPage)}/{nameof(MainPage)}?todo=Item1&todo=Item2&todo=Item3");
    }
  }
}