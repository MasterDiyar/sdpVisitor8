using Godot;
using System;
using finalSDP.scripts.entity;
using finalSDP.scripts.entity.bullet;
using finalSDP.scripts.entity.player;

public partial class Crystalcape : Bullet
{
	AnimatedSprite2D sprite;
	public override void _Ready()
	{
		base._Ready();
		sprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		sprite.Play();
		sprite.AnimationFinished += QueueFree;
	}
	public override void _Process(double delta){}
	
	public override void OnBodyHit(Node body)
	{
		if (body is Player entity)  {
			entity.TakeDamage(Damage);
			QueueFree();
		}
	}
}

