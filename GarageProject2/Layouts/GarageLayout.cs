using GarageProject2.Domain;

namespace GarageProject2.Layouts;

public record GarageLayout(
    GarageCell[,] LogicalGrid,
    char[] TopWall,
    char[] BottomWall,
    char[] LeftWall,
    char[] RightWall,
    BayAnchor[] BayAnchors
);
