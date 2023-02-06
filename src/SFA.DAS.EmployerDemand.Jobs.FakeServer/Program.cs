using SFA.DAS.EmployerDemand.Jobs.FakeServer;

OuterApiBuilder.Create(5003)
       .CreateEndpoints()
       .Build();

Console.WriteLine("Press any key to stop the server");
Console.ReadKey();
