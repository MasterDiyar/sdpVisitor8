using System;
using finalSDP.scripts.Adapters;
using Godot;

namespace finalSDP.scripts.entity.player;

public partial class Movement : Node2D
{
    [Signal] public delegate void OnMoveEventHandler(float delta);
    private float MaxSpeed = 300;
    private float Speed = 200;
    private float JumpForce = -800;
    private float Gravity = 980f;
    private MovementAdapter adapter;
    private InputDevice device;

    private Player parent;
    public Player Body { get; set; }

    public override void _Ready()
    {
        adapter = GetNode<MovementAdapter>("/root/MovementAdapter");
        parent = (Player)GetParent();
    }

    public override void _PhysicsProcess(double delta)
    {
        var attack = adapter.current.AttactPressed();
        if (attack)
        {
            switch (adapter.CurrentDevice)
            {
                case InputDevice.Keyboard:
                    parent.Attack(parent.GetAngleTo(GetGlobalMousePosition()));
                    break;
                case InputDevice.GamePad:
                {
                    var aim = Input.GetVector("aim_left","aim_right","aim_up","aim_down");
                    parent.Attack(aim.Angle());
                    break;
                }
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        var velocity = parent.Velocity;
        var direction  = adapter.current.GetMove();
        
        if (!parent.IsOnFloor())
            velocity.Y += Gravity * (float)delta;
        velocity.X = direction.X* Speed;
        
        var jump = adapter.current.JumpPressed();
        if (jump && parent.IsOnFloor())
            velocity.Y = JumpForce;
        
        parent.Velocity = velocity;
        parent.MoveAndSlide();
        
        if (direction != Vector2.Zero) EmitSignal("OnMove",direction.X);
    }
}