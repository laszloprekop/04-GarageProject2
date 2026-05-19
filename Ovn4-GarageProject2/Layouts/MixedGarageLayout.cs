namespace Ovn4_GarageProject2.Layouts;
using Domain;

public static class MixedGarageLayout
{
    private static readonly string[] Blueprint =
    [
        "░░░░░░░░░░░░░░░░",
        "░░│C│C│p│p│  bb░",
        "░            bb░",
        "░ │C│c│c│p│  bb░",
        "░ ├─┼─┼─┼─┤  ──░",
        "░ │C│c│c│P│  bb░",
        "░            bb░",
        "░░│C│C│p│P│  bb░",
        "░░░░░░░░░░░  ░░░",
    ];

    public static Garage<Vehicle> Create() =>
        LayoutParser.Parse<Vehicle>("Mixed Garage", Blueprint);
}
