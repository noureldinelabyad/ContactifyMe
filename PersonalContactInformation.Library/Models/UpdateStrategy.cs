using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalContactInformation.Library.Models
{
    public enum UpdateStrategy  // If there are duplicates from JSON-input, defines how they are handled
    {
        Skip = 0,
        MergeSkip = 1,
        MergeReplace = 2,
        Replace = 3
    }
}
