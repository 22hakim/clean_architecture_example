using project.api.Filters;
using project.api.Middleware;
using project.Application;
using project.Infra;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddApplication()
                    .AddInfrasctructure(builder.Configuration);
    builder.Services
        .AddControllers(o => o.Filters.Add<ErrorHandlingFilterAttribute>());

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
}

var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseMiddleware<ErrorHandlingMiddleware>();
    app.UseHttpsRedirection();
    app.UseAuthorization();
    app.MapControllers();
    app.Run();
}


