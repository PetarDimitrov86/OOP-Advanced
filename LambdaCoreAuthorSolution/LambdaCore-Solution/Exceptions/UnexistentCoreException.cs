namespace LambdaCore_Solution.Exceptions
{
    public class UnexistentCoreException : LambdaCoreBaseException
    {
        public UnexistentCoreException()
        {
        }

        public UnexistentCoreException(string message)
            : base(message)
        {
        }
    }
}
