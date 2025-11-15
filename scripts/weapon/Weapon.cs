using System;
using finalSDP.scripts.entity;
using finalSDP.scripts.entity.bullet;
using finalSDP.scripts.entity.player;
using Godot;

namespace finalSDP.scripts.weapon;

public partial class Weapon : Node2D
{
    [Export] public PackedScene bulletScene;

    public Entity Player;
    public Timer timer;

    public virtual float Damage { get; set; } = 10;
    public virtual float Consume { get; set; } = 10;

    public override void _Ready()
    {
        timer = GetNode<Timer>("Timer");
        timer.Start();
        timer.Timeout += () => { timer.Stop();};
        Player = GetParent<Entity>();
        Player.OnAttack += Attack;
    }

    public virtual bool TimerCheck()
    {
        timer ??= GetNode<Timer>("Timer");
        if (!timer.IsStopped()) return false;
        timer.Start();
        return true;
    }

    public virtual Bullet InstantiateBullet(float angle)
    {
        var bullet = bulletScene.Instantiate<Bullet>();
        bullet.Angle = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        bullet.Position = GlobalPosition;
        return bullet;
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

    public void OtPiska()
    {
        Player.OnAttack -= Attack;
    }

    public override void _ExitTree()
    {
        if (Player != null)
            Player.OnAttack -= Attack;
    }
    
    
}