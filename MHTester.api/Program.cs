using MHTester.api.Filters;
using MHTester.Application;
using MHTester.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
	builder.Services
		.AddApplication()
		.AddInfrastructure(builder.Configuration);
	builder.Services.AddControllers();
	// Second approach
	// builder.Services.AddControllers(		
	// 	options => options.Filters.Add<ErrorHandlingFilterAttribute>()
	// 	);
}

var app = builder.Build();
{
	//app.UseMiddleware<ErrorHandlingMiddleware>(); First approach
	app.UseExceptionHandler("/error");
	app.UseHttpsRedirection();
	app.MapControllers();
	app.Run();
}
