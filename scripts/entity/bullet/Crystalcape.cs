using Godot;
using System;
using finalSDP.scripts.entity;
using finalSDP.scripts.entity.bullet;
using finalSDP.scripts.entity.player;

public partial class Crystalcape : Bullet
{
	AnimatedSprite2D sprite;
	CollisionShape2D collision;
	public override void _Ready()
	{
		base._Ready();
		sprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		collision = GetNode<CollisionShape2D>("CollisionShape2D");
		sprite.Play();
		sprite.AnimationFinished += QueueFree;
	}

	public override void _Process(double delta)
	{
		collision.Scale += (collision.Scale.X <= 1 ) ? (float)delta * Vector2.Right : Vector2.Zero;
		GD.Print("Crystalcape ", collision.Scale.X);
	}
	
	public override void OnBodyHit(Node body)
	{
		if (body is Player entity)  {
			entity.TakeDamage(Damage);
			QueueFree();
		}
	}
}

