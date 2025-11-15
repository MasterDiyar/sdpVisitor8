using finalSDP.scripts.entity;
using finalSDP.scripts.entity.bullet;
using finalSDP.scripts.entity.player;
using Godot;

namespace finalSDP.scripts.decorators;

public partial class PoisonousBulletDecorator(Bullet bullet) : BulletDecorator(bullet)
{
    public override void OnBodyHit(Node body)
    {
        if (body is not Player and Entity entity)
        {
            entity.TakeDamage(Damage);
            entity.AddChild(GD.Load<PackedScene>("res://scenes/bullets/poison.tscn").Instantiate());
        }
    }
}