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
    public bool isDecorator = false;
    public Weapon _weapon;
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
        node.Scale = Player.Scale;
        GetTree().Root.AddChild(node);
    }

    public virtual void Attack(float angle = 0)
    {
        if (!TimerCheck()) return;
        var bullet = InstantiateBullet(angle);
        SpawnWay(bullet);
    }
    
    bool otpisan = false;
    public void OtPiska()
    {
        if (!otpisan && Player != null)
            Player.OnAttack -= Attack;
        otpisan = true;
    }

    public override void _ExitTree()
    {
        if (Player != null)
            Player.OnAttack -= Attack;
    }

    public virtual Timer GetTimer()
    {
        return isDecorator ? _weapon.GetTimer() : timer;
    }

    public virtual Entity GetEntity()
    {
        return isDecorator ? _weapon.GetEntity() : Player;
    }

    public void ReSubscribe()
    {
        Position = new Vector2(0, 0);
        Player = GetParent<Entity>();
        Player.OnAttack += Attack;
    }
    
}