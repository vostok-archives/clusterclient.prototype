﻿using JetBrains.Annotations;
using Vstk.Clusterclient.Model;

namespace Vstk.Clusterclient.Ordering.Weighed.Leadership
{
    public interface ILeaderResultDetector
    {
        /// <summary>
        /// <para>Returns <c>true</c> if given <paramref name="result"/> definitely belongs to a leader of cluster, or <c>false otherwise</c>.</para>
        /// <para>See <see cref="LeadershipWeightModifier"/> for more details about assumed leader-reservist model.</para>
        /// </summary>
        [Pure]
        bool IsLeaderResult([NotNull] ReplicaResult result);
    }
}