namespace Newshore.EF.Exceptions
{
    public class EFException: Exception
    {
        public EFException(string message = "") : base(message) { }
    }
}
