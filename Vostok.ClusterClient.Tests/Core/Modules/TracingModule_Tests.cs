using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using Vstk.Clusterclient.Model;
using Vstk.Clusterclient.Modules;
using Vstk.Clusterclient.Strategies;
using Vstk.Tracing;

namespace Vstk.ClusterClient.Tests.Core.Modules
{
    public class TracingModule_Tests
    {
        private TracingModule tracingModule;
        private ITraceReporter traceReporter;

        [SetUp]
        public void SetUp()
        {
            traceReporter = Substitute.For<ITraceReporter>();
            Trace.Configuration.Reporter = traceReporter;
            tracingModule = new TracingModule("serviceName");
        }

        [Test]
        public async Task ExecuteAsync_should_create_trace()
        {
            var requestContext = Substitute.For<IRequestContext>();
            var request = new Request("GET", new Uri("vstk/process?p1=p", UriKind.Relative));
            requestContext.Request.Returns(request);
            requestContext.Strategy.Returns(new ParallelRequestStrategy(2));
            var response = new Response(ResponseCode.Conflict);
            var clusterResult = new ClusterResult(ClusterResultStatus.Success, new List<ReplicaResult>(), response, request);
            var expectedAnnotations = new Dictionary<string, string>
            {
                [TracingAnnotationNames.Kind] = "cluster-client",
                [TracingAnnotationNames.Component] = "cluster-client",
                [TracingAnnotationNames.ClusterStrategy] = "Parallel-2",
                [TracingAnnotationNames.ClusterStatus] = "Success",
                [TracingAnnotationNames.HttpUrl] = "vstk/process",
                [TracingAnnotationNames.HttpMethod] = "GET",
                [TracingAnnotationNames.HttpRequestContentLength] = "0",
                [TracingAnnotationNames.HttpResponseContentLength] = "0",
                [TracingAnnotationNames.HttpCode] = "409",
                [TracingAnnotationNames.Service] = "serviceName"
            };
            traceReporter.SendSpan(Arg.Do<Span>(span =>
            {
                span.Annotations.ShouldBeEquivalentTo(expectedAnnotations);
            }));

            await tracingModule.ExecuteAsync(requestContext, x => Task.FromResult(clusterResult)).ConfigureAwait(false);

            traceReporter.Received().SendSpan(Arg.Any<Span>());
        }
    }
}