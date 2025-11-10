using Godot;
using System;
using finalSDP.scripts.entity;

public partial class Golem : Entity
{
	public override void _Ready()
	{
		base._Ready();
		Speed = 800;
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
