using System.Collections.Concurrent;
using System.Xml;
using Microsoft.Extensions.Logging;

namespace WebStore_Study.Logger
{
    internal class Log4NetLoggerProvider : ILoggerProvider
    {
        private readonly string configurationFile;

        public Log4NetLoggerProvider(string configurationFile)
        {
            this.configurationFile = configurationFile;
        }

        private readonly ConcurrentDictionary<string, Log4NetLogger> loggers = new();


        public ILogger CreateLogger(string categoryName) =>
            loggers.GetOrAdd(categoryName, category =>
            {
                var xml = new XmlDocument();
                xml.Load(configurationFile);
                return new Log4NetLogger(category, xml["log4net"]);
            });

        public void Dispose() => loggers.Clear();
    }

}