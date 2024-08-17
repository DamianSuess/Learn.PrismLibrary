using System;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace Avalonia.UITester;

#pragma warning disable IDE1006 // Naming Styles
public abstract partial class UITest
{
  public string TestName => this.GetType().Name;

  public string Log => this.logAppender.ToString();

  public bool? Successful { get; private set; }

  private readonly StringBuilder logAppender;

  private readonly Stopwatch stopwatch;

  public int TotalElapsedSeconds => (int)this.stopwatch.Elapsed.TotalSeconds;

  public TimeSpan ElapsedTime => this.stopwatch.Elapsed;

  public UITest()
  {
    this.logAppender = new();
    this.stopwatch = new();
  }

  public void Assert(bool condition)
  {
    if (condition == false)
    {
      Successful = false;
      throw new UITestException();
    }
  }

  public void Start()
  {
    Successful = null;
    this.stopwatch.Start();
  }

  public void Finish()
  {
    Successful = Successful is null;
    this.stopwatch.Stop();
    Teardown();
  }

  protected virtual void Teardown()
  {
  }

  public Task Wait(double seconds) => Task.Delay((int)(seconds * 1000));

  protected void AppendToLog(string msg) => this.logAppender.AppendLine(msg);

  public abstract Task RunAsync();
}

public sealed class UITestException : Exception
{
}
#pragma warning restore IDE1006 // Naming Styles
