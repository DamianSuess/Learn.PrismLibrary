using System;
using Prism;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using Test.PrismXF.Tabs;
using Test.PrismXF.Views;

namespace Test.PrismXF.ViewModels
{
  public class Page1ViewModel : BaseViewModel, IActiveAware
  {
    private IPageDialogService _dialogService;

    private bool _isActive;

    public Page1ViewModel(INavigationService navigationService, IPageDialogService dialogService, IAppCommands appCommands)
            : base(navigationService)
    {
      Title = "Main Page";
      _dialogService = dialogService;

      appCommands.SaveCommand.RegisterCommand(SaveCommand);
      appCommands.ResetCommand.RegisterCommand(ResetCommand);
    }

    public event EventHandler IsActiveChanged;

    public DelegateCommand CmdDoubleFwdTo3rd => new DelegateCommand(OnDoubleFwdTo3rd);

    public bool IsActive
    {
      get { return _isActive; }
      set
      {
        SetProperty(ref _isActive, value);
        OnActiveChanged();
      }
    }

    public DelegateCommand CmdNavigatePage2 => new DelegateCommand(OnNavigatePage2);

    public DelegateCommand CmdNavigatePage3 => new DelegateCommand(OnNavigatePage3);

    public DelegateCommand ResetCommand => new DelegateCommand(OnCommandReset);

    public DelegateCommand SaveCommand => new DelegateCommand(OnCommandSave);

    public override void OnNavigatedTo(INavigationParameters parameters)
    {
      var navigationMode = parameters.GetNavigationMode();

      if (navigationMode == NavigationMode.Back)
        Title = "Went Back";
      else if (navigationMode == NavigationMode.New)
        Title = "Went to New Page";
    }

    private void OnActiveChanged()
    {
      SaveCommand.IsActive = IsActive;
    }

    private void OnCommandSave()
    {
      Title = "Saved Settings";
    }

    private void OnCommandReset()
    {
      Title = "Reset Settings";
    }

    private async void OnDoubleFwdTo3rd()
    {
      // use BaseViewModel, not _navService directly
      await NavigationService.NavigateAsync($"{nameof(Page2View)}/{nameof(Page3View)}");
    }

    private async void OnNavigatePage2()
    {
      await NavigationService.NavigateAsync($"{nameof(Page2View)}");
    }

    private async void OnNavigatePage3()
    {
      var p = new NavigationParameters("?id=2&name=damian");
      await NavigationService.NavigateAsync($"{nameof(Page3View)}", p);
      ////  await NavigationService.NavigateAsync($"{nameof(ThirdPage)}?id=2&name=damian");
    }
  }
}