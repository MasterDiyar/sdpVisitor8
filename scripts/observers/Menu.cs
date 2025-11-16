using Godot;
using finalSDP.scripts.Adapters;

public partial class Menu : Node2D
{
    private MovementAdapter _adapter;
    public override void _Ready()
    {
        _adapter = GetTree().Root.GetNode<MovementAdapter>("MovementAdapter");
        var keyboard = GetNode<Button>("Button2");
        var gamepad  = GetNode<Button>("Button3");
        if (keyboard != null)
            keyboard.Pressed += () => {
                _adapter.SetDevice(InputDevice.Keyboard);
                LoadGame();
            };

        if (gamepad != null)
            gamepad.Pressed += () => {
                _adapter.SetDevice(InputDevice.GamePad);
                LoadGame();
            };
    }

    private void LoadGame()
    {
        var scene = GD.Load<PackedScene>("res://scenes/menu/user_select.tscn");
        GetParent().AddChild(scene.Instantiate());
        QueueFree();
    }
}
