using LogMonitoringLib.Model;
using LogMonitoringLib.Reporter;

namespace LogMonitorTest
{
    public class ProcessReporterTest
    {
        [Test]
        public void Generate_ReturnsExpectedMessages()
        {
            var processes = new List<Process>
            {
                new Process(1, "Test 1") { Duration = TimeSpan.FromMinutes(12) },
                new Process(2, "Test 2") { Duration = TimeSpan.FromMinutes(7) },
                new Process(3, "Test 3") { Duration = TimeSpan.FromMinutes(3) },
                new Process(4, "Test 4") // No duration
            };
            var reporter = new ProcessReporter();

            var results = reporter.Generate(processes).ToList();

            Assert.That(results[0], Is.EqualTo("Process 1 took more than 10 minutes"));
            Assert.That(results[1], Is.EqualTo("Process 2 took more than 5 minutes"));
            Assert.That(results[2], Is.EqualTo("Process 3 is OK"));
            Assert.That(results[3], Is.EqualTo("Process 4 has incomplete START/END information"));
        }
    }
}
