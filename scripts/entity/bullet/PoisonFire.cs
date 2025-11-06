namespace finalSDP.scripts.entity.bullet;

using Godot;

public partial class PoisonFire: Bullet
{
    public CollisionShape2D Shape;
    public override void _Ready()
    {
        GetNode<AnimatedSprite2D>("AnimatedSprite2D").Play();
        base._Ready();
        Shape = GetNode<CollisionShape2D>("CollisionShape2D");
    }

    public override void _Process(double delta)
    {
        base._Process(delta);
        Shape.Position += Vector2.Right*40 *(float)delta;
    }
}