using NoobNoob.eWAN.IdentityServer;

try
{
    var builder = WebApplication.CreateBuilder(args);

    var app = builder
        .ConfigureServices()
        .ConfigurePipeline();

    // this seeding is only for the template to bootstrap the DB and users.
    // in production you will likely want a different approach.
    if (args.Contains("/seed"))
    {
        SeedData.EnsureSeedData(app);
        return;
    }

    app.Run();
}
catch (Exception ex) when
    (ex.GetType().Name is not "StopTheHostException") // https://github.com/dotnet/runtime/issues/60600
{
    Console.WriteLine(ex);
}
finally
{
    Console.WriteLine("Shutdown Complete");
}