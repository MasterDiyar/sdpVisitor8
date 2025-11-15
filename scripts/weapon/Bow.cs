using Godot;
using System;
using finalSDP.scripts.Adapters;
using finalSDP.scripts.weapon;

public partial class Bow : Weapon
{
	private AnimatedSprite2D bow;
	private MovementAdapter adapter;
	private InputDevice device;
	public override void _Ready()
	{
		adapter =  GetNode<MovementAdapter>("/root/MovementAdapter");
		bow = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		base._Ready();
		
	}

	public override void _Process(double delta)
	{
		base._Process(delta);
		if(adapter.CurrentDevice == InputDevice.Keyboard) LookAt(GetGlobalMousePosition());
		if (adapter.CurrentDevice == InputDevice.GamePad)
		{
			var aim = new Vector2(
				Input.GetActionStrength("aim_right") - Input.GetActionStrength("aim_left"),
				Input.GetActionStrength("aim_down") - Input.GetActionStrength("aim_up")
				).Normalized();
			LookAt(aim + GlobalPosition);
		}
		

	}

	public override bool TimerCheck()
	{
		if (!timer.IsStopped()) return false;
		bow.Play();
		timer.Start();
		return true;
	}
}
