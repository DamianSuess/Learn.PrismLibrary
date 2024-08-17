﻿using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Media;

namespace Avalonia.UITester;

public abstract partial class UITest
{
  internal void AssertIsHidden(Control control) => Assert((control.IsMeasureValid && control.IsEffectivelyVisible) == false);

  internal void AssertIsVisible(Control control) => Assert((control.IsMeasureValid && control.IsEffectivelyVisible) == true);

  internal void AssertHasStyleClass(Control control, string className) => Assert(control.Classes.Contains(className));

  internal void AssertDoesntHaveStyleClass(Control control, string className) => Assert(control.Classes.Contains(className) == false);

  internal void AssertHasText(TextBlock txtBlock, string txt) => Assert(txtBlock.Text == txt);

  internal void AssertHasText(AutoCompleteBox txtBox, string txt) => Assert(txtBox.Text == txt);

  internal void AssertHasText(TextBox txtBox, string txt) => Assert(txtBox.Text == txt);

  internal void AssertHasText(Button button, string txt) => Assert(((string)button.Content!) == txt);

  internal void AssertHasText(ComboBox cb, string txt) => Assert(cb.SelectedItem is string s && s == txt);

  internal void AssertHasText(ComboBoxItem cbItem, string txt) => Assert(((string)cbItem.Content!) == txt);

  internal void AssertHasText(MenuItem menuItem, string txt) => Assert(((string)menuItem.Header!) == txt);

  internal void AssertHasText(TreeViewItem tvi, string txt) => Assert(((string)tvi.Header!) == txt);

  internal void AssertHasText(CheckBox cb, string txt) => Assert((string)cb.Content! == txt);

  internal void AssertContainsText(TextBox txtBox, string txt) => Assert(txtBox.Text?.Contains(txt) == true);

  internal void AssertContainsText(TextBlock txtBlock, string txt) => Assert(txtBlock.Text?.Contains(txt) == true);

  internal void AssertHasIconVisible(MenuItem menuItem) => Assert(((Image)menuItem.Icon!).IsVisible == true);

  internal void AssertHasIconHidden(MenuItem menuItem) => Assert(((Image)menuItem.Icon!).IsVisible == false);

  internal void AssertSelection(ComboBox cb, ComboBoxItem cbi) => Assert(cb.SelectedItem == cbi);

  internal void AssertBackgroundColor(Panel panel, string hexColor) => Assert(panel.Background is SolidColorBrush scb && ToHexString(scb.Color) == hexColor);

  private static string ToHexString(Color c) =>
      $"#{c.R:X2}{c.G:X2}{c.B:X2}";

  internal void AssertIsChecked(CheckBox cb) => Assert(cb.IsChecked == true);

  internal void AssertIsNotChecked(CheckBox cb) => Assert(cb.IsChecked == false);
}
