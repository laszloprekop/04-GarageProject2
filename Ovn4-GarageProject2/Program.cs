using Ovn4_GarageProject2;
using Ovn4_GarageProject2.Handler;
using Ovn4_GarageProject2.UI;

var handler = new GarageHandler();
var ui = new ConsoleUi(handler);
var manager = new Manager(ui, handler);
handler.SetGarage(manager.ActiveGarage);
// seed garage with some vehicles
handler.ParkAtSpot(15, new Ovn4_GarageProject2.Domain.Car
    { RegNumber = "ABC123", Colour = "Red", WheelCount = "4", FuelType = "Gasoline" });
handler.ParkAtSpot(17, new Ovn4_GarageProject2.Domain.Motorcycle
    { RegNumber = "DEF456", Colour = "Black", WheelCount = "2", CylinderVolume = "650" });

manager.Run();
