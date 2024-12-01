using Projects;

var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Pillars>("Pillars");

builder.Build().Run();
