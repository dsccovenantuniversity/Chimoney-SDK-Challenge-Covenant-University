
using System.Text.Json;

namespace ChimoneyDotNet;

public partial class Chimoney : IChimoneyWrapperBase
{
    /// <summary>
    /// Base Url for API
    /// </summary>
    private readonly static string BaseAPIUrl = "https://api-v2-sandbox.chimoney.io/v0.2/";

    private static HttpClient _httpClient;

    /// <summary>
    /// Developer API Key
    /// </summary>
    private readonly string APIKey;

    private readonly static JsonSerializerOptions serializerOptions = new()
    {
        PropertyNameCaseInsensitive = true,
    };

    /// <summary>
    /// Returns an instance of the API library using API key
    /// </summary>
    /// <param name="APIKey">Developer API Key</param>
    public Chimoney(string APIKey)
    {
        this.APIKey = APIKey;
        _httpClient = new HttpClient();
    }

    /// <summary>
    /// Returns an instance of the API library using API key stored in environment
    /// variable "CHIMONEY_API_KEY"
    /// </summary>
    /// <exception cref="ArgumentNullException">Throws an exception if environment variable is null</exception>
    public Chimoney()
    {
        APIKey = Environment.GetEnvironmentVariable("CHIMONEY_API_KEY")!;
        if (APIKey == null)
        {
            throw new ArgumentNullException(nameof(APIKey), "APIKey Null. Pass key to constructor or set" +
                "environment variable \"CHIMONEY_API_KEY\" ");
        }
        _httpClient = new HttpClient();

    }


    HttpRequestMessage SetupRequestObject(HttpMethod method, string url)
    {
        var request = new HttpRequestMessage(method, url);
        request.Headers.Add("accept", "application/json");
        request.Headers.Add("X-API-KEY", APIKey);

        return request;
    }

    public static void Dispose()
    {
       _httpClient.Dispose();
    }
}
