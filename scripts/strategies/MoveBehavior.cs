using finalSDP.scripts.entity.enemy;
using Godot;
namespace finalSDP.scripts.strategies
{
    public class MoveBehavior : IBehavior
    {
        public void Update(AIBehavior context, float[] delta)
        {
            context.entity.Direction = delta[0];
            context.sprite.Play(("run"));
        }
    }

    public class IdleBehavior : IBehavior
    {
        public void Update(AIBehavior context, float[] delta) 
        {
            context.entity.Direction = delta[0];
            context.sprite.Play("idle");
        }
    }

    public class ToPlayerBehavior : IBehavior
    {
        public void Update(AIBehavior context, float[] delta)
        {
            if (context.player == null) {
                context.Behavior = AIBehavior.WhatNow.Idle;
                return;
            }
            Vector2 playerPos = context.player.Position;
            if (playerPos.Length() <= context.detectorRadius) 
                context.entity.Direction = playerPos.X > 0 ? 1 : -1;
            
            else context.Behavior = AIBehavior.WhatNow.Idle;
            context.sprite.Play("run");
        }
    }

    public class AttackBehavior : IBehavior
    {
        public void Update(AIBehavior context, float[] delta)
        {
            context.sprite.Play("attack");
            context.entity.Attack(0f);
        }
    }
}