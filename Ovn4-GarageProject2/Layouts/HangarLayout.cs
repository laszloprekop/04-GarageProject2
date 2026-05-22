using Ovn4_GarageProject2.Domain;

namespace Ovn4_GarageProject2.Layouts;

public static class HangarLayout
{
    private static readonly string[] Blueprint =
    [
        "░░░  ░░░░░░░░░░  ░░░",
        "░    PPPPPPPPPP    ░",
        "░bb              bb░",
        "░bb  cccc  cccc  bb░",
        "░bb  cccc  cccc  bb░",
        "░                  ░",
        "░   cccc    cccc   ░",
        "░   cccc    cccc   ░",
        "░                  ░",
        "░░░░░░░░    ░░░░░░░░",
    ];

    public static Garage<Airplane> Create() =>
        LayoutParser.Parse<Airplane>("Hangar", Blueprint);
}
