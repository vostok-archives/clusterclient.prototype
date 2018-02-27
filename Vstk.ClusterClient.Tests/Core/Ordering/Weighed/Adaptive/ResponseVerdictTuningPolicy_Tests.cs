﻿using System;
using FluentAssertions;
using NUnit.Framework;
using Vstk.Clusterclient.Model;
using Vstk.Clusterclient.Ordering.Weighed.Adaptive;

namespace Vstk.ClusterClient.Tests.Core.Ordering.Weighed.Adaptive
{
    public class ResponseVerdictTuningPolicy_Tests
    {
        private ResponseVerdictTuningPolicy policy;

        [SetUp]
        public void SetUp()
        {
            policy = new ResponseVerdictTuningPolicy();
        }

        
        [TestCase(ResponseVerdict.Accept, AdaptiveHealthAction.Increase)]
        [TestCase(ResponseVerdict.Reject, AdaptiveHealthAction.Decrease)]
        [TestCase(ResponseVerdict.DontKnow, AdaptiveHealthAction.DontTouch)]
        public void Should_return_correct_action_for_given_response_verdict(ResponseVerdict verdict, AdaptiveHealthAction action)
        {
            var result = new ReplicaResult(new Uri("http://replica"), Responses.Timeout, verdict, TimeSpan.Zero);

            policy.SelectAction(result).Should().Be(action);
        }
    }
}
