using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Business.Layer.Interfaces.Models.Triangle;
using Business.Layer.Interfaces.Processing.Triangle;
using Business.Layer.Model;
using Business.Layer.Models.Triangle;
using Connection.Layer.Interfaces;
using Infrastructure;
using log4net;
using Newtonsoft.Json;

namespace Business.Layer.Processing.Triangle
{
    /// <summary>
    /// Business Layer Triangle Processing  Class.
    /// Contains operations that pertain to triangle actions
    /// <see cref="IBLTriangleProcessing"/>
    /// </summary>
    public class BLTriangleProcessing : BLProcessing
        , IBLTriangleProcessing
    {
        #region Fields
        /// <summary>
        /// Logger for logging information interface
        /// </summary>
        private readonly ILog _logger;
        /// <summary>
        /// Maps one object to another interface
        /// </summary>
        private readonly IMapper _mapper;
        /// <summary>
        /// Client connection layer  processing interface
        /// </summary>
        private readonly ICLClientConnection _clientConnection;
        #endregion

        #region Constructors
        /// <summary>
        /// Position Constructor
        /// </summary>
        /// <param name="logManager">Log  manager interface</param>
        /// <param name="mapper"> Mapping model interface</param>
        /// <param name="clientConnection">Client connection  interface</param>
        public BLTriangleProcessing(ILogManager logManager
            , IMapper mapper
             , ICLClientConnection clientConnection
        //     , IDataAnnotationsValidator dataAnnotationsValidator
        )
        {
            _logger = logManager.GetLog(typeof(BLTriangleProcessing)); 
             _mapper = mapper;
            _clientConnection = clientConnection;
            //   _dataAnnotationsValidator = dataAnnotationsValidator;

        }
        #endregion

        #region IBLTriangleProcessing Processing Operations

        /// <summary>
        /// An asynchronous business layer triangle start up information operation,
        /// Obtains triangle start up information from the connection layer 
        /// </summary>
        /// <param name="baseAddress">Connection server url address</param>
        /// <param name="route">Triangle start up information url route</param>
        /// <param name="cancellationToken">Cancellation token to cancel operation</param>
        /// <returns>Business layer start up model if operation successful</returns>
        public async Task<IBLStartUpInfoModel> GetStartInformationAsync(string baseAddress
            , string route
            , CancellationToken? cancellationToken = default(CancellationToken?))
        {
            return await Task.Run(() => GetStartInformation(baseAddress, route, cancellationToken));

        }

        /// <summary>
        /// Business layer triangle start up information operation,
        /// Obtains triangle start up information from the connection layer 
        /// </summary>
        /// <param name="baseAddress">Connection server url address</param>
        /// <param name="route">Triangle start up information url route</param>
        /// <param name="cancellationToken">Cancellation token to cancel operation</param>
        /// <returns>Business layer start up model if operation successful</returns>
        /// <exception cref="JsonException"></exception>
        ///<exception >Auto mapper exception in mapping objects</exception>
        public IBLStartUpInfoModel GetStartInformation(string baseAddress
            , string route
            , CancellationToken? cancellationToken = default(CancellationToken?))
        {
            IBLStartUpInfoModel blStartUp = null;
            var responseMessage = _clientConnection.GetInformation(new Uri(baseAddress), route, "application/json");
            if (responseMessage.IsSuccessStatusCode)
            {
                try
                {
                    var contact = responseMessage.Content.ReadAsAsync<string>().Result;
                    if (string.IsNullOrEmpty(contact))
                    {
                        _logger.Error("GetStartInformation Failed: Empty string return from server");
                    }
                    else
                    {
                        var retVal = JsonConvert .DeserializeObject<ConnectionTriangleStartUpInfoModel>(contact);
                        blStartUp = _mapper.Map<BLTriangleStartUpInfoModel>(retVal);
                    }

                }
                catch (Exception e)
                {
                    _logger.Fatal($"GetStartInformation Exception: {e.Message}", e);
                }
            }
            return blStartUp;
        }

        /// <summary>
        /// An asynchronous business layer triangle vertice information operation,
        /// Obtains triangle vertice  information from the connection layer 
        /// </summary>
        /// <param name="baseAddress">Connection server URL address</param>
        /// <param name="route">Triangle vertice  URL route</param>
        /// <param name="row">Row to obtain triangle vertice information for</param>
        /// <param name="column">Column to obtain triangle vertice information for</param>
        /// <param name="cancellationToken">Cancellation token to cancel operation</param>
        /// <returns>
        /// If operation is successful a list of business layer BLTriangleVerticeModels 
        /// each of which contains an X and Y vertex 
        /// </returns>
        public async Task<IList<IBLTriangleVerticeModel>> GetTriangleVerticesAsync(string baseAddress
            , string route
            ,string row
            ,int column
            , CancellationToken? cancellationToken = default(CancellationToken?))
        {
            return await Task.Run(() => GetTriangleVertices(baseAddress, route, row,column,cancellationToken));
        }

        /// <summary>
        /// Business layer triangle vertice information operation,
        /// Obtains triangle vertice  information from the connection layer 
        /// </summary>
        /// <param name="baseAddress">Connection server URL address</param>
        /// <param name="route">Triangle vertice  URL route</param>
        /// <param name="row">Row to obtain triangle vertice information for</param>
        /// <param name="column">Column to obtain triangle vertice information for</param>
        /// <param name="cancellationToken">Cancellation token to cancel operation</param>
        /// <returns>
        /// If operation is successful a list of business layer BLTriangleVerticeModels 
        /// each of which contains an X and Y vertex 
        /// </returns>
        /// <exception cref="JsonException"></exception>
        /// <exception >Auto mapper exception in mapping objects</exception>
        /// <exception >ReadAsAsync possible exception </exception>

        public IList<IBLTriangleVerticeModel> GetTriangleVertices(string baseAddress
            , string route
            , string row
            , int column
            , CancellationToken? cancellationToken = default(CancellationToken?))
        {
            var urlRoute = String.Format(route, column, row);
            IList < IBLTriangleVerticeModel > blVertices = new List<IBLTriangleVerticeModel>();
            var responseMessage = _clientConnection.GetInformation(new Uri(baseAddress), urlRoute, "application/json");
            if (responseMessage.IsSuccessStatusCode)
            {
                try
                {
                     var contact = responseMessage.Content.ReadAsAsync<string>().Result;
                    if (string.IsNullOrEmpty(contact))
                    {
                        _logger.Error("GetTriangleVertices Failed: Empty string return from server");
                    }
                    else
                    {
                         var retVals = JsonConvert.DeserializeObject<List<ConnectionTriangleVerticeModel>>(contact);
                        foreach (var retVal in retVals)
                        {
                            blVertices.Add(_mapper.Map<BLTriangleVerticeModel>(retVal));
                        }
                    }

                }
                catch (Exception e)
                {
                    _logger.Fatal($"GetTriangleVertices Exception: {e.Message}",e);
                }
  
            }
            return blVertices;
        }
        #endregion
    }
}
