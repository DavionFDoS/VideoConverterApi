using VideoConverterApi.Models;
using CliWrap;
using CliWrap.Buffered;
using Serilog;
using VideoConverterApi.Interfaces;

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
        var inputFilePath = $"Videos/{inputFileName}";

        var cmd = Cli.Wrap("ffmpeg")
            .WithArguments($"-i {inputFilePath} {_videosFolderName}outputSimple.mp4")
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
        var inputFilePath = $"Videos/{inputFileName}";

        var cmd = Cli.Wrap("ffmpeg")
            .WithArguments($"-i {inputFilePath} {_videosFolderName}outputSimple.avi")
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
        var inputFilePath = $"Videos/{inputFileName}";

        var cmd = Cli.Wrap("ffmpeg")
            .WithArguments($"-i {inputFilePath} {_videosFolderName}outputSimple.webm")
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
    public async Task ConvertToMP4WithArguments()
    {

    }
    public async Task ConvertToAVIWithArguments()
    {

    }
    public async Task ConvertToWebMWithArguments()
    {

    }
    public async Task ConvertToMOVWithArguments()
    {

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
