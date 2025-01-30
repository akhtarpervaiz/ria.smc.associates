using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ria.smc.associates.Common.CommonLayerHelper
{
    public static class CommonHelper
    {
        public static string NewGuidId(this Guid guid) => guid.ToString().ToUpper().Replace("-", string.Empty);
    }
}
