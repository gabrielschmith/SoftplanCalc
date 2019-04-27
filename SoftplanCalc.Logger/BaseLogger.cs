using System;
namespace SoftplanCalc.Logger
{
    /// <summary>
    /// Base logger.
    /// </summary>
    public class BaseLogger : IBaseLogger
    {
        /// <summary>
        /// Log the specified message.
        /// </summary>
        /// <param name="message">Message.</param>
        public void Log(string message, LogEvent logEvent)
        {
            Log(null, message, logEvent);
        }

        /// <summary>
        /// Log the specified ex and message.
        /// </summary>
        /// <param name="ex">Ex.</param>
        /// <param name="message">Message.</param>
        public void Log(Exception ex, LogEvent logEvent)
        {
            Log(ex, string.Empty, logEvent);
        }

        /// <summary>
        /// Log the specified ex, message and logEvent.
        /// </summary>
        /// <param name="ex">Ex.</param>
        /// <param name="message">Message.</param>
        /// <param name="logEvent">Log event.</param>
        public void Log(Exception ex, string message, LogEvent logEvent)
        {
            switch (logEvent)
            {
                case LogEvent.Verbose:
                    Serilog.Log.Verbose(ex, message);
                    break;
                case LogEvent.Debug:
                    Serilog.Log.Debug(ex, message);
                    break;
                case LogEvent.Information:
                    Serilog.Log.Information(ex, message);
                    break;
                case LogEvent.Warning:
                    Serilog.Log.Warning(ex, message);
                    break;
                case LogEvent.Error:
                    Serilog.Log.Error(ex, message);
                    break;
                case LogEvent.Fatal:
                    Serilog.Log.Fatal(ex, message);
                    break;
                default:
                    throw new ArgumentException("Argument LogEvent not found!");
            }
        }
    }
}
