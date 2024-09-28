
using Data.Access;
using Domain.Access;
using Domain.Access.Interfaces;
using Exception.Middleware;
using Logic;
using Logic.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<DbContext, AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("AppDbContext"));
});

builder.Services.AddScoped<IMovieLogic, MovieLogic>();
builder.Services.AddScoped<IEntityAccess, EntityAccess>();

var app = builder.Build();

app.UseMiddleware<APIExceptionHandlerMiddleware>();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();