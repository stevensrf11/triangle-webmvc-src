using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Connection.Layer.Interfaces
{
    /// <summary>
    /// Client derived <see cref="ICLClient"/>connection information layer service interface  .
    /// Used for obtaining site connection information.
    /// </summary>
    /// <history>
    /// </history>
    public interface ICLClientConnection : ICLClient
    {
        /// <summary>
        ///  Retrieves information from the server given the url address and route,
        /// </summary>
        /// <param name="baseAddressUrl"></param>
        /// <param name="routeUrl"></param>
        /// <param name="mime"></param>
        /// <returns>HttpResponseMessage with status code of OK if operation was successful</returns>
        HttpResponseMessage GetInformation(Uri baseAddressUrl
            , string mime
            , string routeUrl);

        /// <summary>
        ///  Retrieves information asynchronously from the server given the url address and route,
        /// </summary>
        /// <param name="baseAddressUrl"></param>
        /// <param name="routeUrl"></param>
        /// <param name="mime"></param>
        /// <returns>HttpResponseMessage with status code of OK if operation was successful</returns>

        /// <history>
        /// </history>
        Task<HttpResponseMessage> GetInformationAsync(Uri baseAddressUrl
            , string mime
            , string routeUrl);

    }

}
