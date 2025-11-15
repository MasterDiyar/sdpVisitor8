using finalSDP.scripts.entity.bullet;
using finalSDP.scripts.weapon;
using Godot;

namespace finalSDP.scripts.decorators;

public partial class RandomAttackWeaponDecorator(Weapon weapon) : WeaponDecorator(weapon)
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
    
    protected override Bullet InstantiateBullet(float angle)
    {
        var rand = GD.RandRange(0, 7);
        var bullet = GD.Load<PackedScene>($"res://scenes/bullets/{_scenes[rand]}.tscn").Instantiate<Bullet>();
        bullet.Angle = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        bullet.Position = GlobalPosition;
        return bullet;
    }
}