using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace MyHW3.Models
{
    public class TokenBuild
    {
        private readonly IHttpClientFactory _clientFactory;
        public TokenBuild(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<AccessToken> GetToken(string requestUri)
        {
            string baseUrl = $"https://tdx.transportdata.tw/auth/realms/TDXConnect/protocol/openid-connect/token";

            var parameters = new Dictionary<string, string>()
            {
                { "grant_type", "client_credentials"},
                { "client_id", "jhliao-4eef97b4-71ea-4884" },
                { "client_secret", "247564cb-0dd9-4043-979d-182e5993b25a"}
            };

            var formData = new FormUrlEncodedContent(parameters);

            var client = _clientFactory.CreateClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
            var response = await client.PostAsync(baseUrl, formData);

            var responseContent = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<AccessToken>(responseContent);
        }

       


        public async Task<string> Get(Dictionary<string, string> parameters, string requestUri, string token)
        {
            var client = _clientFactory.CreateClient();

            if (!string.IsNullOrWhiteSpace(token))
            {
                client.DefaultRequestHeaders.Add("authorization", $"Bearer {token}");
            }
            //client.DefaultRequestHeaders.Add("Content-Type", "application/json; charset=utf-8");

            if (parameters.Any())
            {
                var strParam = string.Join("&", parameters.Where(d => !string.IsNullOrWhiteSpace(d.Value)).Select(o => o.Key + "=" + o.Value));
                requestUri = string.Concat(requestUri, '?', strParam);
            }
            client.BaseAddress = new Uri(requestUri);

            var response = await client.GetAsync(requestUri).ConfigureAwait(false);

            var responseContent = await response.Content.ReadAsStringAsync();

            return responseContent;
        }
    }
}
