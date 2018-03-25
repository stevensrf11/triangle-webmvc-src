using Business.Layer.Interfaces.Models.Triangle;

namespace Business.Layer.Models.Triangle
{
    /// <summary>
    /// Business layer triangle vertice model <see cref="IBLTriangleVerticeModel"/>
    /// Contains an X and Y vertex for a triangle
    /// </summary>
    public class BLTriangleVerticeModel : BLModel
        ,IBLTriangleVerticeModel
    {
        #region Accessor Properties
        /// <summary>
        /// X vertex
        /// </summary>
        public double XValue { get; set; }
        /// <summary>
        /// Y Vertex
        /// </summary>
        public double YValue { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Position constructor
        /// </summary>
        /// <param name="x">X vertex</param>
        /// <param name="y">Y vertex</param>
        public BLTriangleVerticeModel(double x, double y) 
        {
            XValue = x;
            YValue = y;
        }   
        #endregion

    }
}
