using Xamarin.Forms;

namespace Ex7Prism.BarcodeScanner.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            // to clear selection on cell
            (sender as ListView).SelectedItem = null;
        }
    }
}
