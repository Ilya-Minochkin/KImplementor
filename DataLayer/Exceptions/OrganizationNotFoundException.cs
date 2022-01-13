using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Exceptions
{
    [Serializable]
    public class OrganizationNotFoundException : Exception
    {
        public OrganizationNotFoundException() { }
        public OrganizationNotFoundException(string message) : base(message) { }
        public OrganizationNotFoundException(string message, Exception inner) : base(message, inner) { }
        protected OrganizationNotFoundException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
