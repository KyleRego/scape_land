using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using ScapeLand.Data;
using ScapeLand.Services;

var builder = WebApplication.CreateBuilder(args);
string clientAppOrigin = builder.Configuration
                                .GetValue<string>("ClientAppOrigin")
        ?? throw new InvalidOperationException("No client origin config");

string corsPolicyName = "AllowClientApp";

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
// services
builder.Services.AddScoped<IPromptService, PromptService>();
builder.Services.AddScoped<IOptionService, OptionService>();
// repository
builder.Services.AddScoped<IPromptRepository, PromptRepository>();
builder.Services.AddScoped<IOptionRepository, OptionRepository>();
builder.Services.AddScoped<IOptionResultRepository, OptionResultRepository>();

builder.Services.AddAutoMapper(typeof(Program));

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

var connection = new SqliteConnection("DataSource=:memory:");
connection.Open();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(connection)
);

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

app.MapControllers();
app.Run();
