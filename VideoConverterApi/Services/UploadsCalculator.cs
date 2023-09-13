using VideoConverterApi.Enums;
using VideoConverterApi.Interfaces;
using VideoConverterApi.Models;

namespace VideoConverterApi.Services;

public class UploadsCalculator : IUploadsCalculator
{
    public SizeCalculationVariables? SizeCalculationVariables { get; set; }
    public PrecalculatedSize? PrecalculatedSize { get; set; }

    public UploadsCalculatorVariables CheckUploadAccessibility()
    {
        var canBeUploadedToVK = CanUploadToVK();
        var canBeUploadedToTelegram = CanUploadToTelegram();
        var canBeUploadedToReddit = CanUploadToReddit();
        var canBeUploadedToYoutube = CanUploadToYoutube();
        var canBeUploadedToDiscord = CanUploadToDiscord();
        var canBeUploadedToTwitter = CanUploadToTwitter();

        return new UploadsCalculatorVariables
        {
            CanBeUploadedToVK = canBeUploadedToVK,
            CanBeUploadedToTelegram = canBeUploadedToTelegram,
            CanBeUploadedToReddit = canBeUploadedToReddit,
            CanBeUploadedToYoutube = canBeUploadedToYoutube,
            CanBeUploadedToDiscord = canBeUploadedToDiscord,
            CanBeUploadedToTwitter = canBeUploadedToTwitter,
            PrecalculatedSize = PrecalculatedSize
        };
    }

    private bool CanUploadToVK()
    {
        bool acceptableVideoBitrate;
        bool acceptableFileSize;
        ulong maxFileSixe = 2199023255552;  //256gb

        var acceptableFormat = SizeCalculationVariables?.FileFormat switch
        {
            FileFormat.AVI => true,
            FileFormat.MP4 => true,
            FileFormat._3GP => true,
            FileFormat.MPEG => true,
            FileFormat.MOV => true,
            FileFormat.FLV => true,
            FileFormat.F4V => true,
            FileFormat.WMV => true,
            FileFormat.MKV => true,
            FileFormat.WebM => true,
            FileFormat.VOB => true,
            FileFormat.RM => true,
            FileFormat.RMVB => true,
            FileFormat.M4V => true,
            FileFormat.MPG => true,
            FileFormat.OGV => true,
            FileFormat.TS => true,
            FileFormat.M2TS => true,
            FileFormat.MTS => true,
            _ => false
        };

        if (Int32.TryParse(SizeCalculationVariables?.VideoBitrateAsString, out int videoBitrate))
        {
            acceptableVideoBitrate = videoBitrate > 5242880; // 5mbit
        }
        else
        {
            acceptableVideoBitrate = false;
        }

        if (PrecalculatedSize?.SizeInBits > maxFileSixe)
        {
            acceptableFileSize = false;
        }
        else
        {
            acceptableFileSize = true;
        }

        if (acceptableVideoBitrate && acceptableFormat && acceptableFileSize)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool CanUploadToTelegram()
    {
        bool acceptableFileSize;
        ulong maxFileSixe = 17179869184;  //2gb

        var acceptableFormat = SizeCalculationVariables?.FileFormat switch
        {
            FileFormat.AVI => true,
            FileFormat.MP4 => true,
            FileFormat._3GP => true,
            FileFormat.MPEG => true,
            FileFormat.MOV => true,
            FileFormat.FLV => true,
            FileFormat.F4V => true,
            FileFormat.WMV => true,
            FileFormat.MKV => true,
            FileFormat.WebM => true,
            FileFormat.VOB => true,
            FileFormat.RM => true,
            FileFormat.SWF => true,
            FileFormat.M4V => true,
            FileFormat.MPG => true,
            FileFormat.OGV => true,
            FileFormat.OGG => true,
            FileFormat.TS => true,
            FileFormat.DV => true,
            FileFormat.MTS => true,
            FileFormat.ASF => true,
            FileFormat.XVID => true,
            FileFormat.DIVX => true,
            _ => false
        };

        if (PrecalculatedSize?.SizeInBits > maxFileSixe)
        {
            acceptableFileSize = false;
        }
        else
        {
            acceptableFileSize = true;
        }

        if (acceptableFormat && acceptableFileSize)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool CanUploadToReddit()
    {
        bool acceptableFileSize;
        ulong maxFileSixe = 8589934592; //1gb

        var acceptableFormat = SizeCalculationVariables?.FileFormat switch
        {
            FileFormat.MP4 => true,
            FileFormat.MOV => true,
            _ => false
        };

        if (PrecalculatedSize?.SizeInBits > maxFileSixe)
        {
            acceptableFileSize = false;
        }
        else
        {
            acceptableFileSize = true;
        }

        if (acceptableFormat && acceptableFileSize)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool CanUploadToYoutube()
    {
        bool acceptableFileSize;
        bool acceptableDuration;
        ulong maxFileSixe = 2199023255552; //256gb
        var maxDuration = 43200;  //12h
        var minDuration = 33;  //33s

        var acceptableFormat = SizeCalculationVariables?.FileFormat switch
        {
            FileFormat.AVI => true,
            FileFormat.MPEG => true,
            FileFormat.MOV => true,
            FileFormat.FLV => true,
            FileFormat.WMV => true,
            FileFormat.MPG => true,
            _ => false
        };

        if (PrecalculatedSize?.SizeInBits > maxFileSixe)
        {
            return false;
        }
        else
        {
            acceptableFileSize = true;
        }

        if (SizeCalculationVariables?.Duration > maxDuration || SizeCalculationVariables?.Duration < minDuration)
        {
            return false;
        }
        else
        {
            acceptableDuration = true;
        }

        if (acceptableFormat && acceptableFileSize || acceptableDuration)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool CanUploadToDiscord()
    {
        bool acceptableFileSize;
        ulong maxFileSixe = 209715200; //25mb

        var acceptableFormat = SizeCalculationVariables?.FileFormat switch
        {
            FileFormat.MP4 => true,
            FileFormat.WebM => true,
            FileFormat.MOV => true,
            _ => false
        };

        if (PrecalculatedSize?.SizeInBits > maxFileSixe)
        {
            acceptableFileSize = false;
        }
        else
        {
            acceptableFileSize = true;
        }

        if (acceptableFormat && acceptableFileSize)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool CanUploadToTwitter()
    {
        bool acceptableFileSize;
        bool acceptableVideoBitrate;
        ulong maxFileSixe = 209715200; //25mb

        var acceptableFormat = SizeCalculationVariables?.FileFormat switch
        {
            FileFormat.MP4 => true,
            FileFormat.M4V => true,
            FileFormat.MOV => true,
            _ => false
        };

        if (PrecalculatedSize?.SizeInBits > maxFileSixe)
        {
            acceptableFileSize = false;
        }
        else
        {
            acceptableFileSize = true;
        }

        if (Int32.TryParse(SizeCalculationVariables?.VideoBitrateAsString, out int videoBitrate))
        {
            acceptableVideoBitrate = videoBitrate > 26214400;  // 25mbit
        }
        else
        {
            acceptableVideoBitrate = false;
        }

        if (acceptableFormat && acceptableFileSize && acceptableVideoBitrate)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
