using System;
using System.Threading.Tasks;
using Vstk.Clusterclient.Model;
using Vstk.Commons.Model;

namespace Vstk.Clusterclient.Modules
{
    internal class RequestPriorityApplicationModule : IRequestModule
    {
        public Task<ClusterResult> ExecuteAsync(IRequestContext context, Func<IRequestContext, Task<ClusterResult>> next)
        {
            if (context.Priority.HasValue)
                RequestPriorityContext.Current = context.Priority;

            return next(context);
        }
    }
}