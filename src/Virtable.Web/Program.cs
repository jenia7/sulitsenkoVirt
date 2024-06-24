using Autofac;
using Autofac.Extensions.DependencyInjection;
using Serilog;
using Serilog.Extensions.Logging;
using Virtable.Infrastructure;
using Virtable.Infrastructure.Data;
using Virtable.UseCases;

var logger = Log.Logger = new LoggerConfiguration()
  .Enrich.FromLogContext()
  .WriteTo.Console()
  .CreateLogger();

logger.Information("Starting web host");

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("LocalDb");
builder.Services.AddSqlServer<AppDbContext>(connectionString, builder =>
{
    builder.MigrationsAssembly("Virtable.Infrastructure");
});

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
{
    builder.RegisterModule<InfrastructureModule>();
    builder.RegisterModule<UseCasesModule>();
});

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Host.UseSerilog((_, config) => config.ReadFrom.Configuration(builder.Configuration));
var microsoftLogger = new SerilogLoggerFactory(logger)
    .CreateLogger<Program>();

builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.CheckConsentNeeded = context => true;
    options.MinimumSameSitePolicy = SameSiteMode.None;
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();

    using var scope = app.Services.CreateScope();
    SeedData.EnsureDbPopulated(scope.ServiceProvider);
}
else
{
    app.UseHsts();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();

// Make the implicit Program.cs class public, so integration tests can reference the correct assembly for host building
public partial class Program
{
}
