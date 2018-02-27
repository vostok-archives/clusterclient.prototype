using System;
using System.Diagnostics;
using Vstk.Commons.Utilities;

namespace Vstk.Clusterclient.Model
{
    public class RequestTimeBudget : IRequestTimeBudget
    {
        private readonly Stopwatch watch;

        private RequestTimeBudget(TimeSpan total, TimeSpan precision)
        {
            Total = total;
            Precision = precision;

            watch = new Stopwatch();
            watch.Start();
        }

        public static RequestTimeBudget StartNew(TimeSpan total, TimeSpan precision)
        {
            return new RequestTimeBudget(total, precision);
        }

        public TimeSpan Total { get; }

        public TimeSpan Precision { get; }

        public TimeSpan Elapsed => watch.Elapsed;

        public TimeSpan Remaining => TimeSpanExtensions.Max(TimeSpan.Zero, Total - Elapsed - Precision);

        public bool HasExpired => Remaining <= TimeSpan.Zero;
    }
}