using Godot;

namespace finalSDP.scripts.entity.bullet;

public partial class Arrow : Bullet
{
    public override void _Ready()
    {
        Speed = 18;
        Gravity = 18;
        GetNode<Sprite2D>("Arrow").Rotation = Angle.Angle();
        base._Ready();
    }
}