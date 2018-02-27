using System;
using JetBrains.Annotations;
using Vstk.Clusterclient.Model;

namespace Vstk.Clusterclient.Sending
{
    internal interface IRequestConverter
    {
        [CanBeNull]
        Request TryConvertToAbsolute([NotNull] Request relativeRequest, [NotNull] Uri replica);
    }
}
