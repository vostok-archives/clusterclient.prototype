using System.Threading;
using JetBrains.Annotations;
using Vstk.Clusterclient.Model;
using Vstk.Clusterclient.Strategies;
using Vstk.Commons.Model;
using Vstk.Logging;

namespace Vstk.Clusterclient.Modules
{
    /// <summary>
    /// Represents a context of currently executed request.
    /// </summary>
    public interface IRequestContext
    {
        /// <summary>
        /// Returns request which is being sent.
        /// </summary>
        [NotNull]
        Request Request { get; set; }

        /// <summary>
        /// Returns used request strategy.
        /// </summary>
        [NotNull]
        IRequestStrategy Strategy { get; }

        /// <summary>
        /// Returns request time budget. Use <see cref="IRequestTimeBudget.Remaining"/> method to check remaining time.
        /// </summary>
        [NotNull]
        IRequestTimeBudget Budget { get; }

        /// <summary>
        /// Returns an <see cref="ILog"/> instance intended for use in custom modules.
        /// </summary>
        [NotNull]
        ILog Log { get; }

        /// <summary>
        /// Returns a cancellation token used for request.
        /// </summary>
        CancellationToken CancellationToken { get; }

        /// <summary>
        /// Returns used request priority.
        /// </summary>
        [CanBeNull]
        RequestPriority? Priority { get; }

        /// <summary>
        /// Gets or sets the maximum count of replicas a request may use.
        /// </summary>
        int MaximumReplicasToUse { get; set; }
    }
}
