using AutoFixture;
using SFA.DAS.EmployerDemand.Jobs.Infrastructure.Api.Responses;
using System.Net;
using WireMock.Logging;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;
using WireMock.Settings;

namespace SFA.DAS.EmployerDemand.Jobs.FakeServer;

public class OuterApiBuilder
{
    private readonly WireMockServer _server;
    private readonly Fixture _fixture;

    public OuterApiBuilder(int port)
    {
        _server = WireMockServer.Start(new WireMockServerSettings
        {
            Port = port,
            UseSSL = true,
            StartAdminInterface = true,
            Logger = new WireMockConsoleLogger(),
        });

        _fixture = new Fixture();
    }

    public static OuterApiBuilder Create(int port)
        => new OuterApiBuilder(port);

    public OuterApi Build()
        => new OuterApi(_server);

    public OuterApiBuilder CreateEndpoints()
    {
        // AnonymiseOldDemandsTrigger
        _server.Given(Request.Create().WithPath("/demand/older-than-3-years").UsingGet())
                .RespondWith(Response.Create()
                                .WithStatusCode(HttpStatusCode.OK)
                                .WithBodyAsJson(new GetDemandsOlderThan3YearsResponse { EmployerDemandIds = new List<Guid> { Guid.NewGuid() } }));

        _server.Given(Request.Create().WithPath("/demand/*/anonymise").UsingPost())
                .RespondWith(Response.Create()
                                .WithStatusCode(HttpStatusCode.OK)
                                .WithBodyAsJson(_fixture.Create<PostAnonymiseDemandResponse>()));

        // SendAutomaticStopSharingEmailsTimerTrigger
        _server.Given(Request.Create().WithPath("/demand/unmet*").WithParam("demandAgeInDays").UsingGet())
                .RespondWith(Response.Create()
                                .WithStatusCode(HttpStatusCode.OK)
                                .WithBodyAsJson(new GetUnmetDemandResponse { EmployerDemandIds = new List<Guid> { Guid.NewGuid() } }));

        _server.Given(Request.Create().WithPath("/demand/*/send-automatic-stop-sharing-email/*").UsingPost())
                .RespondWith(Response.Create()
                                .WithStatusCode(HttpStatusCode.OK)
                                .WithBodyAsJson(_fixture.Create<PostSendEmailResponse>()));

        // SendCourseStoppedEmailsTimerTrigger
        _server.Given(Request.Create().WithPath("/demand/unmet/expired-course").UsingGet())
                .RespondWith(Response.Create()
                                .WithStatusCode(HttpStatusCode.OK)
                                .WithBodyAsJson(new GetUnmetDemandResponse { EmployerDemandIds = new List<Guid> { Guid.NewGuid() } }));

        _server.Given(Request.Create().WithPath("/demand/*/send-course-stopped-email/*").UsingPost())
                .RespondWith(Response.Create()
                                .WithStatusCode(HttpStatusCode.OK)
                                .WithBodyAsJson(_fixture.Create<PostSendEmailResponse>()));

        // SendCourseStoppedEmailsTimerTrigger
        _server.Given(Request.Create().WithPath("/demand/*/send-reminder-email/*").UsingPost())
                .RespondWith(Response.Create()
                                .WithStatusCode(HttpStatusCode.OK)
                                .WithBodyAsJson(_fixture.Create<PostSendEmailResponse>()));

        return this;
    }
}
