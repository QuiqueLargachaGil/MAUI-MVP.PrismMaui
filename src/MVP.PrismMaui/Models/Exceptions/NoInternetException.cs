using MVP.PrismMaui.Models.Exceptions.Base;

namespace MVP.PrismMaui.Models.Exceptions
{
    //[Serializable]
    public class NoInternetException : BaseException
    {
        public NoInternetException(string message) : base(message)
        {
        }
    }
}
