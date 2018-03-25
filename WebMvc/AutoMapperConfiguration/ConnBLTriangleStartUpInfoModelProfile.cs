using AutoMapper;
using Business.Layer.Model;
using Business.Layer.Models.Triangle;

namespace WebMvc.AutoMapperConfiguration
{
    /// <summary>
    /// Mapping for converting <see cref="ConnectionTriangleStartUpInfoModel"/> model object into an <see cref="BLTriangleStartUpInfoModel"/> object
    /// </summary>
    public class ConnBLTriangleStartUpInfoModelProfile : Profile
    {
        #region Constructors
        /// <summary>
        /// Default constructor
        /// </summary>
        public ConnBLTriangleStartUpInfoModelProfile()
        {
            CreateMap<ConnectionTriangleStartUpInfoModel, BLTriangleStartUpInfoModel>()
                .ForMember(dest => dest.Rows, expression => expression.MapFrom(src => src.Rows))
                .ForMember(dest => dest.Columns, expression => expression.MapFrom(src => src.Columns))
                .ForMember(dest => dest.Links, expression => expression.MapFrom(src => src.Links));
        }
        #endregion
    }
}