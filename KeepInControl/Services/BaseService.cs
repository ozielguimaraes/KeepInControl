using System;
using System.Text.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace KeepInControl.Services
{
    sealed class BaseService
    {
        private static readonly Lazy<BaseService> _Lazy = new Lazy<BaseService>(() => new BaseService());
        private readonly HttpClient httpClient;
        private readonly JsonSerializerOptions jsonSerializerOptions;

        public static BaseService Current { get => _Lazy.Value; }

        public BaseService()
        {
            httpClient = new HttpClient();
            jsonSerializerOptions = new JsonSerializerOptions
            {
                IgnoreReadOnlyProperties = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault
            };
        }

        public async Task<T> GetAsync<T>(string url, string accessToken = null)
        {
            using HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, url);

            if (!string.IsNullOrWhiteSpace(accessToken))
                httpRequestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            using HttpResponseMessage httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

            var responseContent = await httpResponseMessage.Content.ReadAsStringAsync();

            if (!httpResponseMessage.IsSuccessStatusCode)
                await ExceptionFromHttpStatusCode(httpResponseMessage);

            if (string.IsNullOrWhiteSpace(responseContent)) return default;

            return JsonSerializer.Deserialize<T>(responseContent, jsonSerializerOptions);
        }

        private async Task ExceptionFromHttpStatusCode(HttpResponseMessage httpResponseMessage)
        {
            var content = await httpResponseMessage.Content.ReadAsStringAsync();

            throw new InvalidOperationException("Erro desconhecido ao realizar essa operação");
        }
    }
}