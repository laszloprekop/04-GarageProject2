using Ovn4_GarageProject2.Domain;

namespace Ovn4_GarageProject2.Handler;

public class GarageHandler : IHandler
{
    private IGarage _garage;

    public void SetGarage(IGarage garage) => _garage = garage;

    public IEnumerable<Vehicle> GetAllVehicles() =>
        _garage?.GetAll() ?? Enumerable.Empty<Vehicle>();
}
