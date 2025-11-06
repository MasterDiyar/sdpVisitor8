using Godot;
using System;
using finalSDP.scripts.weapon;

public partial class Spray : Weapon
{
    protected override void SpawnWay(Node node)
    {
        GetParent().AddChild(node);
    }
        
}
