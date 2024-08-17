﻿namespace Avalonia.UITester;

using System.Text;
using Avalonia.UITester.Tests;

public static class UITestsRunner
{
  public static Task<string> RunAllTestsAsync() => RunTestsAsync(new UITest[]
  {
        new MainWindowUITest()
  });

  private static async Task<string> RunTestsAsync(params UITest[] tests)
  {
    static TimeSpan SumTotalTime(IEnumerable<UITest> ts)
    {
      var totalTime = TimeSpan.Zero;
      foreach (var t in ts)
      {
        totalTime += t.ElapsedTime;
      }

      return totalTime;
    }

    StringBuilder allTestsLogsAppender = new();
    foreach (var test in tests)
    {
      await RunTestAsync(allTestsLogsAppender, test);
    }

    var totalTime = SumTotalTime(tests);
    string fmtTime = @"hh'h'mm'm'ss's'";
    allTestsLogsAppender.AppendLine("TOTAL TIME: " + totalTime.ToString(fmtTime));
    return allTestsLogsAppender.ToString();
  }

  private static async Task RunTestAsync(StringBuilder allTestsLogsAppender, UITest test)
  {
    try
    {
      test.Start();
      await test.RunAsync();
    }
    catch (Exception ex)
    {
      allTestsLogsAppender.AppendLine(ex.ToString());
    }
    finally
    {
      test.Finish();
      allTestsLogsAppender.AppendLine($"{test.TestName}: {(test.Successful == true ? "SUCCESS" : "FAILED")} {test.TotalElapsedSeconds}s");
      if (!string.IsNullOrWhiteSpace(test.Log))
      {
        allTestsLogsAppender.AppendLine(test.Log);
      }
    }
  }
}
