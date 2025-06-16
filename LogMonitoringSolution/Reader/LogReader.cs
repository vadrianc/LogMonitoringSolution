using LogMonitoringLib.Model;
using System.Globalization;

namespace LogMonitoringLib.Reader
{
    public class LogReader
    {
        private readonly string _logFile;

        public LogReader(string logFile)
        {
            if (string.IsNullOrEmpty(logFile))
            {
                throw new ArgumentException("Not a log file path", nameof(logFile));
            }

            if (!File.Exists(logFile))
            {
                throw new FileNotFoundException("Log file does not exist", logFile);
            }

            _logFile = logFile;
        }

        public IEnumerable<Log> Parse()
        {
            using (var reader = new StreamReader(_logFile))
            {
                string? line;

                while ((line = reader.ReadLine()) != null)
                {
                    var fields = line.Split(',');

                    if (fields.Length != 4)
                    {
                        /*
                         * Possible improvements:
                         * Handle incomplete lines and attempt to parse as much information as possible, and/or
                         * Log error to help with debugging
                         */
                        continue; 
                    }

                    if (!DateTime.TryParseExact(fields[0], "HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out var timestamp))
                    {
                        /*
                         * Log error to help with debugging
                         */
                        continue;
                    }
                    var description = fields[1].Trim();
                    var type = fields[2].Trim();
                    if (!int.TryParse(fields[3], out var pid))
                    {
                        /*
                         * Log error to help with debugging
                         */
                        continue;
                    }

                    yield return new Log(timestamp, description, type, pid);
                }
            }
        }
    }
}
