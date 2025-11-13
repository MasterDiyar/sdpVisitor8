using Godot;
using System;
using finalSDP.scripts.entity.bullet;
using finalSDP.scripts.entity.player;

public partial class Spore : Bullet
{
	public override void _Ready()
	{
		base._Ready();
		Speed = 90;
		Scale = GD.Randf() * 1.5f * Vector2.One;
	}

	public override void _Process(double delta)
	{
		base._Process(delta);
		Speed -= 10*(float) delta;
		Position += (float) delta * Angle * Speed;
		Rotate((float) delta*3);
	}
	
	public override void OnBodyHit(Node body)
	{
		if (body is Player entity) {
			entity.TakeDamage(Damage);
			QueueFree();
		}
	}
}
