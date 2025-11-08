using Godot;
using System;
using finalSDP.scripts.entity.bullet;

public partial class Whatisdad : Bullet
{

	public override void _Ready()
	{
		Gravity = 0;
		Speed = 10;
	}

	public override void _Process(double delta)
	{
		Speed -= (float)delta * 3.3f;
		Angle = Angle.Rotated(2 * (float)delta);
		Velocity = Angle.Normalized() * Speed;
		
		Position += Velocity ;
		
		if (Speed < 0) QueueFree();
	}
}
