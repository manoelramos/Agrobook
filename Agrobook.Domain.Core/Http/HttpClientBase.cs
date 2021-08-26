namespace Agrobook.Domain.Core.Http
{
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;

    public abstract class HttpClientBase
    {
        private readonly JsonSerializer _jsonSerializer;
        private string _address;

        protected HttpClientBase(HttpClient httpClient,
                                 JsonSerializer jsonSerializer,
                                 ILogger logger)
        {
            HttpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _jsonSerializer = jsonSerializer ?? throw new ArgumentNullException(nameof(jsonSerializer));
            Logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        protected HttpClient HttpClient { get; set; }
        protected ILogger Logger { get; }
        protected Dictionary<string, string> DefaultRequestHeaders { get; private set; } = new Dictionary<string, string>();

        #region Requests

        protected async Task<(int statusCode, string response)> GetAsync(string action)
        {
            try
            {
                await ConfigureClientAsync();
                using var result = await HttpClient.GetAsync(action);

                if (!result.IsSuccessStatusCode)
                {
                    Logger.LogError($"Falha na requisição [GET]: {result.ReasonPhrase}");

                    return ((int)result.StatusCode, result.ReasonPhrase);
                }

                var response = await result.Content.ReadAsStringAsync();
                return ((int)result.StatusCode, response);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, DomainResources.GetError);
                throw;
            }
        }

        protected async Task<(int statusCode, string response)> SendAsync(HttpMethod method, string action, object parameter)
        {
            var json = Serialize(parameter);
            return await SendJsonAsync(method, action, json);
        }

        protected async Task<(int statusCode, string response)> SendJsonAsync(HttpMethod method, string action, string json)
        {
            try
            {
                await ConfigureClientAsync();

                using var content = new StringContent(json, Encoding.UTF8, "application/json");
                using var request = new HttpRequestMessage(method, action)
                {
                    Content = content
                };

                using var result = await HttpClient.SendAsync(request);
                if (!result.IsSuccessStatusCode)
                {
                    Logger.LogError($"Falha na requisição [POST]: {result.ReasonPhrase}");

                    return ((int)result.StatusCode, result.ReasonPhrase);
                }

                var response = await result.Content.ReadAsStringAsync();
                return ((int)result.StatusCode, response);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, DomainResources.PostError);
                throw;
            }
        }

        protected string Serialize(object parameter)
        {
            try
            {
                if (parameter is null)
                    return string.Empty;

                var requestStringBuilder = new StringBuilder();
                using var requestStringWriter = new StringWriter(requestStringBuilder);
                using var requestJsonTextReader = new JsonTextWriter(requestStringWriter);
                _jsonSerializer.Serialize(requestJsonTextReader, parameter);

                return requestStringBuilder.ToString();
            }
            catch (Exception ex)
            {
                Logger.LogError($"Erro ao serializar objeto {parameter.GetType().Name}: {ex.Message}");
                throw;
            }
        }

        protected TResult Deserialize<TResult>(string json)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(json))
                    return default;

                using var responseStreamReader = new StringReader(json);
                using var responseJsonTextReader = new JsonTextReader(responseStreamReader);
                return _jsonSerializer.Deserialize<TResult>(responseJsonTextReader);
            }
            catch (Exception ex)
            {
                Logger.LogError($"Erro ao desserializar objeto {typeof(TResult).Name}: {ex.Message}");
                throw;
            }
        }

        #endregion Requests

        protected async Task ConfigureClientAsync()
        {
            _address ??= await GetAddressAsync();
            HttpClient.BaseAddress ??= new Uri(_address);

            foreach (var header in DefaultRequestHeaders)
                HttpClient.DefaultRequestHeaders.Add(header.Key, header.Value);
        }

        protected void AddHeader(string key, string value)
        {
            if (!string.IsNullOrWhiteSpace(key))
                DefaultRequestHeaders.Add(key, value ?? string.Empty);
        }

        protected void SetAuthorization(string token)
        {
            if (string.IsNullOrWhiteSpace(token))
                return;

            if (HttpClient.DefaultRequestHeaders.Contains(DomainResources.Authorization))
                HttpClient.DefaultRequestHeaders.Remove(DomainResources.Authorization);
            HttpClient.DefaultRequestHeaders.Add(DomainResources.Authorization, token);
        }

        protected abstract Task<string> GetAddressAsync();
    }
}
