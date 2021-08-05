using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenuRestAPI_Marcoratti.Logging
{
    public class CustomLoggerProviderConfiguration
    {
        // Model configuration of "Logger"
        public LogLevel LogLevel { get; set; } = LogLevel.Warning;

        public int EventId { get; set; } = 0;
    }
}
