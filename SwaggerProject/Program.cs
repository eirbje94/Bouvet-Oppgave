using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SwaggerProject.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<SwaggerProjectContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SwaggerProjectContext") ?? throw new InvalidOperationException("Connection string 'SwaggerProjectContext' not found.")));

builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

// Add services to the container.

builder.Services.AddControllers();
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
