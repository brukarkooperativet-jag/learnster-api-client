using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace JAG.Learnster.APIClient.Extensions
{
    /// <summary>
    /// Http client extension methods
    /// </summary>
    public static class HttpClientExtensions
    {
        /// <summary>
        /// Deserialize HttpContent
        /// </summary>
        /// <param name="responseMessage"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async Task<T> DeserializeContent<T>(this HttpResponseMessage responseMessage)
        {
            await using (var contentStream = await responseMessage.Content.ReadAsStreamAsync())
            {
                return await JsonSerializer.DeserializeAsync<T>(contentStream);
            }
        }
    }
}