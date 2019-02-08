using System;
using System.Runtime.Serialization;

namespace AcoesDotNet.Model
{
    [Serializable]
    internal class ArgumentExeption : Exception
    {
        public ArgumentExeption()
        {
        }

        public ArgumentExeption(string message) : base(message)
        {
        }

        public ArgumentExeption(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ArgumentExeption(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}