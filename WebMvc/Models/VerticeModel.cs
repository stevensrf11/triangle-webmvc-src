using System.ComponentModel;

namespace WebMvc.Models
{
    /// <summary>
    /// Triangle vertex model
    /// </summary>
    public class VerticeModel
    {
        /// <summary>
        /// X vertex position
        /// </summary>
        [DisplayName("X Vertice")]
        public string X { get; set; }
        /// <summary>
        /// Y vertex position
        /// </summary>
        [DisplayName("Y Vertice")]
        public string Y { get; set; }

    }
}