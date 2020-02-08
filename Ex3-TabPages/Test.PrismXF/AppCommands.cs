using Prism.Commands;

namespace Test.PrismXF.Tabs
{
  public class AppCommands : IAppCommands
  {
    // TRUE: Invoke only on the active command - IActiveAware
    private CompositeCommand _saveCommand = new CompositeCommand(true);

    private CompositeCommand _resetCommand = new CompositeCommand();

    public CompositeCommand SaveCommand => _saveCommand;

    public CompositeCommand ResetCommand => _resetCommand;
  }
}