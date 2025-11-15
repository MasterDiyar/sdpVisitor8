using Godot;
using System;
using finalSDP.scripts.entity.bullet;
using finalSDP.scripts.weapon;

public partial class Cristalix : Weapon
{
    public override void SpawnWay(Bullet node)
    {
        node.Scale *= 3;
        base.SpawnWay(node);
    }
}
