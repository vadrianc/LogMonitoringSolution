using LogMonitoringLib.Model;

namespace LogMonitoringLib.Reporter
{
    public class ProcessReporter
    {
        public IEnumerable<string> Generate(IEnumerable<Process> processes)
        {
            foreach (var process in processes)
            {
                if (process.Duration.HasValue)
                {
                    if (process.Duration.Value.TotalMinutes > 10)
                    {
                        yield return $"Process {process.Pid} took more than 10 minutes";
                    }
                    else if (process.Duration.Value.TotalMinutes > 5)
                    {
                        yield return $"Process {process.Pid} took more than 5 minutes";
                    }
                    else
                    {
                        yield return $"Process {process.Pid} is OK";
                    }
                }
                else
                {
                    yield return $"Process {process.Pid} has incomplete START/END information";
                }
            }
        }
    }
}
