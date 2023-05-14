using VideoConverterApi.Services;
using VideoConverterApi.Interfaces;
using VideoConverterApi.Models;
using VideoConverterApi.Modelsæ;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IVideoToolsService, VideoToolsService>();
builder.Services.AddScoped<IConvertationService, ConvertationService>();
builder.Services.AddScoped<ISizePrecalculationService, SizePrecalculationService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/converttomp4withnoarguments", async (InputFileArguments inputFileArguments, IConvertationService convertationService) => { await convertationService.ConvertToMP4WithNoArguments(inputFileArguments); })
    .WithName("ConvertToMP4WithNoArguments")
    .WithOpenApi()
    .WithTags("ConvertationService");

app.MapPost("/converttoaviwithnoarguments", async (InputFileArguments inputFileArguments, IConvertationService convertationService) => { await convertationService.ConvertToAVIWithNoArguments(inputFileArguments); })
    .WithName("ConvertToAVIWithNoArguments")
    .WithOpenApi()
    .WithTags("ConvertationService");

app.MapPost("/converttowebmwithnoarguments", async (InputFileArguments inputFileArguments, IConvertationService convertationService) => { await convertationService.ConvertToWebMWithNoArguments(inputFileArguments); })
    .WithName("ConvertToWebMWithNoArguments")
    .WithOpenApi()
    .WithTags("ConvertationService");

app.MapPost("/converttomovwithnoarguments", async (InputFileArguments inputFileArguments, IConvertationService convertationService) => { await convertationService.ConvertToMOVWithNoArguments(inputFileArguments); })
    .WithName("ConvertToMOVWithNoArguments")
    .WithOpenApi()
    .WithTags("ConvertationService");

app.MapPost("/converttomkvwithnoarguments", async (InputFileArguments inputFileArguments, IConvertationService convertationService) => { await convertationService.ConvertToMKVWithNoArguments(inputFileArguments); })
    .WithName("ConvertToMKVWithNoArguments")
    .WithOpenApi()
    .WithTags("ConvertationService");

app.MapPost("/converttoflvwithnoarguments", async (InputFileArguments inputFileArguments, IConvertationService convertationService) => { await convertationService.ConvertToFLVWithNoArguments(inputFileArguments); })
    .WithName("ConvertToFLVWithNoArguments")
    .WithOpenApi()
    .WithTags("ConvertationService");

app.MapPost("/convertto3gpwithnoarguments", async (InputFileArguments inputFileArguments, IConvertationService convertationService) => { await convertationService.ConvertTo3GPWithNoArguments(inputFileArguments); })
    .WithName("ConvertTo3GPWithNoArguments")
    .WithOpenApi()
    .WithTags("ConvertationService");

app.MapPost("/converttompegwithnoarguments", async (InputFileArguments inputFileArguments, IConvertationService convertationService) => { await convertationService.ConvertToMPEGWithNoArguments(inputFileArguments); })
    .WithName("ConvertToMPEGWithNoArguments")
    .WithOpenApi()
    .WithTags("ConvertationService");

app.MapPost("/converttowmvwithnoarguments", async (InputFileArguments inputFileArguments, IConvertationService convertationService) => { await convertationService.ConvertToWMVWithNoArguments(inputFileArguments); })
    .WithName("ConvertToWMVWithNoArguments")
    .WithOpenApi()
    .WithTags("ConvertationService");

app.MapPost("/converttogifwithnoarguments", async (ConvertToGIFArguments convertToGIFArguments, IConvertationService convertationService) => { await convertationService.ConvertToGIFWithArguments(convertToGIFArguments); })
    .WithName("ConvertToGIFWithNoArguments")
    .WithOpenApi()
    .WithTags("ConvertationService");

app.MapPost("/converttoseriesofimages", async (ConvertToSeriesOfImagesArguments convertToSeriesOfImages, IConvertationService convertationService) => { await convertationService.ConvertToSeriesOfImages(convertToSeriesOfImages); })
    .WithName("ConvertToSeriesOfImages")
    .WithOpenApi()
    .WithTags("ConvertationService");

