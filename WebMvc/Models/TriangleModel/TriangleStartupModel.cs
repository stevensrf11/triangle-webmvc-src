using System.Collections.Generic;
using System.ComponentModel;
using System.Web.Mvc;

namespace WebMvc.Models.TriangleModel
{
    /// <summary>
    /// Index view model<see cref="TriangleModel"/> which contains triangle start up information.
    /// </summary>
    public class TriangleStartupModel
    {
        #region Accessor Properties
        /// <summary>
        /// Row selections
        /// </summary>
        [DisplayName("Rows")]
        public SelectList RowItems { get; set; }

        /// <summary>
        /// Column selections
        /// </summary>
        [DisplayName("Columns")]
        public SelectList ColumItems { get; set; }

        /// <summary>
        /// Image location of triangle
        /// </summary>
        public string ImageLocatiom {get;set;}
        #endregion


        #region Constructors

        /// <summary>
        /// Position Constructor
        /// </summary>
        /// <param name="rows">Row selections</param>
        /// <param name="columns"> Column Selections</param>
        /// <param name="imageLocation">Image location of triangle image</param>
        public TriangleStartupModel(IList<string> rows, IList<int> columns, string imageLocation)
        {
            RowItems=new SelectList(rows,rows[0]);
            ColumItems = new SelectList(columns, columns[0]);
            ImageLocatiom = imageLocation;
        }
        #endregion
    }
}