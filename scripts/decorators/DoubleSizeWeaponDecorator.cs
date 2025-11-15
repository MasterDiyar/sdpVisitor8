using finalSDP.scripts.entity.bullet;
using finalSDP.scripts.weapon;

namespace finalSDP.scripts.decorators;

public partial class DoubleSizeWeaponDecorator(Weapon weapon) : WeaponDecorator(weapon)
{
    public override void SpawnWay(Bullet node)
    {
        node.Scale *= 2;
        _weapon.SpawnWay(node);
    }
}