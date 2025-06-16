using LogMonitoringLib.Analyzer;
using LogMonitoringLib.Model;

namespace LogMonitorTest
{
    public class LogAnalyzerTest
    {
        [Test]
        public void ProcessLogs_ReturnsProcessesWithCorrectTimesAndDuration()
        {
            var logs = new List<Log>
            {
                new Log(new DateTime(2024, 1, 1, 11, 37, 14), "scheduled task 515", "START", 45135),
                new Log(new DateTime(2024, 1, 1, 11, 49, 37), "scheduled task 515", "END", 45135)
            };
            var analyzer = new LogAnalyzer();

            var processes = analyzer.ProcessLogs(logs).ToList();

            Assert.That(processes.Count, Is.EqualTo(1));
            var process = processes[0];
            Assert.That(process.Pid, Is.EqualTo(45135));
            Assert.That(process.Description, Is.EqualTo("scheduled task 515"));
            Assert.That(process.StartTime, Is.EqualTo(new DateTime(2024, 1, 1, 11, 37, 14)));
            Assert.That(process.EndTime, Is.EqualTo(new DateTime(2024, 1, 1, 11, 49, 37)));
            Assert.That(process.Duration, Is.EqualTo(TimeSpan.FromMinutes(12).Add(TimeSpan.FromSeconds(23))));
        }
    }
}
