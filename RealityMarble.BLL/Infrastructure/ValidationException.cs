using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealityMarble.BLL.Infrastructure
{
    /// <summary>
    /// Class ValidationException.
    /// </summary>
    /// <seealso cref="System.Exception" />
    public class ValidationException :Exception
    {
        public string Property { get; protected set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="property">The property.</param>
        public ValidationException(string message, string property) : base(message)
        {
            Property = property;
        }
    }
}
