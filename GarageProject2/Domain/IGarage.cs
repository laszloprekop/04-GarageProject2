using GarageProject2.Layouts;

namespace GarageProject2.Domain;

public interface IGarage
{
    string Name { get; }
    int Capacity { get; }
    GarageLayout Layout { get; }
    IEnumerable<Vehicle> GetAll();
    GarageCell[,] GetGrid();
}
