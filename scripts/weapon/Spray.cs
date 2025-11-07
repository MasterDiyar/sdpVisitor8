using Godot;
using System;
using finalSDP.scripts.entity.bullet;
using finalSDP.scripts.weapon;

public partial class Spray : Weapon
{
    protected override void SpawnWay(Bullet node)
    {
        node.Gravity = 0;
        base.SpawnWay(node);
    }
}
