using VideoConverterApi.Models;
using VideoConverterApi.Modelsж;

namespace VideoConverterApi.Interfaces;

public interface IConvertationService
{
    Task ConvertTo3GPWithNoArguments(InputFileArguments inputFileArguments);
    Task ConvertToAVIWithArguments(ConvertToAVIArguments convertToAVIArguments);
    Task ConvertToAVIWithNoArguments(InputFileArguments inputFileArguments);
    Task ConvertToFLVWithNoArguments(InputFileArguments inputFileArguments);
    Task ConvertToGIFWithArguments(ConvertToGIFArguments convertToGIFArguments);
    Task ConvertToMKVWithArguments(ConvertToMKVArguments convertToMKVArguments);
    Task ConvertToMKVWithNoArguments(InputFileArguments inputFileArguments);
    Task ConvertToMOVWithArguments(ConvertToMOVArguments convertToMOVArguments);
    Task ConvertToMOVWithNoArguments(InputFileArguments inputFileArguments);
    Task ConvertToMP4WithArguments(ConvertToMP4Arguments convertToMP4Arguments);
    Task ConvertToMP4WithNoArguments(InputFileArguments inputFileArguments);
    Task ConvertToMPEGWithNoArguments(InputFileArguments inputFileArguments);
    Task ConvertToSeriesOfImages(ConvertToSeriesOfImagesArguments convertToSeriesOfImagesArguments);
    Task ConvertToWebMWithArguments(ConvertToWebmArguments convertToWebmArguments);
    Task ConvertToWebMWithNoArguments(InputFileArguments inputFileArguments);
    Task ConvertToWMVWithNoArguments(InputFileArguments inputFileArguments);
}