using System.Linq;
using AutoMapper;
using Business.Layer.Models.Triangle;
using WebMvc.Models.TriangleModel;

namespace WebMvc.AutoMapperConfiguration
{

    /// <summary>
    /// Mapping for converting <see cref="BLTriangleStartUpInfoModel"/> model object into an <see cref="TriangleStartupModel"/> object
    /// </summary>
    public class BLTriangleStartupModelProfile : Profile
    {
        #region Constructors
        /// <summary>
        /// Default constructor
        /// </summary>
        public BLTriangleStartupModelProfile()
        {
            CreateMap<BLTriangleStartUpInfoModel, TriangleStartupModel>()
           .ConstructUsing(x => new TriangleStartupModel(x.Rows.Select(row => row.RowValue).ToList()
                , x.Columns.Select(col => col.ColumnValue).ToList(), @"~/images/verticechart.png"));

        }
        #endregion
    }
}