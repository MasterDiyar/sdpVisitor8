using Godot;
public interface IDecorator
{
    Vector2 GetMove();
    bool JumpPressed();
    bool AttactPressed();
}