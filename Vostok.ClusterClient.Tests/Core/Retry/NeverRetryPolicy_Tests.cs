using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using Vstk.Clusterclient.Model;
using Vstk.Clusterclient.Retry;

namespace Vstk.ClusterClient.Tests.Core.Retry
{
    public class NeverRetryPolicy_Tests
    {
        private NeverRetryPolicy policy;

        [SetUp]
        public void SetUp()
        {
            policy = new NeverRetryPolicy();
        }

        [Test]
        public void NeedToRetry_should_always_return_false()
        {
            policy.NeedToRetry(new List<ReplicaResult>()).Should().BeFalse();
        }
    }
}
