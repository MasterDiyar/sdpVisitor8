using finalSDP.scripts.entity;
using finalSDP.scripts.entity.bullet;
using finalSDP.scripts.weapon;
using Godot;

namespace finalSDP.scripts.decorators;

public partial class KnockBackWeaponDecorator: Weapon
{
    public Entity Player;
    public Timer timer;
    
    public override void _Ready()
    {
        isDecorator = true;
        _weapon = GetParent<Weapon>();
        timer = (_weapon.GetTimer() is null) ? _weapon.GetNode<Timer>("Timer") : _weapon.GetTimer();
        timer.Start();
        timer.Timeout += () => { timer.Stop(); };
        Player = _weapon.GetEntity();
        if (!_weapon.isDecorator)_weapon.OtPiska();
    }
    public override Bullet InstantiateBullet(float angle)
         {
             GD.Print("knockback");
             var bullet = _weapon.InstantiateBullet(angle);
             bullet.AddChild(GD.Load<PackedScene>("res://scenes/bullets/decorator/knockback_bullet_decorator.tscn").Instantiate());        
             return bullet;
         }

    public override bool TimerCheck()
    {
        return _weapon.TimerCheck();
    }

    public override void Attack(float angle = 0)
    {
        if (!TimerCheck()) return;
        var bullet = InstantiateBullet(angle);
        SpawnWay(bullet);
    }
    public override void SpawnWay(Bullet node)
    {
        _weapon.SpawnWay(node);
    }
}