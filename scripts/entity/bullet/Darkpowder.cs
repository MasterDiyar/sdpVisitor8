using Godot;
using System;
using finalSDP.scripts.entity.bullet;
using finalSDP.scripts.entity.player;

public partial class Darkpowder : Bullet
{
	public override void _Ready()
	{
		Speed = 6;
		Gravity = 0;
		base._Ready();
	}

	public override void _Process(double delta)
	{
		base._Process(delta);
		Rotate((float)delta);
	}

	public override void OnBodyHit(Node body)
	{
		var bul = GD.Load<PackedScene>("res://scenes/bullets/matterboom.tscn").Instantiate<Bullet>();
		bul.GlobalPosition = GlobalPosition;
		GetTree().Root.AddChild(bul);
		QueueFree();
	}

	public override void OnTimeout()
	{
		var bul = GD.Load<PackedScene>("res://scenes/bullets/matterboom.tscn").Instantiate<Bullet>();
		bul.GlobalPosition = GlobalPosition;
		GetTree().Root.AddChild(bul);
		QueueFree();
	}
}
