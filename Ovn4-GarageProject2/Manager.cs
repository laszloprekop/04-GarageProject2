using Ovn4_GarageProject2.Domain;
using Ovn4_GarageProject2.Handler;
using Ovn4_GarageProject2.Layouts;
using Ovn4_GarageProject2.UI;

namespace Ovn4_GarageProject2;

public class Manager
{
    private readonly IUi _ui;
    private readonly IHandler _handler;

    private readonly List<IGarage> _garages;
    private int _activeGarageIndex = 0;


    public Manager(IUi ui, IHandler handler)
    {
        _ui = ui;
        _handler = handler;
        _garages = [MixedGarageLayout.Create(), HangarLayout.Create()];
    }

    public void Seed()
    {
        // placeholder for seeding code
    }

    public IGarage ActiveGarage => _garages[_activeGarageIndex];

    public void Run() => _ui.Start();
}
