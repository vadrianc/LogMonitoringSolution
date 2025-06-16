namespace LogMonitoringLib.Model
{
    public class Process
    {
        public Process(int pid, string description)
        {
            Pid = pid;
            Description = description;
        }

        public int Pid { get; set; }
        public string Description { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public TimeSpan? Duration { get; set; }
    }
}
