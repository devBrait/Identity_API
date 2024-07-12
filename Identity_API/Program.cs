using Identity_API.Data;
using Identity_API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddDbContext<AppDbContext>(
    options => options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=identity-db;Trusted_Connection=True;MultipleActiveResultSets=true")
    );

builder.Services.AddAuthentication();
builder.Services.AddAuthorization();

builder.Services
    .AddIdentityApiEndpoints<User>()
    .AddEntityFrameworkStores<AppDbContext>();


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.MapSwagger();

app.MapGet("/", (ClaimsPrincipal user) => user.Identity!.Name)
    .RequireAuthorization();

app.MapIdentityApi<User>();

app.MapPost("/logout", 
    async(SignInManager < User > signInManager, [FromBody]object empty) =>
    {
        await signInManager.SignOutAsync();
        return Results.Ok();
    });

app.Run();
