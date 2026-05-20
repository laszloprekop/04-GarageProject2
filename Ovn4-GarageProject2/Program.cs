using Ovn4_GarageProject2;
using Ovn4_GarageProject2.Domain;
using Ovn4_GarageProject2.Handler;
using Ovn4_GarageProject2.UI;

var handler = new GarageHandler();
var manager = new Manager(handler);
var ui = new ConsoleUi(handler, manager);
handler.SetGarage(manager.ActiveGarage);

handler.LoadState(new GarageState(
    Vehicles:
    [
        new("Car",        21, "DEF345", "Blue",   "4", "EV"),
        new("Motorcycle", 23, "DEF456", "Black",  "2", "650"),
        new("Car",        89, "ABC123", "Red",    "4", "Gasoline"),
        new("Bus",        29, "BUS001", "Yellow", "6", "12"),
    ],
    ReservedSpots:
    [
        new(25,  "GHI789"),
        new(119, "JKL012"),
    ],
    Sessions: []));

manager.Run(ui);
