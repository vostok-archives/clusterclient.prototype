using System.Collections.Generic;
using JetBrains.Annotations;
using Vstk.Clusterclient.Model;

namespace Vstk.Clusterclient.Criteria
{
    internal interface IResponseClassifier
    {
        [Pure]
        ResponseVerdict Decide([NotNull] Response response, [NotNull] IList<IResponseCriterion> criteria);
    }
}
