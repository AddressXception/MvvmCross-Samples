using System;
using System.Runtime.Serialization;

namespace TipCalc.UITest.Shared.Common
{
    [Serializable]
    public class AssertFailedException : Exception
    {
        public AssertFailedException()
        {
        }

        public AssertFailedException(string message) : this(message, (Exception)null)
        {

        }

        public AssertFailedException(string message, Exception innerException) : base(message, innerException)
        {
            Console.WriteLine("Assert Failed: " + message + "Inner Exception: " + innerException);
        }

        public AssertFailedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            Console.WriteLine("Assert Failed");
        }

    }
}
