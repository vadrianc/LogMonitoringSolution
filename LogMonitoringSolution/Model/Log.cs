namespace LogMonitoringLib.Model
{
    public class Log
    {
        public Log(DateTime timestamp, string description, string type, int pid)
        {
            Timestamp = timestamp;
            Description = description;
            Type = type;
            Pid = pid;
        }

        public DateTime Timestamp { get; private set; }
        public string Description { get; private set; }
        public string Type { get; private set; }
        public int Pid { get; private set; }
    }
}
