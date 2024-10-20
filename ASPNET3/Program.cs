using ASPNET3.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
//1
builder.Services.AddTransient<CalcService,CalcService>();

//2
builder.Services.AddTransient<ITimeAnalyzerService,TimeAnalyzerService>();


var app = builder.Build();

app.MapControllers();

app.Run();