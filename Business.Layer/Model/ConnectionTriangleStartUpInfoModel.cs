using System.Collections.Generic;
using Web.Common.Models;

namespace Business.Layer.Model
{
    /// <summary>
    /// Triangle startup model used for storing information at the connection level.
    /// </summary>
    public class ConnectionTriangleStartUpInfoModel
    {
        #region Accessor Properties
        /// <summary>
        /// List to row  information  <see cref="RowModel"/>
        /// </summary>
        public IList<RowModel> Rows { get; }

        /// <summary>
        /// List of column information  <see cref="ColumnModel"/>
        /// </summary>
        public IList<ColumnModel> Columns { get; }

        /// <summary>
        ///  List of link information <see cref="LinkModel"/>
        /// </summary>
        public IList<LinkModel> Links { get; }
        #endregion

        #region Constructor

        // [JsonConstructor]
        /// <summary>
        /// Position Constructor
        /// </summary>
        /// <param name="rows">List of row information</param>
        /// <param name="columns">List of column information</param>
        /// <param name="links">List of link information</param>
        public ConnectionTriangleStartUpInfoModel(IList<RowModel> rows
            , IList<ColumnModel> columns
            , IList<LinkModel> links)
        {
            Rows = rows;
            Columns = columns;
            Links = links;
        }
        #endregion

    }
}
