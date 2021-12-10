using Castle.DynamicProxy;
using Serilog;
using System;

namespace KarmaWebApi.Interceptors
{
    public class LoggingInterceptor : Attribute, IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            try
            {
                Log.Logger.Information("Inteceptor is recieving: " + invocation.Method.Name + " " + invocation.Arguments.ToString());

                invocation.Proceed();
                Log.Logger.Information("Interceptor seen result " + invocation.ReturnValue.ToString());
            }
            catch (Exception ex)
            {
                Log.Logger.Error("Interceptor recieved an exeption " + ex.Message);
            }
        }
    }
}
