using VideoConverterApi.Models;
using CliWrap;
using CliWrap.Buffered;
using Serilog;
using VideoConverterApi.Interfaces;
using Microsoft.OpenApi.Extensions;
using VideoConverterApi.Enums;
using VideoConverterApi.Extensions;

namespace VideoConverterApi.Services;

public class FFMpegCommandHandler : IFFMpegCommandHandler
{
    private readonly CommandArguments _commandArguments;
    private readonly Serilog.ILogger _logger;
    private readonly string _videosFolderName = "Videos/";
    public FFMpegCommandHandler(CommandArguments commandArguments)
    {
        _commandArguments = commandArguments;
        _logger = new LoggerConfiguration()
            .WriteTo.File("logs.txt")
            .CreateLogger();
    }

    public async Task ConvertToMP4WithNoArguments()
    {
        var inputFileName = _commandArguments.InputFileName;

        if (inputFileName is null)
        {
            return;
        }

        var inputFilePath = $"Videos/{inputFileName}";

        var cmd = Cli.Wrap("ffmpeg")
            .WithArguments($"-i {inputFilePath} {_videosFolderName}output.mp4")
            .WithValidation(CommandResultValidation.None)
            .WithStandardErrorPipe(PipeTarget.ToDelegate(_logger.Error))
            .WithStandardOutputPipe(PipeTarget.ToDelegate(_logger.Information));

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

        var cmd = Cli.Wrap("ffmpeg")
            .WithArguments($"-i {inputFilePath} {_videosFolderName}output.avi")
            .WithValidation(CommandResultValidation.None)
            .WithStandardErrorPipe(PipeTarget.ToDelegate(_logger.Error))
            .WithStandardOutputPipe(PipeTarget.ToDelegate(_logger.Information));

        var cmdResult = await cmd.ExecuteBufferedAsync();

        if (cmdResult.ExitCode != 0)
        {
            _logger.Error("Error executing convert to AVI with no arguments command. Exit code: {ExitCode}", cmdResult.ExitCode);
            throw new Exception("Error executing ffmpeg command");
        }

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

        var cmd = Cli.Wrap("ffmpeg")
            .WithArguments($"-i {inputFilePath} {_videosFolderName}output.webm")
            .WithValidation(CommandResultValidation.None)
            .WithStandardErrorPipe(PipeTarget.ToDelegate(_logger.Error))
            .WithStandardOutputPipe(PipeTarget.ToDelegate(_logger.Information));

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

        var cmd = Cli.Wrap("ffmpeg")
            .WithArguments($"-i {inputFilePath} {_videosFolderName}outputSimple.mov")
            .WithValidation(CommandResultValidation.None)
            .WithStandardErrorPipe(PipeTarget.ToDelegate(_logger.Error))
            .WithStandardOutputPipe(PipeTarget.ToDelegate(_logger.Information));

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

        var cmd = Cli.Wrap("ffmpeg")
            .WithArguments($"-i {inputFilePath} {_videosFolderName}outputSimple.mkv")
            .WithValidation(CommandResultValidation.None)
            .WithStandardErrorPipe(PipeTarget.ToDelegate(_logger.Error))
            .WithStandardOutputPipe(PipeTarget.ToDelegate(_logger.Information));

        var cmdResult = await cmd.ExecuteBufferedAsync();

        if (cmdResult.ExitCode != 0)
        {
            _logger.Error("Error executing convert to MKV with no arguments command. Exit code: {ExitCode}", cmdResult.ExitCode);
            throw new Exception("Error executing ffmpeg command");
        }

        _logger.Information("Convert to MKV with no arguments command executed succesfully");
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

        var cmd = Cli.Wrap("ffmpeg")
            .WithArguments(arguments)
            .WithValidation(CommandResultValidation.None)
            .WithStandardErrorPipe(PipeTarget.ToDelegate(_logger.Error))
            .WithStandardOutputPipe(PipeTarget.ToDelegate(_logger.Information));

        var cmdResult = await cmd.ExecuteBufferedAsync();

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

        var cmd = Cli.Wrap("ffmpeg")
            .WithArguments(arguments)
            .WithValidation(CommandResultValidation.None)
            .WithStandardErrorPipe(PipeTarget.ToDelegate(_logger.Error))
            .WithStandardOutputPipe(PipeTarget.ToDelegate(_logger.Information));

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

        var cmd = Cli.Wrap("ffmpeg")
            .WithArguments(arguments)
            .WithValidation(CommandResultValidation.None)
            .WithStandardErrorPipe(PipeTarget.ToDelegate(_logger.Error))
            .WithStandardOutputPipe(PipeTarget.ToDelegate(_logger.Information));

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

        var cmd = Cli.Wrap("ffmpeg")
            .WithArguments(arguments)
            .WithValidation(CommandResultValidation.None)
            .WithStandardErrorPipe(PipeTarget.ToDelegate(_logger.Error))
            .WithStandardOutputPipe(PipeTarget.ToDelegate(_logger.Information));

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
        var videoCodec = _commandArguments.VideoCodec.GetEnumMemberValue() ?? "prores_ks";
        var videoBitrate = _commandArguments.VideoBitrate ?? "12000k";
        var audioCodec = _commandArguments.AudioCodec.GetEnumMemberValue() ?? "pcm_s24le";
        var audioBitrate = _commandArguments.AudioBitrate ?? "320k";
        var guid = Guid.NewGuid();
        var arguments = $"-i {inputFilePath} -c:v {videoCodec} -b:v {videoBitrate} -profile:v 3 -c:a {audioCodec} -b:a {audioBitrate} {_videosFolderName}{guid}.mov";
        var cts = new CancellationTokenSource();
        var token = cts.Token;
        _logger.Information("Command arguments was {arguments}", arguments);

        var cmd = Cli.Wrap("ffmpeg")
            .WithArguments(arguments)
            .WithValidation(CommandResultValidation.None)
            .WithStandardErrorPipe(PipeTarget.ToDelegate(_logger.Error))
            .WithStandardOutputPipe(PipeTarget.ToDelegate(_logger.Information));

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
    public async Task ReverseVideoAsync()
    {
        var inputFileName = _commandArguments.InputFileName;
        var inputFilePath = $"Videos/{inputFileName}";

        var cmd = Cli.Wrap("ffmpeg")
            .WithArguments($"-i {inputFilePath} -vf reverse -af areverse {_videosFolderName}outputReversed.mp4")
            .WithValidation(CommandResultValidation.None)
            .WithStandardErrorPipe(PipeTarget.ToDelegate(_logger.Error))
            .WithStandardOutputPipe(PipeTarget.ToDelegate(_logger.Information));

        var cmdResult = await cmd.ExecuteBufferedAsync();

        if (cmdResult.ExitCode != 0)
        {
            _logger.Error("Error executing reverse video command. Exit code: {ExitCode}", cmdResult.ExitCode);
            throw new Exception("Error executing ffmpeg command");
        }

        _logger.Information("Reverse video command executed succesfully");
    }
}
