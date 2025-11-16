using Godot;
using System;
using finalSDP.scripts.weapon;

public partial class Darkpistol : Weapon
{
	public override void _Ready()
	{
		base._Ready();
		timer ??= GetChild<Timer>(0);
	}

	public override void Attack(float angle = 0)
	{
		if (!TimerCheck()) return;
		var multi = GD.RandRange(1, 2);
		for (int i = 0; i < 4; i++){
			var bullet = InstantiateBullet(angle + i * Mathf.Pi / 8+ multi * Mathf.Pi/ 4);
			bullet.Rotation = bullet.Angle.Angle();
			SpawnWay(bullet);
		}
	}
}
