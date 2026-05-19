using Ovn4_GarageProject2.Domain;

namespace Ovn4_GarageProject2.Handler;

public class GarageHandler : IHandler
{
    private IGarage? _garage;

    public void SetGarage(IGarage garage) => _garage = garage;

    public GarageCell[,] GetGrid() => _garage?.GetGrid() ?? new GarageCell[0, 0];

    public bool ParkAtSpot(int spotId, Vehicle vehicle)
    {
        if (_garage is null) return false;
        var spot = _garage.GetGrid().Cast<GarageCell>()
            .OfType<ParkingSpot>()
            .FirstOrDefault(s => s.Id == spotId);
        return spot?.TryPark(vehicle) ?? false;
    }

    public IEnumerable<Vehicle> GetAllVehicles() =>
        _garage?.GetAll() ?? Enumerable.Empty<Vehicle>();

    public IEnumerable<(string Type, int Count)> GetVehicleTypeCounts() =>
        _garage?.GetAll()
            .GroupBy(vehicle => vehicle.GetType().Name)
            .Select(g => (Type: g.Key, Count: g.Count()))
        ?? Enumerable.Empty<(string, int)>();

    public bool Park(Vehicle vehicle) => true;

    public ParkingSpot? FindFreeSpot(int width, int height, Type? requiredType = null)
    {
        if (_garage is null) return null;
        var grid = _garage.GetGrid();
        int rows = grid.GetLength(0);
        int cols = grid.GetLength(1);

        for (int r = 0; r <= rows - height; r++)
        {
            for (int c = 0; c <= cols - width; c++)
            {
                if (RectangleFree(grid, r, c, width, height, requiredType))
                    return (ParkingSpot)grid[r, c];
            }
        }

        return null;
    }

    private static bool RectangleFree(GarageCell[,] grid, int startRow, int startCol, int width, int height,
        Type? requiredType)
    {
        for (int r = startRow; r < startRow + height; r++)
        {
            for (int c = startCol; c < startCol + width; c++)
            {
                if (grid[r, c] is not ParkingSpot spot) return false;
                if (!spot.CanMerge) return false;
                if (requiredType is not null && spot.AllowedVehicleType != requiredType) return false;
            }
        }

        return true;
    }
}
