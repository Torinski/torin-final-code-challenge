using LaunchpadCodeChallenge.API.Services;
using LaunchpadCodeChallenge.API.Services.Interfaces;

void ConfigureServices(WebApplicationBuilder builder)
{
    builder.Services.AddControllers(); 
    builder.Services.AddScoped<IEmployeeService, EmployeeService>();
}

void ConfigurePipeline(WebApplication app)
{
    if (!app.Environment.IsProduction())
    {
        app.UseDefaultFiles();
        app.UseStaticFiles();
    }

    //app.UseAuthorization();
    app.MapControllers();
}

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

ConfigureServices(builder);

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

ConfigurePipeline(app);

app.Run();
