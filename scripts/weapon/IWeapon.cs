using finalSDP.scripts.entity.bullet;

namespace finalSDP.scripts.weapon;

public interface IWeapon
{
    Bullet InstantiateBullet(float angle);
    bool TimerCheck();
    void SpawnWay(Bullet bullet);
    void Attack(float angle);
}