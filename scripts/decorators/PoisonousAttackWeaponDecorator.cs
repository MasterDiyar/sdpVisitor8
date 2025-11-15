using finalSDP.scripts.entity;
using finalSDP.scripts.entity.bullet;
using finalSDP.scripts.weapon;
using Godot;

namespace finalSDP.scripts.decorators;

public partial class PoisonousAttackWeaponDecorator: Node2D
{
    protected Entity Player;
    protected Timer timer;
    private Weapon _weapon;


    public Bullet InstantiateBullet(float angle)
    {
        
        var bullet = _weapon.bulletScene.Instantiate<Bullet>();
        bullet.Angle = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        bullet.Position = GlobalPosition;
        return bullet;
    }
    
    public override void _Ready()
    {
        _weapon = GetParent<Weapon>();
        timer = GetParent().GetNode<Timer>("Timer");
        timer.Start();
        timer.Timeout += () => { timer.Stop();};
        Player = GetParent().GetParent<Entity>();
        Player.OnAttack += Attack;
        _weapon.OtPiska();
    }

    public virtual bool TimerCheck()
    {
        timer ??= GetNode<Timer>("Timer");
        if (!timer.IsStopped()) return false;
        timer.Start();
        return true;
    }

    public virtual void Attack(float angle = 0)
    {
        if (!TimerCheck()) return;
        var bullet = InstantiateBullet(angle);
        SpawnWay(bullet);
    }
    public  void SpawnWay(Bullet node)
    {
        var nid = new PoisonousBulletDecorator(node);
        _weapon.SpawnWay(nid);
    }
}