using AutoMapper;
using Business.Layer.Model;
using Business.Layer.Models.Triangle;

namespace WebMvc.AutoMapperConfiguration
{
    /// <summary>
    /// Mapping for converting <see cref="ConnectionTriangleVerticeModel"/> model object into an <see cref="BLTriangleVerticeModel"/> object
    /// </summary>
    public class ConnectionBLTriangleVerticeModelProfile : Profile
    {
        #region Constructors
        /// <summary>
        /// Default constructor
        /// </summary>
        public ConnectionBLTriangleVerticeModelProfile()
        {
            CreateMap<ConnectionTriangleVerticeModel, BLTriangleVerticeModel>()
                .ConstructUsing(x => new BLTriangleVerticeModel(x.XValue, x.YValue));
        }
        #endregion

    }
}