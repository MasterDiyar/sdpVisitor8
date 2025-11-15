using finalSDP.scripts.weapon;
using Godot;

namespace finalSDP.scripts.factories;

public class WeaponFactory
{
    public static Weapon CreateBow()
    {
        return GD.Load<PackedScene>("res://scenes/weapon/bow.tscn").Instantiate<Weapon>();
    }
    
    public static Weapon CreateCatana()
    {
        return GD.Load<PackedScene>("res://scenes/weapon/catana.tscn").Instantiate<Weapon>();
    }
    
    public static Weapon CreateSpray()
    {
        return GD.Load<PackedScene>("res://scenes/weapon/spray.tscn").Instantiate<Weapon>();
    }
}