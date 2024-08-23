using Avalonia.Controls;

namespace SampleUITester.UITester.Robots;

public sealed class MainWindowRobot : BaseRobot
{
  public MainWindowRobot(UITest test, Control rootView) : base(test, rootView)
  {
  }

  internal Button BtClick => GetChildView<Button>("btClick")!;

  internal Button BtReset => GetChildView<Button>("btReset")!;

  internal TextBlock CounterMsg => GetChildView<TextBlock>("tbCounter")!;

  internal TextBlock GreetingMsg => GetChildView<TextBlock>("tbGreeting")!;
}
