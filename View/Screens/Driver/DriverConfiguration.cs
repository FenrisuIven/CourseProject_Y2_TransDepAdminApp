using System.Collections.Generic;
using System.Linq;

namespace TransDep_AdminApp.View.Screens;

public static class DriverConfiguration
{
    public static readonly List<string> Categories = new()
    {
        "B",
        "BE",
        "C",
        "CE",
    };

    public static readonly List<string> Ratings = Enumerable.Range(0, 10).Select((_, index) => $"{index + 1}").ToList();
}