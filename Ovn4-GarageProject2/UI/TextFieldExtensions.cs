namespace Ovn4_GarageProject2.UI;

using Terminal.Gui.Input;
using Terminal.Gui.Views;

internal static class TextFieldExtensions
{
    internal static TextField OnEnter(this TextField field, Action action)
    {
        field.KeyDown += (_, key) => { if (key == Key.Enter) action(); };
        return field;
    }
}
