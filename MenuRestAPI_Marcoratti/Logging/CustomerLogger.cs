using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MenuRestAPI_Marcoratti.Logging
{
    public class CustomerLogger : ILogger
    {
        readonly string _loggerName;
        readonly CustomLoggerProviderConfiguration _loggerConfig;

        public CustomerLogger(string name, CustomLoggerProviderConfiguration config) {

            this._loggerName = name;
            this._loggerConfig = config;
        }

        public IDisposable BeginScope<TState>(TState state) {

            return null;
        }

        public bool IsEnabled(LogLevel logLevel) {

            return logLevel == _loggerConfig.LogLevel;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception expection,
            Func<TState, Exception, string> formatter) {
        
            string message = $"{logLevel.ToString()} : {eventId} - {formatter(state, expection)}";

            EscreverTextoNoArquivo(message);
        
        }

        private void EscreverTextoNoArquivo(string message) {

            string caminhoArquivoLog = @"c:\dados\log\Marcoratti_Log.txt";
            using (StreamWriter streamWriter = new StreamWriter(caminhoArquivoLog, true)) {

                try {

                    streamWriter.WriteLine(message);
                    streamWriter.Close();

                } catch (Exception) {
                    throw;
                }

            }
            
        }
    }
}
