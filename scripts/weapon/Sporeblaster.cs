using Godot;
using System;
using finalSDP.scripts.entity.bullet;
using finalSDP.scripts.weapon;

public partial class Sporeblaster : Weapon
{
	private bool Left = false;
	protected override void Attack(float angle = 0)
	{
		if (!TimerCheck()) return;
		Left = !Left;
		for (int i = 0; i < 4; i++) {
			var bullet = InstantiateBullet(angle);
			bullet.Position += 15* (Left ? Vector2.Left : Vector2.Right);
			SpawnWay(bullet);
		}
	}

	protected override Bullet InstantiateBullet(float angle)
	{
		return base.InstantiateBullet(Left ? angle - GD.Randf() * Mathf.Pi/2: angle + Mathf.Pi+ GD.Randf() * Mathf.Pi/2);
	}
}
