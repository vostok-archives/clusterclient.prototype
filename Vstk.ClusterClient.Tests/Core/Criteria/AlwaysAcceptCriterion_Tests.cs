﻿using System;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using Vstk.Clusterclient.Criteria;
using Vstk.Clusterclient.Model;

namespace Vstk.ClusterClient.Tests.Core.Criteria
{
    public class AlwaysAcceptCriterion_Tests
    {
        [Test]
        public void Should_accept_all_response_codes()
        {
            var criterion = new AlwaysAcceptCriterion();

            var codes = Enum.GetValues(typeof (ResponseCode)).Cast<ResponseCode>();

            foreach (var code in codes)
            {
                criterion.Decide(new Response(code)).Should().Be(ResponseVerdict.Accept);
            }
        }
    }
}
