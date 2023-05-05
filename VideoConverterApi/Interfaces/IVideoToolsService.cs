using VideoConverterApi.Models;

namespace VideoConverterApi.Interfaces;

public interface IVideoToolsService
{
    Task AddAudioAsync(AddAudioArguments addAudioArguments);
    Task AddSubtitlesAsync(AddSubtitlesArguments addSubtitlesArguments);
    Task AddWatermarkAsync(AddWatermarkArguments addWatermarkArguments);
    Task ChangeAudioBitrateAsync(ChangeAudioBitrateArguments changeAudioBitrateArguments);
    Task ChangeAudioVolumeAsync(ChangeAudioVolumeArguments changeAudioVolumeArguments);
    Task ChangeVideoBitrateAsync(ChangeVideoBitrateArguments changeVideoBitrateArguments);
    Task ChangeVideoResolutionAsync(ChangeVideoResolutionArguments changeVideoResolutionArguments);
    Task ChangeVideoSpeedAsync(ChangeVideoSpeedArguments changeVideoSpeedArguments);
    Task CropVideoAsync(CropVideoArguments cropVideoArguments);
    Task CutVideoAsync(CutVideoArguments cutVideoArguments);
    Task ExtractAudioAsync(InputFileArguments inputFileArguments);
    Task ExtractSingleFrameAsync(ExtractSingleFrameArguments extractSingleFrameArguments);
    Task MergeVideosAsync(MergeVideosArguments mergeVideosArguments);
    Task ReflectVideoAsync(ReflectVideoArguments reflectVideoArguments);
    Task RemoveAudioAsync(InputFileArguments inputFileArguments);
    Task ReverseVideoAsync(InputFileArguments inputFileArguments);
    Task RotateVideoByAngleAsync(RotateVideoArguments rotateVideoArguments);
    Task WebOptimizeVideoAsync(InputFileArguments inputFileArguments);
}