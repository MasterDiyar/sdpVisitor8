using finalSDP.scripts.entity;
using finalSDP.scripts.entity.bullet;
using finalSDP.scripts.entity.player;
using Godot;

namespace finalSDP.scripts.decorators;

public partial class PoisonousBulletDecorator : Node2D
{
    Bullet _bullet;
    public override void _Ready()
    {
        _bullet = GetParent<Bullet>();
    }

    public void OnBodyHit(Node body)
    {
        if (body is not Player and Entity entity)
        {
            entity.TakeDamage(_bullet.Damage);
            entity.AddChild(GD.Load<PackedScene>("res://scenes/bullets/poison.tscn").Instantiate());
        }
    }
}