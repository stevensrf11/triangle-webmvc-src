using System;
using AutoMapper;
using Business.Layer.Models.Triangle;
using WebMvc.Models;

namespace WebMvc.AutoMapperConfiguration
{
    /// <summary>
    /// Mapping for converting <see cref="BLTriangleVerticeModel"/> model object into an <see cref="VerticeModel"/> object
    /// </summary>
    public class BLTriangleVerticeModelProfile : Profile
    {
        #region Constructors
        /// <summary>
        /// Default constructor
        /// </summary>
        public BLTriangleVerticeModelProfile()
        {
            CreateMap<BLTriangleVerticeModel, VerticeModel>()
            .DisableCtorValidation()
                .ForMember(f => f.X, o => o.ResolveUsing(b =>{ return Convert.ToInt32(b.XValue).ToString();} ))
                .ForMember(f => f.Y, o => o.ResolveUsing(b => { return Convert.ToInt32(b.YValue).ToString(); }));

        }
        #endregion
    }
}