namespace Ovn4_GarageProject2.Layouts;
using Domain;

public static class MixedGarageLayout
{
    private static readonly string[] Blueprint =
    [
        "░░░░░░░░░░░",
        "░░CCpp  bb░",
        "░       bb░",
        "░ Cccp  bb░",
        "░ CccP  bb░",
        "░       bb░",
        "░░CCpP  bb░",
        "░░░░░░  ░░░",
    ];

    public static Garage<Vehicle> Create() =>
        LayoutParser.Parse<Vehicle>("Mixed Garage", Blueprint);
}
