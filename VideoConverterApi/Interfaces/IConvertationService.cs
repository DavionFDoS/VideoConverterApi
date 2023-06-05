using VideoConverterApi.Models;

namespace VideoConverterApi.Interfaces;

public interface IConvertationService
{
    Task<OutputFileArguments?> ConvertTo3GPWithNoArguments(InputFileArguments inputFileArguments);
    Task<OutputFileArguments?> ConvertToAVIWithArguments(ConvertToAVIArguments convertToAVIArguments);
    Task<OutputFileArguments?> ConvertToAVIWithNoArguments(InputFileArguments inputFileArguments);
    Task<OutputFileArguments?> ConvertToFLVWithNoArguments(InputFileArguments inputFileArguments);
    Task<OutputFileArguments?> ConvertToGIFWithArguments(ConvertToGIFArguments convertToGIFArguments);
    Task<OutputFileArguments?> ConvertToMKVWithArguments(ConvertToMKVArguments convertToMKVArguments);
    Task<OutputFileArguments?> ConvertToMKVWithNoArguments(InputFileArguments inputFileArguments);
    Task<OutputFileArguments?> ConvertToMOVWithArguments(ConvertToMOVArguments convertToMOVArguments);
    Task<OutputFileArguments?> ConvertToMOVWithNoArguments(InputFileArguments inputFileArguments);
    Task<OutputFileArguments?> ConvertToMP4WithArguments(ConvertToMP4Arguments convertToMP4Arguments);
    Task<OutputFileArguments?> ConvertToMP4WithNoArguments(InputFileArguments inputFileArguments);
    Task<OutputFileArguments?> ConvertToMPEGWithNoArguments(InputFileArguments inputFileArguments);
    Task<OutputFileArguments?> ConvertToSeriesOfImages(ConvertToSeriesOfImagesArguments convertToSeriesOfImagesArguments);
    Task<OutputFileArguments?> ConvertToWebMWithArguments(ConvertToWebmArguments convertToWebmArguments);
    Task<OutputFileArguments?> ConvertToWebMWithNoArguments(InputFileArguments inputFileArguments);
    Task<OutputFileArguments?> ConvertToWMVWithNoArguments(InputFileArguments inputFileArguments);
}