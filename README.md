# Log Monitoring Analyzer
LogAnalyzerApp is a console application designed to parse a log file, analyze its contents and report on the execution time of the processes inside the log.

## Getting started
Make sure [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download) is installed.

Clone the repository by executing `git clone https://github.com/vadrianc/LogMonitoringSolution.git` in the command line.

## How to build
In the command line execute `dotnet build`.

## How to test
In the command line execute `dotnet test`.

## How to run
In the command line execute `dotnet run --project LogMonitorApp -- "C:\Work\logs.log"`.

## Improvement areas
* Write negative unit tests
* Write integration tests
* Write end to end tests
* Improve log analyzer by covering corner cases
* Architecture consideration: define interfaces for dependency injection that facilitates expanding support for different log formats, analyzers and reports.

## License
MIT license

## Contact
Adrian Constantin Vaideanu