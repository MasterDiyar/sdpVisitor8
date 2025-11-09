using Godot;
using System;
using finalSDP.scripts.entity.bullet;

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
}
