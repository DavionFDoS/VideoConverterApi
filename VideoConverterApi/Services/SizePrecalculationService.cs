﻿using VideoConverterApi.Enums;
using VideoConverterApi.Interfaces;
using VideoConverterApi.Models;

namespace VideoConverterApi.Services;

public class SizePrecalculationService : ISizePrecalculationService
{
    public PrecalculatedSize CalculateSize(SizeCalculationVariables sizeCalculationVariables)
    {
        if (sizeCalculationVariables is null)
        {
            return new PrecalculatedSize();
        }

        bool vb = ulong.TryParse(sizeCalculationVariables.VideoBitrateAsString, out ulong videoBitrate);
        bool ab = ulong.TryParse(sizeCalculationVariables.AudioBitrateAsString, out ulong audioBitrate);

        if (!vb && !ab)
        {
            return new PrecalculatedSize();
        }

        var fileSizeInBits = (videoBitrate + audioBitrate) * sizeCalculationVariables.Duration * CalculateOverheadFactor(sizeCalculationVariables.OverheadFactor);
        return new PrecalculatedSize
        {
            SizeInBits = (ulong)fileSizeInBits,
            SizeInMegaBytes = ToMegabytes(fileSizeInBits)
        };
    }

    private static double ToMegabytes(double sizeInBits)
    {
        return Math.Round(sizeInBits / 1024 / 1024 / 8, 2);
    }

    private static double CalculateOverheadFactor(OverheadFactor overheadFactor)
    {
        return overheadFactor switch
        {
            OverheadFactor.H264 => 1.2,
            OverheadFactor.H265 => 1.35,
            OverheadFactor.VP9 => 1.35,
            OverheadFactor.AV1 => 1.45,
            OverheadFactor.MPEG2 => 1.1,
            OverheadFactor.MPEG4 => 1.2,
            OverheadFactor.DV => 1.0,
            OverheadFactor.ProRes => 1.1,
            OverheadFactor.DNxHD => 1.2,
            OverheadFactor.FFV1 => 1.0,
            OverheadFactor.MJPEG => 1.2,
            _ => 1.25
        };
    }
}
