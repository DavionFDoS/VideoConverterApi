namespace VideoConverterApi.Interfaces;

public interface IConvertationService
{
    Task ConvertTo3GPWithNoArguments();
    Task ConvertToAVIWithArguments();
    Task ConvertToAVIWithNoArguments();
    Task ConvertToFLVWithNoArguments();
    Task ConvertToGIFWithNoArguments();
    Task ConvertToMKVWithArguments();
    Task ConvertToMKVWithNoArguments();
    Task ConvertToMOVWithArguments();
    Task ConvertToMOVWithNoArguments();
    Task ConvertToMP4WithArguments();
    Task ConvertToMP4WithNoArguments();
    Task ConvertToMPEGWithNoArguments();
    Task ConvertToSeriesOfImages();
    Task ConvertToWebMWithArguments();
    Task ConvertToWebMWithNoArguments();
    Task ConvertToWMVWithNoArguments();
}