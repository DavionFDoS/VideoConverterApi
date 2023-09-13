using CliWrap;
using CliWrap.Buffered;
using Serilog;
using System.IO.Compression;
using VideoConverterApi.Extensions;
using VideoConverterApi.Interfaces;
using VideoConverterApi.Models;

namespace VideoConverterApi.Services;

public class ConvertationService : IConvertationService
{
    private readonly Serilog.ILogger _logger;
    private readonly string _videosFolderName = "Videos/Uploads/";
    public ConvertationService()
    {
        _logger = new LoggerConfiguration()
            .WriteTo.File("ConvertationServiceLogs.txt")
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
    public async Task<OutputFileArguments?> ConvertToMP4WithNoArguments(InputFileArguments inputFileArguments)
    {
        if (inputFileArguments is null)
        {
            return await Task.FromResult<OutputFileArguments?>(null);
        }

        var inputFileName = inputFileArguments.InputFileName;

        if (inputFileName is null)
        {
            return await Task.FromResult<OutputFileArguments?>(null);
        }

        var inputFilePath = $"{_videosFolderName}{inputFileName}";
        var guid = Guid.NewGuid();
        var outputFileName = $"{_videosFolderName}{guid}.mp4";

        var cmd = WrapCommand($"-i {inputFilePath} {outputFileName}");

        var cmdResult = await cmd.ExecuteBufferedAsync();

        if (cmdResult.ExitCode != 0)
        {
            _logger.Error("Error executing convert to MP4 with no arguments command. Exit code: {ExitCode}", cmdResult.ExitCode);
            throw new Exception("Error executing ffmpeg command");
        }

        _logger.Information("Convert to MP4 with no arguments command executed succesfully");

        var outputArguments = new OutputFileArguments
        {
            OutputFileName = outputFileName
        };

        return outputArguments;
    }
    public async Task<OutputFileArguments?> ConvertToAVIWithNoArguments(InputFileArguments inputFileArguments)
    {
        if (inputFileArguments is null)
        {
            return await Task.FromResult<OutputFileArguments?>(null);
        }

        var inputFileName = inputFileArguments.InputFileName;

        if (inputFileName is null)
        {
            return await Task.FromResult<OutputFileArguments?>(null);
        }

        var inputFilePath = $"{_videosFolderName}{inputFileName}";
        var guid = Guid.NewGuid();
        var outputFileName = $"{_videosFolderName}{guid}.avi";

        var cmd = WrapCommand($"-i {inputFilePath} {outputFileName}");

        var cmdResult = await cmd.ExecuteBufferedAsync();

        if (cmdResult.ExitCode != 0)
        {
            _logger.Error("Error executing convert to AVI with no arguments command. Exit code: {ExitCode}", cmdResult.ExitCode);
            throw new Exception("Error executing ffmpeg command");
        }
        _logger.Information("Convert to AVI with no arguments command executed succesfully");

        var outputFileArguments = new OutputFileArguments()
        {
            OutputFileName = outputFileName
        };

        return outputFileArguments;
    }
    public async Task<OutputFileArguments?> ConvertToWebMWithNoArguments(InputFileArguments inputFileArguments)
    {
        if (inputFileArguments is null)
        {
            return await Task.FromResult<OutputFileArguments?>(null);
        }

        var inputFileName = inputFileArguments.InputFileName;

        if (inputFileName is null)
        {
            return await Task.FromResult<OutputFileArguments?>(null);
        }

        var inputFilePath = $"{_videosFolderName}{inputFileName}";
        var guid = Guid.NewGuid();
        var outputFileName = $"{_videosFolderName}{guid}.webm";

        var cmd = WrapCommand($"-i {inputFilePath} {outputFileName}");

        var cmdResult = await cmd.ExecuteBufferedAsync();

        if (cmdResult.ExitCode != 0)
        {
            _logger.Error("Error executing convert to WebM with no arguments command. Exit code: {ExitCode}", cmdResult.ExitCode);
            throw new Exception("Error executing ffmpeg command");
        }

        _logger.Information("Convert to WebM with no arguments command executed succesfully");

        var outputArguments = new OutputFileArguments
        {
            OutputFileName = outputFileName
        };

        return outputArguments;
    }
    public async Task<OutputFileArguments?> ConvertToMOVWithNoArguments(InputFileArguments inputFileArguments)
    {
        if (inputFileArguments is null)
        {
            return await Task.FromResult<OutputFileArguments?>(null);
        }

        var inputFileName = inputFileArguments.InputFileName;

        if (inputFileName is null)
        {
            return await Task.FromResult<OutputFileArguments?>(null);
        }

        var inputFilePath = $"{_videosFolderName}{inputFileName}";
        var guid = Guid.NewGuid();
        var outputFileName = $"{_videosFolderName}{guid}.mov";

        var cmd = WrapCommand($"-i {inputFilePath} {outputFileName}");

        var cmdResult = await cmd.ExecuteBufferedAsync();

        if (cmdResult.ExitCode != 0)
        {
            _logger.Error("Error executing convert to MOV with no arguments command. Exit code: {ExitCode}", cmdResult.ExitCode);
            throw new Exception("Error executing ffmpeg command");
        }

        _logger.Information("Convert to MOV with no arguments command executed succesfully");

        var outputArguments = new OutputFileArguments
        {
            OutputFileName = outputFileName
        };

        return outputArguments;
    }
    public async Task<OutputFileArguments?> ConvertToMKVWithNoArguments(InputFileArguments inputFileArguments)
    {
        if (inputFileArguments is null)
        {
            return await Task.FromResult<OutputFileArguments?>(null);
        }

        var inputFileName = inputFileArguments.InputFileName;

        if (inputFileName is null)
        {
            return await Task.FromResult<OutputFileArguments?>(null);
        }

        var inputFilePath = $"{_videosFolderName}{inputFileName}";
        var guid = Guid.NewGuid();
        var outputFileName = $"{_videosFolderName}{guid}.mkv";

        var cmd = WrapCommand($"-i {inputFilePath} {outputFileName}");

        var cmdResult = await cmd.ExecuteBufferedAsync();

        if (cmdResult.ExitCode != 0)
        {
            _logger.Error("Error executing convert to MKV with no arguments command. Exit code: {ExitCode}", cmdResult.ExitCode);
            throw new Exception("Error executing ffmpeg command");
        }

        _logger.Information("Convert to MKV with no arguments command executed succesfully");

        var outputArguments = new OutputFileArguments
        {
            OutputFileName = outputFileName
        };

        return outputArguments;
    }
    public async Task<OutputFileArguments?> ConvertToFLVWithNoArguments(InputFileArguments inputFileArguments)
    {
        if (inputFileArguments is null)
        {
            return await Task.FromResult<OutputFileArguments?>(null);
        }

        var inputFileName = inputFileArguments.InputFileName;

        if (inputFileName is null)
        {
            return await Task.FromResult<OutputFileArguments?>(null);
        }

        var inputFilePath = $"{_videosFolderName}{inputFileName}";
        var guid = Guid.NewGuid();
        var outputFileName = $"{_videosFolderName}{guid}.flv";

        var cmd = WrapCommand($"-i {inputFilePath} {outputFileName}");

        var cmdResult = await cmd.ExecuteBufferedAsync();

        if (cmdResult.ExitCode != 0)
        {
            _logger.Error("Error executing convert to FLV with no arguments command. Exit code: {ExitCode}", cmdResult.ExitCode);
            throw new Exception("Error executing ffmpeg command");
        }

        _logger.Information("Convert to FLV with no arguments command executed succesfully");

        var outputArguments = new OutputFileArguments
        {
            OutputFileName = outputFileName
        };

        return outputArguments;
    }
    public async Task<OutputFileArguments?> ConvertTo3GPWithNoArguments(InputFileArguments inputFileArguments)
    {
        if (inputFileArguments is null)
        {
            return await Task.FromResult<OutputFileArguments?>(null);
        }

        var inputFileName = inputFileArguments.InputFileName;

        if (inputFileName is null)
        {
            return await Task.FromResult<OutputFileArguments?>(null);
        }

        var inputFilePath = $"{_videosFolderName}{inputFileName}";
        var guid = Guid.NewGuid();
        var outputFileName = $"{_videosFolderName}{guid}.3gp";

        var cmd = WrapCommand($"-i {inputFilePath} -c:v libx264 -b:v 512k -c:a aac -b:a 128k -ar 8000 -ac 1 {outputFileName}");

        var cmdResult = await cmd.ExecuteBufferedAsync();

        if (cmdResult.ExitCode != 0)
        {
            _logger.Error("Error executing convert to 3GP with no arguments command. Exit code: {ExitCode}", cmdResult.ExitCode);
            throw new Exception("Error executing ffmpeg command");
        }

        _logger.Information("Convert to 3GP with no arguments command executed succesfully");

        var outputArguments = new OutputFileArguments
        {
            OutputFileName = outputFileName
        };

        return outputArguments;
    }
    public async Task<OutputFileArguments?> ConvertToMPEGWithNoArguments(InputFileArguments inputFileArguments)
    {
        if (inputFileArguments is null)
        {
            return await Task.FromResult<OutputFileArguments?>(null);
        }

        var inputFileName = inputFileArguments.InputFileName;

        if (inputFileName is null)
        {
            return await Task.FromResult<OutputFileArguments?>(null);
        }

        var inputFilePath = $"{_videosFolderName}{inputFileName}";
        var guid = Guid.NewGuid();
        var outputFileName = $"{_videosFolderName}{guid}.mpeg";

        var cmd = WrapCommand($"-i {inputFilePath} {outputFileName}");

        var cmdResult = await cmd.ExecuteBufferedAsync();

        if (cmdResult.ExitCode != 0)
        {
            _logger.Error("Error executing convert to MPEG with no arguments command. Exit code: {ExitCode}", cmdResult.ExitCode);
            throw new Exception("Error executing ffmpeg command");
        }

        _logger.Information("Convert to MPEG with no arguments command executed succesfully");

        var outputArguments = new OutputFileArguments
        {
            OutputFileName = outputFileName
        };

        return outputArguments;
    }
    public async Task<OutputFileArguments?> ConvertToWMVWithNoArguments(InputFileArguments inputFileArguments)
    {
        if (inputFileArguments is null)
        {
            return await Task.FromResult<OutputFileArguments?>(null);
        }

        var inputFileName = inputFileArguments.InputFileName;

        if (inputFileName is null)
        {
            return await Task.FromResult<OutputFileArguments?>(null);
        }

        var inputFilePath = $"{_videosFolderName}{inputFileName}";
        var guid = Guid.NewGuid();
        var outputFileName = $"{_videosFolderName}{guid}.wmv";

        var cmd = WrapCommand($"-i {inputFilePath} {outputFileName}");

        var cmdResult = await cmd.ExecuteBufferedAsync();

        if (cmdResult.ExitCode != 0)
        {
            _logger.Error("Error executing convert to WMV with no arguments command. Exit code: {ExitCode}", cmdResult.ExitCode);
            throw new Exception("Error executing ffmpeg command");
        }

        _logger.Information("Convert to VMV with no arguments command executed succesfully");

        var outputArguments = new OutputFileArguments
        {
            OutputFileName = outputFileName
        };

        return outputArguments;
    }
    public async Task<OutputFileArguments?> ConvertToGIFWithArguments(ConvertToGIFArguments convertToGIFArguments)
    {
        if (convertToGIFArguments is null)
        {
            return await Task.FromResult<OutputFileArguments?>(null);
        }

        var inputFileName = convertToGIFArguments.InputFileName;
        var framerate = convertToGIFArguments.Framerate;

        if (inputFileName is null || framerate <= 0)
        {
            return await Task.FromResult<OutputFileArguments?>(null);
        }

        var inputFilePath = $"{_videosFolderName}{inputFileName}";
        var guid = Guid.NewGuid();
        var outputFileName = $"{_videosFolderName}{guid}.gif";

        var cmd = WrapCommand($"-i {inputFilePath} -vf scale=320:-1 -r {framerate} -f gif {outputFileName}");

        var cmdResult = await cmd.ExecuteBufferedAsync();

        if (cmdResult.ExitCode != 0)
        {
            _logger.Error("Error executing convert to GIF with no arguments command. Exit code: {ExitCode}", cmdResult.ExitCode);
            throw new Exception("Error executing ffmpeg command");
        }

        _logger.Information("Convert to GIF with no arguments command executed succesfully");

        var outputArguments = new OutputFileArguments
        {
            OutputFileName = outputFileName
        };

        return outputArguments;
    }
    public async Task<OutputFileArguments?> ConvertToSeriesOfImages(ConvertToSeriesOfImagesArguments convertToSeriesOfImagesArguments)
    {
        if (convertToSeriesOfImagesArguments is null)
        {
            return await Task.FromResult<OutputFileArguments?>(null);
        }

        var inputFileName = convertToSeriesOfImagesArguments.InputFileName;
        var numberOfImages = convertToSeriesOfImagesArguments.NumberOfImages;
        var perNumberOfSeconds = convertToSeriesOfImagesArguments.PerNumberOfSeconds;

        if (inputFileName is null || numberOfImages == 0 || perNumberOfSeconds == 0)
        {
            return await Task.FromResult<OutputFileArguments?>(null);
        }

        var inputFilePath = $"{_videosFolderName}{inputFileName}";

        var cmd = WrapCommand($"-i {inputFilePath} -vf fps={numberOfImages}/{perNumberOfSeconds} {_videosFolderName}image_%03d.png");

        var cmdResult = await cmd.ExecuteBufferedAsync();

        if (cmdResult.ExitCode != 0)
        {
            _logger.Error("Error executing convert to series of images command. Exit code: {ExitCode}", cmdResult.ExitCode);
            throw new Exception("Error executing ffmpeg command");
        }

        _logger.Information("Convert to series of images command executed succesfully");

        string[] images = Directory
            .GetFiles($"{_videosFolderName}", $"image_*.png");

        var guid = Guid.NewGuid();
        var zipPath = $"{_videosFolderName}{guid}.zip";

        using (var zipArchive = ZipFile.Open(zipPath, ZipArchiveMode.Create))
        {
            foreach (var image in images)
            {
                var fileInfo = new FileInfo(image);
                zipArchive.CreateEntryFromFile(fileInfo.FullName, fileInfo.Name);
                File.Delete(image);
            }
        }



        var outputArguments = new OutputFileArguments
        {
            OutputFileName = zipPath
        };

        return outputArguments;
    }
    public async Task<OutputFileArguments?> ConvertToMP4WithArguments(ConvertToMP4Arguments convertToMP4Arguments)
    {
        if (convertToMP4Arguments is null)
        {
            return await Task.FromResult<OutputFileArguments?>(null);
        }

        var inputFileName = convertToMP4Arguments.InputFileName;

        if (inputFileName is null)
        {
            return await Task.FromResult<OutputFileArguments?>(null);
        }

        var inputFilePath = $"{_videosFolderName}{inputFileName}";
        var videoCodec = convertToMP4Arguments.MP4CompatibleVideoCodecs.GetEnumMemberValue() ?? "libx264";
        var videoBitrate = convertToMP4Arguments.VideoBitrate ?? 10000000;
        var preset = convertToMP4Arguments.Preset.GetEnumMemberValue() ?? "medium";
        var crf = convertToMP4Arguments.Crf;
        var audioCodec = convertToMP4Arguments.MP4CompatibleAudioCodecs.GetEnumMemberValue() ?? "aac";
        var audioBitrate = convertToMP4Arguments.AudioBitrate ?? 128000;
        var guid = Guid.NewGuid();
        var outputFileName = $"{_videosFolderName}{guid}.mp4";
        var arguments = $"-i {inputFilePath} -c:v {videoCodec} -b:v {videoBitrate} -preset {preset} -crf {crf} -c:a {audioCodec} -b:a {audioBitrate} {outputFileName}";
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
            throw new Exception("Error executing ffmpeg command");
        }

        _logger.Information("Convert to MP4 with arguments command executed succesfully");

        var outputArguments = new OutputFileArguments
        {
            OutputFileName = outputFileName
        };

        return outputArguments;
    }
    public async Task<OutputFileArguments?> ConvertToAVIWithArguments(ConvertToAVIArguments convertToAVIArguments)
    {
        if (convertToAVIArguments is null)
        {
            return await Task.FromResult<OutputFileArguments?>(null);
        }

        var inputFileName = convertToAVIArguments.InputFileName;

        if (inputFileName is null)
        {
            return await Task.FromResult<OutputFileArguments?>(null);
        }

        var inputFilePath = $"{_videosFolderName}{inputFileName}";
        var videoCodec = convertToAVIArguments.AVICompatibleVideoCodecs.GetEnumMemberValue() ?? "mpeg4";
        var videoBitrate = convertToAVIArguments.VideoBitrate ?? 500000;
        var preset = convertToAVIArguments.Preset.GetEnumMemberValue() ?? "medium";
        var qv = convertToAVIArguments.Qv;
        var audioCodec = convertToAVIArguments.AVICompatibleAudioCodecs.GetEnumMemberValue() ?? "libmp3lame";
        var audioBitrate = convertToAVIArguments.AudioBitrate ?? 128000;
        var guid = Guid.NewGuid();
        var outputFileName = $"{_videosFolderName}{guid}.avi";

        var arguments = $"-i {inputFilePath} -c:v {videoCodec} -b:v {videoBitrate} -preset {preset} -q:v {qv} -c:a {audioCodec} -b:a {audioBitrate} {outputFileName}";
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
            throw new Exception("Error executing ffmpeg command");
        }

