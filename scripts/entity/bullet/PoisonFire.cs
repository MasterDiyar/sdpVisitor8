using finalSDP.scripts.entity.player;

namespace finalSDP.scripts.entity.bullet;

using Godot;

public partial class PoisonFire: Bullet
{
    public CollisionShape2D Shape;
    AnimatedSprite2D sprite;
    public override void _Ready()
    {
        sprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
        sprite.Play();
        sprite.Rotation = Angle.Angle();
        base._Ready();
        Shape = GetNode<CollisionShape2D>("CollisionShape2D");
        Shape.Rotation = -Mathf.Pi/2 +Angle.Angle();
        Shape.Position = Angle*40;
    }

    public override void _Process(double delta)
    {
        base._Process(delta);
        Shape.Position += Vector2.Right*40*Angle.X *(float)delta;
    }

    public override void OnBodyHit(Node body)
    {
        if (body is not Player && body is Entity entity)
        {
            entity.TakeDamage(Damage);
        }
    }
}