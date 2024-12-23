using BlazorTrails.Api.Persistence;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BlazingTrailsContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("BlazingTrailsContext")));

builder.Services.AddControllers()
    .AddFluentValidation(fv =>
        fv.RegisterValidatorsFromAssembly(Assembly.Load("BlazorTrails.Shared")));

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();

app.UseStaticFiles();

app.UseStaticFiles(new StaticFileOptions()
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"Images")),
    RequestPath = new PathString("/Images")
});

app.UseRouting();

app.MapControllers();

app.MapFallbackToFile("index.html");

app.Run();