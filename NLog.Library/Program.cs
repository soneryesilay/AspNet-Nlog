using NLog;
using NLog.Web;

var builder = WebApplication.CreateBuilder(args);

var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("init main");

try
{
	// Dependecy Injection for NLog
	builder.Logging.ClearProviders();
	builder.Host.UseNLog();

	builder.Services.AddControllers();
	builder.Services.AddEndpointsApiExplorer();
	builder.Services.AddSwaggerGen();



	var app = builder.Build();

	if (app.Environment.IsDevelopment())
	{
		app.UseSwagger();
		app.UseSwaggerUI();
	}

	app.UseHttpsRedirection();

	app.UseAuthorization();

	app.MapControllers();

	app.Run();

}
catch (Exception ex)
{
	logger.Error(ex, "Program bir hata y�z�nden durdu!");
	throw;
}
finally
{
	NLog.LogManager.Shutdown();
}
