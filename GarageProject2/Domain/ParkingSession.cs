namespace GarageProject2.Domain;

public record ParkingSession(int SpotId, string RegNumber, DateTime Start, DateTime? End = null);
