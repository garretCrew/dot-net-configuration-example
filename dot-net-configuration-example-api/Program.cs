using dot_net_configuration_example_api.Models;
using dot_net_configuration_example_api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<AppConfigs>();

builder.Services.Configure<AppStaticConfigs>(builder.Configuration.GetSection("AppStaticConfigs"));
builder.Services.Configure<AppDynamicConfigs>(builder.Configuration.GetSection("AppDynamicConfigs"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();