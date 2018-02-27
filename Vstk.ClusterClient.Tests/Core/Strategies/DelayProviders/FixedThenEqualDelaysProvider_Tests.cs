﻿using FluentAssertions;
using NUnit.Framework;
using Vstk.Clusterclient.Model;
using Vstk.Clusterclient.Strategies.DelayProviders;
using Vstk.ClusterClient.Tests.Helpers;

namespace Vstk.ClusterClient.Tests.Core.Strategies.DelayProviders
{
    public class FixedThenEqualDelaysProvider_Tests
    {
        [Test]
        public void Should_return_fixed_delays_first_and_then_use_equal_division()
        {
            var provider = new FixedThenEqualDelaysProvider(3, 20.Seconds(), 12.Seconds(), 17.Seconds());
            var budget = Budget.WithRemaining(600.Seconds());
            var request = Request.Get("/foo");

            provider.GetForkingDelay(request, budget, 0, 10).Should().Be(20.Seconds());
            provider.GetForkingDelay(request, budget, 1, 10).Should().Be(12.Seconds());
            provider.GetForkingDelay(request, budget, 2, 10).Should().Be(17.Seconds());
            provider.GetForkingDelay(request, budget, 3, 10).Should().Be(200.Seconds());
            provider.GetForkingDelay(request, budget, 4, 10).Should().Be(200.Seconds());
            provider.GetForkingDelay(request, budget, 5, 10).Should().Be(200.Seconds());
            provider.GetForkingDelay(request, budget, 6, 10).Should().Be(200.Seconds());
        }
    }
}