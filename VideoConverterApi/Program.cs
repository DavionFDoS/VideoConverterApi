using VideoConverterApi.Services;
using VideoConverterApi.Interfaces;
using VideoConverterApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.FileProviders;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();
builder.Services.AddScoped<IVideoToolsService, VideoToolsService>();
builder.Services.AddScoped<IConvertationService, ConvertationService>();
builder.Services.AddScoped<ISizePrecalculationService, SizePrecalculationService>();
builder.Services.AddScoped<IUploadsCalculator, UploadsCalculator>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(policy =>
{
    policy.AllowAnyOrigin();
    policy.AllowAnyMethod();
    policy.AllowAnyHeader();
});

app.UseHttpsRedirection();

app.MapPost("/converttomp4withnoarguments", async Task<OutputFileArguments?> (InputFileArguments inputFileArguments, IConvertationService convertationService) => { return await convertationService.ConvertToMP4WithNoArguments(inputFileArguments); })
    .WithName("ConvertToMP4WithNoArguments")
    .WithOpenApi()
    .WithTags("ConvertationService");

app.MapPost("/converttoaviwithnoarguments", async Task<OutputFileArguments?> (InputFileArguments inputFileArguments, IConvertationService convertationService) => { return await convertationService.ConvertToAVIWithNoArguments(inputFileArguments); })
    .WithName("ConvertToAVIWithNoArguments")
    .WithOpenApi()
    .WithTags("ConvertationService");

app.MapPost("/converttowebmwithnoarguments", async Task<OutputFileArguments?> (InputFileArguments inputFileArguments, IConvertationService convertationService) => { return await convertationService.ConvertToWebMWithNoArguments(inputFileArguments); })
    .WithName("ConvertToWebMWithNoArguments")
    .WithOpenApi()
    .WithTags("ConvertationService");

app.MapPost("/converttomovwithnoarguments", async Task<OutputFileArguments?> (InputFileArguments inputFileArguments, IConvertationService convertationService) => { return await convertationService.ConvertToMOVWithNoArguments(inputFileArguments); })
    .WithName("ConvertToMOVWithNoArguments")
    .WithOpenApi()
    .WithTags("ConvertationService");

app.MapPost("/converttomkvwithnoarguments", async Task<OutputFileArguments?> (InputFileArguments inputFileArguments, IConvertationService convertationService) => { return await convertationService.ConvertToMKVWithNoArguments(inputFileArguments); })
    .WithName("ConvertToMKVWithNoArguments")
    .WithOpenApi()
    .WithTags("ConvertationService");

app.MapPost("/converttoflvwithnoarguments", async Task<OutputFileArguments?> (InputFileArguments inputFileArguments, IConvertationService convertationService) => { return await convertationService.ConvertToFLVWithNoArguments(inputFileArguments); })
    .WithName("ConvertToFLVWithNoArguments")
    .WithOpenApi()
    .WithTags("ConvertationService");

app.MapPost("/convertto3gpwithnoarguments", async Task<OutputFileArguments?> (InputFileArguments inputFileArguments, IConvertationService convertationService) => { return await convertationService.ConvertTo3GPWithNoArguments(inputFileArguments); })
    .WithName("ConvertTo3GPWithNoArguments")
    .WithOpenApi()
    .WithTags("ConvertationService");

app.MapPost("/converttompegwithnoarguments", async Task<OutputFileArguments?> (InputFileArguments inputFileArguments, IConvertationService convertationService) => { return await convertationService.ConvertToMPEGWithNoArguments(inputFileArguments); })
    .WithName("ConvertToMPEGWithNoArguments")
    .WithOpenApi()
    .WithTags("ConvertationService");

app.MapPost("/converttowmvwithnoarguments", async Task<OutputFileArguments?> (InputFileArguments inputFileArguments, IConvertationService convertationService) => { return await convertationService.ConvertToWMVWithNoArguments(inputFileArguments); })
    .WithName("ConvertToWMVWithNoArguments")
    .WithOpenApi()
    .WithTags("ConvertationService");

app.MapPost("/converttogifwithnoarguments", async Task<OutputFileArguments?> (ConvertToGIFArguments convertToGIFArguments, IConvertationService convertationService) => { return await convertationService.ConvertToGIFWithArguments(convertToGIFArguments); })
    .WithName("ConvertToGIFWithNoArguments")
    .WithOpenApi()
    .WithTags("ConvertationService");

app.MapPost("/converttoseriesofimages", async Task<OutputFileArguments?> (ConvertToSeriesOfImagesArguments convertToSeriesOfImages, IConvertationService convertationService) => { return await convertationService.ConvertToSeriesOfImages(convertToSeriesOfImages); })
    .WithName("ConvertToSeriesOfImages")
    .WithOpenApi()
    .WithTags("ConvertationService");

