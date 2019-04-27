using System;
namespace SoftplanCalc.Utils.Assert
{
    /// <summary>
    /// Assertion concern.
    /// </summary>
    public class AssertionConcern
    {
        /// <summary>
        /// Asserts the argument not null.
        /// </summary>
        /// <param name="object1">Object1.</param>
        /// <param name="message">Message.</param>
        public static void AssertArgumentNotNull(object object1, string message)
        {
            if (object1 == null)
            {
                throw new AssertionConcernException(message);
            }
        }
    }
}
