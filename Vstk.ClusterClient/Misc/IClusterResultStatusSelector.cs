using System.Collections.Generic;
using JetBrains.Annotations;
using Vstk.Clusterclient.Model;

namespace Vstk.Clusterclient.Misc
{
    internal interface IClusterResultStatusSelector
    {
        ClusterResultStatus Select([NotNull] IList<ReplicaResult> results, [NotNull] IRequestTimeBudget budget);
    }
}
