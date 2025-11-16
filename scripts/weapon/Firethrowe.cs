using Godot;
using System;
using finalSDP.scripts.entity;
using finalSDP.scripts.weapon;

public partial class Firethrowe : Weapon
{
	public override void Attack(float angle = 0)
	{
		if (!TimerCheck()) return;
		var angl =( GetParent().GetParent().GetNode<Entity>("Player").GlobalPosition-GlobalPosition).Angle();
		var bullet = InstantiateBullet(angl);
		SpawnWay(bullet);
	}
}
