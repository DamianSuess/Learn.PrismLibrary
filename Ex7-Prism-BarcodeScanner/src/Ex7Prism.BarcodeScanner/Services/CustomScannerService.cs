using System;
using System.Collections.Generic;
using System.Text;
using BarcodeScanner;
using Rg.Plugins.Popup.Contracts;
using Rg.Plugins.Popup.Interfaces.Animations;
using Xamarin.Forms;
using ZXing;
using ZXing.Mobile;

namespace Ex7Prism.BarcodeScanner.Services
{
  ////public class CustomScannerService : PopupBarcodeScannerService
  ////{
  ////  public CustomScannerService(IPopupNavigation popupNavigation)
  ////    : base(popupNavigation)
  ////  {
  ////    scannerView.HorizontalOptions = LayoutOptions.Center;
  ////  }

  ////  protected override string TopText() => "Prism Scanner";

  ////  protected override string BottomText() => "Align with barcode";

  ////  // protected override View GetScannerOverlay() => new View();

  ////  protected override MobileBarcodeScanningOptions GetScanningOptions()
  ////  {
  ////    var options = base.GetScanningOptions();
  ////    options.PossibleFormats = new List<BarcodeFormat>()
  ////    {
  ////        BarcodeFormat.CODE_128
  ////    };

  ////    return options;
  ////  }
  ////}
}
