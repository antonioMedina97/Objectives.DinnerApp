using MHTester.api.Common.Errors;
using MHTester.Application;
using MHTester.Infrastructure;
using Microsoft.AspNetCore.Mvc.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
	builder.Services
		.AddApplication()
		.AddInfrastructure(builder.Configuration);
	builder.Services.AddControllers();

	builder.Services.AddSingleton<ProblemDetailsFactory, MHTesterProblemDetailsFactory>();
}

var app = builder.Build();
{
	app.UseExceptionHandler("/error");
	app.UseHttpsRedirection();
	app.MapControllers();
	app.Run();
}
