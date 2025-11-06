using Godot;
using System;
using finalSDP.scripts.entity.bullet;
using finalSDP.scripts.weapon;

public partial class Spray : Weapon
{
    protected override void Attack(float angle = 0)
    {
        var bullet = bulletScene.Instantiate<Bullet>();
        bullet.Angle = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        bullet.Position = GlobalPosition;
        bullet.Gravity = 0;
        SpawnWay(bullet);
    }
}