app.MapPost("/converttomp4witharguments", async (ConvertToMP4Arguments convertToMP4Arguments, IConvertationService convertationService) => { await convertationService.ConvertToMP4WithArguments(convertToMP4Arguments); })
    .WithName("ConvertToMP4WithArguments")
    .WithOpenApi()
    .WithTags("ConvertationService");

app.MapPost("/converttoaviwitharguments", async (ConvertToAVIArguments convertToAVIArguments, IConvertationService convertationService) => { await convertationService.ConvertToAVIWithArguments(convertToAVIArguments); })
    .WithName("ConvertToAVIWithArguments")
    .WithOpenApi()
    .WithTags("ConvertationService");

app.MapPost("/converttowebmwitharguments", async (ConvertToWebmArguments convertToWebmArguments, IConvertationService convertationService) => { await convertationService.ConvertToWebMWithArguments(convertToWebmArguments); })
    .WithName("ConvertToWebMWithArguments")
    .WithOpenApi()
    .WithTags("ConvertationService");

app.MapPost("/converttomovwitharguments", async (ConvertToMOVArguments convertToMOVArguments, IConvertationService convertationService) => { await convertationService.ConvertToMOVWithArguments(convertToMOVArguments); })
    .WithName("ConvertToMOVWithArguments")
    .WithOpenApi()
    .WithTags("ConvertationService");

app.MapPost("/converttomkvwitharguments", async (ConvertToMKVArguments convertToMKVArguments, IConvertationService convertationService) => { await convertationService.ConvertToMKVWithArguments(convertToMKVArguments); })
    .WithName("ConvertToMKVWithArguments")
    .WithOpenApi()
    .WithTags("ConvertationService");

app.MapPost("/reversevideo", async (InputFileArguments inputFileArguments, IVideoToolsService videoToolsService) => { await videoToolsService.ReverseVideoAsync(inputFileArguments); })
    .WithName("ReverseVideo")
    .WithOpenApi()
    .WithTags("VideoToolsService");

app.MapPost("/cropvideo", async (CropVideoArguments cropVideoArguments, IVideoToolsService videoToolsService) => { await videoToolsService.CropVideoAsync(cropVideoArguments); })
    .WithName("CropVideo")
    .WithOpenApi()
    .WithTags("VideoToolsService");

app.MapPost("/cutvideo", async (CutVideoArguments cutVideoArguments, IVideoToolsService videoToolsService) => { await videoToolsService.CutVideoAsync(cutVideoArguments); })
    .WithName("CutVideo")
    .WithOpenApi()
    .WithTags("VideoToolsService");

app.MapPost("/reflectvideo", async (ReflectVideoArguments reflectVideoArguments, IVideoToolsService videoToolsService) => { await videoToolsService.ReflectVideoAsync(reflectVideoArguments); })
    .WithName("ReflectVideo")
    .WithOpenApi()
    .WithTags("VideoToolsService");

app.MapPost("/removeaudio", async (InputFileArguments inputFileArguments, IVideoToolsService videoToolsService) => { await videoToolsService.RemoveAudioAsync(inputFileArguments); })
    .WithName("RemoveAudio")
    .WithOpenApi()
    .WithTags("VideoToolsService");

app.MapPost("/changevideobitrate", async (ChangeVideoBitrateArguments changeVideoBitrateArguments, IVideoToolsService videoToolsService) => { await videoToolsService.ChangeVideoBitrateAsync(changeVideoBitrateArguments); })
    .WithName("ChangeVideoBitrate")
    .WithOpenApi()
    .WithTags("VideoToolsService");

app.MapPost("/changeaudiobitrate", async (ChangeAudioBitrateArguments changeAudioBitrateArguments, IVideoToolsService videoToolsService) => { await videoToolsService.ChangeAudioBitrateAsync(changeAudioBitrateArguments); })
    .WithName("ChangeAudioBitrate")
    .WithOpenApi()
    .WithTags("VideoToolsService");

