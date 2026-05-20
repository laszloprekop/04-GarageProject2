using Ovn4_GarageProject2.Domain;

namespace Ovn4_GarageProject2.Layouts;

public static class HangarLayout
{
    private static readonly string[] Blueprint =
    [
        "░░░  ░░░░░░░░░░░░░░░░░░░░░  ░░░",
        "░    │P│P│P│P│P│P│P│P│P│P│    ░",
        "░bb                         bb░",
        "░bb  │c│c│c│c│   │c│c│c│c│  bb░",
        "░bb  ├─┼─┼─┼─┤   ├─┼─┼─┼─┤  bb░",
        "░──  │c│c│c│c│   │c│c│c│c│  ──░",
        "░                             ░",
        "░  │c│c│c│c│       │c│c│c│c│  ░",
        "░  ├─┼─┼─┼─┤       ├─┼─┼─┼─┤  ░",
        "░  │c│c│c│c│       │c│c│c│c│  ░",
        "░                             ░",
        "░░░░░░░░░░░░───────░░░░░░░░░░░░"
    ];

    public static Garage<Airplane> Create() =>
        LayoutParser.Parse<Airplane>("Hangar", Blueprint);
}
