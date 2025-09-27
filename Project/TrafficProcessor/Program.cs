using Serilog;
using Serilog.Events;
using TrafficProcessor.Interface;
using TrafficProcessor.Repository;
using TrafficProcessor.Service;
using TrafficProcessor.Util;

// Serilog 설정
Log.Logger = new LoggerConfiguration()
    .WriteTo.File(new Serilog.Formatting.Json.JsonFormatter(), "C:\\/logs/traffic-.json", 
        rollingInterval: RollingInterval.Day)
    .MinimumLevel.Override("Microsoft", LogEventLevel.Warning) // Microsoft 네임스페이스는 Warning 이상만
    .MinimumLevel.Override("System", LogEventLevel.Warning) // System 네임스페이스는 Warning 이상만
    .MinimumLevel.Override("Default", LogEventLevel.Warning) // 기본 로거는 Warning 이상만
    .MinimumLevel.Information() // 우리 코드는 Information 이상
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);

// Serilog를 기본 로깅 제공자로 설정
builder.Host.UseSerilog();

// Add services to the container.
builder.Services.AddControllersWithViews();

// Swagger 서비스 등록
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUtil, DbService>();
builder.Services.AddScoped<ITrafficService, TrafficService>();
builder.Services.AddScoped<ITrafficRepository, TrafficRepository>();
builder.Services.AddScoped<ICache, CacheService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // Swagger UI 추가
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Traffic}/{action=Get}/{id?}")
    .WithStaticAssets();


app.Run();

// 애플리케이션 종료 시 Serilog 정리
Log.CloseAndFlush();