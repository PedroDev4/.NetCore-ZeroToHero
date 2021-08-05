using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenuRestAPI_Marcoratti.Filters
{
    public class ApiLoggingFilter : IActionFilter
    {
        private readonly ILogger<ApiLoggingFilter> _logger;

        public ApiLoggingFilter(ILogger<ApiLoggingFilter> logger) {

            this._logger = logger;
        }

        // Execute After Action
        public void OnActionExecuted(ActionExecutedContext context)
        {
            this._logger.LogInformation(" Executado -> OnActionExecuted ");
            this._logger.LogInformation("#############################################");
            this._logger.LogInformation($"{DateTime.Now.ToLongTimeString()}");
            this._logger.LogInformation("#############################################");
        }

        // Execute Before Action
        public void OnActionExecuting(ActionExecutingContext context)
        {
            this._logger.LogInformation(" Executando -> OnActionExecuting ");
            this._logger.LogInformation("#############################################");
            this._logger.LogInformation($"{DateTime.Now.ToLongTimeString()}");
            this._logger.LogInformation($"Model State : {context.ModelState.IsValid}");
            this._logger.LogInformation("#############################################");

        }
    }
}
