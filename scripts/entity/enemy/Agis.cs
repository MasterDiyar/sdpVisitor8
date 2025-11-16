using Godot;
using System;
using finalSDP.scripts.entity;

public partial class Agis : Entity
{
	private AnimatedSprite2D sprite;
	public override void _Ready()
	{
		base._Ready();
		sprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		sprite.Play();
		Speed = 4800;
		Gravity = 1f;
	}

	public override void _PhysicsProcess(double delta)
	{
		var velocity = Velocity;
		velocity.X = Direction * Speed * (float)delta;
		Velocity = velocity;
		MoveAndSlide();
	}

	public override void TakeDamage(float damage)
	{
		base.TakeDamage(damage);
		if (Hp < MaxHp / 2)
			Material = GD.Load<ShaderMaterial>("res://scenes/matterboom.tres");
	}
}
