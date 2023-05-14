using VideoConverterApi.Models;

namespace VideoConverterApi.Interfaces
{
    public interface ISizePrecalculationService
    {
        PrecalculatedSize CalculateSize(SizeCalculationVariables sizeCalculationVariables);
    }
}