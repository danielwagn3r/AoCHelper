using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace AoCHelper
{
    public class InputDownloader
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private readonly string _sessionToken;

        public InputDownloader(string sessionToken)
        {
            _sessionToken = sessionToken;
        }

        public async Task<string> GetInput(int day, int year)
        {
            var result = await GetCachedAsync(day, year);
            if (result.IsNullOrEmpty())
            {
                result = await GetFromWebsiteAsync(day, year);
                await PutCacheAsync(day, year, result);
            }
            return result ?? String.Empty;
        }

        private async Task<string> GetFromWebsiteAsync(int day, int year)
        {
            using var request = new HttpRequestMessage(new HttpMethod("GET"), $"https://adventofcode.com/{year}/day/{day}/input");
            request.Headers.TryAddWithoutValidation("cookie", $"session={_sessionToken}");
            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        private async Task PutCacheAsync(int day, int year, string result)
        {
            var file = GetFileForDay(day, year);
            await file.WriteAllTextAsync(result);
        }

        private async Task<string> GetCachedAsync(int day, int year)
        {
            var file = GetFileForDay(day, year);
            return file.Exists ? await file.ReadAllTextAsync() : string.Empty;
        }

        private static FileInfo GetFileForDay(int day, int year)
        {
            var dir = Directory.CreateDirectory("Cache");
            var file = dir.GetFileInfo($"{year}_{day}.txt");
            return file;
        }
    }
}