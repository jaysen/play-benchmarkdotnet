using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenchMarkPlay;

public class DateParser
{
    public int GetYearFromDateTime(string dateTimeAsString)
    {
        DateTime dateTime = DateTime.Parse(dateTimeAsString);
        return dateTime.Year;
    }

    public int GetYearFromSplit(string dateTimeAsString)
    {
        string[] parts = dateTimeAsString.Split('-');
        return int.Parse(parts[0]);
    }

    public int GetYearFromSubstringParse(string dateTimeAsString)
    {
        var indexOfHyphen = dateTimeAsString.IndexOf('-');
        string year = dateTimeAsString.Substring(0,indexOfHyphen);
        return int.Parse(year);
    }

    public int GetYearFromSpanParse(ReadOnlySpan<char> dateTimeAsSpan)
    {
        var indexOfHyphen = dateTimeAsSpan.IndexOf('-');
        return int.Parse(dateTimeAsSpan.Slice(0, indexOfHyphen));
    }

    public int GetYearFromSubstringManual(string dateTimeAsString)
    {
        var indexOfHyphen = dateTimeAsString.IndexOf('-');
        string yearAsString = dateTimeAsString[..indexOfHyphen];
        //string yearAsString = dateTimeAsString.Substring(0,indexOfHyphen);
        int result = 0;

        for (int i = 0; i < yearAsString.Length; i++)
        {
            result = result * 10 + (yearAsString[i] - '0');
        }
        return result;
    }

    public int GetYearFromSpanManual(ReadOnlySpan<char> dateTimeAsSpan)
    {
        var indexOfHyphen = dateTimeAsSpan.IndexOf('-');
        var yearAsSpan = dateTimeAsSpan[..indexOfHyphen];
        int result = 0;

        for (int i = 0; i < yearAsSpan.Length; i++)
        {
            result = result * 10 + (yearAsSpan[i] - '0');
        }
        return result;
    }
}
