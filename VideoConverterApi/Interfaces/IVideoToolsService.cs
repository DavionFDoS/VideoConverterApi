using VideoConverterApi.Models;

namespace VideoConverterApi.Interfaces;

public interface IVideoToolsService
{
    Task AddAudioAsync();
    Task AddSubtitlesAsync();
    Task AddWatermarkAsync();
    Task ChangeAudioBitrateAsync(ChangeAudioBitrateArguments changeAudioBitrateArguments);
    Task ChangeAudioVolumeAsync(ChangeAudioVolumeArguments changeAudioVolumeArguments);
    Task ChangeVideoBitrateAsync(ChangeVideoBitrateArguments changeVideoBitrateArguments);
    Task ChangeVideoResolutionAsync();
    Task ChangeVideoSpeedAsync(ChangeVideoSpeedArguments changeVideoSpeedArguments);
    Task CropVideoAsync(CropVideoArguments cropVideoArguments);
    Task CutVideoAsync(CutVideoArguments cutVideoArguments);
    Task ExtractAudioAsync(InputFileArguments inputFileArguments);
    Task ExtractSingleFrameAsync(ExtractSingleFrameArguments extractSingleFrameArguments);
    Task MergeVideosAsync();
    Task ReflectVideoAsync(ReflectVideoArguments reflectVideoArguments);
    Task RemoveAudioAsync(InputFileArguments inputFileArguments);
    Task ReverseVideoAsync(InputFileArguments inputFileArguments);
    Task RotateVideoByAngleAsync(RotateVideoArguments rotateVideoArguments);
    Task WebOptimizeVideoAsync(InputFileArguments inputFileArguments);
}