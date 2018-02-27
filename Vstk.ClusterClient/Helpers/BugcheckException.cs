using System;

namespace Vstk.Clusterclient.Helpers
{
    internal class BugcheckException : Exception
    {
        public BugcheckException(string message)
            : base(message)
        {
        }
    }
}