app.MapPost("/converttomp4witharguments", async Task<OutputFileArguments?> (ConvertToMP4Arguments convertToMP4Arguments, IConvertationService convertationService) => { return await convertationService.ConvertToMP4WithArguments(convertToMP4Arguments); })
    .WithName("ConvertToMP4WithArguments")
    .WithOpenApi()
    .WithTags("ConvertationService");

app.MapPost("/converttoaviwitharguments", async Task<OutputFileArguments?> (ConvertToAVIArguments convertToAVIArguments, IConvertationService convertationService) => { return await convertationService.ConvertToAVIWithArguments(convertToAVIArguments); })
    .WithName("ConvertToAVIWithArguments")
    .WithOpenApi()
    .WithTags("ConvertationService");

app.MapPost("/converttowebmwitharguments", async Task<OutputFileArguments?> (ConvertToWebmArguments convertToWebmArguments, IConvertationService convertationService) => { return await convertationService.ConvertToWebMWithArguments(convertToWebmArguments); })
    .WithName("ConvertToWebMWithArguments")
    .WithOpenApi()
    .WithTags("ConvertationService");

app.MapPost("/converttomovwitharguments", async Task<OutputFileArguments?> (ConvertToMOVArguments convertToMOVArguments, IConvertationService convertationService) => { return await convertationService.ConvertToMOVWithArguments(convertToMOVArguments); })
    .WithName("ConvertToMOVWithArguments")
    .WithOpenApi()
    .WithTags("ConvertationService");

app.MapPost("/converttomkvwitharguments", async Task<OutputFileArguments?> (ConvertToMKVArguments convertToMKVArguments, IConvertationService convertationService) => { return await convertationService.ConvertToMKVWithArguments(convertToMKVArguments); })
    .WithName("ConvertToMKVWithArguments")
    .WithOpenApi()
    .WithTags("ConvertationService");

app.MapPost("/reversevideo", async Task<OutputFileArguments?> (InputFileArguments inputFileArguments, IVideoToolsService videoToolsService) => { return await videoToolsService.ReverseVideoAsync(inputFileArguments); })
    .WithName("ReverseVideo")
    .WithOpenApi()
    .WithTags("VideoToolsService");

app.MapPost("/rotatevideo", async Task<OutputFileArguments?> (RotateVideoArguments rotateVideoArguments, IVideoToolsService videoToolsService) => { return await videoToolsService.RotateVideoByAngleAsync(rotateVideoArguments); })
    .WithName("RotateVideo")
    .WithOpenApi()
    .WithTags("VideoToolsService");

app.MapPost("/cropvideo", async Task<OutputFileArguments?> (CropVideoArguments cropVideoArguments, IVideoToolsService videoToolsService) => { return await videoToolsService.CropVideoAsync(cropVideoArguments); })
    .WithName("CropVideo")
    .WithOpenApi()
    .WithTags("VideoToolsService");

app.MapPost("/cutvideo", async Task<OutputFileArguments?> (CutVideoArguments cutVideoArguments, IVideoToolsService videoToolsService) => { return await videoToolsService.CutVideoAsync(cutVideoArguments); })
    .WithName("CutVideo")
    .WithOpenApi()
    .WithTags("VideoToolsService");

app.MapPost("/reflectvideo", async Task<OutputFileArguments?> (ReflectVideoArguments reflectVideoArguments, IVideoToolsService videoToolsService) => { return await videoToolsService.ReflectVideoAsync(reflectVideoArguments); })
    .WithName("ReflectVideo")
    .WithOpenApi()
    .WithTags("VideoToolsService");

app.MapPost("/removeaudio", async Task<OutputFileArguments?> (InputFileArguments inputFileArguments, IVideoToolsService videoToolsService) => { return await videoToolsService.RemoveAudioAsync(inputFileArguments); })
    .WithName("RemoveAudio")
    .WithOpenApi()
    .WithTags("VideoToolsService");

app.MapPost("/changevideobitrate", async Task<OutputFileArguments?> (ChangeVideoBitrateArguments changeVideoBitrateArguments, IVideoToolsService videoToolsService) => { return await videoToolsService.ChangeVideoBitrateAsync(changeVideoBitrateArguments); })
    .WithName("ChangeVideoBitrate")
    .WithOpenApi()
    .WithTags("VideoToolsService");

app.MapPost("/changeaudiobitrate", async Task<OutputFileArguments?> (ChangeAudioBitrateArguments changeAudioBitrateArguments, IVideoToolsService videoToolsService) => { return await videoToolsService.ChangeAudioBitrateAsync(changeAudioBitrateArguments); })
    .WithName("ChangeAudioBitrate")
    .WithOpenApi()
    .WithTags("VideoToolsService");

app.MapPost("/extractaudio", async Task<OutputFileArguments?> (InputFileArguments inputFileArguments, IVideoToolsService videoToolsService) => { return await videoToolsService.ExtractAudioAsync(inputFileArguments); })
    .WithName("ExtractAudio")
    .WithOpenApi()
    .WithTags("VideoToolsService");

