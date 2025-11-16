using Godot;
using System;
using finalSDP.scripts.weapon;

public partial class Darkshot : Weapon
{
	public override void _Ready()
	{
		base._Ready();
		timer ??= GetChild<Timer>(0);
	}
	
	public override void Attack(float angle = 0)
	{
		if (!TimerCheck()) return;
		var bullet = InstantiateBullet(angle  +Mathf.Pi /2);
		bullet.Rotation = bullet.Angle.Angle();
		bullet.GlobalPosition = GlobalPosition + Vector2.Left*GD.RandRange(-392, 392);
		SpawnWay(bullet);
	}
}
