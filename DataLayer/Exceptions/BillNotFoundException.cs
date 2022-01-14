using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Exceptions
{

    [Serializable]
    public class BillNotFoundException : Exception
    {
        public BillNotFoundException() { }
        public BillNotFoundException(string message) : base(message) { }
        public BillNotFoundException(string message, Exception inner) : base(message, inner) { }
        protected BillNotFoundException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
