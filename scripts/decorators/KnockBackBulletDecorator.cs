using finalSDP.scripts.entity;
using finalSDP.scripts.entity.bullet;
using finalSDP.scripts.entity.player;
using Godot;

namespace finalSDP.scripts.decorators;

public partial class KnockBackBulletDecorator: Node2D
{
    Bullet _bullet;
    public override void _Ready()
    {
        _bullet = GetParent<Bullet>();
        _bullet.OtPiska();
        _bullet.BodyEntered += OnBodyHit;
    }

    public void OnBodyHit(Node body)
    {
        if (body is not Player and Entity entity)
        {
            entity.TakeDamage(_bullet.Damage);
            entity.Velocity += Vector2.Up * 400;
            entity.MoveAndSlide();
            QueueFree();
        }
    }


}