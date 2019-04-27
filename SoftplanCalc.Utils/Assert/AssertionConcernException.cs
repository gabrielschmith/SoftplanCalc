using System;
using System.Runtime.Serialization;

namespace SoftplanCalc.Utils.Assert
{
    /// <summary>
    /// Assertion concern exception.
    /// </summary>
    public class AssertionConcernException : Exception
    {

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Alltrade.Integrador.Common.Exceptions.Exceptions.Utils.Assert.AssertionConcernException"/> class.
        /// </summary>
        public AssertionConcernException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Alltrade.Integrador.Common.Exceptions.Exceptions.Utils.Assert.AssertionConcernException"/> class.
        /// </summary>
        /// <param name="message">Message.</param>
        public AssertionConcernException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Alltrade.Integrador.Common.Exceptions.Exceptions.Utils.Assert.AssertionConcernException"/> class.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="innerException">Inner exception.</param>
        public AssertionConcernException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Alltrade.Integrador.Common.Exceptions.Exceptions.Utils.Assert.AssertionConcernException"/> class.
        /// </summary>
        /// <param name="info">Info.</param>
        /// <param name="context">Context.</param>
        protected AssertionConcernException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
