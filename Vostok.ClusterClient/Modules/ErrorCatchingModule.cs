using System;
using System.Threading.Tasks;
using Vstk.Clusterclient.Model;
using Vstk.Logging;

namespace Vstk.Clusterclient.Modules
{
    internal class ErrorCatchingModule : IRequestModule
    {
        public async Task<ClusterResult> ExecuteAsync(IRequestContext context, Func<IRequestContext, Task<ClusterResult>> next)
        {
            try
            {
                return await next(context).ConfigureAwait(false);
            }
            catch (OperationCanceledException)
            {
                return ClusterResult.Canceled(context.Request);
            }
            catch (Exception error)
            {
                context.Log.Error("Unexpected failure during request execution.", error);
                return ClusterResult.UnexpectedException(context.Request);
            }
        }
    }
}
