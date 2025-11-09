using Godot;
using System;
using finalSDP.scripts.weapon;

public partial class Invihammer : Weapon
{
	public override void _Ready()
	{
		base._Ready();
		bulletScene ??= GD.Load<PackedScene>("res://scenes/bullets/earthblow.tscn");
	}
}
