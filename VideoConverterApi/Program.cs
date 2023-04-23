using VideoConverterApi.Services;
using VideoConverterApi.Interfaces;
using VideoConverterApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddSingleton(IFFMpegCommandHandler, FFMpegCommandHandler());

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/converttomp4withnoarguments", async (CommandArguments commandArguments) =>
{
    var commandsHandler = new FFMpegCommandHandler(commandArguments);
    await commandsHandler.ConvertToMP4WithNoArguments();
})
.WithName("ConvertToMP4WithNoArguments")
.WithOpenApi();

app.MapPost("/converttoaviwithnoarguments", async (CommandArguments commandArguments) =>
{
    var commandsHandler = new FFMpegCommandHandler(commandArguments);
    await commandsHandler.ConvertToAVIWithNoArguments();
})
.WithName("ConvertToAVIWithNoArguments")
.WithOpenApi();

app.MapPost("/converttowebmwithnoarguments", async (CommandArguments commandArguments) =>
{
    var commandsHandler = new FFMpegCommandHandler(commandArguments);
    await commandsHandler.ConvertToWebMWithNoArguments();
})
.WithName("ConvertToWebMWithNoArguments")
.WithOpenApi();

app.MapPost("/converttomovwithnoarguments", async (CommandArguments commandArguments) =>
{
    var commandsHandler = new FFMpegCommandHandler(commandArguments);
    await commandsHandler.ConvertToMOVWithNoArguments();
})
.WithName("ConvertToMOVWithNoArguments")
.WithOpenApi();

app.MapPost("/reversevideo", async (CommandArguments commandArguments) =>
{
    var commandsHandler = new FFMpegCommandHandler(commandArguments);
    await commandsHandler.ReverseVideoAsync();
})
.WithName("ReverseVideo")
.WithOpenApi();

app.Run();