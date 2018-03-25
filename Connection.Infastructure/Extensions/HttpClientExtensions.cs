using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace Connection.Infastructure.Extensions
{
    /// <summary>
    /// HTTP Client extension class to supplement or modify methods.
    /// </summary>
    /// <history>
    /// </history>
    public static class HttpClientExtensions
    {
        /// <summary>
        /// Patch verb request operation.
        /// </summary>
        /// <param name="client">HTTP client</param>
        /// <param name="requestUri">URL to connect to</param>
        /// <param name="iContent">Request content to send</param>
        /// <returns>HTTP response message</returns>
        /// <history>
        /// Created 4/20/2017
        /// </history> 
        /// <exception cref="TaskCanceledException"></exception>
        /// <remarks>
        /// Ned to handle catch exception to log error or see how response return handles if failed
        /// </remarks>      
        public static async Task<HttpResponseMessage> PatchAsync(this HttpClient client
            , Uri requestUri
            , HttpContent iContent)
        {
            // HTTP method type
            var method = new HttpMethod("PATCH");
            // THe HTTP request message to send
            var request = new HttpRequestMessage(method, requestUri)
            {
                Content = iContent
            };

            // Returned response variable
            var response = new HttpResponseMessage();
            try
            {
                response = await client.SendAsync(request);
            }
            catch (TaskCanceledException e)
            {

                Debug.WriteLine("ERROR: " + e.ToString());
            }

            return response;
        }


    }

}
