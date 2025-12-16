using Scalar.AspNetCore;
using eWorldCup_Manager.Application.Features.GetAllRoundPairs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddMediatR(config=>
{
    config.RegisterServicesFromAssemblyContaining<GetAllRoundPairsRequest>();
});

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


