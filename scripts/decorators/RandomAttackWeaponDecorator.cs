using System;
using finalSDP.scripts.entity;
using finalSDP.scripts.entity.bullet;
using finalSDP.scripts.weapon;
using Godot;

namespace finalSDP.scripts.decorators;

public partial class RandomAttackWeaponDecorator: Weapon
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
    
    public Entity Player;
    public Timer timer;
    
    public override void _Ready()
    {
        isDecorator = true;
        _weapon = GetParent<Weapon>();
        timer = (_weapon.GetTimer() is null) ? _weapon.GetNode<Timer>("Timer") : _weapon.GetTimer();
        timer.Start();
        timer.Timeout += () => { timer.Stop();};
        Player = _weapon.GetEntity();
        Player.OnAttack += Attack;
        if (!_weapon.isDecorator)_weapon.OtPiska();
    }
    
    public override Bullet InstantiateBullet(float angle)
     {
         var rand = GD.RandRange(0, 7);
         var bullet = GD.Load<PackedScene>($"res://scenes/bullets/{_scenes[rand]}.tscn").Instantiate<Bullet>();
         bullet.Angle = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
         bullet.Position = GlobalPosition;
         return bullet;
     }

    public override bool TimerCheck()
    {
        return _weapon.TimerCheck();
    }

    public override void SpawnWay(Bullet node)
    {
        _weapon.SpawnWay(node);
    }

    public override void Attack(float angle = 0)
    {
        if (!TimerCheck()) return;
        var bullet = InstantiateBullet(angle);
        SpawnWay(bullet);
        bullet = _weapon.InstantiateBullet(angle);
        SpawnWay(bullet);
    }
}