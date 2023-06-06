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
    private readonly string _videosFolderName = "Videos/Uploads/";
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
    public async Task<OutputFileArguments?> ReverseVideoAsync(InputFileArguments inputFileArguments)
    {
        if (inputFileArguments is null)
        {
            return await Task.FromResult<OutputFileArguments?>(null);
        }

        var inputFileName = inputFileArguments.InputFileName;
        var extension = inputFileName?[(inputFileName.IndexOf('.') + 1)..];
        var inputFilePath = $"{_videosFolderName}{inputFileName}";
        var guid = Guid.NewGuid();
        var outputFileName = $"{_videosFolderName}{guid}.{extension}";

        var cmd = WrapCommand($"-i {inputFilePath} -vf reverse -af areverse {outputFileName}");

        var cmdResult = await cmd.ExecuteBufferedAsync();

        if (cmdResult.ExitCode != 0)
        {
            _logger.Error("Error executing reverse video command. Exit code: {ExitCode}", cmdResult.ExitCode);
            throw new Exception("Error executing ffmpeg command");
        }

        _logger.Information("Reverse video command executed succesfully");

        var outputArguments = new OutputFileArguments
        {
            OutputFileName = outputFileName
        };

        return outputArguments;
    }

    public async Task<OutputFileArguments?> RotateVideoByAngleAsync(RotateVideoArguments rotateVideoArguments)
    {
        if (rotateVideoArguments is null)
        {
            return await Task.FromResult<OutputFileArguments?>(null);
        }

        var inputFileName = rotateVideoArguments.InputFileName;
        var extension = inputFileName?[(inputFileName.IndexOf('.') + 1)..];
        var angleToRotate = rotateVideoArguments.AngleToRotate;
        var inputFilePath = $"{_videosFolderName}{inputFileName}";
        var guid = Guid.NewGuid();
        var outputFileName = $"{_videosFolderName}{guid}.{extension}";
        var arguments = $"-i {inputFilePath} -vf rotate={angleToRotate}*PI/180 {outputFileName}";
        _logger.Information(arguments);

        var cmd = WrapCommand(arguments);

        var cmdResult = await cmd.ExecuteBufferedAsync();

        if (cmdResult.ExitCode != 0)
        {
            _logger.Error("Error executing rota video by angle command. Exit code: {ExitCode}", cmdResult.ExitCode);
            throw new Exception("Error executing ffmpeg command");
        }

        _logger.Information("Rotate video by angle command executed succesfully");

        var outputArguments = new OutputFileArguments
        {
            OutputFileName = outputFileName
        };

        return outputArguments;
    }
    public async Task<OutputFileArguments?> CropVideoAsync(CropVideoArguments cropVideoArguments)
    {
        if (cropVideoArguments is null)
        {
            return await Task.FromResult<OutputFileArguments?>(null);
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
            return await Task.FromResult<OutputFileArguments?>(null);
        }

        var guid = Guid.NewGuid();
        var outputFileName = $"{_videosFolderName}{guid}.{extension}";
        var arguments = $"-i {inputFilePath} -filter:v crop={height}:{width}:{x}:{y} {outputFileName}";
        _logger.Information(arguments);

        var cmd = WrapCommand(arguments);

        var cmdResult = await cmd.ExecuteBufferedAsync();

        if (cmdResult.ExitCode != 0)
        {
            _logger.Error("Error executing crop video command. Exit code: {ExitCode}", cmdResult.ExitCode);
            throw new Exception("Error executing ffmpeg command");
        }

        _logger.Information("Crop video command executed succesfully");

        var outputArguments = new OutputFileArguments
        {
            OutputFileName = outputFileName
        };

        return outputArguments;
    }

    public async Task<OutputFileArguments?> CutVideoAsync(CutVideoArguments cutVideoArgunents)
    {
        if (cutVideoArgunents is null)
        {
            return await Task.FromResult<OutputFileArguments?>(null);
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

        if (fromInSeconds >= duration || fromInSeconds < 0 || toInSeconds > duration || (toInSeconds - fromInSeconds) < 0)
        {
            return await Task.FromResult<OutputFileArguments?>(null);
        }

        var guid = Guid.NewGuid();
        var outputFileName = $"{_videosFolderName}{guid}.{extension}";
        var arguments = $"-i {inputFilePath} -ss {fromHours}:{fromMinutes}:{fromSeconds} -to {toHours}:{toMinutes}:{toSeconds} -c copy {outputFileName}";
        _logger.Information(arguments);

        var cmd = WrapCommand(arguments);

        var cmdResult = await cmd.ExecuteBufferedAsync();

        if (cmdResult.ExitCode != 0)
        {
            _logger.Error("Error executing cut video command. Exit code: {ExitCode}", cmdResult.ExitCode);
            throw new Exception("Error executing ffmpeg command");
        }

        _logger.Information("Cut video command executed succesfully");

        var outputArguments = new OutputFileArguments
        {
            OutputFileName = outputFileName
        };

        return outputArguments;
    }

    private static int ToSeconds(int hours, int minutes, int seconds)
    {
        return hours * 3600 + minutes * 60 + seconds;
    }

    public async Task<OutputFileArguments?> ReflectVideoAsync(ReflectVideoArguments reflectVideoArguments)
    {
        if (reflectVideoArguments is null)
        {
            return await Task.FromResult<OutputFileArguments?>(null);
        }

        var inputFileName = reflectVideoArguments.InputFileName;
        var extension = inputFileName?[(inputFileName.IndexOf('.') + 1)..];
        var inputFilePath = $"{_videosFolderName}{inputFileName}";
        var reflectHorozontally = reflectVideoArguments.ReflectHorizontally;
        var reflectVertically = reflectVideoArguments.ReflectVertically;
        var guid = Guid.NewGuid();
        var outputFileName = $"{_videosFolderName}{guid}.{extension}";
        string? arguments;

        if (reflectHorozontally && reflectVertically)
        {
            arguments = $"-i {inputFilePath} -vf hflip,vflip {outputFileName}";
        }
        else if (reflectHorozontally)
        {
            arguments = $"-i {inputFilePath} -vf hflip {outputFileName}";
        }
        else if (reflectVertically)
        {
            arguments = $"-i {inputFilePath} -vf vflip {outputFileName}";
        }
        else
        {
            return await Task.FromResult<OutputFileArguments?>(null);
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

        var outputArguments = new OutputFileArguments
        {
            OutputFileName = outputFileName
        };

        return outputArguments;
    }

    public async Task<OutputFileArguments?> RemoveAudioAsync(InputFileArguments inputFileArguments)
    {
        if (inputFileArguments is null)
        {
            return await Task.FromResult<OutputFileArguments?>(null);
        }

        var inputFileName = inputFileArguments.InputFileName;
        var extension = inputFileName?[(inputFileName.IndexOf('.') + 1)..];
        var inputFilePath = $"{_videosFolderName}{inputFileName}";

        var guid = Guid.NewGuid();
        var outputFileName = $"{_videosFolderName}{guid}.{extension}";
        var arguments = $"-i {inputFilePath} -c:v copy -an {outputFileName}";
        _logger.Information(arguments);

        var cmd = WrapCommand(arguments);

        var cmdResult = await cmd.ExecuteBufferedAsync();

        if (cmdResult.ExitCode != 0)
        {
            _logger.Error("Error executing remove audio command. Exit code: {ExitCode}", cmdResult.ExitCode);
            throw new Exception("Error executing ffmpeg command");
        }

        _logger.Information("Remove audio command executed succesfully");

        var outputArguments = new OutputFileArguments
        {
            OutputFileName = outputFileName
        };

        return outputArguments;
    }

    public async Task<OutputFileArguments?> ChangeVideoBitrateAsync(ChangeVideoBitrateArguments changeVideoBitrateArguments)
    {
        if (changeVideoBitrateArguments is null)
        {
            return await Task.FromResult<OutputFileArguments?>(null);
        }

        var inputFileName = changeVideoBitrateArguments.InputFileName;
        var extension = inputFileName?[(inputFileName.IndexOf('.') + 1)..];
        var inputFilePath = $"{_videosFolderName}{inputFileName}";
        var videoBitrate = changeVideoBitrateArguments.VideoBitrate;

        var guid = Guid.NewGuid();
        var outputFileName = $"{_videosFolderName}{guid}.{extension}";
        var arguments = $"-i {inputFilePath} -b:v {videoBitrate} {videoBitrate} {outputFileName}";
        _logger.Information(arguments);

        var cmd = WrapCommand(arguments);

        var cmdResult = await cmd.ExecuteBufferedAsync();

        if (cmdResult.ExitCode != 0)
        {
            _logger.Error("Error executing change video bitrate command. Exit code: {ExitCode}", cmdResult.ExitCode);
            throw new Exception("Error executing ffmpeg command");
        }

        _logger.Information("Change video bitrate command executed succesfully");

        var outputArguments = new OutputFileArguments
        {
            OutputFileName = outputFileName
        };

        return outputArguments;
    }

    public async Task<OutputFileArguments?> ChangeAudioBitrateAsync(ChangeAudioBitrateArguments changeAudioBitrateArguments)
    {
        if (changeAudioBitrateArguments is null)
        {
            return await Task.FromResult<OutputFileArguments?>(null);
        }

        var inputFileName = changeAudioBitrateArguments.InputFileName;
        var extension = inputFileName?[(inputFileName.IndexOf('.') + 1)..];
        var inputFilePath = $"{_videosFolderName}{inputFileName}";
        var audioBitrate = changeAudioBitrateArguments.AudioBitrate;

        var guid = Guid.NewGuid();
        var outputFileName = $"{_videosFolderName}{guid}.{extension}";
        var arguments = $"-i {inputFilePath} -b:a {audioBitrate} {outputFileName}";
        _logger.Information(arguments);

        var cmd = WrapCommand(arguments);

        var cmdResult = await cmd.ExecuteBufferedAsync();

        if (cmdResult.ExitCode != 0)
        {
            _logger.Error("Error executing change audio bitrate command. Exit code: {ExitCode}", cmdResult.ExitCode);
            throw new Exception("Error executing ffmpeg command");
        }

        _logger.Information("Change audio bitrate command executed succesfully");

        var outputArguments = new OutputFileArguments
        {
            OutputFileName = outputFileName
        };

        return outputArguments;
    }

    public async Task<OutputFileArguments?> ExtractAudioAsync(InputFileArguments inputFileArguments)
    {
        if (inputFileArguments is null)
        {
            return await Task.FromResult<OutputFileArguments?>(null);
        }

        var inputFileName = inputFileArguments.InputFileName;
        var inputFilePath = $"{_videosFolderName}{inputFileName}";

        var guid = Guid.NewGuid();
        var outputFileName = $"{_videosFolderName}{guid}.mp3";
        var arguments = $"-i {inputFilePath} -vn {outputFileName}";
        _logger.Information(arguments);

        var cmd = WrapCommand(arguments);

        var cmdResult = await cmd.ExecuteBufferedAsync();

        if (cmdResult.ExitCode != 0)
        {
            _logger.Error("Error executing extract audio command. Exit code: {ExitCode}", cmdResult.ExitCode);
            throw new Exception("Error executing ffmpeg command");
        }

        _logger.Information("Extract audio command executed succesfully");

        var outputArguments = new OutputFileArguments
        {
            OutputFileName = outputFileName
        };

        return outputArguments;
    }

    public async Task<OutputFileArguments?> WebOptimizeVideoAsync(InputFileArguments inputFileArguments)
    {
        if (inputFileArguments is null)
        {
            return await Task.FromResult<OutputFileArguments?>(null);
        }

        var inputFileName = inputFileArguments.InputFileName;
        var extension = inputFileName?[(inputFileName.IndexOf('.') + 1)..];
        var inputFilePath = $"{_videosFolderName}{inputFileName}";

        var guid = Guid.NewGuid();
        var outputFileName = $"{_videosFolderName}{guid}.{extension}";
        var arguments = $"-i {inputFilePath} -movflags +faststart {outputFileName}";
        _logger.Information(arguments);

        var cmd = WrapCommand(arguments);

        var cmdResult = await cmd.ExecuteBufferedAsync();

        if (cmdResult.ExitCode != 0)
        {
            _logger.Error("Error executing web optimize video command. Exit code: {ExitCode}", cmdResult.ExitCode);
            throw new Exception("Error executing ffmpeg command");
        }

        _logger.Information("Web optimize video command executed succesfully");

        var outputArguments = new OutputFileArguments
        {
            OutputFileName = outputFileName
        };

        return outputArguments;
    }

    public async Task<OutputFileArguments?> AddWatermarkAsync(AddWatermarkArguments addWaterMarkArguments)
    {
        if (addWaterMarkArguments is null)
        {
            return await Task.FromResult<OutputFileArguments?>(null);
        }

        var inputFileName = addWaterMarkArguments.InputFileName;
        var extension = inputFileName?[(inputFileName.IndexOf('.') + 1)..];
        var inputFilePath = $"{_videosFolderName}{inputFileName}";
        var watermarkFileName = addWaterMarkArguments.WatermarkFileName;

        if (watermarkFileName is null)
        {
            return await Task.FromResult<OutputFileArguments?>(null);
        }

        var watermarkFilePath = $"{_videosFolderName}{watermarkFileName}";
        var x = addWaterMarkArguments.X;
        var y = addWaterMarkArguments.Y;
        var guid = Guid.NewGuid();
        var outputFileName = $"{_videosFolderName}{guid}.{extension}";
        var arguments = $"-i {inputFilePath} -i {watermarkFilePath} -filter_complex overlay={x}:{y} {outputFileName}";
        _logger.Information(arguments);

        var cmd = WrapCommand(arguments);

        var cmdResult = await cmd.ExecuteBufferedAsync();

        if (cmdResult.ExitCode != 0)
        {
            _logger.Error("Error executing add watermark command. Exit code: {ExitCode}", cmdResult.ExitCode);
            throw new Exception("Error executing ffmpeg command");
        }

        _logger.Information("Add watermark command executed succesfully");

        var outputArguments = new OutputFileArguments
        {
            OutputFileName = outputFileName
        };

        return outputArguments;
    }

    public async Task<OutputFileArguments?> AddAudioAsync(AddAudioArguments addAudioArguments)
    {
        if (addAudioArguments is null)
        {
            return await Task.FromResult<OutputFileArguments?>(null);
        }

        var inputFileName = addAudioArguments.InputFileName;
        var extension = inputFileName?[(inputFileName.IndexOf('.') + 1)..];
        var inputFilePath = $"{_videosFolderName}{inputFileName}";
        var audioFileName = addAudioArguments.AudioFileName;
        var audioFilePath = $"{_videosFolderName}{audioFileName}";
        var guid = Guid.NewGuid();
        var outputFileName = $"{_videosFolderName}{guid}.{extension}";
        var arguments = $"-i {inputFilePath} -i {audioFilePath} -c copy -shortest {outputFileName}";
        _logger.Information(arguments);

        var cmd = WrapCommand(arguments);

        var cmdResult = await cmd.ExecuteBufferedAsync();

        if (cmdResult.ExitCode != 0)
        {
            _logger.Error("Error executing add audio command. Exit code: {ExitCode}", cmdResult.ExitCode);
            throw new Exception("Error executing ffmpeg command");
        }

        _logger.Information("Add audio command executed succesfully");

        var outputArguments = new OutputFileArguments
        {
            OutputFileName = outputFileName
        };

        return outputArguments;
    }

    public async Task<OutputFileArguments?> AddSubtitlesAsync(AddSubtitlesArguments addSubtitlesArguments)
    {
        if (addSubtitlesArguments is null)
        {
            return await Task.FromResult<OutputFileArguments?>(null);
        }

        var inputFileName = addSubtitlesArguments.InputFileName;
        var extension = inputFileName?[(inputFileName.IndexOf('.') + 1)..];
        var inputFilePath = $"{_videosFolderName}{inputFileName}";
        var subtitlesFileName = addSubtitlesArguments.SubtitlesFileName;
        var subtitlesFilePath = $"{_videosFolderName}{subtitlesFileName}";
        var subtitlesExtension = subtitlesFileName?[(subtitlesFileName.IndexOf('.') + 1)..];
        var guid = Guid.NewGuid();
        var outputFileName = $"{_videosFolderName}{guid}.{extension}";
        string? arguments = null;

        if (subtitlesExtension == "srt")
        {
            arguments = $"-i {inputFilePath} -vf subtitles={subtitlesFilePath} -c:s mov_text  {outputFileName}";
            _logger.Information(arguments);
        }

        if (subtitlesExtension == "ass")
        {
            arguments = $"-i {inputFilePath} -vf ass={subtitlesFilePath} -c:s mov_text  {outputFileName}";
            _logger.Information(arguments);
        }

        if (arguments is null)
        {
            return await Task.FromResult<OutputFileArguments?>(null);
        }

        var cmd = WrapCommand(arguments);

        var cmdResult = await cmd.ExecuteBufferedAsync();

        if (cmdResult.ExitCode != 0)
        {
            _logger.Error("Error executing add subtitles command. Exit code: {ExitCode}", cmdResult.ExitCode);
            throw new Exception("Error executing ffmpeg command");
        }

        _logger.Information("Add subtitles command executed succesfully");

        var outputArguments = new OutputFileArguments
        {
            OutputFileName = outputFileName
        };

        return outputArguments;
    }

    public async Task<OutputFileArguments?> ChangeVideoSpeedAsync(ChangeVideoSpeedArguments changeVideoSpeedArguments)
    {
        if (changeVideoSpeedArguments is null)
        {
            return await Task.FromResult<OutputFileArguments?>(null);
        }

        var inputFileName = changeVideoSpeedArguments.InputFileName;
        var extension = inputFileName?[(inputFileName.IndexOf('.') + 1)..];
        var inputFilePath = $"{_videosFolderName}{inputFileName}";
        var speedChangeCoefficient = changeVideoSpeedArguments.SpeedChangeCoefficient;
        var guid = Guid.NewGuid();
        var outputFileName = $"{_videosFolderName}{guid}.{extension}";
        var arguments = $"-i {inputFilePath} -filter_complex [0:v]setpts={speedChangeCoefficient.ToString().Replace(',', '.')}*PTS[v];[0:a]atempo={Math.Round(1 / speedChangeCoefficient, 2).ToString().Replace(',', '.')}[a] -map [v] -map [a] {outputFileName}";
        _logger.Information(arguments);

        var cmd = WrapCommand(arguments);

        var cmdResult = await cmd.ExecuteBufferedAsync();

        if (cmdResult.ExitCode != 0)
        {
            _logger.Error("Error executing change video speed command. Exit code: {ExitCode}", cmdResult.ExitCode);
            throw new Exception("Error executing ffmpeg command");
        }

        _logger.Information("Change video speed command executed succesfully");

        var outputArguments = new OutputFileArguments
        {
            OutputFileName = outputFileName
        };

        return outputArguments;
    }

    public async Task<OutputFileArguments?> ChangeVideoFramerateAsync(ChangeVideoFramerateArguments changeVideoFramerateArguments)
    {
        if (changeVideoFramerateArguments is null)
        {
            return await Task.FromResult<OutputFileArguments?>(null);
        }

        var inputFileName = changeVideoFramerateArguments.InputFileName;
        var extension = inputFileName?[(inputFileName.IndexOf('.') + 1)..];
        var inputFilePath = $"{_videosFolderName}{inputFileName}";
        var desiredFramerate = changeVideoFramerateArguments.DesiredFramerate;

        if (desiredFramerate < 0)
        {
            return await Task.FromResult<OutputFileArguments?>(null);
        }

        var guid = Guid.NewGuid();
        var outputFileName = $"{_videosFolderName}{guid}.{extension}";
        var arguments = $"-i {inputFilePath} -r {desiredFramerate} {outputFileName}";
        _logger.Information(arguments);

        var cmd = WrapCommand(arguments);

        var cmdResult = await cmd.ExecuteBufferedAsync();

        if (cmdResult.ExitCode != 0)
        {
            _logger.Error("Error executing change video framerate command. Exit code: {ExitCode}", cmdResult.ExitCode);
            throw new Exception("Error executing ffmpeg command");
        }

        _logger.Information("Change video framerate command executed succesfully");

        var outputArguments = new OutputFileArguments
        {
            OutputFileName = outputFileName
        };

        return outputArguments;
    }

    public async Task<OutputFileArguments?> ChangeAudioVolumeAsync(ChangeAudioVolumeArguments changeAudioVolumeArguments)
    {
        if (changeAudioVolumeArguments is null)
        {
            return await Task.FromResult<OutputFileArguments?>(null);
        }

        var inputFileName = changeAudioVolumeArguments.InputFileName;
        var extension = inputFileName?[(inputFileName.IndexOf('.') + 1)..];
        var inputFilePath = $"{_videosFolderName}{inputFileName}";
        var volumeChangeCoefficient = changeAudioVolumeArguments.VolumeChangeCoefficient;
        var guid = Guid.NewGuid();
        var outputFileName = $"{_videosFolderName}{guid}.{extension}";
        var arguments = $"-i {inputFilePath} -filter:a volume={volumeChangeCoefficient.ToString().Replace(',', '.')} {outputFileName}";
        _logger.Information(arguments);

        var cmd = WrapCommand(arguments);

        var cmdResult = await cmd.ExecuteBufferedAsync();

        if (cmdResult.ExitCode != 0)
        {
            _logger.Error("Error executing change audio volume command. Exit code: {ExitCode}", cmdResult.ExitCode);
            throw new Exception("Error executing ffmpeg command");
        }

        _logger.Information("Change audio volume command executed succesfully");

        var outputArguments = new OutputFileArguments
        {
            OutputFileName = outputFileName
        };

        return outputArguments;
    }

    public async Task<OutputFileArguments?> ChangeVideoResolutionAsync(ChangeVideoResolutionArguments changeVideoResolutionArguments)
    {
        if (changeVideoResolutionArguments is null)
        {
            return await Task.FromResult<OutputFileArguments?>(null);
        }

        var inputFileName = changeVideoResolutionArguments.InputFileName;
        var extension = inputFileName?[(inputFileName.IndexOf('.') + 1)..];
        var inputFilePath = $"{_videosFolderName}{inputFileName}";
        var resolution = changeVideoResolutionArguments.Resolution.GetEnumMemberValue();
        var guid = Guid.NewGuid();
        var outputFileName = $"{_videosFolderName}{guid}.{extension}";
        var arguments = $"-i {inputFilePath} -vf scale={resolution} -c:a copy {outputFileName}";
        _logger.Information(arguments);

        var cmd = WrapCommand(arguments);

        var cmdResult = await cmd.ExecuteBufferedAsync();

        if (cmdResult.ExitCode != 0)
        {
            _logger.Error("Error executing change audio volume command. Exit code: {ExitCode}", cmdResult.ExitCode);
            throw new Exception("Error executing ffmpeg command");
        }

        _logger.Information("Change audio volume command executed succesfully");

        var outputArguments = new OutputFileArguments
        {
            OutputFileName = outputFileName
        };

        return outputArguments;
    }

    public async Task<OutputFileArguments?> ExtractSingleFrameAsync(ExtractSingleFrameArguments extractSingleFrameArguments)
    {
        if (extractSingleFrameArguments is null)
        {
            return await Task.FromResult<OutputFileArguments?>(null);
        }

        var inputFileName = extractSingleFrameArguments.InputFileName;
        var inputFilePath = $"{_videosFolderName}{inputFileName}";
        var hour = extractSingleFrameArguments.Hour;
        var minute = extractSingleFrameArguments.Minute;
        var second = extractSingleFrameArguments.Second;
        var metadata = _mediaMetadataService.GetMediaMetadata(inputFilePath);
        var durationInSeconds = ToSeconds(hour, minute, second);

        if (durationInSeconds > metadata.Duration || durationInSeconds < 0)
        {
            return await Task.FromResult<OutputFileArguments?>(null);
        }

        var guid = Guid.NewGuid();
        var outputFileName = $"{_videosFolderName}{guid}.png";
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

        var outputArguments = new OutputFileArguments
        {
            OutputFileName = outputFileName
        };

        return outputArguments;
    }

    public async Task<OutputFileArguments?> MergeVideosAsync(MergeVideosArguments mergeVideosArguments)
    {
        if (mergeVideosArguments is null)
        {
            return await Task.FromResult<OutputFileArguments?>(null);
        }

        var inputFileName = mergeVideosArguments.InputFileName;
        var inputFilePath = $"{_videosFolderName}{inputFileName}";
        var extension = inputFileName?[(inputFileName.IndexOf('.') + 1)..];
        var videosToMerge = mergeVideosArguments.VideosToMerge;

        if(videosToMerge is null)
        {
            return await Task.FromResult<OutputFileArguments?>(null);
        }

        var videosToMergeArgument = GetVideosToMerge(videosToMerge);

        if (videosToMergeArgument is null)
        {
            return await Task.FromResult<OutputFileArguments?>(null);
        }

        var guid = Guid.NewGuid();
        var outputFileName = $"{_videosFolderName}{guid}.{extension}";
        var arguments = $"-i {inputFilePath} {videosToMergeArgument}-filter_complex [0:v:0][0:a:0][1:v:0][1:a:0]concat=n={videosToMerge.Count + 1}:v=1:a=1 {outputFileName}";
        _logger.Information(arguments);

        var cmd = WrapCommand(arguments);

        var cmdResult = await cmd.ExecuteBufferedAsync();

        if (cmdResult.ExitCode != 0)
        {
            _logger.Error("Error executing merge videos command. Exit code: {ExitCode}", cmdResult.ExitCode);
            throw new Exception("Error executing ffmpeg command");
        }

        _logger.Information("Merge videos command executed succesfully");

        var outputArguments = new OutputFileArguments
        {
            OutputFileName = outputFileName
        };

        return outputArguments;
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
