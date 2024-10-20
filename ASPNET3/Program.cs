using ASPNET3.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

builder.Services.AddTransient<CalcService,CalcService>();


var app = builder.Build();

app.MapControllers();

app.Run();