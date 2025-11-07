using Godot;

namespace finalSDP.scripts.entity.enemy;

public partial class AiBehavior : Node2D
{
    [Export] Timer timer;
    private RandomNumberGenerator rng = new RandomNumberGenerator();
    public enum WhatNow
    {
        Idle,
        RunLeft,
        RunRight,
        RunToPlayer,
        Attack1,
        Attack2
    }

    private WhatNow Behavior = WhatNow.Idle;

    public override void _Ready()
    {
        timer.Timeout += TimerOnTimeout;
    }

    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);

        switch (Behavior)
        {
            case WhatNow.Idle:
                break;
            case WhatNow.RunLeft:
                break;
            case WhatNow.RunRight:
                break;
            case WhatNow.RunToPlayer:
                break;
            case WhatNow.Attack1:
                break;
            case WhatNow.Attack2:
                break;
        }
    }

    private void TimerOnTimeout()
    {
        Behavior = (WhatNow)rng.RandiRange(0, 5);
    }
}