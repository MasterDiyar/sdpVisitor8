using Godot;
using System;
using finalSDP.scripts.entity;

public partial class Mushroom : Entity
{
	public override void _Ready()
	{
		base._Ready();
		Speed = 2400;
		Gravity = 9.8f;
	}
	public override void _PhysicsProcess(double delta)
	{
		var velocity = Velocity;

		if (!IsOnFloor())
			velocity.Y += Gravity * (float)delta;
		velocity.X = Direction * Speed * (float)delta;
		Velocity = velocity;
		MoveAndSlide();
	}
}
