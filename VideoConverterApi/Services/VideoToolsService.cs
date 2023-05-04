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
    public async Task ReverseVideoAsync(InputFileArguments inputFileArguments)
    {
        if (inputFileArguments is null)
        {
            return;
        }

        var inputFileName = inputFileArguments.InputFileName;
        var extension = inputFileName?[(inputFileName.IndexOf('.')+1)..];
        var inputFilePath = $"{_videosFolderName}{inputFileName}";
        var guid = Guid.NewGuid();

        var cmd = WrapCommand($"-i {inputFilePath} -vf reverse -af areverse {_videosFolderName}{guid}.{extension}");

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
        var arguments = $"-i {inputFilePath} -vf rotate={angleToRotate}*PI/180 {_videosFolderName}{guid}.{extension}";
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
        var arguments = $"-i {inputFilePath} -filter:v crop={height}:{width}:{x}:{y} {_videosFolderName}{guid}.{extension}";
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
        var arguments = $"-i {inputFilePath} -ss {fromHours}:{fromMinutes}:{fromSeconds} -to {toHours}:{toMinutes}:{toSeconds} -c copy {_videosFolderName}{guid}.{extension}";
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

    private static int ToSeconds(int hours, int minutes, int seconds)
    {
        return hours * 3600 + minutes * 60 + seconds;
    }

    public async Task ReflectVideoAsync(ReflectVideoArguments reflectVideoArguments)
    {
        if (reflectVideoArguments is null)
        {
            return;
        }

        var inputFileName = reflectVideoArguments.InputFileName;
        var extension = inputFileName?[(inputFileName.IndexOf('.') + 1)..];
        var inputFilePath = $"{_videosFolderName}{inputFileName}";
        var reflectHorozontally = reflectVideoArguments.ReflectHorizontally;
        var reflectVertically = reflectVideoArguments.ReflectVertically;
        var guid = Guid.NewGuid();
        string? arguments;

        if(reflectHorozontally && reflectVertically)
        {
            arguments = $"-i {inputFilePath}  {_videosFolderName}{guid}.{extension}";
        }
        else if (reflectHorozontally)
        {
            arguments = $"-i {inputFilePath}  {_videosFolderName}{guid}.{extension}";
        }
        else
        {
            arguments = $"-i {inputFilePath}  {_videosFolderName}{guid}.{extension}";
        }
        
        _logger.Information(arguments);

        var cmd = WrapCommand(arguments);

        var cmdResult = await cmd.ExecuteBufferedAsync();

        if (cmdResult.ExitCode != 0)
        {
            _logger.Error("Error executing reflect video command. Exit code: {ExitCode}", cmdResult.ExitCode);
            throw new Exception("Error executing ffmpeg command");
        }

        _logger.Information("Reflect video command executed succesfully");
    }

    public async Task RemoveAudioAsync(InputFileArguments inputFileArguments)
    {
        if (inputFileArguments is null)
        {
            return;
        }

        var inputFileName = inputFileArguments.InputFileName;
        var extension = inputFileName?[(inputFileName.IndexOf('.') + 1)..];
        var inputFilePath = $"{_videosFolderName}{inputFileName}";

        var guid = Guid.NewGuid();
        var arguments = $"-i {inputFilePath} -c:v copy -an {_videosFolderName}{guid}.{extension}";
        _logger.Information(arguments);

        var cmd = WrapCommand(arguments);

        var cmdResult = await cmd.ExecuteBufferedAsync();

        if (cmdResult.ExitCode != 0)
        {
            _logger.Error("Error executing remove audio command. Exit code: {ExitCode}", cmdResult.ExitCode);
            throw new Exception("Error executing ffmpeg command");
        }

        _logger.Information("Remove audio command executed succesfully");
    }

    public async Task ChangeVideoBitrateAsync(ChangeVideoBitrateArguments changeVideoBitrateArguments)
    {
        if (changeVideoBitrateArguments is null)
        {
            return;
        }

        var inputFileName = changeVideoBitrateArguments.InputFileName;
        var extension = inputFileName?[(inputFileName.IndexOf('.') + 1)..];
        var inputFilePath = $"{_videosFolderName}{inputFileName}";
        var videoBitrate = changeVideoBitrateArguments.VideoBitrate;

        var guid = Guid.NewGuid();
        var arguments = $"-i {inputFilePath} -b:v {videoBitrate} {_videosFolderName}{guid}.{extension}";
        _logger.Information(arguments);

        var cmd = WrapCommand(arguments);

        var cmdResult = await cmd.ExecuteBufferedAsync();

        if (cmdResult.ExitCode != 0)
        {
            _logger.Error("Error executing change video bitrate command. Exit code: {ExitCode}", cmdResult.ExitCode);
            throw new Exception("Error executing ffmpeg command");
        }

        _logger.Information("Change video bitrate command executed succesfully");
    }

    public async Task ChangeAudioBitrateAsync(ChangeAudioBitrateArguments changeAudioBitrateArguments)
    {
        if (changeAudioBitrateArguments is null)
        {
            return;
        }

        var inputFileName = changeAudioBitrateArguments.InputFileName;
        var extension = inputFileName?[(inputFileName.IndexOf('.') + 1)..];
        var inputFilePath = $"{_videosFolderName}{inputFileName}";
        var audioBitrate = changeAudioBitrateArguments.AudioBitrate;

        var guid = Guid.NewGuid();
        var arguments = $"-i {inputFilePath} -b:a {audioBitrate} {_videosFolderName}{guid}.{extension}";
        _logger.Information(arguments);

        var cmd = WrapCommand(arguments);

        var cmdResult = await cmd.ExecuteBufferedAsync();

        if (cmdResult.ExitCode != 0)
        {
            _logger.Error("Error executing change audio bitrate command. Exit code: {ExitCode}", cmdResult.ExitCode);
            throw new Exception("Error executing ffmpeg command");
        }

        _logger.Information("Change audio bitrate command executed succesfully");
    }

    public async Task ExtractAudioAsync(InputFileArguments inputFileArguments)
    {
        if (inputFileArguments is null)
        {
            return;
        }

        var inputFileName = inputFileArguments.InputFileName;
        var inputFilePath = $"{_videosFolderName}{inputFileName}";

        var guid = Guid.NewGuid();
        var arguments = $"-i {inputFilePath} -vn {_videosFolderName}{guid}.mp3";
        _logger.Information(arguments);

        var cmd = WrapCommand(arguments);

        var cmdResult = await cmd.ExecuteBufferedAsync();

        if (cmdResult.ExitCode != 0)
        {
            _logger.Error("Error executing extract audio command. Exit code: {ExitCode}", cmdResult.ExitCode);
            throw new Exception("Error executing ffmpeg command");
        }

        _logger.Information("Extract audio command executed succesfully");
    }

    public async Task WebOptimizeVideoAsync(InputFileArguments inputFileArguments)
    {
        if (inputFileArguments is null)
        {
            return;
        }

        var inputFileName = inputFileArguments.InputFileName;
        var extension = inputFileName?[(inputFileName.IndexOf('.') + 1)..];
        var inputFilePath = $"{_videosFolderName}{inputFileName}";

        var guid = Guid.NewGuid();
        var arguments = $"-i {inputFilePath} -movflags +faststart {_videosFolderName}{guid}.{extension}";
        _logger.Information(arguments);

        var cmd = WrapCommand(arguments);

        var cmdResult = await cmd.ExecuteBufferedAsync();

        if (cmdResult.ExitCode != 0)
        {
            _logger.Error("Error executing web optimize video command. Exit code: {ExitCode}", cmdResult.ExitCode);
            throw new Exception("Error executing ffmpeg command");
        }

        _logger.Information("Web optimize video command executed succesfully");
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

    public async Task ChangeVideoSpeedAsync(ChangeVideoSpeedArguments changeVideoBitrateArguments)
    {
        if (changeVideoBitrateArguments is null)
        {
            return;
        }

        var inputFileName = changeVideoBitrateArguments.InputFileName;
        var extension = inputFileName?[(inputFileName.IndexOf('.') + 1)..];
        var inputFilePath = $"{_videosFolderName}{inputFileName}";
        var speedChangeCoefficient = changeVideoBitrateArguments.SpeedChangeCoefficient;
        var guid = Guid.NewGuid();
        var arguments = $"-i {inputFilePath}  {_videosFolderName}{guid}.{extension}";
        _logger.Information(arguments);

        var cmd = WrapCommand(arguments);

        var cmdResult = await cmd.ExecuteBufferedAsync();

        if (cmdResult.ExitCode != 0)
        {
            _logger.Error("Error executing change video speed command. Exit code: {ExitCode}", cmdResult.ExitCode);
            throw new Exception("Error executing ffmpeg command");
        }

        _logger.Information("Change video speed command executed succesfully");
    }

    public async Task ChangeAudioVolumeAsync(ChangeAudioVolumeArguments changeAudioVolumeArguments)
    {
        if (changeAudioVolumeArguments is null)
        {
            return;
        }

        var inputFileName = changeAudioVolumeArguments.InputFileName;
        var extension = inputFileName?[(inputFileName.IndexOf('.') + 1)..];
        var inputFilePath = $"{_videosFolderName}{inputFileName}";
        var speedChangeCoefficient = changeAudioVolumeArguments.VolumeChangeCoefficient;
        var guid = Guid.NewGuid();
        var arguments = $"-i {inputFilePath}  {_videosFolderName}{guid}.{extension}";
        _logger.Information(arguments);

        var cmd = WrapCommand(arguments);

        var cmdResult = await cmd.ExecuteBufferedAsync();

        if (cmdResult.ExitCode != 0)
        {
            _logger.Error("Error executing change video speed command. Exit code: {ExitCode}", cmdResult.ExitCode);
            throw new Exception("Error executing ffmpeg command");
        }

        _logger.Information("Change video speed command executed succesfully");
    }

    public async Task ChangeVideoResolutionAsync()
    {

    }

    public async Task ExtractSingleFrameAsync(ExtractSingleFrameArguments extractSingleFrameArguments)
    {
        if (extractSingleFrameArguments is null)
        {
            return;
        }

        var inputFileName = extractSingleFrameArguments.InputFileName;
        var inputFilePath = $"{_videosFolderName}{inputFileName}";
        var hour = extractSingleFrameArguments.Hour;
        var minute = extractSingleFrameArguments.Minute;
        var second = extractSingleFrameArguments.Second;
        var framenumber = extractSingleFrameArguments.FrameNumber;
        var metadata = _mediaMetadataService.GetMediaMetadata(inputFilePath);
        var durationInSeconds = ToSeconds(hour, minute, second);

        if (durationInSeconds > metadata.Duration || framenumber > metadata.FrameRate)
        {
            return;
        }

        var guid = Guid.NewGuid();
        var arguments = $"-i {inputFilePath} -ss {hour}:{minute}:{second} -frames:v {framenumber} {_videosFolderName}{guid}.jpg";
        _logger.Information(arguments);

        var cmd = WrapCommand(arguments);

        var cmdResult = await cmd.ExecuteBufferedAsync();

        if (cmdResult.ExitCode != 0)
        {
            _logger.Error("Error executing extract single frame command. Exit code: {ExitCode}", cmdResult.ExitCode);
            throw new Exception("Error executing ffmpeg command");
        }

        _logger.Information("Extract single frame command executed succesfully");
    }

    public async Task MergeVideosAsync()
    {

    }
}
