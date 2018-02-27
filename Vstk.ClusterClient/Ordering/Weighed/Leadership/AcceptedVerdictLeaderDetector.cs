using Vstk.Clusterclient.Model;

namespace Vstk.Clusterclient.Ordering.Weighed.Leadership
{
    /// <summary>
    /// Represents a leader result detector which accepts any result with <see cref="ResponseVerdict.Accept"/> verdict.
    /// </summary>
    public class AcceptedVerdictLeaderDetector : ILeaderResultDetector
    {
        public bool IsLeaderResult(ReplicaResult result)
        {
            return result.Verdict == ResponseVerdict.Accept;
        }
    }
}