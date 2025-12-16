
namespace Locator.Features.IpLocation
{
    [Serializable]
    internal class InvalidProviderResultException : Exception
    {
        private const string message = "Invalid provider to find the location for IP:{0}";
        public InvalidProviderResultException(string ipAddress) : base(string.Format(message,ipAddress))
        {
        }
    }
}