using VideoConverterApi.Services;
using VideoConverterApi.Interfaces;
using VideoConverterApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IVideoToolsService, VideoToolsService>();
//builder.Services.AddSingleton<IConvertationService, ConvertationService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/converttomp4withnoarguments", async (CommandArguments commandArguments) =>
{
    var commandsHandler = new ConvertationService(commandArguments);
    await commandsHandler.ConvertToMP4WithNoArguments();
})
.WithName("ConvertToMP4WithNoArguments")
.WithOpenApi();

app.MapPost("/converttoaviwithnoarguments", async (CommandArguments commandArguments) =>
{
    var commandsHandler = new ConvertationService(commandArguments);
    await commandsHandler.ConvertToAVIWithNoArguments();
})
.WithName("ConvertToAVIWithNoArguments")
.WithOpenApi();

app.MapPost("/converttowebmwithnoarguments", async (CommandArguments commandArguments) =>
{
    var commandsHandler = new ConvertationService(commandArguments);
    await commandsHandler.ConvertToWebMWithNoArguments();
})
.WithName("ConvertToWebMWithNoArguments")
.WithOpenApi();

app.MapPost("/converttomovwithnoarguments", async (CommandArguments commandArguments) =>
{
    var commandsHandler = new ConvertationService(commandArguments);
    await commandsHandler.ConvertToMOVWithNoArguments();
})
.WithName("ConvertToMOVWithNoArguments")
.WithOpenApi();

app.MapPost("/converttomkvwithnoarguments", async (CommandArguments commandArguments) =>
{
    var commandsHandler = new ConvertationService(commandArguments);
    await commandsHandler.ConvertToMKVWithNoArguments();
})
.WithName("ConvertToMKVWithNoArguments")
.WithOpenApi();

app.MapPost("/converttoflvwithnoarguments", async (CommandArguments commandArguments) =>
{
    var commandsHandler = new ConvertationService(commandArguments);
    await commandsHandler.ConvertToFLVWithNoArguments();
})
.WithName("ConvertToFLVWithNoArguments")
.WithOpenApi();

app.MapPost("/convertto3gpwithnoarguments", async (CommandArguments commandArguments) =>
{
    var commandsHandler = new ConvertationService(commandArguments);
    await commandsHandler.ConvertTo3GPWithNoArguments();
})
.WithName("ConvertTo3GPWithNoArguments")
.WithOpenApi();

app.MapPost("/converttompegwithnoarguments", async (CommandArguments commandArguments) =>
{
    var commandsHandler = new ConvertationService(commandArguments);
    await commandsHandler.ConvertToMPEGWithNoArguments();
})
.WithName("ConvertToMPEGWithNoArguments")
.WithOpenApi();

app.MapPost("/converttowmvwithnoarguments", async (CommandArguments commandArguments) =>
{
    var commandsHandler = new ConvertationService(commandArguments);
    await commandsHandler.ConvertToWMVWithNoArguments();
})
.WithName("ConvertToWMVWithNoArguments")
.WithOpenApi();

app.MapPost("/converttogifwithnoarguments", async (CommandArguments commandArguments) =>
{
    var commandsHandler = new ConvertationService(commandArguments);
    await commandsHandler.ConvertToGIFWithNoArguments();
})
.WithName("ConvertToGIFWithNoArguments")
.WithOpenApi();

app.MapPost("/converttoseriesofimages", async (CommandArguments commandArguments) =>
{
    var commandsHandler = new ConvertationService(commandArguments);
    await commandsHandler.ConvertToSeriesOfImages();
})
.WithName("ConvertToSeriesOfImages")
.WithOpenApi();

app.MapPost("/converttomp4witharguments", async (CommandArguments commandArguments) =>
{
    var commandsHandler = new ConvertationService(commandArguments);
    await commandsHandler.ConvertToMP4WithArguments();
})
.WithName("ConvertToMP4WithArguments")
.WithOpenApi();

app.MapPost("/converttoaviwitharguments", async (CommandArguments commandArguments) =>
{
    var commandsHandler = new ConvertationService(commandArguments);
    await commandsHandler.ConvertToAVIWithArguments();
})
.WithName("ConvertToAVIWithArguments")
.WithOpenApi();

app.MapPost("/converttowebmwitharguments", async (CommandArguments commandArguments) =>
{
    var commandsHandler = new ConvertationService(commandArguments);
    await commandsHandler.ConvertToWebMWithArguments();
})
.WithName("ConvertToWebMWithArguments")
.WithOpenApi();

app.MapPost("/converttomovwitharguments", async (CommandArguments commandArguments) =>
{
    var commandsHandler = new ConvertationService(commandArguments);
    await commandsHandler.ConvertToMOVWithArguments();
})
.WithName("ConvertToMOVWithArguments")
.WithOpenApi();

app.MapPost("/reversevideo", async (InputFileArguments inputFileArguments, IVideoToolsService videoToolsService) => { await videoToolsService.ReverseVideoAsync(inputFileArguments); })
.WithName("ReverseVideo")
.WithOpenApi();

