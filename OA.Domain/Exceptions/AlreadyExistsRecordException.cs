namespace OA.Domain.Exceptions
{
    public class AlreadyExistsRecordException : Exception
    {
        public AlreadyExistsRecordException()
        {

        }

        public AlreadyExistsRecordException(string message) : base(message)
        {

        }
    }
}
