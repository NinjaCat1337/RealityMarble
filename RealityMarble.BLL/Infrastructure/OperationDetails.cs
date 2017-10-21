using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealityMarble.BLL.Infrastructure
{
    public class OperationDetails
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OperationDetails"/> class.
        /// </summary>
        /// <param name="succedeed">if set to <c>true</c> [succedeed].</param>
        /// <param name="message">The message.</param>
        /// <param name="property">The property.</param>
        public OperationDetails(bool succedeed, string message, string property)
        {
            Succedeed = succedeed;
            Message = message;
            Property = property;
        }
        public bool Succedeed { get; private set; }
        public string Message { get; private set; }
        public string Property { get; private set; }
    }
}
