using System;
using System.Linq;
using BarcodeScanner;
using Ex7Prism.BarcodeScanner.Models;
using Ex7Prism.BarcodeScanner.Strings;
using MvvmHelpers;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using ZXing;

namespace Ex7Prism.BarcodeScanner.ViewModels
{
  public class MainPageViewModel : ViewModelBase
  {
    private IBarcodeScannerService _barcodeService;

    public MainPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService, IDeviceService deviceService, IBarcodeScannerService barcodeService)
        : base(navigationService, pageDialogService, deviceService)
    {
      Title = Resources.MainPageTitle;
      _barcodeService = barcodeService;

      TodoItems = new ObservableRangeCollection<TodoItem>();

      AddItemCommand = new DelegateCommand(OnAddItemCommandExecuted);
      DeleteItemCommand = new DelegateCommand<TodoItem>(OnDeleteItemCommandExecuted);
      TodoItemTappedCommand = new DelegateCommand<TodoItem>(OnTodoItemTappedCommandExecuted);
    }

    public ObservableRangeCollection<TodoItem> TodoItems { get; set; }

    public DelegateCommand AddItemCommand { get; }

    public DelegateCommand ScanCommand => new DelegateCommand(OnScanBarcode);

    public DelegateCommand<TodoItem> DeleteItemCommand { get; }

    public DelegateCommand<TodoItem> TodoItemTappedCommand { get; }

    public override void OnNavigatedTo(NavigationParameters parameters)
    {
      IsBusy = true;
      switch (parameters.GetNavigationMode())
      {
        case NavigationMode.Back:
          if (parameters.ContainsKey("todoItem"))
          {
            TodoItems.Add(parameters.GetValue<TodoItem>("todoItem"));
          }

          break;

        case NavigationMode.New:
          TodoItems.AddRange(parameters.GetValues<string>("todo")
                                       .Select(n => new TodoItem { Name = n }));
          break;

        default:

          System.Diagnostics.Debug.WriteLine("Unhandled navigation type to MainPage.");

          break;
      }

      IsBusy = false;
    }

    private async void OnAddItemCommandExecuted() =>
      await _navigationService.NavigateAsync("TodoItemDetail", new NavigationParameters
      {
        { "new", true },
        { "todoItem", new TodoItem() }
      });

    private void OnDeleteItemCommandExecuted(TodoItem item) => TodoItems.Remove(item);

    private async void OnScanBarcode()
    {
      // Returns the scring value of the barcode
      string barcodeValue = await _barcodeService.ReadBarcodeAsync();

      // Returns the ZXing barcode scan result
      //// Result result = await _barcodeService.ReadBarcodeResultAsync();

      Title = barcodeValue;
    }

    private async void OnTodoItemTappedCommandExecuted(TodoItem item) =>
      await _navigationService.NavigateAsync("TodoItemDetail", new NavigationParameters{
        { "todoItem", item }
      });
  }
}
