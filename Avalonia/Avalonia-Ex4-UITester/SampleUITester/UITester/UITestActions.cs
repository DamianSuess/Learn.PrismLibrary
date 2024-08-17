using System;
using System.Linq;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;

namespace SampleUITester.UITester;

#pragma warning disable IDE1006 // Naming Styles
internal static class UITestActions
{
  // increase the time below to make the tests run slower
  private static readonly TimeSpan DefaultWaitingTimeAfterActions = TimeSpan.FromSeconds(0.05);

  internal static Task WaitAfterActionAsync() => Task.Delay(DefaultWaitingTimeAfterActions);

  internal static TreeViewItem? GetTreeViewItemViewAtIndex(this TreeView parentView, int index) =>
      (TreeViewItem?)parentView.ItemsView[index];

  internal static async Task ClickOn(this Button control)
  {
    control.Command?.Execute(null);
    await WaitAfterActionAsync();
  }

  internal static async Task ClickOn(this MenuItem control)
  {
    // if it is a parent menu item (drawer), then just open
    if (control.Items.Count > 0)
    {
      control.Open();
    }
    else
    {
      RoutedEventArgs args = new(MenuItem.ClickEvent);
      control.RaiseEvent(args);
    }

    await WaitAfterActionAsync();
  }

  internal static async Task ClickOn(this CheckBox cb)
  {
    cb.IsChecked = !cb.IsChecked;
    await WaitAfterActionAsync();
  }

  internal static async Task Select(this ComboBox cb, string item)
  {
    cb.IsDropDownOpen = true;
    cb.SelectedIndex = cb.Items.IndexOf(
        cb.Items.First(x => x is string s && s == item));
    cb.IsDropDownOpen = false;
    await WaitAfterActionAsync();
  }

  internal static async Task Select(this ComboBox cb, ComboBoxItem item)
  {
    cb.IsDropDownOpen = true;
    cb.SelectedIndex = cb.Items.IndexOf(item);
    cb.IsDropDownOpen = false;
    await WaitAfterActionAsync();
  }

  internal static async Task Select(this AutoCompleteBox acb, string? item)
  {
    acb.SelectedItem = item;
    await WaitAfterActionAsync();
  }

  internal static async Task Select(this TabControl tc, TabItem ti)
  {
    tc.SelectedItem = ti;
    await WaitAfterActionAsync();
  }

  internal static async Task ClearText(this TextBox txtBox)
  {
    txtBox.Clear();
    await WaitAfterActionAsync();
  }

  internal static async Task TypeText(this TextBox control, string txt)
  {
    TextInputEventArgs args = new();
    args.RoutedEvent = InputElement.TextInputEvent;
    args.Text = txt;
    control.RaiseEvent(args);
    await WaitAfterActionAsync();
  }

  /*internal static async Task TypeText(this TextEditor editor, string txt)
  {
      editor.Document.Insert(editor.Document.TextLength, txt);
      await WaitAfterActionAsync();
  }*/

  internal static async Task ClearAndTypeText(this TextBox txtBox, string newTxt)
  {
    await txtBox.ClearText();
    await txtBox.TypeText(newTxt);
  }

  /*internal static async Task ClearAndTypeText(this TextEditor editor, string newTxt)
  {
      await editor.ClearText();
      await editor.TypeText(newTxt);
  }*/

  internal static async Task PressKey(this Control control, Key key, KeyModifiers keyModifiers = KeyModifiers.None)
  {
    KeyEventArgs args = new() { Key = key, KeyModifiers = keyModifiers };
    args.RoutedEvent = InputElement.KeyDownEvent;
    control.RaiseEvent(args);
    args.RoutedEvent = InputElement.KeyUpEvent;
    control.RaiseEvent(args);
    await WaitAfterActionAsync();
  }
}
#pragma warning restore IDE1006 // Naming Styles
