namespace finalSDP.scripts.Adapters;
using Godot;
public class KeyBordAdapter : IDecorator
{
    public Vector2 GetMove()
    {
        var x = Input.GetActionStrength("right") - Input.GetActionStrength("left");
        return new Vector2(x, 0f);
    }

    public bool JumpPressed()
    {
        return Input.IsActionJustPressed("Jump");
    }
    public bool AttactPressed()
    {
        return Input.IsActionJustPressed("Attack");
    }
}