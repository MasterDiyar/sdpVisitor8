using Godot;
using System;
using finalSDP.scripts.entity;

public partial class Bolvanchik : Entity
{
    public override void TakeDamage(float damage)
    {
        GD.Print("Bolvanchik Take Damage");
        Hp -= damage;
        base.TakeDamage(damage);
    }
}
