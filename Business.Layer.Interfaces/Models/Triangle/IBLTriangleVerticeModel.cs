using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Layer.Interfaces.Models.Triangle
{
    public interface IBLTriangleVerticeModel :IBLModel
    {
         double XValue { get; set; }
         double YValue { get; set; }

    }
}
