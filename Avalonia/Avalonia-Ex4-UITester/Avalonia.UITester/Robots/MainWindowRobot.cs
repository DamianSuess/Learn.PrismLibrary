using System.Text;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;

namespace Avalonia.UITester.Robots;

public sealed class MainWindowRobot : BaseRobot
{
  public MainWindowRobot(UITest test, Control rootView) : base(test, rootView) { }

  internal TextBlock GreetingMsg => GetChildView<TextBlock>("tbGreeting")!;

  internal TextBlock CounterMsg => GetChildView<TextBlock>("tbCounter")!;

  internal Button BtClick => GetChildView<Button>("btClick")!;

  internal Button BtReset => GetChildView<Button>("btReset")!;
}
