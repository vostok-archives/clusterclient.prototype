using System;
using Vstk.Clusterclient.Model;

namespace Vstk.Clusterclient.Transforms
{
    /// <summary>
    /// Represents a request transform which uses external delegate to modify requests.
    /// </summary>
    public class AdHocRequestTransform : IRequestTransform
    {
        private readonly Func<Request, Request> transform;

        public AdHocRequestTransform(Func<Request, Request> transform)
        {
            this.transform = transform;
        }

        public Request Transform(Request request)
        {
            return transform(request);
        }
    }
}
