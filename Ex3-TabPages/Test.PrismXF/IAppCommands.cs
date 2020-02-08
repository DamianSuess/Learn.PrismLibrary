using Prism.Commands;

namespace Test.PrismXF.Tabs
{
  public interface IAppCommands
  {
    CompositeCommand SaveCommand { get; }

    CompositeCommand ResetCommand { get; }
  }
}