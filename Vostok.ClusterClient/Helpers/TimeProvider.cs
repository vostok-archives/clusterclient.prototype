using System;

namespace Vstk.Clusterclient.Helpers
{
    internal class TimeProvider : ITimeProvider
    {
        public DateTime GetCurrentTime()
        {
            return DateTime.UtcNow;
        }
    }
}
