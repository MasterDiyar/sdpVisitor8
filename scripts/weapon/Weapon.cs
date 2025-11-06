using finalSDP.scripts.entity.bullet;
using finalSDP.scripts.entity.player;
using Godot;

namespace finalSDP.scripts.weapon;

public partial class Weapon : Node2D
{
    [Export] PackedScene bulletScene;

    private Player Player;

    public virtual float Damage { get; set; } = 10;
    public virtual float Consume { get; set; } = 10;

    public override void _Ready()
    {
        Player = GetParent<Player>();
        Player.OnAttack += Attack;
    }

    protected void Attack(float angle = 0)
    {
        var bullet = bulletScene.Instantiate<Bullet>();
        bullet.Angle = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        bullet.Position = GlobalPosition;
        SpawnWay(bullet);
    }

    protected virtual void SpawnWay(Node node)
    {
        GetTree().Root.AddChild(node);
    }
    
    
}