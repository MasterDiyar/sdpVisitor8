using System;
using finalSDP.scripts.entity;
using finalSDP.scripts.entity.bullet;
using finalSDP.scripts.weapon;
using Godot;

namespace finalSDP.scripts.decorators;

public partial class RandomAttackWeaponDecorator: Node2D
{
    private string[] _scenes = [
        "arrow",
        "catana_swing",
        "cristal",
        "fireball",
        "poisonous",
        "smoke",
        "spore",
        "whatisdad"
    ];
    
    protected Entity Player;
    protected Timer timer;


    public Bullet InstantiateBullet(float angle)
    {
        var rand = GD.RandRange(0, 7);
        var bullet = GD.Load<PackedScene>($"res://scenes/bullets/{_scenes[rand]}.tscn").Instantiate<Bullet>();
        bullet.Angle = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        bullet.Position = GlobalPosition;
        return bullet;
    }
    
    public override void _Ready()
    {
        timer = GetParent().GetNode<Timer>("Timer");
        timer.Start();
        timer.Timeout += () => { timer.Stop();};
        Player = GetParent().GetParent<Entity>();
        Player.OnAttack += Attack;
    }

    public virtual bool TimerCheck()
    {
        timer ??= GetNode<Timer>("Timer");
        if (!timer.IsStopped()) return false;
        timer.Start();
        return true;
    }

    public virtual void SpawnWay(Bullet node)
    {
        GetTree().Root.AddChild(node);
    }

    public virtual void Attack(float angle = 0)
    {
        if (!TimerCheck()) return;
        var bullet = InstantiateBullet(angle);
        SpawnWay(bullet);
    }
}