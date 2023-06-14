using VideoConverterApi.Models;

namespace VideoConverterApi.Interfaces
{
    public interface IUploadsCalculator
    {
        PrecalculatedSize? PrecalculatedSize { get; set; }
        SizeCalculationVariables? SizeCalculationVariables { get; set; }

        UploadsCalculatorVariables CheckUploadAccessibility();
    }
}