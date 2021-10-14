using System;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

namespace Ex7Prism.BarcodeScanner.UITests.Pages
{
    public class MainPage : BasePage
    {
        public void AppStarted()
        {
            AppResult[] results = app.WaitForElement(c => c.Marked("Item1"));
            AppResult[] results2 = app.WaitForElement(c => c.Marked("Item2"));
            AppResult[] results3 = app.WaitForElement(c => c.Marked("Item3"));
            app.Screenshot("Main Page");
        }
    }
}