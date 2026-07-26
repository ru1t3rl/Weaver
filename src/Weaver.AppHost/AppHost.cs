using Weaver.AppHost;

var builder = DistributedApplication.CreateBuilder(args);
var composeEnv = builder.AddDockerComposeEnvironment("compose");

// var cache = builder.AddRedis("cache");

var postgres = builder
    .AddPostgres("postgres")
    .WithDbGate()
    .WithDataVolume()
    .WithLifetime(ContainerLifetime.Persistent)
    .WithHostPort(5432);

var database = postgres
    .AddDatabase("Weaver");

var apiService = builder
    .AddProject<Projects.Weaver_WebApi>("webapi")
    .WithHttpHealthCheck("/health")
    .WithReference(database)
    .WithMigrator<Projects.Weaver_Migrator>(database);

var dockerEngineHost = builder.AddParameter("DockerEngineHost", secret: false);
var dockerApiService = builder
    .AddProject<Projects.Weaver_Docker_WebApi>("docker-webapi")
    .WithEnvironment("DockerEngine__Host", dockerEngineHost)
    .WithHttpHealthCheck("/health")
    .WithUrlForEndpoint(
        "http",
        url => { url.Url = "/docs"; }
    );

var appEnvPrefix = builder.AddParameter("AppEnvPrefix", secret: false);

builder
    .AddViteApp("webapp-vite", "../Weaver.WebApp", "dev")
    .WithApiClientGenerator("../Weaver.WebApp/packages/shared/", displayName: "Generate WebApi Client")
    .WithApiClientGenerator("../Weaver.WebApp/packages/docker/", displayName: "Generate Docker Api Client")
    .WithBun()
    .WaitFor(apiService)
    .WithReference(apiService)
    .WaitFor(dockerApiService)
    .WithReference(dockerApiService)
    .WithEnvironment("VITE_API_ADDRESS", apiService.GetEndpoint("http"))
    .WithEnvironment("VITE_DOCKER_API_ADDRESS", dockerApiService.GetEndpoint("http"))
    .WithEnvironment("APP_ENV_PREFIX", appEnvPrefix)
    .WithHttpEndpoint(4200, env: "PORT")
    .WithExternalHttpEndpoints()
    .PublishAsDockerFile();

builder.Build().Run();