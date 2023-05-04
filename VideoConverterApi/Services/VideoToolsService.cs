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
    private readonly MediaMetadataService _mediaMetadataService = new();

    public VideoToolsService()
    {
        _logger = new LoggerConfiguration()
            .WriteTo.File("VideoToolsServiceLogs.txt")
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
    public async Task ReverseVideoAsync(ReverseVideoArguments reverseVideoArguments)
    {
        if (reverseVideoArguments is null)
        {
            return;
        }

        var inputFileName = reverseVideoArguments.InputFileName;
        var extension = inputFileName?[(inputFileName.IndexOf('.')+1)..];
        var inputFilePath = $"{_videosFolderName}{inputFileName}";
        var guid = Guid.NewGuid();

        var cmd = WrapCommand($"-i {inputFilePath} -vf reverse -af areverse {_videosFolderName}{guid}Reversed.{extension}");

        var cmdResult = await cmd.ExecuteBufferedAsync();

        if (cmdResult.ExitCode != 0)
        {
            _logger.Error("Error executing reverse video command. Exit code: {ExitCode}", cmdResult.ExitCode);
            throw new Exception("Error executing ffmpeg command");
        }

        _logger.Information("Reverse video command executed succesfully");
    }

    public async Task RotateVideoByAngleAsync(RotateVideoArguments rotateVideoArguments)
    {
        if (rotateVideoArguments is null)
        {
            return;
        }

        var inputFileName = rotateVideoArguments.InputFileName;
        var extension = inputFileName?[(inputFileName.IndexOf('.') + 1)..];
        var angleToRotate = rotateVideoArguments.AngleToRotate;
        var inputFilePath = $"{_videosFolderName}{inputFileName}";
        var guid = Guid.NewGuid();
        var arguments = $"-i {inputFilePath} -vf rotate={angleToRotate}*PI/180 {_videosFolderName}{guid}Rotated.{extension}";
        _logger.Information(arguments);

        var cmd = WrapCommand(arguments);

        var cmdResult = await cmd.ExecuteBufferedAsync();

        if (cmdResult.ExitCode != 0)
        {
            _logger.Error("Error executing rota video by angle command. Exit code: {ExitCode}", cmdResult.ExitCode);
            throw new Exception("Error executing ffmpeg command");
        }

        _logger.Information("Rotate video by angle command executed succesfully");
    }
    public async Task CropVideoAsync(CropVideoArguments cropVideoArguments)
    {
        if (cropVideoArguments is null)
        {
            return;
        }

        var inputFileName = cropVideoArguments.InputFileName;
        var extension = inputFileName?[(inputFileName.IndexOf('.') + 1)..];
        var height = cropVideoArguments.Height;
        var width = cropVideoArguments.Width;
        var x = cropVideoArguments.X;
        var y = cropVideoArguments.Y;
        var inputFilePath = $"{_videosFolderName}{inputFileName}";
        var metadata = _mediaMetadataService.GetMediaMetadata(inputFilePath);
        var videoHeight = metadata.Height;
        var videoWidth = metadata.Width;        

        if (height > videoHeight || width > videoWidth)
        {
            return;
        }

        var guid = Guid.NewGuid();
        var arguments = $"-i {inputFilePath} -filter:v crop={height}:{width}:{x}:{y} {_videosFolderName}{guid}Croped.{extension}";
        _logger.Information(arguments);

        var cmd = WrapCommand(arguments);

        var cmdResult = await cmd.ExecuteBufferedAsync();

        if (cmdResult.ExitCode != 0)
        {
            _logger.Error("Error executing crop video command. Exit code: {ExitCode}", cmdResult.ExitCode);
            throw new Exception("Error executing ffmpeg command");
        }

        _logger.Information("Crop video command executed succesfully");
    }

    public async Task CutVideoAsync(CutVideoArguments cutVideoArgunents)
    {
        if (cutVideoArgunents is null)
        {
            return;
        }

        var inputFileName = cutVideoArgunents.InputFileName;
        var extension = inputFileName?[(inputFileName.IndexOf('.') + 1)..];
        var fromHours = cutVideoArgunents.FromHours;
        var fromMinutes = cutVideoArgunents.FromMinutes;
        var fromSeconds = cutVideoArgunents.FromSeconds;
        var toHours = cutVideoArgunents.ToHours;
        var toMinutes = cutVideoArgunents.ToMinutes;
        var toSeconds = cutVideoArgunents.ToSeconds;

        var fromInSeconds = ToSeconds(fromHours, fromMinutes, fromSeconds);
        var toInSeconds = ToSeconds(toHours, toMinutes, toSeconds);

        var inputFilePath = $"{_videosFolderName}{inputFileName}";
        var duration = _mediaMetadataService.GetMediaMetadata(inputFilePath).Duration;

        if (fromInSeconds >= duration || toInSeconds > duration)
        {
            return;
        }

        var guid = Guid.NewGuid();
        var arguments = $"-i {inputFilePath} -ss {fromHours}:{fromMinutes}:{fromSeconds} -to {toHours}:{toMinutes}:{toSeconds} -c copy {_videosFolderName}{guid}Cuted.{extension}";
        _logger.Information(arguments);

        var cmd = WrapCommand(arguments);

        var cmdResult = await cmd.ExecuteBufferedAsync();

        if (cmdResult.ExitCode != 0)
        {
            _logger.Error("Error executing cut video command. Exit code: {ExitCode}", cmdResult.ExitCode);
            throw new Exception("Error executing ffmpeg command");
        }

        _logger.Information("Cut video command executed succesfully");
    }

    private int ToSeconds(int hours, int minutes, int seconds)
    {
        return hours * 3600 + minutes * 60 + seconds;
    }

    public async Task ReflectVideoAsync(ReflectVideoArguments reflectVideoArguments)
    {

    }

    public async Task RemoveAudioAsync(RemoveVideoArguments removeVideoArguments)
    {

    }

    public async Task ChangeVideoBitrateAsync(ChangeVideoBitrateArguments changeVideoBitrateArguments)
    {

    }

    public async Task ChangeAudioBitrateAsync(ChangeAudioBitrateArguments changeAudioBitrateArguments)
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
