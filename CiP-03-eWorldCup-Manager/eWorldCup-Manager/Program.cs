using Microsoft.EntityFrameworkCore;
using eWorldCup_Manager;
using eWorldCup_Manager.Models;
using eWorldCup_Manager.Domain.Interfaces;
using eWorldCup_Manager.Applications.Services;
using System.Reflection.Metadata.Ecma335; // Add this line if TournamentService is in the Services namespace
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

//builder.Services.AddScoped<ITournamentService, TournamentService>();
//builder.Services.AddSwaggerGen(); behövs ej med AddOpenApi
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseCors("AllowFrontend");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


