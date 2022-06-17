namespace LoggingSample.Infrastructure
{
    public class ColoredConsoleLogger : ILogger
    {
        private string name;
        private ColoredConsoleLoggingConfiguartion configuartion;

        public ColoredConsoleLogger(string name, ColoredConsoleLoggingConfiguartion configuartion)
        {
            this.name = name;
            this.configuartion = configuartion;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return logLevel == configuartion.LogLevel;
        }

        private static object _lock = new object();
        
        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            if (!IsEnabled(logLevel))
            {
                return;
            }

            lock (_lock)
            {
                if (configuartion.EventId == 0 || configuartion.EventId == eventId.Id)
                {
                    var color = Console.ForegroundColor;
                    Console.ForegroundColor = configuartion.Color;
                    Console.WriteLine($"{logLevel} - {eventId.Id} - {name}- {formatter(state,exception)}");
                    Console.ForegroundColor = color;
                }
            }
            
        }
    }
}
