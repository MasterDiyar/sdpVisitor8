using finalSDP.scripts.visitors;

namespace finalSDP.scripts.entity;

using Godot;
using System;

public partial class Entity : Node2D
{
    public virtual float MaxHp {get; set;}
    public float Hp {get; set;}
    public virtual float MaxStamina {get; set;}
    public float Stamina {get; set;}
    public virtual float Speed {get; set;}
    public virtual float Gravity {get; set;}

    public Action<float> OnHurt;
    public Action<float> OnAttack;
    
    public virtual void Visit(IVisitor visitor) => visitor.Visit(this);
    
    public virtual void TakeDamage(float damage)
    {
        
        OnHurt?.Invoke(damage);
    }

    public virtual void Attack()
    {
        
        OnAttack?.Invoke(0);
    }
    
}