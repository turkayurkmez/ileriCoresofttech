using System.Collections.Concurrent;

namespace LoggingSample.Infrastructure
{
    public class ColoredConsoleLoggerProvider : ILoggerProvider
    {
        private ColoredConsoleLoggingConfiguartion configuartion;
        private ConcurrentDictionary<string, ColoredConsoleLogger> loggers=new ConcurrentDictionary<string, ColoredConsoleLogger> ();

        public ColoredConsoleLoggerProvider(ColoredConsoleLoggingConfiguartion configuartion)
        {
            this.configuartion = configuartion;
            this.configuartion.Color = ConsoleColor.Yellow;
        }

        public ILogger CreateLogger(string categoryName)
        {
            return loggers.GetOrAdd(categoryName, name => new ColoredConsoleLogger(name, configuartion));
        }

        public void Dispose()
        {
            loggers.Clear();
        }
    }
}
