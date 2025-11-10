using finalSDP.scripts.entity.bullet;
using finalSDP.scripts.entity.player;
using Godot;
namespace finalSDP.scripts.decorators;

public partial class OnlyPlayersDecorator : BulletDecorator
{
    public OnlyPlayersDecorator(Bullet bullet) : base(bullet) { }

    public override void OnBodyHit(Node body)
    {
        if (body is Player entity)
        {
            entity.TakeDamage(Damage);
        }
    }
}