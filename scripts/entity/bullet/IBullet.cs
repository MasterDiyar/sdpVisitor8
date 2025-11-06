using Godot;

namespace finalSDP.scripts.entity.bullet;

public interface IBullet
{
    void OnBodyHit(Node body);
    void OnTimeout();
}