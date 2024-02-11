using HRBBoilerplate.Filters;
using HRBBoilerplate.Middleware;
using Infrastructure;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

//Add Libraries
builder.Services
    .AddAPIDependency()
    .AddInfrastructureDependency(configuration)
    .AddApplicationDependency();

// Add services to the container.
builder.Services.AddControllers(options => options.Filters.Add<ExceptionHandleFilter>());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<CustomMiddleware>();
app.UseAuthentication();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
