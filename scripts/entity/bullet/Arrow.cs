using finalSDP.scripts.entity.player;
using Godot;

namespace finalSDP.scripts.entity.bullet;

public partial class Arrow : Bullet
{
    public override void _Ready()
    {
        Speed = 18;
        Gravity = 18;
        GetNode<Sprite2D>("Arrow").Rotation = Angle.Angle();
        base._Ready();
    }

    public override void _Process(double delta)
    {
        Velocity.Y += Gravity * (float)delta;
        Position += Velocity ;  
    
        Rotation = Angle.Angle();
    }

    public override void OnBodyHit(Node body)
    {
        if (body is not Player && body is Entity entity)
        {
            entity.TakeDamage(Damage * 60);
        }
    }
}