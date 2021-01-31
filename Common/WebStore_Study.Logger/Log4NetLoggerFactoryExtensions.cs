using System;
using System.IO;
using System.Reflection;
using Microsoft.Extensions.Logging;

namespace WebStore_Study.Logger
{
    public static class Log4NetLoggerFactoryExtensions
    {
        public static ILoggerFactory AddLog4Net(ILoggerFactory factory, string configurationFile = "log4net.config")
        {
            if (configurationFile is null) throw new ArgumentNullException(nameof(configurationFile));
            
            if (!Path.IsPathRooted(configurationFile))
            {
                var assembly = Assembly.GetEntryAssembly() ?? throw new InvalidOperationException("Не удалось определить сборку для Log4Net поиска пути к конфигурационному файлу");
                var dir = Path.GetDirectoryName(assembly.Location) ?? throw new InvalidOperationException("Получена пустая ссылка на директорию приложения");
                configurationFile = Path.Combine(dir, configurationFile);
            }
            factory.AddProvider(new Log4NetLoggerProvider(configurationFile));
            return factory;
        }
    }

}
