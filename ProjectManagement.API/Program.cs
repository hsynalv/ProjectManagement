using NLog;
using ProjectManagement.API.Extensions;
using ProjectManagement.Contracts;
using ProjectManagement.Presentation;

var builder = WebApplication.CreateBuilder(args);

LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

// Add services to the container.

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.ConfigureCors();
builder.Services.ConfigureLoggerManager();
builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.ConfigureUnitOfWork();
builder.Services.ConfigureServiceManager();
builder.Services.AddAutoMapper(typeof(Program));


builder.Services.AddControllers()
    .AddApplicationPart(typeof(AssemblyReference).Assembly);


var app = builder.Build();

var logger = app.Services.GetRequiredService<ILoggerManager>();
app.ConfigureExceptionHandler(logger);

if (app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors("CorsPolicy");

app.Run();