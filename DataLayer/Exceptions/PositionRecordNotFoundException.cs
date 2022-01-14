using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Exceptions
{

    [Serializable]
    public class PositionRecordNotFoundException : Exception
    {
        public PositionRecordNotFoundException() { }
        public PositionRecordNotFoundException(string message) : base(message) { }
        public PositionRecordNotFoundException(string message, Exception inner) : base(message, inner) { }
        protected PositionRecordNotFoundException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
