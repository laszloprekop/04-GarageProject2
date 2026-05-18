using System.Collections;

namespace Ovn4_GarageProject2.Domain;

public class Garage<T> : IGarage, IEnumerable<T> where T : Vehicle
{
    private readonly GarageCell[,] _grid = new GarageCell[0, 0];

    public string Name => "Garage";
    public int Capacity => 0;

    public IEnumerable<Vehicle> GetAll() => Enumerable.Empty<Vehicle>();
    public GarageCell[,] GetGrid() => _grid;

    public IEnumerator<T> GetEnumerator() => Enumerable.Empty<T>().GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
