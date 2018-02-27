using System.Collections.Generic;
using Vstk.Clusterclient.Model;

namespace Vstk.Clusterclient.Criteria
{
    internal class ResponseClassifier : IResponseClassifier
    {
        public ResponseVerdict Decide(Response response, IList<IResponseCriterion> criteria)
        {
            for (var i = 0; i < criteria.Count; i++)
            {
                var verdict = criteria[i].Decide(response);
                if (verdict != ResponseVerdict.DontKnow)
                    return verdict;
            }

            return ResponseVerdict.DontKnow;
        }
    }
}
