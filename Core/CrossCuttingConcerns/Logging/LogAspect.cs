using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Logging.Log4Net;
using Core.Utilities.Interceptors;
using Core.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Logging
{
    public class LogAspect : MethodInterception
    {
        LoggerServiceBase _loggerServiceBase;
        public LogAspect(Type loggerService)
        {
            if (!loggerService.BaseType.Equals(typeof(LoggerServiceBase)))
            {
                throw new ArgumentException(AspectMessages.WrongLoggerType);
            }

            _loggerServiceBase = Activator.CreateInstance(loggerService) as LoggerServiceBase;
        }

        protected override void OnBefore(IInvocation invocation)
        {
            _loggerServiceBase.Info(invocation);
        }

        private LogDetail GetLogDetail(IInvocation invocation)
        {
            var logParameters = invocation.Arguments.Select(x => new LogParameter
            {
                Value = x,
                Type = x.GetType().Name
            }).ToList();

            return new LogDetail
            {
                MethodName = invocation.Method.Name,
                LogParameters = logParameters
            };

        }
    }
}
