namespace LambdaCore_Solution.Exceptions
{
    using System;

    public abstract class LambdaCoreBaseException : Exception
    {
        protected LambdaCoreBaseException()
        {
        }

        protected LambdaCoreBaseException(string message)
            : base(message)
        {
        }
    }
}
