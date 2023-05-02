using CliWrap;
using CliWrap.Buffered;
using Serilog;
using VideoConverterApi.Interfaces;
using VideoConverterApi.Models;

namespace VideoConverterApi.Services;

public class VideoToolsService : IVideoToolsService
{
    private readonly Serilog.ILogger _logger;
    private readonly string _videosFolderName = "Videos/";

    public VideoToolsService()
    {
        _logger = new LoggerConfiguration()
            .WriteTo.File("VideoToolsServiceLogs.txt")
            .CreateLogger();
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

    public async Task RotateVideoByAngleAsync()
    {

    }
    public async Task CropVideoAsync()
    {

    }

    public async Task CutVideoAsync()
    {

    }

    public async Task ReflectVideoAsync()
    {

    }

    public async Task RemoveAudioAsync()
    {

    }

    public async Task ChangeVideoBitrateAsync()
    {

    }

    public async Task ChangeAudioBitrateAsync()
    {

    }

    public async Task ExtractAudioAsync()
    {

    }

    public async Task WebOptimizeVideoAsync()
    {

    }

    public async Task AddWatermarkAsync()
    {

    }

    public async Task AddAudioAsync()
    {

    }

    public async Task AddSubtitlesAsync()
    {

    }

    public async Task ChangeVideoSpeedAsync()
    {

    }

    public async Task ChangeAudioVolumeAsync()
    {

    }

    public async Task ChangeVideoResolutionAsync()
    {

    }

    public async Task ExtractSingleFrameAsync()
    {

    }

    public async Task MergeVideosAsync()
    {

    }
}
