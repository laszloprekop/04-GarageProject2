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
        new("Car",        13, "DEF345", "Blue",   "4", "EV"),       // row1 col2 C (EV)
        new("Motorcycle", 36, "DEF456", "Black",  "2", "650"),      // row3 col3 c
        new("Car",        47, "ABC123", "Red",    "4", "Gasoline"), // row4 col3 c
        new("Bus",        19, "BUS001", "Yellow", "6", "12"),       // row1 col8 b (bay 1 anchor)
    ],
    ReservedSpots:
    [
        new(15, "GHI789"),  // row1 col4 p
        new(70, "JKL012"),  // row6 col4 p
    ],
    Sessions: []));

manager.Run(ui);
