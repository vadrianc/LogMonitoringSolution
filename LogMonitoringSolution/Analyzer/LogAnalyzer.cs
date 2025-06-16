using LogMonitoringLib.Model;

namespace LogMonitoringLib.Analyzer
{
    public class LogAnalyzer
    {
        private readonly Dictionary<int, Model.Process> processes = new();

        public IEnumerable<Model.Process> ProcessLogs(IEnumerable<Log> logs)
        {
            foreach (var log in logs)
            {
                /*
                 * Improve handling for:
                 * Same PID occurs multiple times
                 * Missing START/END
                 * Description different for START & END logs
                 */
                if (!processes.ContainsKey(log.Pid))
                {
                    processes[log.Pid] = new Process(log.Pid, log.Description);
                }

                if (log.Type.Equals("START", StringComparison.InvariantCultureIgnoreCase))
                {
                    processes[log.Pid].StartTime = log.Timestamp;
                }
                else if (log.Type.Equals("END", StringComparison.InvariantCultureIgnoreCase))
                {
                    processes[log.Pid].EndTime = log.Timestamp;
                }

                if (processes[log.Pid].StartTime.HasValue && processes[log.Pid].EndTime.HasValue)
                {
                    processes[log.Pid].Duration = processes[log.Pid].EndTime - processes[log.Pid].StartTime;
                }
            }

            return processes.Values;
        }
    }
}
