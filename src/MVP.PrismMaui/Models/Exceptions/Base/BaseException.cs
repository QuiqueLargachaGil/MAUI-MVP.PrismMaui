using System.Runtime.Serialization;

namespace MVP.PrismMaui.Models.Exceptions.Base
{
    //[Serializable]
    public abstract class BaseException : Exception, ISerializable
    {
        public BaseException(string message) : base(message)
        {
        }
    }
}
