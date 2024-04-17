using RestSharp.Authenticators;
using RestSharp;
using System.Threading;

namespace Mediatheque.Poster

{
    public class PosterManager

    {
        public async Task<string> GetPosterAsync(string titre)
        {
         
            var client = new RestClient();
            var request = new RestRequest($"https://www.omdbapi.com/?s={titre}&apikey=9358fa09");
            // The cancellation token comes from the caller. You can still make a call without it.
            var response = await client.GetAsync(request);
            return response.Content;
        }
    }
}
