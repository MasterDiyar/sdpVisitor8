using Godot;
using System;
using finalSDP.scripts.entity.bullet;
using finalSDP.scripts.entity.player;

public partial class Smoke : Bullet
{
	public override void _Process(double delta)
	{
		Scale += (float) delta * Vector2.One;
	}
	
	public override void OnBodyHit(Node body)
	{
		if (body is Player entity) {
			entity.TakeDamage(Damage);
			QueueFree();
		}
	}
}
