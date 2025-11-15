using Godot;
using System;
using finalSDP.scripts.weapon;

public partial class Inidat : Weapon
{
	public override void _Ready()
	{
		base._Ready();
		timer ??= GetChild<Timer>(0);
		bulletScene ??= GD.Load<PackedScene>("res://scenes/bullets/whatisdad.tscn");
	}

	public override void Attack(float angle = 0)
	{
		if (!TimerCheck()) return;
		for (int i = 0; i < 8; i++){
			GD.Print(angle + i * Mathf.Pi / 4);
			var bullet = InstantiateBullet(angle + i * Mathf.Pi / 4);
			SpawnWay(bullet);
		}
	}
}
