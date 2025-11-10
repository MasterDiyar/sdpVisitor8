using finalSDP.scripts.entity.player;
using finalSDP.scripts.weapon;
using Godot;

namespace finalSDP.scripts.entity.enemy;

public partial class AIBehavior : Node2D
{
    [Export] Timer timer;
    [Export] private PackedScene weaponscene1, weaponscene2;
    private Weapon currentWep;
    private RandomNumberGenerator rng = new RandomNumberGenerator();
    private Player player;
    private Entity entity;
    private float detectorRadius = 200f;
    private double lastEquipTime = -10;
    private AnimatedSprite2D sprite;
    
    public enum WhatNow
    {
        Idle,
        RunLeft,
        RunRight,
        RunToPlayer,
        Attack1,
        Attack2,
        IdleAttack
    }

    private WhatNow Behavior  = WhatNow.Idle;
    private Vector2 velocity  = Vector2.Zero;
    private Vector2 direction = Vector2.Zero;
    

    public override void _Ready()
    {
        timer.Timeout += TimerOnTimeout;
        timer.Start();
        entity = GetParent<Entity>();
        player = GetParent().GetParent().GetNode<Player>("Player");
        sprite ??= entity.GetNode<AnimatedSprite2D>("AnimatedSprite2D");
    }

    public override void _Process(double delta)
    {
        switch (Behavior)
        {
            case WhatNow.Idle:
                Idle(delta); break;
            case WhatNow.RunLeft:
                Left(delta); break;
            case WhatNow.RunRight:
                Right(delta); break;
            case WhatNow.RunToPlayer:
                ToPlayer(delta); break;
            case WhatNow.Attack1:
                Attack1(delta); break;
            case WhatNow.Attack2:
                Attack2(delta); break;
            case WhatNow.IdleAttack:
                AttackIdle(delta);break;        
        }
    }

    protected virtual void AttackIdle(double delta)
    {
        sprite.Play("attack");
    }
    
    protected virtual void Idle(double delta)
    {
        entity.Direction = 0;
        sprite.Play("idle");
    }

    protected virtual void Left(double delta)
    {
        entity.Direction = -1;
        sprite.Play("run");
        sprite.FlipH = true;
    }

    protected virtual void Right(double delta)
    {
        entity.Direction = 1;
        sprite.Play("run");
        sprite.FlipH = false;
    }

    protected virtual void ToPlayer(double delta)
    {
        if (player == null) {
            Behavior = WhatNow.Idle;
            return;
        }

        Vector2 toPlayer = player.GlobalPosition - entity.GlobalPosition;
        if (toPlayer.Length() <= detectorRadius) {
            entity.Direction = toPlayer.X > 0 ? 1 : -1;
        } else 
            Behavior = WhatNow.Idle;
        sprite.Play("run");
    }

    protected virtual void Attack1(double delta)
    {
        sprite.Play("attack");
        entity.Attack(0f);
    }

    protected virtual void Attack2(double delta)
    {
        sprite.Play("attack");
        entity.Attack(0f);
    }

    protected virtual void MoveEntity(double delta)
    {
        entity.Velocity = new Vector2(velocity.X, entity.Velocity.Y + entity.Gravity * (float)delta);
        entity.MoveAndSlide();
    }
    

    protected virtual void TimerOnTimeout()
    {
        Behavior = (WhatNow)rng.RandiRange(0, 5);
        GD.Print(Behavior);
        
        if (Behavior == WhatNow.Attack1) {Equip(weaponscene1);}
        else if (Behavior == WhatNow.Attack2) {Equip(weaponscene2);}
    }

    protected virtual void Equip(PackedScene scene)
    {
        currentWep?.QueueFree();
        currentWep = scene.Instantiate<Weapon>();
        entity.AddChild(currentWep);
    }

}