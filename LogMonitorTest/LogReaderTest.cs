using LogMonitoringLib.Reader;

namespace LogMonitorTest
{
    public class LogReaderTest
    {
        private string _tempLogFile;

        [SetUp]
        public void Setup()
        {
            _tempLogFile = Path.GetTempFileName();
            File.WriteAllText(_tempLogFile, "11:37:14,scheduled task 515, START,45135\n11:49:37,scheduled task 515, END,45135");
        }

        [TearDown]
        public void TearDown()
        {
            if (File.Exists(_tempLogFile))
                File.Delete(_tempLogFile);
        }

        [Test]
        public void LogReader_Parse_ReturnsValidLog()
        {
            var reader = new LogReader(_tempLogFile);
            var logs = reader.Parse().ToList();

            Assert.That(logs.Count, Is.EqualTo(2));

            Assert.That(logs[0].Timestamp.ToString("HH:mm:ss"), Is.EqualTo("11:37:14"));
            Assert.That(logs[0].Description, Is.EqualTo("scheduled task 515"));
            Assert.That(logs[0].Type, Is.EqualTo("START"));
            Assert.That(logs[0].Pid, Is.EqualTo(45135));

            Assert.That(logs[1].Timestamp.ToString("HH:mm:ss"), Is.EqualTo("11:49:37"));
            Assert.That(logs[1].Description, Is.EqualTo("scheduled task 515"));
            Assert.That(logs[1].Type, Is.EqualTo("END"));
            Assert.That(logs[1].Pid, Is.EqualTo(45135));
        }
    }
}