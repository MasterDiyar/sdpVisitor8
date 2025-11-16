using finalSDP.scripts.entity;
using finalSDP.scripts.entity.bullet;
using finalSDP.scripts.weapon;
using Godot;

namespace finalSDP.scripts.decorators;

public partial class WeD : Weapon
{
    protected Weapon _weapon;

    public override void _Ready()
    {
        _weapon = GetParent<Weapon>();
    }

    public override bool TimerCheck()
        => _weapon.TimerCheck();

    public override Bullet InstantiateBullet(float angle)
        => _weapon.InstantiateBullet(angle);

    public override void SpawnWay(Bullet bullet)
        => _weapon.SpawnWay(bullet);

    public override void Attack(float angle)
        => _weapon.Attack(angle);
}