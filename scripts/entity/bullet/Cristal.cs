using Godot;
using System;
using finalSDP.scripts.entity;
using finalSDP.scripts.entity.bullet;
using finalSDP.scripts.entity.player;

public partial class Cristal : Bullet
{
    public override void _Ready()
    {
        base._Ready();
        Speed = 10;
    }
    
    public override void _Process(double delta)
    {
        base._Process(delta);
        Speed -= (float)delta * 2.5f;
        Velocity = Angle.Normalized() * Speed;
		Rotation = Angle.Angle();
        Position += Velocity ;
		
        if (Speed < 0) QueueFree();
    }
    public override void OnBodyHit(Node body)
    {
        if (body is Player entity) {
            entity.TakeDamage(Damage);
            QueueFree();
        }
    }
}
