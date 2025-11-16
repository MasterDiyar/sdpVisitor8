using Godot;
using System;

public partial class Firegolem : Golem
{
	public override void _Ready()
	{
		base._Ready();
		Speed = 1600;
		Gravity = 700f;
	}

	
}
