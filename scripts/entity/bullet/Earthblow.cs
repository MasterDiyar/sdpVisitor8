using Godot;
using System;
using finalSDP.scripts.entity.bullet;
using finalSDP.scripts.entity.player;

public partial class Earthblow : Bullet
{
	private AnimatedSprite2D anim;
	public override void _Ready()
	{
		anim = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		anim.Play();
		anim.AnimationFinished += QueueFree;
		Gravity = 0;
	}
	
	public override void OnBodyHit(Node body)
	{
		if (body is Player entity)
		{
			entity.TakeDamage(Damage);
		}
	}
}
