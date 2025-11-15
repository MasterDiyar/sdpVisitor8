using finalSDP.scripts.entity;
using finalSDP.scripts.entity.bullet;
using finalSDP.scripts.entity.player;
using finalSDP.scripts.weapon;
using Godot;
namespace finalSDP.scripts.decorators;

public partial class WeaponDecorator : Weapon, IWeapon
{
    protected Weapon _weapon;

    public WeaponDecorator(Weapon weapon)
    {
        _weapon = weapon;
    }
    
    
    
    public override void _Ready()
    {
        timer = GetParent().GetNode<Timer>("Timer");
        timer.Start();
        timer.Timeout += () => { timer.Stop();};
        Player = GetParent().GetParent<Entity>();
        Player.OnAttack += Attack;
    }

    public override Bullet InstantiateBullet(float angle)
    {
        GD.Print("InstantiateBullet");
        return _weapon.InstantiateBullet(angle);
    }

    public override bool TimerCheck()
    {
        return _weapon.TimerCheck();
    }

    public override void SpawnWay(Bullet bullet)
    {
        _weapon.SpawnWay(bullet);
    }

    public override void Attack(float angle = 0)
    {
        _weapon.Attack(angle);
    }
}