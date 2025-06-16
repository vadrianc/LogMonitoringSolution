// See https://aka.ms/new-console-template for more information

using LogMonitoringLib.Analyzer;
using LogMonitoringLib.Reader;
using LogMonitoringLib.Reporter;

if (args.Length == 0)
{
    Console.WriteLine("Provide the logs file path as the first argument");
    return;
}

LogReader reader = new(args[0]);
LogAnalyzer analyzer = new();

var logs = reader.Parse();
var processes = analyzer.ProcessLogs(logs);

ProcessReporter reporter = new();
var reports = reporter.Generate(processes);

foreach (var report in reports)
{
    Console.WriteLine(report);
}