using CliWrap;
using CliWrap.Buffered;
using Serilog;
using System.Text;
using VideoConverterApi.Extensions;
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
            arguments = $"-i {inputFilePath} -vf hflip,vflip {_videosFolderName}{guid}.{extension}";
        }
        else if (reflectHorozontally)
        {
            arguments = $"-i {inputFilePath} -vf hflip {_videosFolderName}{guid}.{extension}";
        }
        else if (reflectVertically)
        {
            arguments = $"-i {inputFilePath} -vf vflip {_videosFolderName}{guid}.{extension}";
        }
        else
        {
            arguments = null;
        }

        if (arguments is not null)
        {
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
        var arguments = $"-i {inputFilePath} -b:v {videoBitrate} {videoBitrate} {_videosFolderName}{guid}.{extension}";
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

    public async Task AddWatermarkAsync(AddWatermarkArguments addWaterMarkArguments)
    {
        if (addWaterMarkArguments is null)
        {
            return;
        }

        var inputFileName = addWaterMarkArguments.InputFileName;
        var extension = inputFileName?[(inputFileName.IndexOf('.') + 1)..];
        var inputFilePath = $"{_videosFolderName}{inputFileName}";
        var watermarkFileName = addWaterMarkArguments.WatermarkFileName;

        if (watermarkFileName is null)
        {
            return;
        }

        var watermarkFilePath = $"{_videosFolderName}{watermarkFileName}";
        var x = addWaterMarkArguments.X;
        var y = addWaterMarkArguments.Y;
        var guid = Guid.NewGuid();
        var arguments = $"-i {inputFilePath} -i {watermarkFilePath} -filter_complex overlay={x}:{y} {_videosFolderName}{guid}.{extension}";
        _logger.Information(arguments);

        var cmd = WrapCommand(arguments);

        var cmdResult = await cmd.ExecuteBufferedAsync();

        if (cmdResult.ExitCode != 0)
        {
            _logger.Error("Error executing add watermark command. Exit code: {ExitCode}", cmdResult.ExitCode);
            throw new Exception("Error executing ffmpeg command");
        }

        _logger.Information("Add watermark command executed succesfully");
    }

    public async Task AddAudioAsync(AddAudioArguments addAudioArguments)
    {
        if (addAudioArguments is null)
        {
            return;
        }

        var inputFileName = addAudioArguments.InputFileName;
        var extension = inputFileName?[(inputFileName.IndexOf('.') + 1)..];
        var inputFilePath = $"{_videosFolderName}{inputFileName}";
        var audioFileName = addAudioArguments.AudioFileName;
        var audioFilePath = $"{_videosFolderName}{audioFileName}";
        var guid = Guid.NewGuid();
        var arguments = $"-i {inputFilePath} -i {audioFilePath} -c copy -shortest {_videosFolderName}{guid}.{extension}";
        _logger.Information(arguments);

        var cmd = WrapCommand(arguments);

        var cmdResult = await cmd.ExecuteBufferedAsync();

        if (cmdResult.ExitCode != 0)
        {
            _logger.Error("Error executing add audio command. Exit code: {ExitCode}", cmdResult.ExitCode);
            throw new Exception("Error executing ffmpeg command");
        }

        _logger.Information("Add audio command executed succesfully");
    }

    public async Task AddSubtitlesAsync(AddSubtitlesArguments addSubtitlesArguments)
    {
        if (addSubtitlesArguments is null)
        {
            return;
        }

        var inputFileName = addSubtitlesArguments.InputFileName;
        var extension = inputFileName?[(inputFileName.IndexOf('.') + 1)..];
        var inputFilePath = $"{_videosFolderName}{inputFileName}";
        var subtitlesFileName = addSubtitlesArguments.SubtitlesFileName;
        var subtitlesFilePath = $"{_videosFolderName}{subtitlesFileName}";
        var subtitlesExtension = subtitlesFileName?[(subtitlesFileName.IndexOf('.') + 1)..];
        var guid = Guid.NewGuid();
        string? arguments = null;

        if (subtitlesExtension == "srt")
        {
            arguments = $"-i {inputFilePath} -vf subtitles={subtitlesFilePath} -c:s mov_text  {_videosFolderName}{guid}.{extension}";
            _logger.Information(arguments);
        }
        
        if(subtitlesExtension == "ass")
        {
            arguments = $"-i {inputFilePath} -vf ass={subtitlesFilePath} -c:s mov_text  {_videosFolderName}{guid}.{extension}";
            _logger.Information(arguments);
        }

        if(arguments is null)
        {
            return;
        }

        var cmd = WrapCommand(arguments);

        var cmdResult = await cmd.ExecuteBufferedAsync();

        if (cmdResult.ExitCode != 0)
        {
            _logger.Error("Error executing add subtitles command. Exit code: {ExitCode}", cmdResult.ExitCode);
            throw new Exception("Error executing ffmpeg command");
        }

        _logger.Information("Add subtitles command executed succesfully");
    }

    public async Task ChangeVideoSpeedAsync(ChangeVideoSpeedArguments changeVideoSpeedArguments)
    {
        if (changeVideoSpeedArguments is null)
        {
            return;
        }

        var inputFileName = changeVideoSpeedArguments.InputFileName;
        var extension = inputFileName?[(inputFileName.IndexOf('.') + 1)..];
        var inputFilePath = $"{_videosFolderName}{inputFileName}";
        var speedChangeCoefficient = changeVideoSpeedArguments.SpeedChangeCoefficient;
        var guid = Guid.NewGuid();
        var arguments = $"-i {inputFilePath} -filter_complex [0:v]setpts={speedChangeCoefficient.ToString().Replace(',', '.')}*PTS[v];[0:a]atempo={Math.Round(1/speedChangeCoefficient,2).ToString().Replace(',', '.')}[a] -map [v] -map [a] {_videosFolderName}{guid}.{extension}";
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

    public async Task ChangeVideoFramerateAsync(ChangeVideoFramerateArguments changeVideoFramerateArguments)
    {
        if (changeVideoFramerateArguments is null)
        {
            return;
        }

        var inputFileName = changeVideoFramerateArguments.InputFileName;
        var extension = inputFileName?[(inputFileName.IndexOf('.') + 1)..];
        var inputFilePath = $"{_videosFolderName}{inputFileName}";
        var desiredFramerate = changeVideoFramerateArguments.DesiredFramerate;

        if(desiredFramerate < 0)
        {
            return;
        }

        var guid = Guid.NewGuid();
        var arguments = $"-i {inputFilePath} -r {desiredFramerate} {_videosFolderName}{guid}.{extension}";
        _logger.Information(arguments);

        var cmd = WrapCommand(arguments);

        var cmdResult = await cmd.ExecuteBufferedAsync();

        if (cmdResult.ExitCode != 0)
        {
            _logger.Error("Error executing change video framerate command. Exit code: {ExitCode}", cmdResult.ExitCode);
            throw new Exception("Error executing ffmpeg command");
        }

        _logger.Information("Change video framerate command executed succesfully");
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
        var volumeChangeCoefficient = changeAudioVolumeArguments.VolumeChangeCoefficient;
        var guid = Guid.NewGuid();
        var arguments = $"-i {inputFilePath} -filter:a volume={volumeChangeCoefficient.ToString().Replace(',', '.')} {_videosFolderName}{guid}.{extension}";
        _logger.Information(arguments);

        var cmd = WrapCommand(arguments);

        var cmdResult = await cmd.ExecuteBufferedAsync();

        if (cmdResult.ExitCode != 0)
        {
            _logger.Error("Error executing change audio volume command. Exit code: {ExitCode}", cmdResult.ExitCode);
            throw new Exception("Error executing ffmpeg command");
        }

        _logger.Information("Change audio volume command executed succesfully");
    }

    public async Task ChangeVideoResolutionAsync(ChangeVideoResolutionArguments changeVideoResolutionArguments)
    {
        if (changeVideoResolutionArguments is null)
        {
            return;
        }

        var inputFileName = changeVideoResolutionArguments.InputFileName;
        var extension = inputFileName?[(inputFileName.IndexOf('.') + 1)..];
        var inputFilePath = $"{_videosFolderName}{inputFileName}";
        var resolution = changeVideoResolutionArguments.Resolution.GetEnumMemberValue();
        var guid = Guid.NewGuid();
        var arguments = $"-i {inputFilePath} -vf scale={resolution} -c:a copy {_videosFolderName}{guid}.{extension}";
        _logger.Information(arguments);

        var cmd = WrapCommand(arguments);

        var cmdResult = await cmd.ExecuteBufferedAsync();

        if (cmdResult.ExitCode != 0)
        {
            _logger.Error("Error executing change audio volume command. Exit code: {ExitCode}", cmdResult.ExitCode);
            throw new Exception("Error executing ffmpeg command");
        }

        _logger.Information("Change audio volume command executed succesfully");
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
        var arguments = $"-i {inputFilePath} -ss {hour}:{minute}:{second} -vframes 1 {_videosFolderName}{guid}.png";
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

    public async Task MergeVideosAsync(MergeVideosArguments mergeVideosArguments)
    {
        if (mergeVideosArguments is null)
        {
            return;
        }

        var inputFileName = mergeVideosArguments.InputFileName;
        var inputFilePath = $"{_videosFolderName}{inputFileName}";
        var extension = inputFileName?[(inputFileName.IndexOf('.') + 1)..];
        var videosToMerge = mergeVideosArguments.VideosToMerge;        
        var videosToMergeArgument = GetVideosToMerge(videosToMerge);

        if (videosToMergeArgument is null)
        {
            return;
        }

        var guid = Guid.NewGuid();
        var arguments = $"-i {inputFilePath} {videosToMergeArgument}-filter_complex [0:v:0][0:a:0][1:v:0][1:a:0]concat=n={videosToMerge.Count + 1}:v=1:a=1 {_videosFolderName}{guid}.{extension}";
        _logger.Information(arguments);

        var cmd = WrapCommand(arguments);

        var cmdResult = await cmd.ExecuteBufferedAsync();

        if (cmdResult.ExitCode != 0)
        {
            _logger.Error("Error executing merge videos command. Exit code: {ExitCode}", cmdResult.ExitCode);
            throw new Exception("Error executing ffmpeg command");
        }

        _logger.Information("Merge videos command executed succesfully");
    }

    private string GetVideosToMerge(IList<string> videosToMerge)
    {
        if (videosToMerge is null || videosToMerge.Count == 0)
        {
            return string.Empty;
        }

        var sb = new StringBuilder();

        foreach (var videoToMerge in videosToMerge)
        {
            sb.Append($"-i {_videosFolderName}{videoToMerge} ");
        }

        return sb.ToString();
    }
}
