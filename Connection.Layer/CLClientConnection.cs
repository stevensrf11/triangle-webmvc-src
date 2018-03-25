using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net;
//using BCryption;
using Connection.Layer.Interfaces;
using Infrastructure;
using log4net;

namespace Connection.Layer
{
    /// <summary>
    /// Client connection <see cref="ICLClientConnection"/>service layer for obtaining  information
    /// </summary>
    /// <history>
    /// Created 4/20/2017
    /// </history>
    public class CLClientConnection : ICLClientConnection
    {
        #region Fields
        /// <summary>
        /// Logger for logging information interface
        /// </summary>
        private readonly ILog _logger;
        #endregion

        #region Constructors
        /// <summary>
        /// Position Constructor
        /// </summary>
        /// <param name="logManager">Log manager interface</param>
        public CLClientConnection(ILogManager logManager)
        {
            _logger= logManager.GetLog(typeof(CLClientConnection)); ;
        }
        #endregion

        #region Operation
        /// <summary>
        /// Wrapper for retrieving information from the server given the server's url address and route
        /// , and returning the information obtained an <see cref="HttpResponseMessage"/> HttpResponse object..
        /// </summary>
        /// <param name="baseAddressUrl">Serve url address</param>
        /// <param name="routeUrl">Route url</param>
        /// <param name="mime"> Format of a document</param>
        /// <returns>HttpResponseMessage with status code of OK if operation was successful</returns>
        public HttpResponseMessage GetInformation(Uri baseAddressUrl
            , string routeUrl
            , string mime
            )

        {
            var result =  Get(baseAddressUrl, routeUrl, mime).Result;

            return result;

        }

        /// <summary>
        /// Asynchronously wrapper for retrieving information from the server given the server's url address and route .
        /// , and returning the information obtained an <see cref="HttpResponseMessage"/> HttpResponse object..
        /// </summary>
        /// <param name="baseAddressUrl">Serve url address</param>
        /// <param name="routeUrl">Route url</param>
        /// <param name="mime"> Format of a document</param>
        /// <returns>HttpResponseMessage with status code of OK if operation was successful</returns>
        /// <history>
        /// </history>
        /// <remarks>
        /// https://baseurl/routurl/integer/getconnectionsuri/enctuptedstrng
        /// </remarks>
        public async Task<HttpResponseMessage> GetInformationAsync(Uri baseAddressUrl
            , string routeUrl
            , string mime
            )

        {
            var result = await Get(baseAddressUrl, routeUrl, mime);

            return result;
         }
        #endregion
        #region Utility Methods


        /// <summary>
        ///  Retrieves information from the server given the url address and route,
        ///  and returns the information obtained an <see cref="HttpResponseMessage"/> HttpResponse object..
        /// </summary>
        /// <param name="baseAddressUrl"></param>
        /// <param name="routeUrl"></param>
        /// <param name="mime"></param>
        /// <returns>HttpResponseMessage with status code of OK if operation was successful</returns>
        private async Task<HttpResponseMessage> Get(Uri baseAddressUrl
            , string routeUrl
            ,string mime
            )
        {
            HttpResponseMessage responseMessage = null;
            var requestHandler = new WebRequestHandler();

            HttpClient client = new HttpClient(requestHandler)
            {
                BaseAddress = baseAddressUrl
            };

            client.DefaultRequestHeaders.Accept.Clear();

            try
            {
             //   var s = await client.GetStringAsync(routeUrl);

                responseMessage = await client.GetAsync(routeUrl);

            }
            catch (Exception ex)
            {
                _logger.Fatal(ex.Message, ex);
                responseMessage = new HttpResponseMessage(HttpStatusCode.ExpectationFailed);
                responseMessage.Content = null;
            }
            return responseMessage;
        }
        #endregion
    }

}