app.MapPost("/weboptimizevideo", async Task<OutputFileArguments?> (InputFileArguments inputFileArguments, IVideoToolsService videoToolsService) => { return await videoToolsService.WebOptimizeVideoAsync(inputFileArguments); })
    .WithName("WebOptimizeVideo")
    .WithOpenApi()
    .WithTags("VideoToolsService");

app.MapPost("/addwatermark", async Task<OutputFileArguments?> (AddWatermarkArguments addWatermarkArguments, IVideoToolsService videoToolsService) => { return await videoToolsService.AddWatermarkAsync(addWatermarkArguments); })
    .WithName("AddWatermark")
    .WithOpenApi()
    .WithTags("VideoToolsService");

app.MapPost("/addaudio", async Task<OutputFileArguments?> (AddAudioArguments addAudioArguments, IVideoToolsService videoToolsService) => { return await videoToolsService.AddAudioAsync(addAudioArguments); })
    .WithName("AddAudio")
    .WithOpenApi()
    .WithTags("VideoToolsService");

app.MapPost("/addsubtitles", async Task<OutputFileArguments?> (AddSubtitlesArguments addSubtitlesArguments, IVideoToolsService videoToolsService) => { return await videoToolsService.AddSubtitlesAsync(addSubtitlesArguments); })
    .WithName("AddSubtitles")
    .WithOpenApi()
    .WithTags("VideoToolsService");

app.MapPost("/changevideospeed", async Task<OutputFileArguments?> (ChangeVideoSpeedArguments changeVideoSpeedArguments, IVideoToolsService videoToolsService) => { return await videoToolsService.ChangeVideoSpeedAsync(changeVideoSpeedArguments); })
    .WithName("ChangeVideoSpeed")
    .WithOpenApi()
    .WithTags("VideoToolsService");

app.MapPost("/changevideoframerate", async Task<OutputFileArguments?> (ChangeVideoFramerateArguments changeVideoFramerateArguments, IVideoToolsService videoToolsService) => { return await videoToolsService.ChangeVideoFramerateAsync(changeVideoFramerateArguments); })
    .WithName("ChangeVideoFramerate")
    .WithOpenApi()
    .WithTags("VideoToolsService");

app.MapPost("/changeaudiovolume", async Task<OutputFileArguments?> (ChangeAudioVolumeArguments changeAudioVolumeArguments, IVideoToolsService videoToolsService) => { return await videoToolsService.ChangeAudioVolumeAsync(changeAudioVolumeArguments); })
    .WithName("ChangeAudioVolume")
    .WithOpenApi()
    .WithTags("VideoToolsService");

app.MapPost("/changevideoresolution", async Task<OutputFileArguments?> (ChangeVideoResolutionArguments changeVideoResolutionArguments, IVideoToolsService videoToolsService) => { return await videoToolsService.ChangeVideoResolutionAsync(changeVideoResolutionArguments); })
    .WithName("ChangeVideoResolution")
    .WithOpenApi()
    .WithTags("VideoToolsService");

app.MapPost("/extractsingleframe", async Task<OutputFileArguments?> (ExtractSingleFrameArguments extractSingleFrameArguments, IVideoToolsService videoToolsService) => { return await videoToolsService.ExtractSingleFrameAsync(extractSingleFrameArguments); })
    .WithName("ExtractSingleFrame")
    .WithOpenApi()
    .WithTags("VideoToolsService");

app.MapPost("/mergevideos", async Task<OutputFileArguments?> (MergeVideosArguments mergeVideosArguments, IVideoToolsService videoToolsService) => { return await videoToolsService.MergeVideosAsync(mergeVideosArguments); })
    .WithName("MergeVideos")
    .WithOpenApi()
    .WithTags("VideoToolsService");

app.MapPost("/precalculatevideosize", UploadsCalculatorVariables (SizeCalculationVariables variables, ISizePrecalculationService sizePrecalculationService, IUploadsCalculator uploadsCalculator) =>
{
    var precalculatedSize = sizePrecalculationService.CalculateSize(variables);
    uploadsCalculator.SizeCalculationVariables = variables;
    uploadsCalculator.PrecalculatedSize = precalculatedSize;

    return uploadsCalculator.CheckUploadAccessibility();
})
.WithName("PrecalculateVideoSize")
.WithOpenApi()
.WithTags("SizePrecalculationService");

app.MapGet("/download", async (string filePath, HttpContext context) =>
{
    if (File.Exists(filePath))
    {
        var fileProvider = new PhysicalFileProvider(Path.GetDirectoryName(filePath)!);
        var fileInfo = fileProvider.GetFileInfo(Path.GetFileName(filePath));

        context.Response.ContentType = "application/octet-stream";
        context.Response.Headers["Content-Disposition"] = $"attachment; filename={fileInfo.Name}";

        await context.Response.SendFileAsync(fileInfo);

        File.Delete(filePath);
    }
    else
    {
        context.Response.StatusCode = StatusCodes.Status404NotFound;
    }
})
.WithName("Download")
.WithOpenApi()
.WithTags("DownloadFileService");

app.Run();