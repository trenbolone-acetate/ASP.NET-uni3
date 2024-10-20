using ASPNET3;
using ASPNET3.Models;
using ASPNET3.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
//1
builder.Services.AddTransient<CalcService>();

//2
builder.Services.AddTransient<ITimeAnalyzerService,TimeAnalyzerService>();

//LB4
builder.Configuration.AddJsonFile("Properties/dataFile.json", optional: false, reloadOnChange: true);
builder.Services.Configure<List<Book>>(
    builder.Configuration.GetSection("booksTable"));
builder.Services.Configure<List<Profile>>(
    builder.Configuration.GetSection("profiles"));

builder.Services.AddTransient<Repositories>();
builder.Services.AddTransient<LibraryService>();


var app = builder.Build();

app.MapControllers();

app.Run();