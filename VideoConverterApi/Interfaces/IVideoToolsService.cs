using VideoConverterApi.Models;

namespace VideoConverterApi.Interfaces;

public interface IVideoToolsService
{
    Task<OutputFileArguments?> AddAudioAsync(AddAudioArguments addAudioArguments);
    Task<OutputFileArguments?> AddSubtitlesAsync(AddSubtitlesArguments addSubtitlesArguments);
    Task<OutputFileArguments?> AddWatermarkAsync(AddWatermarkArguments addWatermarkArguments);
    Task<OutputFileArguments?> ChangeAudioBitrateAsync(ChangeAudioBitrateArguments changeAudioBitrateArguments);
    Task<OutputFileArguments?> ChangeAudioVolumeAsync(ChangeAudioVolumeArguments changeAudioVolumeArguments);
    Task<OutputFileArguments?> ChangeVideoBitrateAsync(ChangeVideoBitrateArguments changeVideoBitrateArguments);
    Task<OutputFileArguments?> ChangeVideoFramerateAsync(ChangeVideoFramerateArguments changeVideoFramerateArguments);
    Task<OutputFileArguments?> ChangeVideoResolutionAsync(ChangeVideoResolutionArguments changeVideoResolutionArguments);
    Task<OutputFileArguments?> ChangeVideoSpeedAsync(ChangeVideoSpeedArguments changeVideoSpeedArguments);
    Task<OutputFileArguments?> CropVideoAsync(CropVideoArguments cropVideoArguments);
    Task<OutputFileArguments?> CutVideoAsync(CutVideoArguments cutVideoArguments);
    Task<OutputFileArguments?> ExtractAudioAsync(InputFileArguments inputFileArguments);
    Task<OutputFileArguments?> ExtractSingleFrameAsync(ExtractSingleFrameArguments extractSingleFrameArguments);
    Task<OutputFileArguments?> MergeVideosAsync(MergeVideosArguments mergeVideosArguments);
    Task<OutputFileArguments?> ReflectVideoAsync(ReflectVideoArguments reflectVideoArguments);
    Task<OutputFileArguments?> RemoveAudioAsync(InputFileArguments inputFileArguments);
    Task<OutputFileArguments?> ReverseVideoAsync(InputFileArguments inputFileArguments);
    Task<OutputFileArguments?> RotateVideoByAngleAsync(RotateVideoArguments rotateVideoArguments);
    Task<OutputFileArguments?> WebOptimizeVideoAsync(InputFileArguments inputFileArguments);
}