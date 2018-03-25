using System.Collections.Generic;
using Web.Common.Interfaces.Model;

namespace Business.Layer.Interfaces.Models.Triangle
{
    public interface IBLStartUpInfoModel :IBLModel
    {
         IList<IRowModel> Rows { get; }
         IList<IColumnModel> Columns { get; }
         IList<ILinkModel> Links { get; }
    }
}
