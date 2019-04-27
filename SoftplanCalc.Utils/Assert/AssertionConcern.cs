using System;
namespace SoftplanCalc.Utils.Assert
{
    /// <summary>
    /// Assertion concern.
    /// </summary>
    public class AssertionConcern
    {
        /// <summary>
        /// Asserts the argument equals.
        /// </summary>
        /// <param name="object1">Object1.</param>
        /// <param name="object2">Object2.</param>
        /// <param name="message">Message.</param>
        public static void AssertArgumentEquals(object object1, object object2, string message)
        {
            if (!object1.Equals(object2))
            {
                throw new AssertionConcernException(message);
            }
        }

        /// <summary>
        /// Asserts the argument not equals.
        /// </summary>
        /// <param name="object1">Object1.</param>
        /// <param name="object2">Object2.</param>
        /// <param name="message">Message.</param>
        public static void AssertArgumentNotEquals(object object1, object object2, string message)
        {
            if (object1.Equals(object2))
            {
                throw new AssertionConcernException(message);
            }
        }

        /// <summary>
        /// Asserts the argument not empty.
        /// </summary>
        /// <param name="stringValue">String value.</param>
        /// <param name="message">Message.</param>
        public static void AssertArgumentNotEmpty(string stringValue, string message)
        {
            if (stringValue == null || stringValue.Trim().Length == 0)
            {
                throw new AssertionConcernException(message);
            }
        }

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

        /// <summary>
        /// Asserts the argument true.
        /// </summary>
        /// <param name="boolValue">If set to <c>true</c> bool value.</param>
        /// <param name="message">Message.</param>
        public static void AssertArgumentTrue(bool boolValue, string message)
        {
            if (!boolValue)
            {
                throw new AssertionConcernException(message);
            }
        }

        /// <summary>
        /// Asserts the length of the argument string max.
        /// </summary>
        /// <param name="object1">Object1.</param>
        /// <param name="len">Length.</param>
        /// <param name="message">Message.</param>
        public static void AssertArgumentStringMaxLength(string object1, long len, string message)
        {
            if (object1.Length > len)
            {
                throw new AssertionConcernException(message);
            }
        }

        /// <summary>
        /// Asserts the argument not less or equals than zero.
        /// </summary>
        /// <param name="object1">Object1.</param>
        /// <param name="message">Message.</param>
        public static void AssertArgumentNotLessOrEqualsThanZero(object object1, string message)
        {
            if (Convert.ToInt64(object1) <= 0)
            {
                throw new AssertionConcernException(message);
            }
        }
    }
}
