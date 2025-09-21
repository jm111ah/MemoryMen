using TrafficProcessor.Interface;
using TrafficProcessor.Repository;
using TrafficProcessor.Service;
using TrafficProcessor.Util;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Swagger 서비스 등록
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUtil, DbService>();
builder.Services.AddScoped<ITrafficService, TrafficService>();
builder.Services.AddScoped<ITrafficRepository, TrafficRepository>();

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