using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Order;
using CommandLine;

namespace BenchMarkPlay;

[MemoryDiagnoser]
//[ShortRunJob]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]

public class DateTimeBenchmarks
{
    private const string DateTime = "1972-05-14T23:00:00";
    private static readonly DateParser parser = new();

    [Benchmark]
    public void GetYearFromDateTime()
    {
        parser.GetYearFromDateTime(DateTime);
    }

    [Benchmark]
    public void GetYearFromStringSplit()
    {
        parser.GetYearFromSplit(DateTime);
    }

    [Benchmark]
    public void GetYearFromStringParse()
    {
        parser.GetYearFromSubstringParse(DateTime);
    }

    [Benchmark]
    public void GetYearFromSpanParse()
    {
        parser.GetYearFromSpanParse(DateTime.AsSpan());
    }

    [Benchmark]
    public void GetYearFromStringManual()
    {
        parser.GetYearFromSubstringManual(DateTime);
    }

    [Benchmark]
    public void GetYearFromSpanManual()
    {
        parser.GetYearFromSubstringManual(DateTime);
    }
}
