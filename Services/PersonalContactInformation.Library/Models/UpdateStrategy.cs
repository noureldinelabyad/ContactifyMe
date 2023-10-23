using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalContactInformation.Library.Models
{
    /// <summary>
    /// If there are duplicates from a JSON-inputfile, this defines how they are handled
    /// </summary>
    public enum UpdateStrategy
    {
        Skip = 0,
        MergeSkip = 1,
        MergeReplace = 2,
        Replace = 3
    }
}
