using PropertyManagement.Helper.Models;

namespace PropertyManagement.Helper.ExtensionMethods
{
    public static class IEnumerableExtensions
    {
        public static string JoinNext(this IEnumerable<TransportationModel> source, string separator, Func<TransportationModel, string> format)
        {
            return string.Join(separator, source.ToList().Select(format));
        }
    }
}
