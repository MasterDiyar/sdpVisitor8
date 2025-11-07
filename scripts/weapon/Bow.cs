using Godot;
using System;
using finalSDP.scripts.weapon;

public partial class Bow : Weapon
{
	private AnimatedSprite2D bow;
	public override void _Ready()
	{
		bow = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		base._Ready();
		
	}

	public override void _Process(double delta)
	{
		base._Process(delta);
		LookAt(GetGlobalMousePosition());
	}

	protected override bool TimerCheck()
	{
		if (!timer.IsStopped()) return false;
		bow.Play();
		timer.Start();
		return true;
	}
}
