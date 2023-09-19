using Android.Accessibilityservice.AccessibilityService;
using Newtonsoft.Json;
using Soccr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soccr.Services
{
    internal class HttpService
    {
        public static async Task PostPlayersAsync(List<PlayerModel> players)
        {
            string jsonPlayers = JsonConvert.SerializeObject(players);
            MultipartFormDataContent requestContent = new MultipartFormDataContent();
            requestContent.Add(new StringContent(jsonPlayers), "playersJson");
            await PostAsync(Endpoints.AddPlayersURL, requestContent);
        }

        public static async Task<bool> AuthorizeAsync(string username, string password)
        {
            MultipartFormDataContent requestContent = new MultipartFormDataContent();
            requestContent.Add(new StringContent(username), "username");
            requestContent.Add(new StringContent(password), "password");

            string response = await PostAsync(Endpoints.LoginURL, requestContent);

            if (string.IsNullOrEmpty(response))
                return false;

            return bool.Parse(response);
        }

        public static async Task<string> PostImageAsync(byte[] imageBytes, string name, string fileName)
        {
            MultipartFormDataContent requestContent = new MultipartFormDataContent();
            requestContent.Add(new ByteArrayContent(imageBytes), name, fileName);
            string response = await PostAsync(Endpoints.RecognizeURL, requestContent);
            return await Task.FromResult(response);
        }
        public static async Task<string> PostAsync(string url, HttpContent requestContent)
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.PostAsync(url, requestContent);
            return await response.Content.ReadAsStringAsync();
        }
    }
}
