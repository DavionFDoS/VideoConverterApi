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

app.MapPost("/converttomkvwithnoarguments", async (CommandArguments commandArguments) =>
{
    var commandsHandler = new FFMpegCommandHandler(commandArguments);
    await commandsHandler.ConvertToMKVWithNoArguments();
})
.WithName("ConvertToMKVWithNoArguments")
.WithOpenApi();

app.MapPost("/converttoflvwithnoarguments", async (CommandArguments commandArguments) =>
{
    var commandsHandler = new FFMpegCommandHandler(commandArguments);
    await commandsHandler.ConvertToFLVWithNoArguments();
})
.WithName("ConvertToFLVWithNoArguments")
.WithOpenApi();

app.MapPost("/convertto3gpwithnoarguments", async (CommandArguments commandArguments) =>
{
    var commandsHandler = new FFMpegCommandHandler(commandArguments);
    await commandsHandler.ConvertTo3GPWithNoArguments();
})
.WithName("ConvertTo3GPWithNoArguments")
.WithOpenApi();

app.MapPost("/converttompegwithnoarguments", async (CommandArguments commandArguments) =>
{
    var commandsHandler = new FFMpegCommandHandler(commandArguments);
    await commandsHandler.ConvertToMPEGWithNoArguments();
})
.WithName("ConvertToMPEGWithNoArguments")
.WithOpenApi();

app.MapPost("/converttowmvwithnoarguments", async (CommandArguments commandArguments) =>
{
    var commandsHandler = new FFMpegCommandHandler(commandArguments);
    await commandsHandler.ConvertToWMVWithNoArguments();
})
.WithName("ConvertToWMVWithNoArguments")
.WithOpenApi();

app.MapPost("/converttomp4witharguments", async (CommandArguments commandArguments) =>
{
    var commandsHandler = new FFMpegCommandHandler(commandArguments);
    await commandsHandler.ConvertToMP4WithArguments();
})
.WithName("ConvertToMP4WithArguments")
.WithOpenApi();

app.MapPost("/converttoaviwitharguments", async (CommandArguments commandArguments) =>
{
    var commandsHandler = new FFMpegCommandHandler(commandArguments);
    await commandsHandler.ConvertToAVIWithArguments();
})
.WithName("ConvertToAVIWithArguments")
.WithOpenApi();

app.MapPost("/converttowebmwitharguments", async (CommandArguments commandArguments) =>
{
    var commandsHandler = new FFMpegCommandHandler(commandArguments);
    await commandsHandler.ConvertToWebMWithArguments();
})
.WithName("ConvertToWebMWithArguments")
.WithOpenApi();

app.MapPost("/converttomovwitharguments", async (CommandArguments commandArguments) =>
{
    var commandsHandler = new FFMpegCommandHandler(commandArguments);
    await commandsHandler.ConvertToMOVWithArguments();
})
.WithName("ConvertToMOVWithArguments")
.WithOpenApi();

app.MapPost("/reversevideo", async (CommandArguments commandArguments) =>
{
    var commandsHandler = new FFMpegCommandHandler(commandArguments);
    await commandsHandler.ReverseVideoAsync();
})
.WithName("ReverseVideo")
.WithOpenApi();

app.Run();