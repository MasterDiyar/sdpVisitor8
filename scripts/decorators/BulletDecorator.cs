using finalSDP.scripts.entity.bullet;
using Godot;

namespace finalSDP.scripts.decorators;

public partial class BulletDecorator(Bullet bullet): Bullet, IBullet
{
    protected Bullet _bullet = bullet;

    public virtual void OnBodyHit(Node body)
    {
        _bullet.OnBodyHit(body);
    }

    public void OnTimeout()
    {
        _bullet.OnTimeout();
    }
}