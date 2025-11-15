using finalSDP.scripts.entity.player;
using finalSDP.scripts.strategies;
using finalSDP.scripts.weapon;
using Godot;
using Godot.Collections;

namespace finalSDP.scripts.entity.enemy;

public partial class AIBehavior : Node2D
{
    [Export] public Timer timer;
    [Export] public PackedScene weaponscene1, weaponscene2;
    [Export] public bool Inverted = false;
    public Weapon currentWep;
    public RandomNumberGenerator rng = new RandomNumberGenerator();
    public Player player;
    public Entity entity;
    public float detectorRadius = 200f;
    public double lastEquipTime = -10;
    public AnimatedSprite2D sprite;
    
    public enum Tactic
    {
        Passive,
        Normal,
        Aggressive,
    }
    
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

    public WhatNow Behavior  = WhatNow.Idle;
    public Tactic MyTactic = Tactic.Normal;
    public Vector2 velocity  = Vector2.Zero;
    
    private IBehavior[] behaviors;
    public override void _Ready()
    {
        timer.Timeout += TimerOnTimeout;
        timer.Start();
        
        entity = GetParent<Entity>();
        player = GetParent().GetParent().GetNode<Player>("Player");
        sprite ??= entity.GetNode<AnimatedSprite2D>("AnimatedSprite2D");
        
        behaviors = [
              new IdleBehavior() ,
              new MoveBehavior() ,
              new MoveBehavior() ,
              new ToPlayerBehavior() ,
              new AttackBehavior() ,
              new AttackBehavior() 
        ];
    }

    public override void _Process(double delta)
    {
        float dir = 0f;
        if (Behavior == WhatNow.RunLeft) dir = -1;
        else if (Behavior == WhatNow.RunRight) dir = 1;

        float[] args = { dir };

        var behavior = behaviors[(int)Behavior];
        
        behavior.Update(this, args);
    }

    protected virtual void TimerOnTimeout()
    {
        Behavior = MyTactic switch
        {
            Tactic.Normal => (WhatNow)rng.RandiRange(0, 5),
            Tactic.Aggressive => (WhatNow)rng.RandiRange(4, 5),
            Tactic.Passive => (WhatNow)rng.RandiRange(0, 3),
        };
            
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