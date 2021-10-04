using System;

namespace TestTask.Infrastructure
{
    internal class BadResponseException : Exception
    {
        public BadResponseException(int? code, string message) : base($"Code: {code ?? 0} Message: {message}")
        {
        }
    }
}
