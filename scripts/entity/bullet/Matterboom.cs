using Godot;
using System;
using finalSDP.scripts.entity.bullet;
using finalSDP.scripts.entity.player;

public partial class Matterboom : Bullet
{
    private double time;

    public override void _Ready()
    {
        base._Ready();
        GetNode<AnimatedSprite2D>("AnimatedSprite2D").Play();
    }

    public override void _Process(double delta)
    {
        Rotate((float) delta);
        if (time >= 3)Scale -= Vector2.One*(float) delta;
        else if (time >= 4)QueueFree();
        time += delta;
    }

    public override void OnBodyHit(Node body)
    {
        if (body is Player entity)
        {
            entity.TakeDamage(Damage);
        }
    }
}
