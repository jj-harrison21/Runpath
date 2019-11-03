using System.Net.Http;

namespace RunpathCodingTest.WebApi.HttpClient
{
    public interface IPhotoRequestor
    {
        T GetRequest<T>(string requestUri);
    }
}