using finalSDP.scripts.entity.bullet;
using finalSDP.scripts.weapon;

namespace finalSDP.scripts.decorators;

public partial class KnockBackWeaponDecorator(Weapon weapon) : WeaponDecorator(weapon)
{
    public override void SpawnWay(Bullet node)
    {
        var nid = new KnockBackBulletDecorator(node);
        _weapon.SpawnWay(nid);
    }
}