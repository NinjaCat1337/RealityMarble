using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealityMarble.BLL.Infrastructure
{
    public class ValidationException :Exception
    {
        public string Property { get; protected set; }
        public ValidationException(string message, string property) : base(message)
        {
            Property = property;
        }
    }
}
