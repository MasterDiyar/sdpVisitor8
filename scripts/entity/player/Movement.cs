using Godot;

namespace finalSDP.scripts.entity.player;

public partial class Movement : Node2D
{
    private float MaxSpeed = 300;
    private float Speed = 200;
    private float JumpForce = -1000;
    private float Gravity = 980f;

    private Player parent;

    public override void _Ready()
    {
        parent = (Player)GetParent();
    }

    public override void _PhysicsProcess(double delta)
    {
        if (Input.IsActionJustPressed("q"))
            parent.Attack(GetAngleTo(GetGlobalMousePosition()));
        
        var velocity = parent.Velocity;
        var direction  = Input.GetActionStrength("d") - Input.GetActionStrength("a");

        if (!parent.IsOnFloor())
            velocity.Y += Gravity * (float)delta;
        velocity.X = direction * Speed;

        if (Input.IsActionJustPressed("w") && parent.IsOnFloor())
            velocity.Y = JumpForce;
        parent.Velocity = velocity;
        parent.MoveAndSlide();

    }
}