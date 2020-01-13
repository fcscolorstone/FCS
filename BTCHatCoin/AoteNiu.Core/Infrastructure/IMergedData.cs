using System.Collections.Generic;

namespace AoteNiu.Core
{
    public interface IMergedData
    {
        bool MergedDataIgnore { get; set; }

        Dictionary<string, object> MergedDataValues { get; }
    }
}
