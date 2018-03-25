using System.Collections.Generic;
using Business.Layer.Interfaces.Models.Triangle;
using Web.Common.Interfaces.Model;

namespace Business.Layer.Models.Triangle
{
    /// <summary>
    /// Business layer triangle start up information model <see cref="IBLStartUpInfoModel"/>
    /// Contains column, row, and link information
    /// </summary>
    public class BLTriangleStartUpInfoModel : BLModel
        ,IBLStartUpInfoModel
    {
        #region Accessor Properties
        /// <summary>
        /// List of row information
        /// </summary>
        public IList<IRowModel> Rows { get; }
        /// <summary>
        /// List of column information
        /// </summary>
        public IList<IColumnModel> Columns { get; }
        /// <summary>
        /// Link of link information
        /// </summary>
        public IList<ILinkModel> Links { get; }
        #endregion

        #region Constructors
        /// <summary>
        /// Position constructor
        /// </summary>
        /// <param name="rows">List of row information</param>
        /// <param name="columns">List of column information</param>
        /// <param name="links">List of link information</param>
        public BLTriangleStartUpInfoModel(IList<IRowModel> rows
            , IList<IColumnModel> columns
            , IList<ILinkModel> links)
        {
            Rows = rows;
            Columns = columns;
            Links = links;
        }
        #endregion

    }
}
