using System.Collections.Generic;

namespace WebMvc.Models.TriangleModel
{
    /// <summary>
    /// Index<see cref="TriangleModel"/> and Vertices view models 
    /// </summary>
    public class TriangleVerticesModel
    {
        /// <summary>
        /// List of vertices for a triangle
        /// </summary>
        public IList<VerticeModel> Vertices { get; set; }
    }
}