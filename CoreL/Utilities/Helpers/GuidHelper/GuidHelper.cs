using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CoreL.Utilities.Helpers.GuidHelper
{
    public class GuidHelper
    {
        public static Guid CreateGuid() => Guid.NewGuid();
    }
}
