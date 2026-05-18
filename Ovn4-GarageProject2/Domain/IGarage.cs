namespace Ovn4_GarageProject2.Domain;

public interface IGarage
{
    string Name { get; }
    int Capacity { get; }
    IEnumerable<Vehicle> GetAll();
    GarageCell[,] GetGrid();
}
