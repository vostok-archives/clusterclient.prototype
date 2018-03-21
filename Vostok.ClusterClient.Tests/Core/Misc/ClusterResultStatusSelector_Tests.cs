using System;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using Vstk.Clusterclient.Misc;
using Vstk.Clusterclient.Model;
using Vstk.ClusterClient.Tests.Helpers;

namespace Vstk.ClusterClient.Tests.Core.Misc
{
    public class ClusterResultStatusSelector_Tests
    {
        private ClusterResultStatusSelector selector;

        [SetUp]
        public void SetUp()
        {
            selector = new ClusterResultStatusSelector();
        }

        [Test]
        public void Should_return_success_status_if_there_is_at_least_one_accepted_result()
        {
            var status = selector.Select(Group(Result(ResponseVerdict.Reject), Result(ResponseVerdict.Accept)), Budget.Infinite);

            status.Should().Be(ClusterResultStatus.Success);
        }

        [Test]
        public void Should_return_replicas_exhausted_status_if_there_are_no_accepted_results()
        {
            var status = selector.Select(Group(Result(ResponseVerdict.Reject), Result(ResponseVerdict.Reject)), Budget.Infinite);

            status.Should().Be(ClusterResultStatus.ReplicasExhausted);
        }

        [Test]
        public void Should_return_replicas_exhausted_status_if_there_are_no_accepted_results_and_time_budget_has_expired()
        {
            var status = selector.Select(Group(Result(ResponseVerdict.Reject), Result(ResponseVerdict.Reject)), Budget.Expired);

            status.Should().Be(ClusterResultStatus.TimeExpired);
        }

        private IList<ReplicaResult> Group(params ReplicaResult[] results)
        {
            return results;
        }

        private ReplicaResult Result(ResponseVerdict verdict)
        {
            return new ReplicaResult(new Uri("http://replica"), new Response(ResponseCode.NotFound), verdict, TimeSpan.Zero);
        }
    }
}
