namespace LambdaCore_Solution.Exceptions
{
    public class NoSelectedCoreException : LambdaCoreBaseException
    {
        public NoSelectedCoreException()
        {
        }

        public NoSelectedCoreException(string message)
            : base(message)
        {
        }
    }
}
