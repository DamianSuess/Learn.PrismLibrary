namespace Avalonia.UITester.Robots;

using Avalonia.Controls;

public abstract class BaseRobot
{
  protected readonly UITest test;
  protected readonly Control rootView;

  protected BaseRobot(UITest test, Control rootView)
  {
    this.test = test;
    this.rootView = rootView;
  }

  protected A? GetChildView<A>(string name) where A : Control =>
      this.rootView.FindControl<A>(name);

}
