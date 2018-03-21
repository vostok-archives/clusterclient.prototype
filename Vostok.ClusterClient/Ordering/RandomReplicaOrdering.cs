using System.Collections.Generic;
using Vstk.Clusterclient.Ordering.Weighed;

namespace Vstk.Clusterclient.Ordering
{
    /// <summary>
    /// Represents an ordering which returns replicas in random order.
    /// </summary>
    public class RandomReplicaOrdering : WeighedReplicaOrdering
    {
        public RandomReplicaOrdering()
            : base (new List<IReplicaWeightModifier>())
        {
        }
    }
}
