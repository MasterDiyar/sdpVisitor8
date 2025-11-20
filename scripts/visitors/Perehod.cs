using Godot;
using System;
using finalSDP.scripts.entity.player;

public partial class Perehod : Area2D
{
	[Export]private Node Deleter;
	[Export]private PackedScene Adder;
	[Export] private bool JustCome = false;
	bool canLeave = false;
	public override void _Ready()
	{
		BodyEntered += OnBodyEntered;
		BodyExited += OnBodyExited;
		if (JustCome)
		{
			Visible = false;
		}

	}

	public override void _Process(double delta)
	{
		if (canLeave && Input.IsActionJustPressed("e"))
			Prohod();
	}

	private void OnBodyExited(Node2D body)
	{
		canLeave = false;
	}

	private void OnBodyEntered(Node2D body)
	{
		if (body is not Player) return;
		if (JustCome)
			Prohod();
		else
			canLeave = true;
	}

	void Prohod()
	{
		Deleter.GetParent().AddChild(Adder.Instantiate());
		Deleter.QueueFree();
	}
}
