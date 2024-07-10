using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using Progreso2CATAPIJR.Models;
using Newtonsoft.Json;

namespace Progreso2CATAPIJR.Services
{
    public class CatImageServiceJR
    {
        private readonly HttpClient _httpClient;

        public CatImageServiceJR()
        {
            _httpClient = new HttpClient();
        }

        public async Task<CatImageJR> GetRandomCatImage()
        {
            CatImageJR catImage = null;
            HttpResponseMessage response;
            string requestUrl = "https://api.thecatapi.com/v1/images/search";

            try
            {
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, requestUrl);
                response = await _httpClient.SendAsync(request);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    var catImages = JsonConvert.DeserializeObject<List<CatImageJR>>(json);
                    catImage = catImages?.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                throw;
            }

            return catImage;
        }
    }
}
