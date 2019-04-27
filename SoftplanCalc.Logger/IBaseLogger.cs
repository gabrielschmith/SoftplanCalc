using System;
namespace SoftplanCalc.Logger
{
    /// <summary>
    /// Base logger.
    /// </summary>
    public interface IBaseLogger
    {
        /// <summary>
        /// Log the specified message and logEvent.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="logEvent">Log event.</param>
        void Log(string message, LogEvent logEvent);

        /// <summary>
        /// Log the specified ex and logEvent.
        /// </summary>
        /// <param name="ex">Ex.</param>
        /// <param name="logEvent">Log event.</param>
        void Log(Exception ex, LogEvent logEvent);

        /// <summary>
        /// Log the specified ex, message and logEvent.
        /// </summary>
        /// <param name="ex">Ex.</param>
        /// <param name="message">Message.</param>
        /// <param name="logEvent">Log event.</param>
        void Log(Exception ex, string message, LogEvent logEvent);
    }
}
