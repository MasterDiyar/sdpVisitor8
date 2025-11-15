using System;
namespace finalSDP.scripts.Adapters;
using Godot;
public partial class MovementAdapter : Control
{
    public IDecorator current { get; private set; }
    public InputDevice CurrentDevice;
    private readonly KeyBordAdapter kb = new();
    private readonly GamePadAdapter pad = new();
    public override void _Ready() {
        SetDevice(InputDevice.Keyboard);
    }
    public void SetDevice(InputDevice device)
    {
        CurrentDevice = device; 
        switch (device)
        { 
            case InputDevice.GamePad:
                current = pad;
                GD.Print("GamePad");
                break;
            case InputDevice.Keyboard:
                current = kb;
                GD.Print("KeyBord");
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(device), device, null);
        }
    }
}