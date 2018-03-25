
namespace WebMvc.Models.TriangleModel
{
    /// <summary>
    /// Index view model which contains triangle start up <see cref="TriangleStartupModel"/>
    /// and vertices <seealso cref="TriangleVerticesModel"/>information.
    /// 
    /// </summary>
    public class TriangleModel
    {
        #region Accessor Properties

        /// <summary>
        /// Index view model which contains triangle start up information
        /// </summary>
        public TriangleStartupModel TriangleStartupModel { get; set; }

        /// <summary>
        /// Index view model which contains triangle vertices information
        /// </summary>
        public TriangleVerticesModel TriangleVerticesModel { get; set; }
        #endregion

    }
}