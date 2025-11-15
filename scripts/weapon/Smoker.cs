using Godot;
using System;
using finalSDP.scripts.weapon;

public partial class Smoker : Weapon
{
	private bool Left = true;

	public override void Attack(float angle = 0)
	{
		if (!TimerCheck()) return;
		Left = !Left;
		var bullet = InstantiateBullet(angle);
		bullet.Position += 30* (Left ? Vector2.Left : Vector2.Right);
		SpawnWay(bullet);
	}
}
