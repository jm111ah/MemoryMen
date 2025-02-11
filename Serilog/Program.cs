



using Microsoft.Extensions.Configuration;
using Serilog;
using System.Text.Json;



#region log 설정
Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(new ConfigurationBuilder().AddJsonFile("C:\\tacoyaggi\\MemoryMen\\Serilog\\appsettingsDB.json").Build())
    .CreateLogger();
#endregion

try
{
    Log.ForContext("Test", "MemoryManFatal").Fatal("Fatal Message");
    Log.Verbose("verbose");
    Log.Debug("debug");
    Log.Information("information");
    Log.Warning("warning");
    Log.Error("error");
    var jsonObject = new { UserId = 1, UserName = "JohnDoe", Role = "Admin" };
    Log.Information(JsonSerializer.Serialize(jsonObject));


    throw new Exception();
}
catch (Exception ex)
{
    
    Log.Error(ex,"예외처리");
}
finally
{
    Log.CloseAndFlush();
}












