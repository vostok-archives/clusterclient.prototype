using System;
using System.Collections.Generic;
using Vstk.Clusterclient.Model;
using Vstk.Clusterclient.Ordering.Storage;

namespace Vstk.Clusterclient.Ordering
{
    /// <summary>
    /// Represents an ordering which never changes replicas order.
    /// </summary>
    public class AsIsReplicaOrdering : IReplicaOrdering
    {
        public IEnumerable<Uri> Order(IList<Uri> replicas, IReplicaStorageProvider storageProvider, Request request)
        {
            return replicas;
        }

        public void Learn(ReplicaResult result, IReplicaStorageProvider storageProvider)
        {
        }
    }
}
