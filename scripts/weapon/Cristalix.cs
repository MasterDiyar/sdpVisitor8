using Godot;
using System;
using finalSDP.scripts.entity.bullet;
using finalSDP.scripts.weapon;

public partial class Cristalix : Weapon
{
    protected override void SpawnWay(Bullet node)
    {
        node.Scale *= 3;
        base.SpawnWay(node);
    }
}
