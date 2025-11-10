using finalSDP.scripts.entity.player;
using finalSDP.scripts.weapon;
using Godot;
namespace finalSDP.scripts.decorators;

public partial class WeaponDecorator(Weapon weapon) : Weapon
{
    protected Weapon _weapon = weapon;
    
}