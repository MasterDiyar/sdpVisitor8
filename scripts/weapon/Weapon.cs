using finalSDP.scripts.entity.bullet;
using finalSDP.scripts.entity.player;
using Godot;

namespace finalSDP.scripts.weapon;

public partial class Weapon : Node2D
{
    [Export] protected PackedScene bulletScene;

    private Player Player;
    protected Timer timer;

    public virtual float Damage { get; set; } = 10;
    public virtual float Consume { get; set; } = 10;

    public override void _Ready()
    {
        timer = GetNode<Timer>("Timer");
        timer.Start();
        timer.Timeout += () => { timer.Stop();};
        Player = GetParent<Player>();
        Player.OnAttack += Attack;
    }

    protected virtual bool TimerCheck()
    {
        if (!timer.IsStopped()) return false;
        timer.Start();
        return true;
    }

    protected virtual Bullet InstantiateBullet(float angle)
    {
        var bullet = bulletScene.Instantiate<Bullet>();
        bullet.Angle = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        bullet.Position = GlobalPosition;
        return bullet;
    }
    
    protected virtual void SpawnWay(Bullet node)
    {
         GetTree().Root.AddChild(node);
    }

    protected virtual void Attack(float angle = 0)
    {
        if (!TimerCheck()) return;
        var bullet = InstantiateBullet(angle);
        SpawnWay(bullet);
    }

    
    
    
}