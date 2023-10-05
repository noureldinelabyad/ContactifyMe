using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalContactInformation.Library.Models
{
    public enum UpdateStrategy  //This is for the JSON input function, in case of duplicates
    {
        Skip = 0,
        MergeSkip = 1,      // when choosing this, old data will be preserved, additional numbers will be added
        MergeReplace = 2,   // when choosing this, old data will be overridden, numbers work the same way as above
        Replace = 3
    }
}
