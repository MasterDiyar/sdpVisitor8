using Godot;

namespace finalSDP.scripts.Adapters;

public class GamePadAdapter : IDecorator
{
    public Vector2 GetMove()
    {
        var x = Input.GetActionStrength("move_right2") - Input.GetActionStrength("move_left2");
        return new Vector2(x, 0f);
    }

    public bool JumpPressed()
    {
        return Input.IsActionJustPressed("jump2");
    }

    public bool AttactPressed()
    {
        return Input.IsActionJustPressed("attack2");
        
    }
}