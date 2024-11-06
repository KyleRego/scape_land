using Microsoft.EntityFrameworkCore;
using ScapeLand.Data;
using ScapeLand.Services;
using ScapeLand.Model;

var builder = WebApplication.CreateBuilder(args);
string clientAppOrigin = builder.Configuration
                                .GetValue<string>("ClientAppOrigin")
        ?? throw new InvalidOperationException("No client origin config");

string corsPolicyName = "AllowClientApp";
string dbConn = builder.Configuration.GetValue<string>("DbConn")
        ?? throw new InvalidOperationException("No db connection string");

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy(corsPolicyName, policy =>
    {
        policy.WithOrigins(clientAppOrigin)
              .AllowAnyMethod()
              .AllowAnyHeader()
              .AllowCredentials();
    });
});

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(dbConn)
);

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddHostedService<GameOrchestrator>();
builder.Services.AddSingleton<GameState>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}

app.UseHttpsRedirection();
app.UseCors(corsPolicyName);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/", context =>
{
    context.Response.Redirect("/swagger");
    return Task.CompletedTask;
});

app.MapControllers();
app.Run();
