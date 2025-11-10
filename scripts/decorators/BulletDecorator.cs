using finalSDP.scripts.entity.bullet;

namespace finalSDP.scripts.decorators;

public partial class BulletDecorator(Bullet bullet): Bullet
{
    protected Bullet _bullet = bullet;
    
}