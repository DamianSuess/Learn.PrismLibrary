using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Media;

namespace Avalonia.UITester;

public abstract partial class UITest
////public partial class UITest
{
  void AssertIsHidden(Control control) => Assert((control.IsMeasureValid && control.IsEffectivelyVisible) == false);

  void AssertIsVisible(Control control) => Assert((control.IsMeasureValid && control.IsEffectivelyVisible) == true);

  void AssertHasStyleClass(Control control, string className) => Assert(control.Classes.Contains(className));

  void AssertDoesntHaveStyleClass(Control control, string className) => Assert(control.Classes.Contains(className) == false);

  void AssertHasText(TextBlock txtBlock, string txt) => Assert(txtBlock.Text == txt);

  void AssertHasText(AutoCompleteBox txtBox, string txt) => Assert(txtBox.Text == txt);

  void AssertHasText(TextBox txtBox, string txt) => Assert(txtBox.Text == txt);

  void AssertHasText(Button button, string txt) => Assert(((string)button.Content!) == txt);

  void AssertHasText(ComboBox cb, string txt) => Assert(cb.SelectedItem is string s && s == txt);

  void AssertHasText(ComboBoxItem cbItem, string txt) => Assert(((string)cbItem.Content!) == txt);

  void AssertHasText(MenuItem menuItem, string txt) => Assert(((string)menuItem.Header!) == txt);

  void AssertHasText(TreeViewItem tvi, string txt) => Assert(((string)tvi.Header!) == txt);

  void AssertHasText(CheckBox cb, string txt) => Assert((string)cb.Content! == txt);

  void AssertContainsText(TextBox txtBox, string txt) => Assert(txtBox.Text?.Contains(txt) == true);

  void AssertContainsText(TextBlock txtBlock, string txt) => Assert(txtBlock.Text?.Contains(txt) == true);

  void AssertHasIconVisible(MenuItem menuItem) => Assert(((Image)menuItem.Icon!).IsVisible == true);

  void AssertHasIconHidden(MenuItem menuItem) => Assert(((Image)menuItem.Icon!).IsVisible == false);

  void AssertSelection(ComboBox cb, ComboBoxItem cbi) => Assert(cb.SelectedItem == cbi);

  void AssertBackgroundColor(Panel panel, string hexColor) => Assert(panel.Background is SolidColorBrush scb && ToHexString(scb.Color) == hexColor);

  private static string ToHexString(Color c) =>
      $"#{c.R:X2}{c.G:X2}{c.B:X2}";

  void AssertIsChecked(CheckBox cb) => Assert(cb.IsChecked == true);

  void AssertIsNotChecked(CheckBox cb) => Assert(cb.IsChecked == false);
}
