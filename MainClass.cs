using System;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Net.Http;

namespace Lib46
///using namespae called Lib46
//{
{
    /// <Summary>
    /// Class <c>Falak_Integration</c>
    ///is a simple class that contain a method 
    ///  which called <c>SendAsync</c>
    /// </Summary>
    public class Falak_Integration
    {
        /// <Summary>
        /// Method <c>SendAsync</c>
        /// This method sends an HTTP request to a localhost server
        /// with a JSON payload containing an "id" and "name" field.
        /// The "name" field is set to the value of the value passed
        /// into the method. The method also prints out the response
        /// body that is returned from the server.
        /// </Summary>
        public async Task SendAsync(string name)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("http://localhost:8080/users"),
                Content = new StringContent("{\"id\":\"3\",\"name\":\"" + name + "\"}")
                {
                    Headers =
                {
                    ContentType = new MediaTypeHeaderValue("application/json")
                }
                }
                
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                Console.WriteLine(body);
            }
        }
    }
}
