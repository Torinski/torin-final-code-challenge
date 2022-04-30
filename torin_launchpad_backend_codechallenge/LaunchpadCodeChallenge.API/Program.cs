using LaunchpadCodeChallenge.API.Repositories;
using LaunchpadCodeChallenge.API.Services;
using LaunchpadCodeChallenge.API.Services.Interfaces;

void ConfigureServices(WebApplicationBuilder builder)
{
    builder.Services.AddControllers();

    // Add to configuration if database was implemented:
    // Would also need to add NuGet packages to support this database.

    //builder.Services.AddDbContext<ApplicationDbContext>(options =>
    //    options.UseNpgsql(
    //        builder.Configuration.GetConnectionString("DefaultConnection"),
    //        b =>
    //        {
    //            b.MigrationsAssembly("LaunchpadCodeChallenge.API.Repositories");
    //        })
    //    );

    // Code to allow program to run without full database implementation:
    builder.Services.AddDbContext<ApplicationDbContext>();

    // Dependency injection
    builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
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

/* To add on database implementation:
 * 
// Migration on startup information
void ExecuteMigrations(WebApplication app)
{
    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;

        var context = services.GetService<ApplicationDbContext>();
        context.Database.Migrate();
    }
}
*/

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

ConfigureServices(builder);

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

ConfigurePipeline(app);

app.Run();
