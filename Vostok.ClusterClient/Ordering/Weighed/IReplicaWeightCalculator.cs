using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Vstk.Clusterclient.Model;
using Vstk.Clusterclient.Ordering.Storage;

namespace Vstk.Clusterclient.Ordering.Weighed
{
    internal interface IReplicaWeightCalculator
    {
        double GetWeight(
            [NotNull] Uri replica, 
            [NotNull] IList<Uri> allReplicas, 
            [NotNull] IReplicaStorageProvider storageProvider, 
            [NotNull] Request request);
    }
}
