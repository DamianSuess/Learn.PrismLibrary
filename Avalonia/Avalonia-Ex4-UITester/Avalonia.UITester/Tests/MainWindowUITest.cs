using Avalonia.Controls;
using Avalonia.UITester.Robots;
using SampleUITester.Views;

namespace Avalonia.UITester.Tests;

public sealed class MainWindowUITest : UITest
{
  private MainWindowRobot Robot { get; }

  public MainWindowUITest()
  {
    var content = MainWindow.Instance!.Content;
    Robot = new(this, (Control)content!);
  }

  public override async Task RunAsync()
  {
    AssertIsVisible(Robot.GreetingMsg);
    AssertIsVisible(Robot.CounterMsg);
    AssertIsVisible(Robot.BtClick);
    AssertIsVisible(Robot.BtReset);

    await Robot.BtReset.ClickOn();

    AssertHasText(Robot.GreetingMsg, "Press F7 to run UI tests");
    AssertHasText(Robot.CounterMsg, "Clicked 0 times");
    AssertHasText(Robot.BtClick, "Click me");

    await Robot.BtClick.ClickOn();
    AssertHasText(Robot.CounterMsg, "Clicked 1 times");

    await Robot.BtClick.ClickOn();
    AssertHasText(Robot.CounterMsg, "Clicked 2 times");

    await Robot.BtReset.ClickOn();
    await Wait(1);
    AssertHasText(Robot.CounterMsg, "Clicked 0 times");
  }
}
