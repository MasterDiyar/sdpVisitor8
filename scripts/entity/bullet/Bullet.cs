using Godot;

namespace finalSDP.scripts.entity.bullet;
public partial class Bullet : Area2D, IBullet
{
    public Vector2 Angle = Vector2.Zero, Velocity;
    public float Speed = 3f;
    [Export]public float Damage = 20f;
    public float Gravity = 9f;

    protected Timer timer;
    public override void _Ready()
    {
        Velocity = Angle.Normalized() * Speed;
        timer = GetNode<Timer>("Timer");
        timer.Start();
        timer.Timeout += OnTimeout;
        BodyEntered   += OnBodyHit;
    }

    public override void _Process(double delta)
    {
        Velocity.Y += Gravity * (float)delta;
        Position += Velocity ;  
    }
    
    public virtual void OnBodyHit(Node body)
    {
        if (body is IEntity entity)
            entity.TakeDamage(Damage);
        QueueFree();
    }

    public virtual void OnTimeout()
    {
        QueueFree();
    }
}