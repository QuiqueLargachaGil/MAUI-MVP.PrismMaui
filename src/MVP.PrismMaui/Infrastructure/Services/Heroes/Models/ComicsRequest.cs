using MVP.PrismMaui.Infrastructure.Services.Base;

namespace MVP.PrismMaui.Infrastructure.Services.Heroes.Models
{
    public class ComicsRequest : BaseRequest
    {
        public ComicsRequest(string baseUrl, string absolutePath) : base(baseUrl)
        {
            AbsolutePath = absolutePath;
        }

        public string AbsolutePath { get; }
    }
}
