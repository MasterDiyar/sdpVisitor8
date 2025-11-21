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
		var t = GetNode<Timer>("Timer");
		t.Start();
		t.WaitTime = 5;
		t.Timeout += TOnTimeout;
	}

	private void TOnTimeout()
	{
		var chld =GD.Load<PackedScene>("res://scenes/levels/hand.tscn");
		for (int i = 4; i >= 0; i--)
		{
			var hand = chld.Instantiate<Hand>();
			hand.Position = GlobalPosition;
			GetParent().CallDeferred("add_child", hand);
		}
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