app.MapPost("/cropvideo", async (CropVideoArguments cropVideoArguments, IVideoToolsService videoToolsService) => { await videoToolsService.CropVideoAsync(cropVideoArguments); })
.WithName("CropVideo")
.WithOpenApi();

app.MapPost("/cutvideo", async (CutVideoArguments cutVideoArguments, IVideoToolsService videoToolsService) => { await videoToolsService.CutVideoAsync(cutVideoArguments); })
.WithName("CutVideo")
.WithOpenApi();

app.MapPost("/reflectvideo", async (ReflectVideoArguments reflectVideoArguments, IVideoToolsService videoToolsService) => { await videoToolsService.ReflectVideoAsync(reflectVideoArguments); })
.WithName("ReflectVideo")
.WithOpenApi();

app.MapPost("/removeaudio", async (InputFileArguments inputFileArguments, IVideoToolsService videoToolsService) => { await videoToolsService.RemoveAudioAsync(inputFileArguments); })
.WithName("RemoveAudio")
.WithOpenApi();

app.MapPost("/changevideobitrate", async (ChangeVideoBitrateArguments changeVideoBitrateArguments, IVideoToolsService videoToolsService) => { await videoToolsService.ChangeVideoBitrateAsync(changeVideoBitrateArguments); })
.WithName("ChangeVideoBitrate")
.WithOpenApi();

app.MapPost("/changeaudiobitrate", async (ChangeAudioBitrateArguments changeAudioBitrateArguments, IVideoToolsService videoToolsService) => { await videoToolsService.ChangeAudioBitrateAsync(changeAudioBitrateArguments); })
.WithName("ChangeAudioBitrate")
.WithOpenApi();

app.MapPost("/extractaudio", async (InputFileArguments inputFileArguments, IVideoToolsService videoToolsService) => { await videoToolsService.ExtractAudioAsync(inputFileArguments); })
.WithName("ExtractAudio")
.WithOpenApi();

app.MapPost("/weboptimizevideo", async (InputFileArguments inputFileArguments, IVideoToolsService videoToolsService) => { await videoToolsService.WebOptimizeVideoAsync(inputFileArguments); })
.WithName("WebOptimizeVideo")
.WithOpenApi();

app.MapPost("/addwatermark", async (AddWatermarkArguments addWatermarkArguments, IVideoToolsService videoToolsService) => { await videoToolsService.AddWatermarkAsync(addWatermarkArguments); })
.WithName("AddWatermark")
.WithOpenApi();

app.MapPost("/addaudio", async (AddAudioArguments addAudioArguments, IVideoToolsService videoToolsService) => { await videoToolsService.AddAudioAsync(addAudioArguments); })
.WithName("AddAudio")
.WithOpenApi();

app.MapPost("/addsubtitles", async (AddSubtitlesArguments addSubtitlesArguments, IVideoToolsService videoToolsService) => { await videoToolsService.AddSubtitlesAsync(addSubtitlesArguments); })
.WithName("AddSubtitles")
.WithOpenApi();

app.MapPost("/changevideospeed", async (ChangeVideoSpeedArguments changeVideoSpeedArguments, IVideoToolsService videoToolsService) => { await videoToolsService.ChangeVideoSpeedAsync(changeVideoSpeedArguments); })
.WithName("ChangeVideoSpeed")
.WithOpenApi();

app.MapPost("/changevideoframerate", async (ChangeVideoFramerateArguments changeVideoFramerateArguments, IVideoToolsService videoToolsService) => { await videoToolsService.ChangeVideoFramerateAsync(changeVideoFramerateArguments); })
.WithName("ChangeVideoFramerate")
.WithOpenApi();

app.MapPost("/changeaudiovolume", async (ChangeAudioVolumeArguments changeAudioVolumeArguments, IVideoToolsService videoToolsService) => { await videoToolsService.ChangeAudioVolumeAsync(changeAudioVolumeArguments); })
.WithName("ChangeAudioVolume")
.WithOpenApi();

app.MapPost("/changevideoresolution", async (ChangeVideoResolutionArguments changeVideoResolutionArguments, IVideoToolsService videoToolsService) => { await videoToolsService.ChangeVideoResolutionAsync(changeVideoResolutionArguments); })
.WithName("ChangeVideoResolution")
.WithOpenApi();

app.MapPost("/extractsingleframe", async (ExtractSingleFrameArguments extractSingleFrameArguments, IVideoToolsService videoToolsService) => { await videoToolsService.ExtractSingleFrameAsync(extractSingleFrameArguments); })
.WithName("ExtractSingleFrame")
.WithOpenApi();

app.MapPost("/mergevideos", async (MergeVideosArguments mergeVideosArguments, IVideoToolsService videoToolsService) => { await videoToolsService.MergeVideosAsync(mergeVideosArguments); })
.WithName("MergeVideos")
.WithOpenApi();

app.MapPost("/precalculatevideosize", (SizeCalculationVariables variables) =>
{
    var sizePrecalculationService = new SizePrecalculationService();
    var precalculatedSize = sizePrecalculationService.CalculateSize(variables);
    return precalculatedSize;
})
.WithName("PrecalculateVideoSize")
.WithOpenApi();

app.Run();