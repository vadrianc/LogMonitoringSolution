// See https://aka.ms/new-console-template for more information

using LogMonitoringLib.Analyzer;
using LogMonitoringLib.Reader;
using LogMonitoringLib.Reporter;

LogReader reader = new("logs.log");
LogAnalyzer analyzer = new();

var logs = reader.Parse();
var processes = analyzer.ProcessLogs(logs);

ProcessReporter reporter = new();
var reports = reporter.Generate(processes);

foreach (var report in reports)
{
    Console.WriteLine(report);
}