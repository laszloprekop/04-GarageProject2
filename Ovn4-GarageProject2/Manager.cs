using Ovn4_GarageProject2.Domain;
using Ovn4_GarageProject2.Handler;
using Ovn4_GarageProject2.Layouts;
using Ovn4_GarageProject2.UI;

namespace Ovn4_GarageProject2;

public class Manager(IHandler handler)
{
    private readonly IHandler _handler = handler;

    private readonly List<IGarage> _garages = [MixedGarageLayout.Create(), HangarLayout.Create()];
    private int _activeGarageIndex;


    public void Seed()
    {
        // placeholder for seeding code
    }

    public IReadOnlyList<IGarage> Garages => _garages.AsReadOnly();

    public void SwitchGarage(int? index)
    {
        if (index is not { } i || i < 0 || i >= _garages.Count) return;
        _activeGarageIndex = i;
        ((Handler.GarageHandler)_handler).SetGarage(_garages[i]);
    }

    public IGarage ActiveGarage => _garages[_activeGarageIndex];

    public void Run(IUi ui) => ui.Start();
}
