using finalSDP.scripts.entity;
using finalSDP.scripts.entity.bullet;
using finalSDP.scripts.entity.player;
using Godot;

namespace finalSDP.scripts.decorators;

public partial class KnockBackBulletDecorator(Bullet bullet) : BulletDecorator(bullet)
{
    public override void OnBodyHit(Node body)
    {
        if (body is Entity entity and not Player)
        {
            entity.TakeDamage(Damage);
            entity.Velocity += Vector2.Up * 40;
            entity.MoveAndSlide();
        }
    }
}