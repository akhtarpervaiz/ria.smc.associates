﻿using System;

namespace ria.smc.associates.UI
{
    public class CustomException : Exception
    {
        public CustomException()
        {
        }

        public CustomException(string message) : base(message)
        {
        }

        public CustomException(string message, string responseModel) : base(message)
        {
        }

        public CustomException(string message, Exception innerException) : base(message, innerException)
        {

        }
        public enum Exceptions
        {
            NullReferenceException = 1,
            FileNotFoundException = 2,
            OverflowException = 3,
            OutOfMemoryException = 4,
            InvalidCastException = 5,
            ObjectDisposedException = 6,
            UnauthorizedAccessException = 7,
            NotImplementedException = 8,
            NotSupportedException = 9,
            InvalidOperationException = 10,
            TimeoutException = 11,
            ArgumentException = 12,
            FormatException = 13,
            StackOverflowException = 14,
            SqlException = 15,
            IndexOutOfRangeException = 16,
            IOException = 17
        }
    }
}
