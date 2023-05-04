using VideoConverterApi.Models;
using CliWrap;
using CliWrap.Buffered;
using Serilog;
using VideoConverterApi.Interfaces;
using Microsoft.OpenApi.Extensions;
using VideoConverterApi.Enums;
using VideoConverterApi.Extensions;
using System;

namespace VideoConverterApi.Services;

public class ConvertationService : IConvertationService
{
    private readonly CommandArguments _commandArguments;
    private readonly Serilog.ILogger _logger;
    private readonly string _videosFolderName = "Videos/";
    private readonly MediaMetadataService _mediaMetadataService = new();
    public ConvertationService(CommandArguments commandArguments)
    {
        _commandArguments = commandArguments;
        _logger = new LoggerConfiguration()
            .WriteTo.File("ConvertionServiceLogs.txt")
            .CreateLogger();
    }

    private Command WrapCommand(string arguments)
    {
        return Cli.Wrap("ffmpeg")
            .WithArguments(arguments)
            .WithValidation(CommandResultValidation.None)
            .WithStandardErrorPipe(PipeTarget.ToDelegate(_logger.Error))
            .WithStandardOutputPipe(PipeTarget.ToDelegate(_logger.Information));
    }
    public async Task ConvertToMP4WithNoArguments()
    {
        var inputFileName = _commandArguments.InputFileName;

        if (inputFileName is null)
        {
            return;
        }

        var inputFilePath = $"{_videosFolderName}{inputFileName}";
        var guid = Guid.NewGuid();

        var cmd = WrapCommand($"-i {inputFilePath} {_videosFolderName}{guid}.mp4");        

        var cmdResult = await cmd.ExecuteBufferedAsync();

        if (cmdResult.ExitCode != 0)
        {
            _logger.Error("Error executing convert to MP4 with no arguments command. Exit code: {ExitCode}", cmdResult.ExitCode);
            throw new Exception("Error executing ffmpeg command");
        }

        _logger.Information("Convert to MP4 with no arguments command executed succesfully");
    }
    public async Task ConvertToAVIWithNoArguments()
    {
        var inputFileName = _commandArguments.InputFileName;

        if (inputFileName is null)
        {
            return;
        }

        var inputFilePath = $"Videos/{inputFileName}";
        var metadata = _mediaMetadataService.GetMediaMetadata(inputFilePath);
        _logger.Information(metadata.ToString());
        var guid = Guid.NewGuid();

        var cmd = WrapCommand($"-i {inputFilePath} {_videosFolderName}{guid}.avi");

        var cmdResult = await cmd.ExecuteBufferedAsync();

        if (cmdResult.ExitCode != 0)
        {
            _logger.Error("Error executing convert to AVI with no arguments command. Exit code: {ExitCode}", cmdResult.ExitCode);
            throw new Exception("Error executing ffmpeg command");
        }
        metadata = _mediaMetadataService.GetMediaMetadata($"{ _videosFolderName}{guid}.avi");
        _logger.Information(metadata.ToString());
        _logger.Information("Convert to AVI with no arguments command executed succesfully");
    }
    public async Task ConvertToWebMWithNoArguments()
    {
        var inputFileName = _commandArguments.InputFileName;


        if (inputFileName is null)
        {
            return;
        }

        var inputFilePath = $"Videos/{inputFileName}";
        var guid = Guid.NewGuid();

        var cmd = WrapCommand($"-i {inputFilePath} {_videosFolderName}{guid}.webm");

        var cmdResult = await cmd.ExecuteBufferedAsync();

        if (cmdResult.ExitCode != 0)
        {
            _logger.Error("Error executing convert to WebM with no arguments command. Exit code: {ExitCode}", cmdResult.ExitCode);
            throw new Exception("Error executing ffmpeg command");
        }

        _logger.Information("Convert to WebM with no arguments command executed succesfully");
    }
    public async Task ConvertToMOVWithNoArguments()
    {
        var inputFileName = _commandArguments.InputFileName;

        if (inputFileName is null)
        {
            return;
        }

        var inputFilePath = $"Videos/{inputFileName}";
        var guid = Guid.NewGuid();

        var cmd = WrapCommand($"-i {inputFilePath} {_videosFolderName}{guid}.mov");

        var cmdResult = await cmd.ExecuteBufferedAsync();

        if (cmdResult.ExitCode != 0)
        {
            _logger.Error("Error executing convert to MOV with no arguments command. Exit code: {ExitCode}", cmdResult.ExitCode);
            throw new Exception("Error executing ffmpeg command");
        }

        _logger.Information("Convert to MOV with no arguments command executed succesfully");
    }
    public async Task ConvertToMKVWithNoArguments()
    {
        var inputFileName = _commandArguments.InputFileName;

        if (inputFileName is null)
        {
            return;
        }

        var inputFilePath = $"Videos/{inputFileName}";
        var guid = Guid.NewGuid();

        var cmd = WrapCommand($"-i {inputFilePath} {_videosFolderName}{guid}.mkv");

        var cmdResult = await cmd.ExecuteBufferedAsync();

        if (cmdResult.ExitCode != 0)
        {
            _logger.Error("Error executing convert to MKV with no arguments command. Exit code: {ExitCode}", cmdResult.ExitCode);
            throw new Exception("Error executing ffmpeg command");
        }

        _logger.Information("Convert to MKV with no arguments command executed succesfully");
    }
    public async Task ConvertToFLVWithNoArguments()
    {
        var inputFileName = _commandArguments.InputFileName;

        if (inputFileName is null)
        {
            return;
        }

        var inputFilePath = $"Videos/{inputFileName}";
        var guid = Guid.NewGuid();

        var cmd = WrapCommand($"-i {inputFilePath} {_videosFolderName}{guid}.flv");

        var cmdResult = await cmd.ExecuteBufferedAsync();

        if (cmdResult.ExitCode != 0)
        {
            _logger.Error("Error executing convert to FLV with no arguments command. Exit code: {ExitCode}", cmdResult.ExitCode);
            throw new Exception("Error executing ffmpeg command");
        }

        _logger.Information("Convert to FLV with no arguments command executed succesfully");
    }
    public async Task ConvertTo3GPWithNoArguments()
    {
        var inputFileName = _commandArguments.InputFileName;

        if (inputFileName is null)
        {
            return;
        }

        var inputFilePath = $"Videos/{inputFileName}";
        var guid = Guid.NewGuid();

        var cmd = WrapCommand($"-i {inputFilePath} -c:v libx264 -b:v 512k -c:a aac -b:a 128k -ar 8000 -ac 1 {_videosFolderName}{guid}.3gp");      

        var cmdResult = await cmd.ExecuteBufferedAsync();

        if (cmdResult.ExitCode != 0)
        {
            _logger.Error("Error executing convert to 3GP with no arguments command. Exit code: {ExitCode}", cmdResult.ExitCode);
            throw new Exception("Error executing ffmpeg command");
        }

        _logger.Information("Convert to 3GP with no arguments command executed succesfully");
    }
    public async Task ConvertToMPEGWithNoArguments()
    {
        var inputFileName = _commandArguments.InputFileName;

        if (inputFileName is null)
        {
            return;
        }

        var inputFilePath = $"Videos/{inputFileName}";
        var guid = Guid.NewGuid();

        var cmd = WrapCommand($"-i {inputFilePath} {_videosFolderName}{guid}.mpeg");

        var cmdResult = await cmd.ExecuteBufferedAsync();

        if (cmdResult.ExitCode != 0)
        {
            _logger.Error("Error executing convert to MPEG with no arguments command. Exit code: {ExitCode}", cmdResult.ExitCode);
            throw new Exception("Error executing ffmpeg command");
        }

        _logger.Information("Convert to MPEG with no arguments command executed succesfully");
    }
    public async Task ConvertToWMVWithNoArguments()
    {
        var inputFileName = _commandArguments.InputFileName;

        if (inputFileName is null)
        {
            return;
        }

        var inputFilePath = $"Videos/{inputFileName}";
        var guid = Guid.NewGuid();

        var cmd = WrapCommand($"-i {inputFilePath} {_videosFolderName}{guid}.wmv");

        var cmdResult = await cmd.ExecuteBufferedAsync();

        if (cmdResult.ExitCode != 0)
        {
            _logger.Error("Error executing convert to WMV with no arguments command. Exit code: {ExitCode}", cmdResult.ExitCode);
            throw new Exception("Error executing ffmpeg command");
        }

        _logger.Information("Convert to VMV with no arguments command executed succesfully");
    }
    public async Task ConvertToGIFWithNoArguments()
    {
        var inputFileName = _commandArguments.InputFileName;

        if (inputFileName is null)
        {
            return;
        }

        var inputFilePath = $"Videos/{inputFileName}";
        var guid = Guid.NewGuid();

        var cmd = WrapCommand($"-i {inputFilePath} -vf scale=320:-1 -r 10 -f gif {_videosFolderName}{guid}.gif");

        var cmdResult = await cmd.ExecuteBufferedAsync();

        if (cmdResult.ExitCode != 0)
        {
            _logger.Error("Error executing convert to GIF with no arguments command. Exit code: {ExitCode}", cmdResult.ExitCode);
            throw new Exception("Error executing ffmpeg command");
        }

        _logger.Information("Convert to GIF with no arguments command executed succesfully");
    }
    public async Task ConvertToSeriesOfImages()
    {
        var inputFileName = _commandArguments.InputFileName;

        if (inputFileName is null)
        {
            return;
        }

        var inputFilePath = $"Videos/{inputFileName}";

        var cmd = WrapCommand($"-i {inputFilePath} -r 1/5 {_videosFolderName}image_%03d.jpg");
        
        var cmdResult = await cmd.ExecuteBufferedAsync();

        if (cmdResult.ExitCode != 0)
        {
            _logger.Error("Error executing convert to series of images command. Exit code: {ExitCode}", cmdResult.ExitCode);
            throw new Exception("Error executing ffmpeg command");
        }

        _logger.Information("Convert to series of images command executed succesfully");
    }
    public async Task ConvertToMP4WithArguments()
    {
        var inputFileName = _commandArguments.InputFileName;

        if (inputFileName is null)
        {
            return;
        }

        var inputFilePath = $"Videos/{inputFileName}";
        var videoCodec = _commandArguments.VideoCodec.GetEnumMemberValue() ?? "libx264";
        var videoBitrate = _commandArguments.VideoBitrate ?? "10000k";
        var preset = _commandArguments.Preset.GetEnumMemberValue() ?? "medium";
        var crf = _commandArguments.Crf ?? "23";
        var audioCodec = _commandArguments.AudioCodec.GetEnumMemberValue() ?? "aac";
        var audioBitrate = _commandArguments.AudioBitrate ?? "128k";
        var guid = Guid.NewGuid();
        var arguments = $"-i {inputFilePath} -c:v {videoCodec} -b:v {videoBitrate} -preset {preset} -crf {crf} -c:a {audioCodec} -b:a {audioBitrate} {_videosFolderName}{guid}.mp4";
        var cts = new CancellationTokenSource();
        var token = cts.Token;

        var cmd = WrapCommand(arguments);

        var cmdResult = await cmd.ExecuteBufferedAsync();

        if (token.IsCancellationRequested)
        {
            cts?.Cancel();
            _logger.Error("Command execution was cancelled");
        }

        if (cmdResult.ExitCode != 0)
        {
            _logger.Error("Error executing convert to MP4 with arguments command. Exit code: {ExitCode}", cmdResult.ExitCode);
            _logger.Error("Command arguments was {arguments}", arguments);
            throw new Exception("Error executing ffmpeg command");
        }

        _logger.Information("Convert to MP4 with arguments command executed succesfully");
    }
    public async Task ConvertToAVIWithArguments()
    {
        var inputFileName = _commandArguments.InputFileName;

        if (inputFileName is null)
        {
            return;
        }

        var inputFilePath = $"Videos/{inputFileName}";
        var videoCodec = _commandArguments.VideoCodec.GetEnumMemberValue() ?? "mpeg4";
        var videoBitrate = _commandArguments.VideoBitrate ?? "500k";
        var preset = _commandArguments.Preset.GetEnumMemberValue() ?? "medium";
        var audioCodec = _commandArguments.AudioCodec.GetEnumMemberValue() ?? "libmp3lame";
        var audioBitrate = _commandArguments.AudioBitrate ?? "128k";
        var guid = Guid.NewGuid();
        var arguments = $"-i {inputFilePath} -c:v {videoCodec} -b:v {videoBitrate} -preset {preset} -q:v 10 -c:a {audioCodec} -b:a {audioBitrate} {_videosFolderName}{guid}.avi";
        var cts = new CancellationTokenSource();
        var token = cts.Token;
        _logger.Information("Command arguments was {arguments}", arguments);

        var cmd = WrapCommand(arguments);

        var cmdResult = await cmd.ExecuteBufferedAsync(token);

        if (token.IsCancellationRequested)
        {
            cts?.Cancel();
            _logger.Error("Command execution was cancelled");
        }

        if (cmdResult.ExitCode != 0)
        {
            _logger.Error("Error executing convert to AVI with arguments command. Exit code: {ExitCode}", cmdResult.ExitCode);
            _logger.Error("Command arguments was {arguments}", arguments);
            throw new Exception("Error executing ffmpeg command");
        }

        _logger.Information("Convert to AVI with arguments command executed succesfully");
    }
    public async Task ConvertToWebMWithArguments()
    {
        var inputFileName = _commandArguments.InputFileName;

        if (inputFileName is null)
        {
            return;
        }

        var inputFilePath = $"Videos/{inputFileName}";
        var videoCodec = _commandArguments.VideoCodec.GetEnumMemberValue() ?? "libvpx-vp9";
        var videoBitrate = _commandArguments.VideoBitrate ?? "0";
        var preset = _commandArguments.Preset.GetEnumMemberValue() ?? "medium";
        var crf = _commandArguments.Crf ?? "30";
        var audioCodec = _commandArguments.AudioCodec.GetEnumMemberValue() ?? "libopus";
        var audioBitrate = _commandArguments.AudioBitrate ?? "128k";
        var guid = Guid.NewGuid();
        var arguments = $"-i {inputFilePath} -c:v {videoCodec} -b:v {videoBitrate} -preset {preset} -crf {crf} -c:a {audioCodec} -b:a {audioBitrate} {_videosFolderName}{guid}.webm";
        var cts = new CancellationTokenSource();
        var token = cts.Token;
        _logger.Information("Command arguments was {arguments}", arguments);

        var cmd = WrapCommand(arguments);

        var cmdResult = await cmd.ExecuteBufferedAsync(token);

        if (token.IsCancellationRequested)
        {
            cts?.Cancel();
            _logger.Error("Command execution was cancelled");
        }

        if (cmdResult.ExitCode != 0)
        {
            _logger.Error("Error executing convert to WebM with arguments command. Exit code: {ExitCode}", cmdResult.ExitCode);
            _logger.Error("Command arguments was {arguments}", arguments);
            throw new Exception("Error executing ffmpeg command");
        }

        _logger.Information("Convert to WebM with arguments command executed succesfully");
    }
    public async Task ConvertToMOVWithArguments()
    {
        var inputFileName = _commandArguments.InputFileName;

        if (inputFileName is null)
        {
            return;
        }

        var inputFilePath = $"Videos/{inputFileName}";
        var videoCodec = _commandArguments.VideoCodec.GetEnumMemberValue() ?? "prores_ks";
        var videoBitrate = _commandArguments.VideoBitrate ?? "12000k";
        var audioCodec = _commandArguments.AudioCodec.GetEnumMemberValue() ?? "pcm_s24le";
        var audioBitrate = _commandArguments.AudioBitrate ?? "320k";
        var guid = Guid.NewGuid();
        var arguments = $"-i {inputFilePath} -c:v {videoCodec} -b:v {videoBitrate} -profile:v 3 -c:a {audioCodec} -b:a {audioBitrate} {_videosFolderName}{guid}.mov";
        var cts = new CancellationTokenSource();
        var token = cts.Token;
        _logger.Information("Command arguments was {arguments}", arguments);

        var cmd = WrapCommand(arguments);

        var cmdResult = await cmd.ExecuteBufferedAsync(token);

        if (token.IsCancellationRequested)
        {
            cts?.Cancel();
            _logger.Error("Command execution was cancelled");
        }

        if (cmdResult.ExitCode != 0)
        {
            _logger.Error("Error executing convert to MOV with arguments command. Exit code: {ExitCode}", cmdResult.ExitCode);
            _logger.Error("Command arguments was {arguments}", arguments);
            throw new Exception("Error executing ffmpeg command");
        }

        _logger.Information("Convert to MOV with arguments command executed succesfully");
    }
    public async Task ConvertToMKVWithArguments()
    {
        var inputFileName = _commandArguments.InputFileName;

        if (inputFileName is null)
        {
            return;
        }

        var inputFilePath = $"Videos/{inputFileName}";
        var videoCodec = _commandArguments.VideoCodec.GetEnumMemberValue() ?? "libx264"; //to change
        var videoBitrate = _commandArguments.VideoBitrate ?? "12000k";
        var preset = _commandArguments.Preset.GetEnumMemberValue() ?? "slow";
        var crf = _commandArguments.Crf ?? "22";
        var audioCodec = _commandArguments.AudioCodec.GetEnumMemberValue() ?? "aac";
        var audioBitrate = _commandArguments.AudioBitrate ?? "192k";
        var guid = Guid.NewGuid();
        var arguments = $"-i {inputFilePath} -c:v {videoCodec} -b:v {videoBitrate} -preset {preset} -crf {crf}  -c:a {audioCodec} -b:a {audioBitrate} {_videosFolderName}{guid}.mkv";
        var cts = new CancellationTokenSource();
        var token = cts.Token;
        _logger.Information("Command arguments was {arguments}", arguments);

        var cmd = WrapCommand(arguments);

        var cmdResult = await cmd.ExecuteBufferedAsync(token);

        if (token.IsCancellationRequested)
        {
            cts?.Cancel();
            _logger.Error("Command execution was cancelled");
        }

        if (cmdResult.ExitCode != 0)
        {
            _logger.Error("Error executing convert to MKV with arguments command. Exit code: {ExitCode}", cmdResult.ExitCode);
            _logger.Error("Command arguments was {arguments}", arguments);
            throw new Exception("Error executing ffmpeg command");
        }

        _logger.Information("Convert to MKV with arguments command executed succesfully");
    }
}