app.MapPost("/extractaudio", async (InputFileArguments inputFileArguments, IVideoToolsService videoToolsService) => { await videoToolsService.ExtractAudioAsync(inputFileArguments); })
    .WithName("ExtractAudio")
    .WithOpenApi()
    .WithTags("VideoToolsService");

app.MapPost("/weboptimizevideo", async (InputFileArguments inputFileArguments, IVideoToolsService videoToolsService) => { await videoToolsService.WebOptimizeVideoAsync(inputFileArguments); })
    .WithName("WebOptimizeVideo")
    .WithOpenApi()
    .WithTags("VideoToolsService");

app.MapPost("/addwatermark", async (AddWatermarkArguments addWatermarkArguments, IVideoToolsService videoToolsService) => { await videoToolsService.AddWatermarkAsync(addWatermarkArguments); })
    .WithName("AddWatermark")
    .WithOpenApi()
    .WithTags("VideoToolsService");

app.MapPost("/addaudio", async (AddAudioArguments addAudioArguments, IVideoToolsService videoToolsService) => { await videoToolsService.AddAudioAsync(addAudioArguments); })
    .WithName("AddAudio")
    .WithOpenApi()
    .WithTags("VideoToolsService");

app.MapPost("/addsubtitles", async (AddSubtitlesArguments addSubtitlesArguments, IVideoToolsService videoToolsService) => { await videoToolsService.AddSubtitlesAsync(addSubtitlesArguments); })
    .WithName("AddSubtitles")
    .WithOpenApi()
    .WithTags("VideoToolsService");

app.MapPost("/changevideospeed", async (ChangeVideoSpeedArguments changeVideoSpeedArguments, IVideoToolsService videoToolsService) => { await videoToolsService.ChangeVideoSpeedAsync(changeVideoSpeedArguments); })
    .WithName("ChangeVideoSpeed")
    .WithOpenApi()
    .WithTags("VideoToolsService");

app.MapPost("/changevideoframerate", async (ChangeVideoFramerateArguments changeVideoFramerateArguments, IVideoToolsService videoToolsService) => { await videoToolsService.ChangeVideoFramerateAsync(changeVideoFramerateArguments); })
    .WithName("ChangeVideoFramerate")
    .WithOpenApi()
    .WithTags("VideoToolsService");

app.MapPost("/changeaudiovolume", async (ChangeAudioVolumeArguments changeAudioVolumeArguments, IVideoToolsService videoToolsService) => { await videoToolsService.ChangeAudioVolumeAsync(changeAudioVolumeArguments); })
    .WithName("ChangeAudioVolume")
    .WithOpenApi()
    .WithTags("VideoToolsService");

app.MapPost("/changevideoresolution", async (ChangeVideoResolutionArguments changeVideoResolutionArguments, IVideoToolsService videoToolsService) => { await videoToolsService.ChangeVideoResolutionAsync(changeVideoResolutionArguments); })
    .WithName("ChangeVideoResolution")
    .WithOpenApi()
    .WithTags("VideoToolsService");

app.MapPost("/extractsingleframe", async (ExtractSingleFrameArguments extractSingleFrameArguments, IVideoToolsService videoToolsService) => { await videoToolsService.ExtractSingleFrameAsync(extractSingleFrameArguments); })
    .WithName("ExtractSingleFrame")
    .WithOpenApi()
    .WithTags("VideoToolsService");

app.MapPost("/mergevideos", async (MergeVideosArguments mergeVideosArguments, IVideoToolsService videoToolsService) => { await videoToolsService.MergeVideosAsync(mergeVideosArguments); })
    .WithName("MergeVideos")
    .WithOpenApi()
    .WithTags("VideoToolsService");

app.MapPost("/precalculatevideosize", (SizeCalculationVariables variables, ISizePrecalculationService sizePrecalculationService) =>
{
    var precalculatedSize = sizePrecalculationService.CalculateSize(variables);
    return precalculatedSize;
})
.WithName("PrecalculateVideoSize")
.WithOpenApi()
.WithTags("SizePrecalculationService");

app.Run();