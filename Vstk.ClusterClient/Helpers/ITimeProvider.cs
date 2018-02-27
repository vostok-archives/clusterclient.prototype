using System;

namespace Vstk.Clusterclient.Helpers
{
    internal interface ITimeProvider
    {
        DateTime GetCurrentTime();
    }
}
