namespace GarageProject2.Domain;

public record VehicleRecord(
    string Type,
    int SpotId,
    string RegNumber,
    string Colour,
    string WheelCount,
    string Extra);

public record ReservedRecord(int SpotId, string RegNumber);

public record GarageState(
    List<VehicleRecord> Vehicles,
    List<ReservedRecord> ReservedSpots,
    List<ParkingSession> Sessions);
