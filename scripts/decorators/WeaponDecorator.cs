using finalSDP.scripts.entity;
using finalSDP.scripts.entity.bullet;
using finalSDP.scripts.entity.player;
using finalSDP.scripts.weapon;
using Godot;
namespace finalSDP.scripts.decorators;

public partial class WeaponDecorator :  IWeapon
{
    protected Weapon _weapon;

    public WeaponDecorator(Weapon weapon)
    {
        _weapon = weapon;
    }
    
    public WeaponDecorator()
    {
        var timer = _weapon.GetNode<Timer>("Timer");
        timer.Start();
        timer.Timeout += () => { timer.Stop();};
        var Player = _weapon.GetParent<Entity>();
        Player.OnAttack += Attack;
    }

    public Bullet InstantiateBullet(float angle)
    {
        return _weapon.InstantiateBullet(angle);
    }
    public bool TimerCheck()
    {
        return _weapon.TimerCheck();
    }
    public void SpawnWay(Bullet bullet)
    {
        _weapon.SpawnWay(bullet);
    }
    public void Attack(float angle = 0)
    {
        _weapon.Attack(angle);
    }
}