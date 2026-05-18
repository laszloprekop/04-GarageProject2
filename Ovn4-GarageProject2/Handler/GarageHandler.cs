using Ovn4_GarageProject2.Domain;

namespace Ovn4_GarageProject2.Handler;

public class GarageHandler : IHandler
{
    private IGarage? _garage;

    public void SetGarage(IGarage garage) => _garage = garage;

    public bool ParkAtSpot(int spotId, Vehicle vehicle)
    {
        if (_garage is null) return false;
        var spot = _garage.GetGrid().Cast<Domain.GarageCell>()
            .OfType<Domain.ParkingSpot>()
            .FirstOrDefault(s => s.Id == spotId);
        return spot?.TryPark(vehicle) ?? false;
    }

    public IEnumerable<Vehicle> GetAllVehicles() =>
        _garage?.GetAll() ?? Enumerable.Empty<Vehicle>();
}
