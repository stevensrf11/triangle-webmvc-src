using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Business.Layer.Interfaces.Models.Triangle;

namespace Business.Layer.Interfaces.Processing.Triangle
{
    /// <summary>
    /// Business Layer Triangle Processing  interface <see cref="IBLProcessing"/>.
    /// Contains operations that pertain to triangle actions
    /// </summary>
    public interface IBLTriangleProcessing : IBLProcessing
    {
        /// <summary>
        /// A task business layer triangle start up information operation,
        /// Obtains triangle start up information from the connection layer 
        /// </summary>
        /// <param name="baseAddress">Connection server url address</param>
        /// <param name="route">Triangle start up information url route</param>
        /// <param name="cancellationToken">Cancellation token to cancel operation</param>
        /// <returns>Business layer start up model </returns>
        /// <history>
        /// </history>      
        Task<IBLStartUpInfoModel> GetStartInformationAsync(string baseAddress
            , string route
            , CancellationToken? cancellationToken = null);

        /// <summary>
        /// Business layer triangle start up information operation,
        /// Obtains triangle start up information from the connection layer 
        /// </summary>
        /// <param name="baseAddress">Connection server url address</param>
        /// <param name="route">Triangle start up information url route</param>
        /// <param name="cancellationToken">Cancellation token to cancel operation</param>
        /// <returns>Business layer start up model </returns>
        IBLStartUpInfoModel GetStartInformation(string baseAddress
            , string route
            , CancellationToken? cancellationToken = null);

        /// <summary>
        ///  Business layer triangle vertice information operation,
        /// Obtains triangle vertice  information from the connection layer 
        /// </summary>
        /// <param name="baseAddress">Connection server URL address</param>
        /// <param name="route">Triangle vertice  URL route</param>
        /// <param name="row">Row to obtain triangle vertice information for</param>
        /// <param name="column">Column to obtain triangle vertice information for</param>
        /// <param name="cancellationToken">Cancellation token to cancel operation</param>
        /// <returns>
        /// A list of business layer BLTriangleVerticeModels each of which contains an X and Y vertex 
        /// </returns>
        IList<IBLTriangleVerticeModel> GetTriangleVertices(string baseAddress
            , string route
            , string row
            , int column
            , CancellationToken? cancellationToken = null);

        /// <summary>
        /// An task business layer triangle vertice information operation,
        /// Obtains triangle vertice  information from the connection layer 
        /// </summary>
        /// <param name="baseAddress">Connection server URL address</param>
        /// <param name="route">Triangle vertice  URL route</param>
        /// <param name="row">Row to obtain triangle vertice information for</param>
        /// <param name="column">Column to obtain triangle vertice information for</param>
        /// <param name="cancellationToken">Cancellation token to cancel operation</param>
        /// <returns>
        /// A list of business layer BLTriangleVerticeModels each of which contains an X and Y vertex 
        /// </returns>
        Task<IList<IBLTriangleVerticeModel>> GetTriangleVerticesAsync(string baseAddress
            , string route
            , string row
            , int column
            , CancellationToken? cancellationToken = null);
    }
}
