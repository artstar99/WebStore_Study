using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Xml;
using log4net;
using log4net.Core;
using Microsoft.Extensions.Logging;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace WebStore_Study.Logger
{
    class Log4NetLogger : ILogger
    {
        private readonly ILog log;
        public Log4NetLogger(string categoryName, XmlElement configuration)
        {
            var loggerRepository = LogManager.CreateRepository(
                Assembly.GetEntryAssembly(),
                typeof(log4net.Repository.Hierarchy.Hierarchy));

            log = LogManager.GetLogger(loggerRepository.Name, categoryName);

            log4net.Config.XmlConfigurator.Configure(loggerRepository, configuration);
        }

        public IDisposable BeginScope<TState>(TState state) => null;

        public bool IsEnabled(LogLevel logLevel) => logLevel switch
        {
            LogLevel.None => false,
            LogLevel.Trace => log.IsDebugEnabled,
            LogLevel.Debug => log.IsDebugEnabled,
            LogLevel.Information => log.IsInfoEnabled,
            LogLevel.Warning => log.IsWarnEnabled,
            LogLevel.Error => log.IsErrorEnabled,
            LogLevel.Critical => log.IsFatalEnabled,
            _ => throw new ArgumentOutOfRangeException(nameof(Level), logLevel, null)
        };

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (formatter is null)
                throw new ArgumentNullException(nameof(formatter));
            if (!IsEnabled(logLevel)) return;
            var logMessage = formatter(state, exception);
            if (string.IsNullOrEmpty(logMessage) && exception is null) return;

            switch (logLevel)
            {
                default: throw new ArgumentOutOfRangeException(nameof(Level), logLevel, null);
                case LogLevel.None: break;
                case LogLevel.Trace:
                case LogLevel.Debug:
                    log.Debug(logMessage);
                    break;
                case LogLevel.Information:
                    log.Info(logMessage);
                    break;
                case LogLevel.Warning:
                    log.Warn(logMessage);
                    break;
                case LogLevel.Error:
                    log.Error(logMessage, exception);
                    break;
                case LogLevel.Critical:
                    log.Fatal(logMessage, exception);
                    break;
            }

        }
    }

}