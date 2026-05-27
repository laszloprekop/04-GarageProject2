using GarageProject2.Domain;
using GarageProject2.Layouts;

namespace GarageProject2.Handler;

public interface IHandler
{
    IEnumerable<Vehicle> GetAllVehicles();
    GarageCell[,] GetGrid();
    GarageLayout GetLayout();
    IEnumerable<(string Type, int Count)> GetVehicleTypeCounts();

    /// <summary>
    /// Parks <paramref name="vehicle"/> in the first available spot.
    /// </summary>
    /// <returns>The anchor spot's ID on success, or <see langword="null"/> if parking failed.</returns>
    int? Park(Vehicle vehicle);

    bool Remove(string regNumber);
    IEnumerable<Vehicle> FindByReg(string partialRegNumber);
    IEnumerable<Vehicle> Search(string? colour, string? wheelCount, Type? vehicleType);
    IReadOnlyList<ParkingSession> GetSessionHistory();
    IEnumerable<string> GetReservedRegNumbers();
    void LoadState(GarageState state);
    GarageState SaveState();
}
