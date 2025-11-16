using Godot;
using System;
using finalSDP.scripts.entity.bullet;
using finalSDP.scripts.weapon;

public partial class Cristshoot : Weapon
{
	public override void Attack(float angle = 0)
	{
		if (!TimerCheck()) return;
		for (int i = 0; i < 9; i++){
			GD.Print(angle - i * Mathf.Pi / 8);
			var bullet = InstantiateBullet(angle - i * Mathf.Pi / 8);
			bullet.Position += 32 * Vector2.Down;
			SpawnWay(bullet);
		}
	}

	public override void SpawnWay(Bullet node)
	{
		base.SpawnWay(node);
		node.Scale = Vector2.One;
	}
}
