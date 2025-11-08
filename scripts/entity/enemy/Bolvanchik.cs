using Godot;
using System;
using finalSDP.scripts.entity;

public partial class Bolvanchik : Entity
{
    private float Gravity = 400f;
    public override float Speed {get; set;} = 800f;
    public override void TakeDamage(float damage)
    {
        GD.Print("Bolvanchik Take Damage");
        Hp -= damage;
        base.TakeDamage(damage);
    }

    public override void _Ready()
    {
        base._Ready();
        GetNode<AnimatedSprite2D>("AnimatedSprite2D").Play();
    }

    public override void _PhysicsProcess(double delta)
    {
        var velocity = Velocity;

        if (!IsOnFloor())
            velocity.Y += Gravity * (float)delta;
        velocity.X = Direction * Speed * (float)delta;
        Velocity = velocity;
        MoveAndSlide();
    }
}
