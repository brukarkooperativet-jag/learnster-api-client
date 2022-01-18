﻿using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace JAG.Learnster.APIClient.Extensions
{
    public static class HttpClientExtensions
    {
        public static async Task<T> DeserializeContent<T>(this HttpResponseMessage responseMessage)
        {
            await using (var contentStream = await responseMessage.Content.ReadAsStreamAsync())
            {
                return await JsonSerializer.DeserializeAsync<T>(contentStream);
            }
        }
    }
}