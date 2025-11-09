using Godot;
using System;
using finalSDP.scripts.entity;
using finalSDP.scripts.entity.bullet;
using finalSDP.scripts.entity.player;

public partial class CatanaSwing : Bullet
{
	public override void _Ready()
	{
		var Ano = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		Ano.Play();
		Ano.AnimationFinished += QueueFree;
		base._Ready();
		Gravity = 0;
		Speed = 0;	
	}
	
	public override void OnBodyHit(Node body)
	{
		if (body is not Player && body is Entity entity)
		{
			entity.TakeDamage(Damage);
		}
	}
}
