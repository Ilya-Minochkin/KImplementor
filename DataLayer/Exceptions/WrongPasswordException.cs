using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Exceptions
{

    [Serializable]
    public class WrongPasswordException : Exception
    {
        public WrongPasswordException() { }
        public WrongPasswordException(string message) : base(message) { }
        public WrongPasswordException(string message, Exception inner) : base(message, inner) { }
        protected WrongPasswordException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
