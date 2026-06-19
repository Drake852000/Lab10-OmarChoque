using Lab10_OmarChoque.Api.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Registrar servicios
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssemblies(
        typeof(Lab10_OmarChoque.Application.Common.ApplicationAssemblyMarker).Assembly
    ));

var app = builder.Build();

// Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();

    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Lab10 API v1");
        c.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();

// Authentication
app.UseAuthentication();

// Authorization
app.UseAuthorization();

// Controllers
app.MapControllers();

app.Run();