        _logger.Information("Convert to AVI with arguments command executed succesfully");

        var outputArguments = new OutputFileArguments
        {
            OutputFileName = outputFileName
        };

        return outputArguments;
    }
    public async Task<OutputFileArguments?> ConvertToWebMWithArguments(ConvertToWebmArguments convertToWebmArguments)
    {
        if (convertToWebmArguments is null)
        {
            return await Task.FromResult<OutputFileArguments?>(null);
        }

        var inputFileName = convertToWebmArguments.InputFileName;

        if (inputFileName is null)
        {
            return await Task.FromResult<OutputFileArguments?>(null);
        }

        var inputFilePath = $"{_videosFolderName}{inputFileName}";
        var videoCodec = convertToWebmArguments.WebmCompatibleVideoCodecs.GetEnumMemberValue() ?? "libvpx-vp9";
        var videoBitrate = convertToWebmArguments.VideoBitrate ?? 1000000;
        var preset = convertToWebmArguments.Preset.GetEnumMemberValue() ?? "medium";
        var audioCodec = convertToWebmArguments.WebmCompatibleAudioCodecs.GetEnumMemberValue() ?? "libopus";
        var audioBitrate = convertToWebmArguments.AudioBitrate ?? 128000;
        var guid = Guid.NewGuid();
        var outputFileName = $"{_videosFolderName}{guid}.webm";
        var arguments = $"-i {inputFilePath} -c:v {videoCodec} -b:v {videoBitrate} -preset {preset} -c:a {audioCodec} -b:a {audioBitrate} {outputFileName}";
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
            throw new Exception("Error executing ffmpeg command");
        }

        _logger.Information("Convert to WebM with arguments command executed succesfully");

        var outputArguments = new OutputFileArguments
        {
            OutputFileName = outputFileName
        };

        return outputArguments;
    }
    public async Task<OutputFileArguments?> ConvertToMOVWithArguments(ConvertToMOVArguments convertToMOVArguments)
    {
        if (convertToMOVArguments is null)
        {
            return await Task.FromResult<OutputFileArguments?>(null);
        }

        var inputFileName = convertToMOVArguments.InputFileName;

        if (inputFileName is null)
        {
            return await Task.FromResult<OutputFileArguments?>(null);
        }

        var inputFilePath = $"{_videosFolderName}{inputFileName}";
        var videoCodec = convertToMOVArguments.MOVCompatibleVideoCodecs.GetEnumMemberValue() ?? "prores_ks";
        var videoBitrate = convertToMOVArguments.VideoBitrate ?? 12000000;
        var audioCodec = convertToMOVArguments.MOVCompatibleAudioCodecs.GetEnumMemberValue() ?? "pcm_s24le";
        var audioBitrate = convertToMOVArguments.AudioBitrate ?? 320000;
        var guid = Guid.NewGuid();
        var outputFileName = $"{_videosFolderName}{guid}.mov";
        var arguments = $"-i {inputFilePath} -c:v {videoCodec} -b:v {videoBitrate} -c:a {audioCodec} -b:a {audioBitrate} {outputFileName}";
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
            throw new Exception("Error executing ffmpeg command");
        }

        _logger.Information("Convert to MOV with arguments command executed succesfully");

        var outputArguments = new OutputFileArguments
        {
            OutputFileName = outputFileName
        };

        return outputArguments;
    }
    public async Task<OutputFileArguments?> ConvertToMKVWithArguments(ConvertToMKVArguments convertToMKVArguments)
    {
        if (convertToMKVArguments is null)
        {
            return await Task.FromResult<OutputFileArguments?>(null);
        }

        var inputFileName = convertToMKVArguments.InputFileName;

        if (inputFileName is null)
        {
            return await Task.FromResult<OutputFileArguments?>(null);
        }

        var inputFilePath = $"{_videosFolderName}{inputFileName}";
        var videoCodec = convertToMKVArguments.MKVCompatibleVideoCodecs.GetEnumMemberValue() ?? "libx264";
        var videoBitrate = convertToMKVArguments.VideoBitrate ?? 12000000;
        var preset = convertToMKVArguments.Preset.GetEnumMemberValue() ?? "slow";
        var crf = convertToMKVArguments.Crf;
        var audioCodec = convertToMKVArguments.MKVCompatibleAudioCodecs.GetEnumMemberValue() ?? "aac";
        var audioBitrate = convertToMKVArguments.AudioBitrate ?? 192000;
        var guid = Guid.NewGuid();
        var outputFileName = $"{_videosFolderName}{guid}.mkv";
        var arguments = $"-i {inputFilePath} -c:v {videoCodec} -b:v {videoBitrate} -preset {preset} -crf {crf} -c:a {audioCodec} -b:a {audioBitrate} {outputFileName}";
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
            throw new Exception("Error executing ffmpeg command");
        }

        _logger.Information("Convert to MKV with arguments command executed succesfully");

        var outputArguments = new OutputFileArguments
        {
            OutputFileName = outputFileName
        };

        return outputArguments;
    }
}
